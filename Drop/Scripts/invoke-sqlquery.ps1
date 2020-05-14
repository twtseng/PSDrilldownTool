function Invoke-SqlQuery
(
    [Parameter(Mandatory=$true)]
    [string] $ConnectionString,
    [Parameter(Mandatory=$true)]
    [string] $SqlText,
    [Parameter(Mandatory=$false)]
    [int] $CommandTimeout=600
)
{
<#
.DESCRIPTION
    Run SQL query and return results
.PARAMETER ConnectionString
    The ADO connection string
.PARAMETER SqlQuery
    SQL query text
.PARAMETER CommandTimeout
    Command timeout seconds
#>
    $conn = $null
    try
    {
        $conn = new-object System.Data.SqlClient.SqlConnection $ConnectionString
        $conn.Open()
        $comm = $conn.CreateCommand()
        $comm.CommandText = $SqlText
        $comm.CommandTimeout = $CommandTimeout

        $table = new-object System.Data.DataTable
        $adapter = new-object System.Data.SqlClient.SqlDataAdapter($comm)
        $adapter.Fill($table) | out-null
    }
    finally
    {
        if ($conn -ne $null)
        {
            $conn.Close()
        }
    }
    return $table
}

function Write-ObjectsToSQLServer
(
    [Parameter(Mandatory=$true)]
    [PSObject[]] $ObjectArray,
    [ValidateNotNullorEmpty()]
    [string]$DestinationConnStr,
    [Parameter(Mandatory=$true)]
    [string] $InputSproc,
    [Parameter(Mandatory=$true)]
    [int] $BatchSize,
    [Parameter(Mandatory=$false)]
    [hashtable] $ParameterHash,
    [int] $commandTimeout=600
)
{
<#
.DESCRIPTION

Write objects to a SQL server using a sproc with table variable @table

.PARAMETER ObjectArray
    Array of objects to write to SQL
.PARAMETER DestinationConnStr
    SQL server fqdn
.PARAMETER InputSproc
    Stored procedure with table parameter "@table" which matches data structure of ObjectArray
.PARAMETER BatchSize
    Number of items to upload in a batch. I recommend between 1000 or 5000. Larger values can hit SQL timeouts.
.PARAMETER ParameterHash
    Hashtable of additional parameters (if any) to pass to InputSproc

Write-ObjectsToSQLServer -ObjectArray $y -DestinationConnStr $env:MyDbConnStr -InputSproc [usp_AmazonBills_Insert] -BatchSize 100
#>
    $stopwatch = New-Object System.Diagnostics.StopWatch
    $stopwatch.Start()
    try
    {

        $destinationConn = new-object System.Data.SqlClient.SqlConnection $DestinationConnStr

        $destinationConn.Open()
        
        # Create datatable template for uploading the data
        $outputTable = new-object System.Data.DataTable
        $ObjectArray[0].PSObject.Members | where { $_.MemberType -eq "NoteProperty" } | % {
            $column = new-object System.Data.DataColumn
            if ([string]::IsNullOrWhiteSpace($_.TypeNameOfValue))
            {
                $column.DataType = [string]
            }
            else
            {
                $column.DataType = $_.TypeNameOfValue
            }
            $column.ColumnName = $_.Name
            $column.ReadOnly = $true
            $outputTable.Columns.Add($column)
        }

        $itemCount = $ObjectArray.Length
        $numBatches = [Math]::Ceiling($itemCount / $BatchSize)
        $itemNum = 0
        for ($i=0 ; $i -lt $numBatches; ++$i)
        {
            $uploadTable = $outputTable.Clone()
            for ($j = 0; $j -lt $batchSize -and $itemNum -lt $itemCount; ++$j)
            {
                $row = $uploadTable.NewRow()
                $inputRow = $ObjectArray[$itemNum]
                $inputRow.PSObject.Members | where { $_.MemberType -eq "NoteProperty" } | % {
                    if ($_.Value -eq $null)
                    {
                        $row[$_.Name] = [System.DBNull]::Value
                    }
                    else
                    {
                        if ($_.TypeNameOfValue -match "DateTime")
                        {
                            $row[$_.Name] = [DateTime] $_.Value
                        }
                        else
                        {
                            $row[$_.Name] = $_.Value
                        }
                    }
                }
                $uploadTable.Rows.Add($row)
                ++$itemNum
            }
            $outputReader = new-object System.Data.DataTableReader($uploadTable)
            $ansiOffCmd = $destinationConn.CreateCommand()
            $ansiOffCmd.CommandText = "set ansi_warnings off"
            $ansiOffCmd.ExecuteNonQuery() | out-null
            $cmd = $destinationConn.CreateCommand()
            $cmd.CommandText = $InputSproc
            $cmd.CommandType = [System.Data.CommandType]::StoredProcedure
            $cmd.CommandTimeout = $commandTimeout
            $param = $cmd.Parameters.AddWithValue("@table", $outputReader)
            $param.SqlDbType = [System.Data.SqlDbType]::Structured
            if ($ParameterHash -ne $null)
            {
                foreach($key in $ParameterHash.Keys)
                {
                    $param = $cmd.Parameters.AddWithValue($key.ToString(), $ParameterHash[$key])
                }
            }

            $cmd.ExecuteNonQuery()
            $outputReader.Close()
            "Write-ObjectsToSQLServer processed [{0}]/[{1}] InputSproc[{2}] ElapsedMins[{3}]" -f  $itemNum, $itemCount, $InputSproc, $stopwatch.Elapsed.TotalMinutes.ToString("0.00")
        }
        "Write-ObjectsToSQLServer Completed. Total items [{0}]. InputSproc[{1}]. ElapsedMins[{2}]" -f $itemCount, $InputSproc, $stopwatch.Elapsed.TotalMinutes.ToString("0.00")
    }
    catch
    {
        "Write-ObjectsToSQLServer failed. InputSproc[{0}]. ElapsedMins[{1}] {2}" -f $InputSproc , $stopwatch.Elapsed.TotalMinutes.ToString("0.00") , $_.ToString() 
    }
    finally
    {
        if ($destinationConn.State -eq [System.Data.ConnectionState]::Open)
        {
            $destinationConn.Close()
        }
    }
}
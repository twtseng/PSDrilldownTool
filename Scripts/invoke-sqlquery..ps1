function Invoke-SqlQuery
(
    [Parameter(Mandatory=$true)]
    [string] $ConnectionString,
    [Parameter(Mandatory=$true)]
    [string] $SqlText,
    [Parameter(Mandatory=$false)]
    [string] $ReturnAsHashKey = ''
)
{
<#
.DESCRIPTION
    Run SQL query and return results
.PARAMETER ConnectionString
    The ADO connection string
.PARAMETER SqlQuery
    SQL query text
.PARAMETER ReturnAsHashKey
    If specified, returns a DataTableReader in a hashtable
    Used to workaround to prevent powershell autocast to object[] when I actually want a DataTable
    The DataTable is used for passing bulk data to sproc with table valued parameter
#>
    $conn = $null
    try
    {
        $conn = new-object System.Data.SqlClient.SqlConnection $ConnectionString
        $conn.Open()
        $comm = $conn.CreateCommand()
        $comm.CommandText = $SqlText
        $comm.CommandTimeout = 600

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
    if ([string]::IsNullOrEmpty($ReturnAsHashKey))
    {
        return $table
    }
    else
    {
        return @{ $ReturnAsHashKey = $table }
    }
}
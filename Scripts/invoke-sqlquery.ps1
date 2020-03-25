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
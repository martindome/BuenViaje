CREATE TABLE FilesInFolder (

       ID INT IDENTITY(1,1) NOT NULL,

       TheFileName NVARCHAR(260) NOT NULL,

       FileLength BIGINT NOT NULL,

       LastModified DATETIME2 NOT NULL,

       PRIMARY KEY (ID)

);

 
1	10/11/2021 23:21:20	LOW	SW5pY2lvIGRlIHNlc2lvbiBzYXRpc2ZhY3Rvcmlv	396536	bWFydGluZG9tZTk2QGdtYWlsLmNvbQ==
53	11/11/2021 00:49:37	HIGH	U2UgcmVhbGl6byB1bmEgcmVzdGF1cmFjaW9uIGRlbCBzaXN0ZW1h	350215	dW5AbWFpbC5jb20=
54	11/11/2021 00:49:44	LOW	VXN1YXJpbyBjZXJybyBzZXNpb24=	182050	dW5AbWFpbC5jb20=
55	11/11/2021 00:49:57	MEDIUM	SW5ncmVzbyBkZSBjbGF2ZSBpbmNvcnJlY3RhIGVuIGVsIGluaWNpbyBkZSBzZXNpb24=	704213	bWFydGluZG9tZTk2QGdtYWlsLmNvbQ==
56	11/11/2021 00:49:57	HIGH	RXJyb3IgYWwgaW5pY2lhciBzZXNpb24=	167713	TlVMTA==
57	11/11/2021 00:50:02	LOW	SW5pY2lvIGRlIHNlc2lvbiBzYXRpc2ZhY3Rvcmlv	404238	bWFydGluZG9tZTk2QGdtYWlsLmNvbQ==
Then paste the following code into a .PS1 file (you have to edit the $DBServer and $DBName values first) and run it using Powershell:

 

function Do-FilesInsertRowByRow ([Data.SqlClient.SqlConnection] $OpenSQLConnection) {

 

    $sqlCommand = New-Object System.Data.SqlClient.SqlCommand

    $sqlCommand.Connection = $sqlConnection

 

    # This SQL query will insert 1 row based on the parameters, and then will return the ID

    # field of the row that was inserted.

    $sqlCommand.CommandText = "INSERT INTO Bitacora(ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, Nombre_Usuario) VALUES (@ID_Bitacora, @Fecha, @Tipo, @Descripcion, @DVH, @Nombre_Usuario)"

   

    # I am adding the parameters without values outside the loop.  This means that inside the

    #  loop all I have to do is assign the values and say "run" - much less work than setting

    #  up everything from scratch in each iteration.

    # Also notice the doubled-up (()) - this is how you create a new object and then

    #  immediately pass it as a function parameter in PowerShell.

    # Next, the class names in square brackets are .NET types.  Powershell assumes System.,

    #  so you can omit it.  The double-colon is how you reference enumeration members.

    # Finally, I am piping the output of these calls to Out-Null since otherwise PowerShell

    #  would output the properties of the command object to the console on each call since

    #  there is no assignment made to a variable or another pipeline destination.

    $sqlCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@ID_Bitacora",[Data.SQLDBType]::BigInt))) | Out-Null

    $sqlCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@Fecha",[Data.SQLDBType]::DateTime2))) | Out-Null

    $sqlCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@Tipo",[Data.SQLDBType]::NVarChar))) | Out-Null

    $sqlCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@Descripcion",[Data.SQLDBType]::NVarChar, 260))) | Out-Null

    $sqlCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@DVH",[Data.SQLDBType]::NVarChar, 260))) | Out-Null

    $sqlCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@Nombre_Usuario",[Data.SQLDBType]::NVarChar, 260))) | Out-Null

   

    # I love how I can foreach over a call like "dir *.*" in PowerShell!!

    foreach ($file in dir *.*) {

        # Here we set the values of the pre-existing parameters based on the $file iterator

        $sqlCommand.Parameters[0].Value = $file.FullName

        $sqlCommand.Parameters[1].Value = $file.Length

        $sqlCommand.Parameters[2].Value = $file.LastWriteTime

 

        # Run the query and get the scope ID back into $InsertedID

        $InsertedID = $sqlCommand.ExecuteScalar()

        # Write to the console.

        "Inserted row ID $InsertedID for file " + $file.Name

    }

 

}

 

 

# Open SQL connection (you have to change these variables)

$DBServer = "DESKTOP-ID1JEHJ"

$DBName = "BuenViaje"

$sqlConnection = New-Object System.Data.SqlClient.SqlConnection

$sqlConnection.ConnectionString = "Server=$DBServer;Database=$DBName;Integrated Security=True;"

$sqlConnection.Open()

 

# Quit if the SQL connection didn't open properly.

if ($sqlConnection.State -ne [Data.ConnectionState]::Open) {

    "Connection to DB is not open."

    Exit

}


 

# Call the function that does the inserts.

Do-FilesInsertRowByRow ($sqlConnection)

 

# Close the connection.

if ($sqlConnection.State -eq [Data.ConnectionState]::Open) {

    $sqlConnection.Close()

}
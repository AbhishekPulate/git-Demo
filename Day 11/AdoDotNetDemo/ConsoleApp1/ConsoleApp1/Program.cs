using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

string connString = "Server=localhost;Database=CrmDb;Uid=root;Pwd=Root;";

using (var conn = new MySqlConnection(connString))
{
    try
    {
        conn.Open();
        Console.WriteLine("Connection Successful!");
        //ExecuteReader(conn);
        //ExecuteScalar(conn);
        //ExecuteNonQuery(conn);
        //SqlDataAdapterDemo(conn);
        InsertCustomerDemo(conn);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
        return;
    }
    finally
    {
        Console.WriteLine("Closing Connection.");
        conn.Close();
    }
}


void ParameterizedQueryDemo(SqlConnection connection)
{
    using (SqlCommand command = new SqlCommand(
        "SELECT * FROM Customers WHERE Name LIKE @Name",
        connection))

    {
        // var id = "3";
        // var id = "3 or 1 = 1";
        // var id = "3 or 1 = 1";
        // Add parameters - database treats them as DATA, never as SQL code
        var name = "John or 1 = 1";
        command.Parameters.AddWithValue("@Name", name);

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
        else
        {
            Console.WriteLine("No customer found with the specified Id.");
        }
    }
}

void SqlInjectionDemo(SqlConnection connection)
{
    // Query: SELECT * FROM Customers WHERE Id = 1 or 1 = 1
    var userInput = "1 or 1 = 1";
    // var userInput = "1; DROP TABLE Customers; ";
    // var userInput = "3";
    var query = $"SELECT * FROM Customers WHERE Id = {userInput}";

    using var command = new SqlCommand(query, connection);
    try
    {
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error executing query: {ex.Message}");
    }
}

void InsertCustomerDemo(MySqlConnection connection)
{
    var dataSet = new DataSet();
    var selectQuery = "SELECT * FROM Customers";
    using var selectCommand = new MySqlCommand(selectQuery, connection);
    using var adapter = new MySqlDataAdapter(selectCommand);
    adapter.Fill(dataSet, "Customers");

    var dataTable = dataSet.Tables["Customers"];

    var newRow = dataTable.NewRow();
    newRow["Id"] = 2;
    newRow["Name"] = "New Customer";
    newRow["Age"] = 28;

    dataTable.Rows.Add(newRow);

    adapter.InsertCommand = new MySqlCommand("INSERT INTO Customers (Id, Name, Age) VALUES (@Id, @Name, @Age)", connection);
    adapter.InsertCommand.Parameters.Add("@Id)", MySqlDbType.Int32, 6, "Id");

    adapter.InsertCommand.Parameters.Add("@Id", MySqlDbType.Int32, 6, "Id");
    adapter.InsertCommand.Parameters.Add("@Name", MySqlDbType.VarChar, 50, "Name");
    adapter.InsertCommand.Parameters.Add("@Age", MySqlDbType.Int32, 0, "Age");
    Console.WriteLine("Adding new customer to dataset.");
    dataSet.AcceptChanges();
    
}

void SqlDataAdapterDemo(MySqlConnection conn)                       
{       
    var query = "SELECT * FROM Customers";
    //MySqlCommand command = new MySqlCommand(query, conn);
    //using var selectAllCustomersCommand = command;
    using var adapter = new MySqlDataAdapter(query,conn);
    var customerDataTable = new DataTable();
    adapter.Fill(customerDataTable);
    foreach (DataRow row in customerDataTable.Rows)
    {
        Console.WriteLine($"ID: {row["id"]}, NAME: {row["name"]}, AGE: {row["age"]}");
    }
}   

void ExecuteReader(MySqlConnection conn)
{
    MySqlCommand command = new MySqlCommand("SELECT * FROM Customers", conn);

    using (MySqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, NAME: {reader["name"]}, AGE: {reader["age"]}");
        }
    }
}
void ExecuteScalar(MySqlConnection conn)
{
    MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM Customers", conn);

    var reader = command.ExecuteScalar();

    Console.WriteLine(reader);
}
void ExecuteNonQuery(MySqlConnection conn)
{
    MySqlCommand command = new MySqlCommand("INSERT INTO Customers VALUES (4,'DINESH',23)", conn);
    var reader = command.ExecuteNonQuery();
    Console.WriteLine(reader);
}



//using Microsoft.Data.SqlClient;

//string crmConn ="Server=localhost,1433;Database=crmdb;User Id=sa;Password=YourStrong@Password123;TrustServerCertificate=True;";

//using (SqlConnection conn = new SqlConnection(crmConn))
//{
//    conn.Open();

//    string selectQuery = "SELECT * FROM Customers";

//    SqlCommand cmd = new SqlCommand(selectQuery, conn);

//    SqlDataReader reader = cmd.ExecuteReader();

//    while (reader.Read())
//    {
//        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
//    }

//    Console.WriteLine("Closing Connection.");
//}



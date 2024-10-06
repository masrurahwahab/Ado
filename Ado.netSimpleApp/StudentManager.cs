using MySql.Data.MySqlClient;
using System.Reflection;
using System.Xml.Linq;

public class StudentManager
{
    private static string ConnectionStringWithoutDB = "Server = localhost; User = root; password =9594";
    private static string ConnectionString = "Server = localhost; User = root; database = StudentDataBase; password = 9594";
    Student student = new Student();
    public static void CreateDB()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionStringWithoutDB))
        {
            connection.Open();
            string query = "Create Database if not exists StudentDataBase";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Database Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Database.");
            }
        }
    }

    public static void CreateStudentTable()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "create table if not exists StudentDataBase.Students(id int primary Key not null auto_increment, Name varchar(255) Not Null, Address varchar(255),  Email varbinary(200) not null unique);";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute == 0)
            {
                Console.WriteLine("Table Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Table.");
            }
        }
    }

    public static void CreateStudent(Student student)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            MySqlCommand insert = new MySqlCommand($"insert into StudentDataBase.students(name, address, email) values('{student.Name = "Bola"}', '{student.Address= "Abeokuta"}','{student.Email = "Bola@gmail.com"}');", connection);

            
            var execute = insert.ExecuteNonQuery();

            if (execute == 0)
            {
                Console.WriteLine("Student Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Student.");
            }
        }
    }

    public static void UpdateStudent()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "UPDATE StudentDataBase.students SET name = 'Jide' where id = 1";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Update.");
            }
        }
    }

    public static void DeleteStudent()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "delete from students where id = 1;";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Delete.");
            }
        }
    }

    public static void GetAllStudents()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = "SELECT id, name, address,email From students";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Students in the database: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Address: {reader["address"]},Email: {reader["email"]}");
                    }
                }
            }
        }
    }

    public static void GetStudents()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = "SELECT id, name, address,email From students where id = 7";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Students: ");
                    if (!reader.Read())
                    {
                        Console.WriteLine("Student Not Found");
                    }
                    else
                    {

                        Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Address: {reader["address"]},Email: {reader["email"]}");
                    }
                    //while (reader.Read())
                    //{
                    //    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Address: {reader["address"]},Email: {reader["email"]}");
                    //}
                }
            }
        }
    }
}



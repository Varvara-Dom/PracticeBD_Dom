using System;

using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace CodForBD

{

    internal class Program

    {

        static async Task Main(string[] args)

        {

            string connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION");

            if (string.IsNullOrEmpty(connectionString))

            {

                Console.WriteLine("Ошибка: Переменная PRACTICE_DB_CONNECTION не найдена.");

                return;

            }

            Console.WriteLine("--- Тест на добавление сотрудника ---");



            await AddEmployee(connectionString, "Домрачева Варвара", 35000, 2);

            Console.WriteLine("\n--- Тестирование на список всех сотрудников ---");



            await PrintAllEmployees(connectionString);

        }

        static async Task AddEmployee(string connectionString, string name, decimal salary, int deptId)

        {

            try

            {

                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    await connection.OpenAsync();

                    string query = @"

                       INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId)  

                       VALUES (@name, @salary, GETDATE(), @deptId)";

                    using (SqlCommand command = new SqlCommand(query, connection))

                    {

                        command.Parameters.AddWithValue("@name", name);

                        command.Parameters.AddWithValue("@salary", salary);

                        command.Parameters.AddWithValue("@deptId", deptId);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        Console.WriteLine($"Успешно: Добавлен сотрудник '{name}'. Затронуто строк: {rowsAffected}");

                    }

                }

            }

            catch (SqlException ex)

            {

                Console.WriteLine($"Ошибка SQL Server при добавлении: {ex.Message}");

            }

        }

        static async Task PrintAllEmployees(string connectionString)

        {

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                await connection.OpenAsync();

                string query = "SELECT TOP 5 EmployeeName, Salary FROM Employees ORDER BY EmployeeId DESC";



                using (SqlCommand command = new SqlCommand(query, connection))

                using (SqlDataReader reader = await command.ExecuteReaderAsync())

                {

                    while (await reader.ReadAsync())

                    {

                        Console.WriteLine($"{reader.GetString(0)} - {reader.GetDecimal(1)} руб.");

                    }

                }

            }

        }

    }

}
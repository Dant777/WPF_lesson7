using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TEST
    {
        static void Main(string[] args)
        {
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=Lesson_7;" +
                "Integrated Security=True;" +
                "Pooling=False";
            // Connection - Устанавливает подключение к источнику данных
            // Command - Позволяет выполнять операции с данными из БД
            // DataReader - Позволяет хранить и работать с данными независимо от БД
            // DataSet, DataTable - содержит данные, полученные из БД
            #region wrait

            try
            {

                var random = new Random();
                string Depar = String.Empty;
                for (int i = 0; i < 10; i++)
                {
                    switch (random.Next(2, 4))
                    {
                        case 1:
                            Depar = "Department_111";
                            break;
                        case 2:
                            Depar = "Department_222";
                            break;
                        case 3:
                            Depar = "Department_333";
                            break;
                        default:
                            break;
                    }
                    var user = new UserTest
                    {
                        FIO = $"ФИО_{random.Next(0, 100)}",
                        Age = $"{random.Next(20, 50)}",
                        Salary = $"{random.Next(50000, 200000)}",
                        Dep = $"{Depar}"
                    };
                    //запрос
                    var sql = String.Format("INSERT INTO Employee (FIO, Age, Salary, Department) VALUES (N'{0}', '{1}', '{2}', '{3}')", user.FIO, user.Age, user.Salary, user.Dep);
                    //var sql = String.Format("UPDATE Employee SET Department = N'{0}'", user.Dep);
                    Debug.WriteLine(sql);

                    using (SqlConnection connection = new SqlConnection(connectString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();//не выполняет никаких операций т.к. мы записываем в таблицу
                    }

                }

                //    var sql = String.Format("DELETE FROM Employee WHERE Id < 1200");
                //    Debug.WriteLine(sql);
                //    using (SqlConnection connection = new SqlConnection(connectString))
                //    {
                //        connection.Open();
                //        SqlCommand command = new SqlCommand(sql, connection);
                //        command.ExecuteNonQuery();//не выполняет никаких операций т.к. мы записываем в таблицу
                //    }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            #endregion


            #region read
            try
            {

                using (SqlConnection connection = new SqlConnection(connectString))//установка подключения через конструктор и путь connectString
                {
                    connection.Open(); //Открытие подключенных данных
                    var sql = @"SELECT * FROM Employee"; // запрос
                    SqlCommand command = new SqlCommand(sql, connection); //выполняет операцию запроса через конструктор (запрос, открытые базы даных) 
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0],4} | {reader[1],10} | {reader[2],10} | {reader[3],10} | {reader[4],10} ");
                    }

                    //}
                    //using (SqlConnection connection = new SqlConnection(connectString))//установка подключения через конструктор и путь connectString
                    //{
                    //    connection.Open(); //Открытие подключенных данных
                    //    var sql = @"SELECT * FROM Department"; // запрос
                    //    SqlCommand command = new SqlCommand(sql, connection); //выполняет операцию запроса через конструктор (запрос, открытые базы даных) 
                    //    SqlDataReader reader = command.ExecuteReader();//записывает колекцию запроса в reader

                    //    while (reader.Read())
                    //    {
                    //        Console.WriteLine($"{reader[0],4} | {reader[1],10}");
                    //    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


            #endregion




            Console.ReadKey();
        }
    }
}

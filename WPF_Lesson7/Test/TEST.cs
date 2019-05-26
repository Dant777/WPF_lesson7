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

            //try
            //{

            //    var random = new Random();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        var user = new UserTest
            //        {
            //            FIO = $"ФИО_{random.Next(0, 100)}",
            //            Age = $"{random.Next(20, 50)}",
            //            Salary = $"{random.Next(50000, 200000)}"
            //        };
            //        //запрос
            //        var sql = String.Format("INSERT INTO Employee (FIO, Age, Salary) VALUES (N'{0}', '{1}', '{2}')", user.FIO, user.Age, user.Salary);

            //        Debug.WriteLine(sql);

            //        using (SqlConnection connection = new SqlConnection(connectString))
            //        {
            //            connection.Open();
            //            SqlCommand command = new SqlCommand(sql, connection);
            //            command.ExecuteNonQuery();//не выполняет никаких операций т.к. мы записываем в таблицу
            //        }

            //    }
            //}

            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
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
                        Console.WriteLine($"{reader[0],4} | {reader[1],10} | {reader[2],10} | {reader[3],10} ");
                    }

                }
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

                //}


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

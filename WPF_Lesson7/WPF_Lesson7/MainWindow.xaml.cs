using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WPF_Lesson7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(); //адаптер    
            
            #region Select

            var sql = "SELECT Id, FIO, Age, Salary FROM Employee";//sql запрос
            SqlCommand command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;

            #endregion

            #region Insert
            command = new SqlCommand(@"INSERT INTO Employee (FIO, Age, Salary) 
                          VALUES (@FIO, @Age, @Salary); SET @ID = @@IDENTITY;",
              connection);

            command.Parameters.Add("@FIO", SqlDbType.NVarChar, -1, "FIO");
            command.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
            command.Parameters.Add("@Salary", SqlDbType.NVarChar, 58, "Salary");

            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");

            param.Direction = ParameterDirection.Output;

            adapter.InsertCommand = command;
            #endregion

            #region Update
            command = new SqlCommand(@"UPDATE Employee SET FIO = @FIO,
                Age = @Age, Salary = @Salary WHERE ID = @ID", connection);

            command.Parameters.Add("@FIO", SqlDbType.NVarChar, -1, "FIO");
            command.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
            command.Parameters.Add("@Salary", SqlDbType.NVarChar, -1, "Salary");
            
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = command;
            #endregion

            #region delete

            command = new SqlCommand("DELETE FROM Employee WHERE Id = @ID", connection);
            SqlParameter parameter = command.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            adapter.DeleteCommand = command;

            #endregion

            dt = new DataTable(); // прослойка которая сцепляет видимую таблицу(View) и адаптер
            adapter.Fill(dt);

            EmployeeDataGrid.DataContext = dt.DefaultView;

        }

        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dt.NewRow();
            editWindow editWindow = new editWindow(newRow);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.Value)
            {
                dt.Rows.Add(editWindow.resultRow);
                adapter.Update(dt);
            }
        }

        private void BtnChengeEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)EmployeeDataGrid.SelectedItem; //выбор строки
            newRow.BeginEdit();
            editWindow editWindow = new editWindow(newRow.Row);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapter.Update(dt);
            }
            else
            {
                newRow.CancelEdit();
            }
        }

        private void BtnRevomeEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)EmployeeDataGrid.SelectedItem;

            newRow.Row.Delete();
            adapter.Update(dt);
        }
    }
    
}

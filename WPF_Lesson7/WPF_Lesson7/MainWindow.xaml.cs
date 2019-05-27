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
using System.Diagnostics;

namespace WPF_Lesson7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection connection;
        //Employee
        SqlDataAdapter adapterEmp;
        DataTable dtEmp;
        //Department
        SqlDataAdapter adapterDep;
        DataTable dtDep;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //Employee
            connection = new SqlConnection(connectionString);
            adapterEmp = new SqlDataAdapter(); //адаптер    
            //Department
            adapterDep = new SqlDataAdapter();

            #region Select

            //Department
            SqlCommand commandDep = new SqlCommand("SELECT Id, Name FROM Department", connection);
            adapterDep.SelectCommand = commandDep;
            #endregion

            #region Insert
  

            //Department
            commandDep = new SqlCommand(@"INSERT INTO Department (Name) 
                          VALUES (@Name); SET @ID = @@IDENTITY;",
              connection);
            commandDep.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");

            SqlParameter paramDep = commandDep.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            paramDep.Direction = ParameterDirection.Output;
            adapterDep.InsertCommand = commandDep;
            #endregion

            #region Update


            //Department
            commandDep = new SqlCommand(@"UPDATE Department SET Name = @Name WHERE ID = @ID", 
              connection);
            commandDep.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            paramDep = commandDep.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            paramDep.SourceVersion = DataRowVersion.Original;
            adapterDep.UpdateCommand = commandDep;
            #endregion

            #region delete

            // Department
            commandDep = new SqlCommand("DELETE FROM Department WHERE Id = @ID", connection);
            SqlParameter parameterDep = commandDep.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            adapterDep.DeleteCommand = commandDep;

            #endregion


            // View Department
            dtDep = new DataTable();
            adapterDep.Fill(dtDep);
            DepartamentDataGrid.DataContext = dtDep.DefaultView;

        }

       

        #region Button Department

        private void BtnAddDep_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dtDep.NewRow();
            EditDepWindow editDepWindow = new EditDepWindow(newRow);
            editDepWindow.ShowDialog();
            if (editDepWindow.DialogResult.Value)
            {
                dtDep.Rows.Add(editDepWindow.resultRow);
                adapterDep.Update(dtDep);
            }

        }

        private void BtnChengeDep_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)DepartamentDataGrid.SelectedItem; //выбор строки
            //Изьятие из View название департамента
            string departmentName_1 = String.Empty;
            string departmentName_2 = String.Empty;
            departmentName_1 = Convert.ToString(newRow.Row.ItemArray.GetValue(1));

            newRow.BeginEdit();
            EditDepWindow editDepWindow = new EditDepWindow(newRow.Row);
            editDepWindow.ShowDialog();

            if (editDepWindow.DialogResult.HasValue && editDepWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapterDep.Update(dtDep);
                departmentName_2 = Convert.ToString(newRow.Row.ItemArray.GetValue(1));
 
            }
            else
            {
                newRow.CancelEdit();
            }
        }
        private void BtnRevomeDep_Click(object sender, RoutedEventArgs e)
        {
            string departmentName = String.Empty;
            DataRowView newRow = (DataRowView)DepartamentDataGrid.SelectedItem;
            //Изьятие из View название департамента
            if (newRow != null)
            {
                departmentName = Convert.ToString(newRow.Row.ItemArray.GetValue(1));
            }

            //Department
            DataRowView depRow = (DataRowView)DepartamentDataGrid.SelectedItem;
            depRow.Row.Delete();
            adapterDep.Update(dtDep);

            //Employee
            
            var sql = String.Format("DELETE FROM Employee WHERE Department = '{0}'", departmentName);
            Debug.WriteLine(sql);
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        #endregion

        private void DepartamentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRevomeDep.IsEnabled = true;
            btnChengeDep.IsEnabled = true;
            btnAddEmp.IsEnabled = true;
            string departmentName = String.Empty;
            DataRowView newRow = (DataRowView)DepartamentDataGrid.SelectedItem;
            //Изьятие из View название департамента
            if (newRow != null)
            {
                departmentName = Convert.ToString(newRow.Row.ItemArray.GetValue(1));
            }
            
            #region Select
            //Employee Select
            var sql = String.Format("SELECT * FROM Employee WHERE Department = N'{0}'", departmentName);//sql запрос
            SqlCommand commandEmp = new SqlCommand(sql, connection);
            adapterEmp.SelectCommand = commandEmp;
            #endregion

            #region Insert
            //Employee Insert
            sql = String.Format(@"INSERT INTO Employee (FIO, Age, Salary, Department) 
                          VALUES (@FIO, @Age, @Salary,@{0}); SET @ID = @@IDENTITY;", departmentName);
            commandEmp = new SqlCommand(sql, connection);

            commandEmp.Parameters.Add("@FIO", SqlDbType.NVarChar, -1, "FIO");
            commandEmp.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
            commandEmp.Parameters.Add("@Salary", SqlDbType.NVarChar, 58, "Salary");
            commandEmp.Parameters.Add(departmentName, SqlDbType.NVarChar, 58, "Department");

            SqlParameter param = commandEmp.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");

            param.Direction = ParameterDirection.Output;

            adapterEmp.InsertCommand = commandEmp;
            #endregion

            #region Update
            //Employee Update
            sql = String.Format(@"UPDATE Employee SET FIO = @FIO,
                Age = @Age, Salary = @Salary, Department = @{0} WHERE ID = @ID", departmentName);
            commandEmp = new SqlCommand(sql, connection);

            commandEmp.Parameters.Add("@FIO", SqlDbType.NVarChar, -1, "FIO");
            commandEmp.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
            commandEmp.Parameters.Add("@Salary", SqlDbType.NVarChar, -1, "Salary");
            commandEmp.Parameters.Add(departmentName, SqlDbType.NVarChar, 58, "Department");

            param = commandEmp.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.SourceVersion = DataRowVersion.Original;

            adapterEmp.UpdateCommand = commandEmp;

            #endregion



            #region Delete
            //Employee Delete
            //sql = String.Format("DELETE FROM Employee WHERE Department = @{}",departmentName)
            commandEmp = new SqlCommand("DELETE FROM Employee WHERE Id = @ID", connection);
            SqlParameter parameter = commandEmp.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            adapterEmp.DeleteCommand = commandEmp;

            #endregion

            //View
            dtEmp = new DataTable(); // прослойка которая сцепляет видимую таблицу(View) и адаптер
            adapterEmp.Fill(dtEmp);
            EmployeeDataGrid.DataContext = dtEmp.DefaultView;
            

        }

        #region Button Employee


        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DepartamentDataGrid.SelectedItem;
            //Изьятие из View название департамента
            string departmentName = Convert.ToString(dataRow.Row.ItemArray.GetValue(1));

            DataRow newRow = dtEmp.NewRow();
            editWindow editWindow = new editWindow(newRow, departmentName);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.Value)
            {
                dtEmp.Rows.Add(editWindow.resultRow);
                adapterEmp.Update(dtEmp);
            }
        }

        private void BtnChengeEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DepartamentDataGrid.SelectedItem;
            //Изьятие из View название департамента
            string departmentName = Convert.ToString(dataRow.Row.ItemArray.GetValue(1));

            DataRowView newRow = (DataRowView)EmployeeDataGrid.SelectedItem; //выбор строки
            newRow.BeginEdit();

            editWindow editWindow = new editWindow(newRow.Row, departmentName);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapterEmp.Update(dtEmp);
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
            adapterEmp.Update(dtEmp);
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRevomeEmp.IsEnabled = true;
            btnChengeEmp.IsEnabled = true;
        }
        #endregion


    }

}

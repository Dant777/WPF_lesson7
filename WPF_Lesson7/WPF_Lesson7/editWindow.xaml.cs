using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Diagnostics;

namespace WPF_Lesson7
{
    /// <summary>
    /// Логика взаимодействия для editWindow.xaml
    /// </summary>
    public partial class editWindow : Window
    {
        public DataRow resultRow { get; set; }
        /// <summary>
        /// Имя департамента
        /// </summary>
        public string depName { get; set; }

        /// <summary>
        /// Конструктор для добавления трудяг с входным именем депортамента для трудяги
        /// </summary>
        /// <param name="dataRow">Входная строка</param>
        /// <param name="depName">Имя департамента</param>
        public editWindow(DataRow dataRow, string depName)
        {
            InitializeComponent();
            resultRow = dataRow;
            this.depName = depName;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAddNameEmp.Text = resultRow["FIO"].ToString();
            txtAddAgeEmp.Text = resultRow["Age"].ToString();
            txtAddSalaryEmp.Text = resultRow["Salary"].ToString();
        }

        private void BtnAddOK_Click(object sender, RoutedEventArgs e)
        {
            resultRow["FIO"] = txtAddNameEmp.Text;
            resultRow["Age"] = txtAddAgeEmp.Text;
            resultRow["Salary"] = txtAddSalaryEmp.Text;
            resultRow["Department"] = depName;
            this.DialogResult = true;
        }

        private void BtnAddCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

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

namespace WPF_Lesson7
{
    /// <summary>
    /// Логика взаимодействия для EditDepWindow.xaml
    /// </summary>
    public partial class EditDepWindow : Window
    {
        public DataRow resultRow { get; set; }

        public EditDepWindow(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAddNameDep.Text = resultRow["Name"].ToString();
            
        }

        private void BtnAddOK_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = txtAddNameDep.Text;
            this.DialogResult = true;
        }

        private void BtnAddCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

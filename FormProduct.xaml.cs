using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using System.Windows.Markup;

namespace Torg_texnic
{
    /// <summary>
    /// Логика взаимодействия для FormProduct.xaml
    /// </summary>
    public partial class FormProduct : Window
    {
        private readonly string connectionString = "Data Source=F:\\уп0301\\Torg_texnic.db;Version=3;"; 

        public FormProduct()
        {
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM Product", connection);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    UsersDataGrid.ItemsSource = dataTable.DefaultView; // Привязка данных к DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        
    }
}

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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace projectengineer
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            show_thing_search_name("id_thing","");
        }

        private void show_thing_search_name(string s, string name)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"SELECT id_thing AS 'รหัสพัสดุ', name_thing AS 'ชื่อพัสดุ', 
balance_thing || '/' || all_thing AS 'จำนวน(เหลือ/ทั้งหมด)', price AS 'ราคา' , other AS 'หมายเหตุ'
FROM thing;";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

    }
}

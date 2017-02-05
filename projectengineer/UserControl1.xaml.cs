using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data.SQLite;

namespace projectengineer
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        //public string id;

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (what_name_thing(textBox.Text))
            {
                //namething.Text = id;
                namething.Text = "มีข้อมูล";
                
            }
            else {
                //namething.Text = id;
                namething.Text = "ไม่มีข้อมูล";
            }

        }

        private bool what_name_thing(string id_thing) {
            bool namething = false;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT name_thing FROM thing WHERE id_thing = '" + id_thing + "' ;";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        namething = true;
                    }
                }
            }

            m_dbConnection.Close();
            return namething;
        }
        private void intonly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

    }
}

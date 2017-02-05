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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Data;
using System.Globalization;
using System.Windows.Threading;

namespace projectengineer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            inout_datePicker_loan.BlackoutDates.Clear();
            inout_datePicker_return.BlackoutDates.Clear();
            

            

            admin_form.Visibility = Visibility.Collapsed;
            admin_form.MinWidth += 380;
            admin_form.MinHeight += 140;
            //MessageBox.Show("gyhj" + tabwhite.ActualWidth);
            //CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Now);
            //inout_datePicker_loan.BlackoutDates.Add(cdr);
            inout_timePicker_loan.Is24Hours = true;
            CultureInfo UsaCulture = new CultureInfo("en-US");
            //inout_datePicker_return.BlackoutDates.Add(cdr);
            inout_timePicker_return.Is24Hours = true;
            tab_change();
            //show_thing();

            //inout_datePicker_loan.Text = "2016-07-15 04:09:30";
            //inout_timePicker_loan.Text = "04:09:30";



            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (loan.IsChecked==true) {

                inout_datePicker_loan.IsEnabled = false;
                inout_timePicker_loan.IsEnabled = false;

                if (isidkmitl(inout_IdKmitl.Text))
                {
                    if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                    {
                        dateText.Text = DateTime.Now.ToString("HH:mm:ss");
                        //inout_datePicker_return.BlackoutDates.Clear();
                        inout_datePicker_loan.BlackoutDates.Clear();
                        inout_datePicker_loan.SelectedDate = DateTime.Now;
                        inout_timePicker_loan.SelectedTime = DateTime.Now;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    //inout_datePicker_return.BlackoutDates.Clear();
                    inout_datePicker_loan.BlackoutDates.Clear();
                    dateText.Text = DateTime.Now.ToString("HH:mm:ss");
                    inout_datePicker_loan.SelectedDate = DateTime.Now;
                    inout_timePicker_loan.SelectedTime = DateTime.Now;
                }
            }
            
        }
    

    private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            admin_form.Visibility = Visibility.Collapsed;
            //addMember_IdKmitl.MinWidth = tabwhite.Width / 2.0;
            //MessageBox.Show("gyhj" + textblock12.ActualWidth);

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            admin_form.Visibility = Visibility.Visible;
            //addMember_IdKmitl.MinWidth = tabwhite.Width / 2.0;    
            //MessageBox.Show("gyhj" + textblock12.ActualWidth);
        }

        private void changesize(object sender, SizeChangedEventArgs e)
        {
            try
            {
                tabwhite.MinWidth = 700;

                addMember_IdKmitl.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_IdKmitl.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock12.ActualWidth + 96);

                addMember_name.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_name.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock13.ActualWidth + 96);

                addMember_other.MaxWidth = tabwhite.ActualWidth - (textblock27.ActualWidth + 96 + 96);

                addMember_nicname.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_nicname.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock14.ActualWidth + 96);

                addMember_park.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_park.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock16.ActualWidth + 96);

                addMember_user_admin.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_user_admin.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock22.ActualWidth + 96 + 96);

                addMember_pass_admin.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_pass_admin.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock23.ActualWidth + 96 + 96);

                addMember_pass_admin_con.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_pass_admin_con.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock24.ActualWidth + 96 + 96);

                addMember_user_god.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_user_god.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock25.ActualWidth + 96 + 96);

                addMember_pass_god.MinWidth = tabwhite.ActualWidth / 5.0;
                addMember_pass_god.MaxWidth = (tabwhite.ActualWidth / 2.0) - (textblock26.ActualWidth + 96 + 96);
            }
            catch
            {
                tabwhite.Width = 1000;
                //changesize(sender, e);
            }

        }

        private void reset()
        {
            addMember_IdKmitl.Foreground = new SolidColorBrush(Colors.Black);
            addMember_name.Text = "";
            addMember_nicname.Text = "";
            addMember_fa.SelectedIndex = 0;
            addMember_park.Text = "";
            addMember_room.SelectedIndex = 0;
            addMember_phone.Text = "";
            addMember_other.Text = "";

            inout_IdKmitl.Foreground = new SolidColorBrush(Colors.Black);
            inout_name.Text = "";
            inout_fa.Text = "";
            inout_project.Text = "";
            inout_park.Text = "";
            inout_room.Text = "";
            inout_belong_to.Text = "";
            inout_project.Text = "";
        }

        private void addMember_IdKmitl_TextChanged(object sender, TextChangedEventArgs e)
        {
            reset();
            inout_IdKmitl.Text = "";
            searchmember();
            
        }

        private void searchmember()
        {

            if (isidkmitl(addMember_IdKmitl.Text))
            {

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                string stm = "SELECT * FROM member WHERE idkmitl = '" + addMember_IdKmitl.Text + "' ;";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //MessageBox.Show("ss//"+rdr["idkmitl"]);
                            addMember_IdKmitl.Foreground = new SolidColorBrush(Colors.Green);
                            addMember_name.Text = rdr["name"].ToString();
                            addMember_nicname.Text = rdr["nickname"].ToString();
                            addMember_fa.Text = rdr["faculty"].ToString();
                            addMember_park.Text = rdr["park"].ToString();
                            addMember_room.Text = rdr["room"].ToString();
                            addMember_phone.Text = rdr["phone"].ToString();
                            addMember_other.Text = rdr["other"].ToString();
                        }
                    }
                }

                m_dbConnection.Close();
            }
        }

        private bool isidkmitl(String idkmitl)
        {
            bool istrue = false;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT idkmitl FROM member WHERE idkmitl = '" + idkmitl + "' ;";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        istrue = true;
                    }
                }
            }

            m_dbConnection.Close();
            addMember_IdKmitl.Foreground = new SolidColorBrush(Colors.Black);
            return istrue;
        }

        private void intonly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void click_add_member(object sender, RoutedEventArgs e)
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = @"CREATE TABLE member (
	idkmitl INT PRIMARY KEY,
	name VARCHAR,
	nickname VARCHAR,
	faculty VARCHAR,
	park VARCHAR,
	room VARCHAR,
	phone VARCHAR,
	other VARCHAR
);

CREATE TABLE member_data(
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	username VARCHAR,
	password VARCHAR,
	stana INT
);
INSERT INTO member VALUES(12345678, 'god', 'god', 'วิศวกรรมศาสตร์', 'god', '-', 1234567890, 'god');
INSERT INTO member_data VALUES(12345678, 'god', 'god', 2);

CREATE TABLE reservation(
	id_res INTEGER PRIMARY KEY AUTOINCREMENT,
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	belong_to VARCHAR,
	project VARCHAR,
	loan_date VARCHAR,
	loan_date_time VARCHAR,
	returned_date VARCHAR,
	returned_date_time VARCHAR,
	licensor INT,
	type VARCHAR DEFAULT 'จอง',
	place VARCHAR,
    time_stamp DATETIME DEFAULT (DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'))
);

CREATE TABLE res_thing(
	id_res INT REFERENCES reservation (id_res) ON DELETE CASCADE,
	id_thing VARCHAR,
	num_thing INT
);

CREATE TABLE loaning(
	id_loan INTEGER PRIMARY KEY AUTOINCREMENT,
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	belong_to VARCHAR,
	project VARCHAR,
	loan_date VARCHAR,
	loan_date_time VARCHAR,
	returned_date VARCHAR,
	returned_date_time VARCHAR,
	licensor INT,
	type VARCHAR DEFAULT 'ยืม',
	place VARCHAR,
    card VARCHAR,
    time_stamp DATETIME DEFAULT (DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'))
);

CREATE TABLE loan_thing(
	id_loan INT REFERENCES loaning (id_loan) ON DELETE CASCADE,
	id_thing VARCHAR,
	num_thing INT
);


CREATE TABLE returned(
	id_return INTEGER PRIMARY KEY AUTOINCREMENT,
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	belong_to VARCHAR,
	project VARCHAR,
	loan_date VARCHAR,
	loan_date_time VARCHAR,
	returned_date VARCHAR,
	returned_date_time VARCHAR,
	licensor INT,
	type VARCHAR DEFAULT 'คืน',
    time_stamp DATETIME DEFAULT (DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'))
);

CREATE TABLE return_thing(
	id_return INT REFERENCES returned (id_return) ON DELETE CASCADE,
	id_thing VARCHAR,
	num_thing INT
);

CREATE TABLE thing(
	id_thing VARCHAR PRIMARY KEY,
	name_thing VARCHAR,
	all_thing INT,
	balance_thing INT,
	price DOUBLE,
	other
);";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            //string sql2 = "insert into highscores (name, score) values ('Me', 9001)";
            //SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
            //command2.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        private bool isgod(string username, string pass)
        {
            bool god = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT username FROM member_data WHERE username = '" + username + "' AND password = '" + pass + "' AND stana = 2;";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        god = true;
                    }
                }
            }

            m_dbConnection.Close();

            return god;
        }
        private bool isadmin(string username, string pass) {
            bool admin = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT username FROM member_data WHERE username = '" + username + "' AND password = '" + pass + "' AND stana = 1;";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        admin = true;
                    }
                }
            }

            m_dbConnection.Close();

            return admin;
        }

        private int who_admin_or_god(string username) {
            int idkmitl = 0;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT idkmitl FROM member_data WHERE username = '" + username + "' ;";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        idkmitl = Int32.Parse(rdr["idkmitl"].ToString());
                    }
                }
            }

            m_dbConnection.Close();
            

            return idkmitl;
        }

        private bool isUsernameUnix(string username)
        {
            bool unix = true;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT username FROM member_data WHERE username = '" + username + "' ;";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        unix = false;
                    }
                }
            }

            m_dbConnection.Close();
            return unix;
        }
        private bool isEqualsPass(string pass1, string pass2)
        {
            bool isequals = false;
            if (pass1.Equals(pass2)) { isequals = true; }
            return isequals;
        }

        private async void changemember(object sender, RoutedEventArgs e)
        {

            LoginDialogData result = await this.ShowLoginAsync("Login", "กรุณากรอกโดยใช้ God เท่านั้น", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "" });
            if (result == null){}
            else
            {
                if (isme(Int32.Parse(addMember_IdKmitl.Text), result.Username))
                {
                    await this.ShowMessageAsync("Unsucessful login", "ขออภัยคุณไม่สามารถอนุญาติตัวเองได้", MessageDialogStyle.Affirmative);
                    return;
                }
                else
                {
                    if (checkpass(result.Username, result.Password))
                    {
                        updatemember(Int32.Parse(addMember_IdKmitl.Text), addMember_name.Text, addMember_nicname.Text, addMember_phone.Text, addMember_other.Text);
                        await this.ShowMessageAsync("Sucessful login", "บันทึกการเปลี่ยนแปลงข้อมูลเรียบร้อย", MessageDialogStyle.Affirmative);
                        //MessageBox.Show("บันทึกการเปลี่ยนแปลงข้อมูลเรียบร้อย", "successful");
                        //this.Close();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Unsucessful login", "ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", MessageDialogStyle.Affirmative);
                        //MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง");
                        return;
                    }
                }
            }



            

        }

        public bool isme(int idkmitl, string username)
        {
            bool ime = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT idkmitl FROM member_data WHERE username = '" + username + "'AND idkmitl = " + idkmitl + ";";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ime = true;
                    }
                }
            }

            m_dbConnection.Close();

            return ime;
        }

        public bool checkpass(string username, string password)
        {
            bool pass = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT idkmitl FROM member_data WHERE username = '" + username + "'AND password = '" + password + "';";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pass = true;
                    }
                }
            }

            m_dbConnection.Close();

            return pass;
        }

        public void updatemember(int idkmitl, string name, string nickname, string phone, string other)
        {

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "UPDATE member SET name = @name, nickname = @nickname, phone = @phone, other = @other WHERE idkmitl = " + idkmitl + ";";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@nickname", nickname);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@other", other);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();


        }

        private void add_admin()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO member_data (idkmitl, username, password, stana) VALUES(@idkmitl, @username, @password, @stana)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(addMember_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@username", addMember_user_admin.Text);
                cmd.Parameters.AddWithValue("@password", addMember_pass_admin.Password);
                cmd.Parameters.AddWithValue("@stana", 1);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private async void add_member(object sender, RoutedEventArgs e)
        {

            if (addMember_IdKmitl.Text.Equals("") || addMember_name.Text.Equals("") || addMember_nicname.Text.Equals("") || addMember_phone.Text.Equals("") || addMember_other.Text.Equals("")) {
                await this.ShowMessageAsync("Unsucessful", "กรุณากรอกรายละเอียดให้ครบถ้วน", MessageDialogStyle.Affirmative);
                return;
            }

            if (isidkmitl(addMember_IdKmitl.Text))
            {
                changemember(sender, e);
                //reset();
                return;
            }

            if (ToggleButton.IsChecked == true)
            {
                if (isUsernameUnix(addMember_user_admin.Text))
                {
                    if (isEqualsPass(addMember_pass_admin.Password, addMember_pass_admin_con.Password))
                    {
                        LoginDialogData result = await this.ShowLoginAsync("Login", "กรุณากรอกโดยใช้ God เท่านั้น", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "" });
                        if (result == null)
                        {
                            //tab_addmember.IsSelected = true;
                        }
                        else
                        {
                            //MessageDialogResult messageResult = await this.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}", result.Username, result.Password));
                            if (isgod(result.Username, result.Password))
                            {
                                add_admin();
                                await this.ShowMessageAsync("Sucessful login", "บันทึกข้อมูล Admin เสร็จสมบูรณ์", MessageDialogStyle.Affirmative);
                            }
                            else
                            {
                                await this.ShowMessageAsync("Unsucessful login", "ขออภัยคุณไม่มีสิทธิเข้าถึงส่วนนี้ หรือ username, password ผิด", MessageDialogStyle.Affirmative);
                                //tab_addmember.IsSelected = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        await this.ShowMessageAsync("Unsuccessful", "ขออภัยคุณกรอก Password ไม่ตรงกัน(Admin)", MessageDialogStyle.Affirmative);
                        //MessageBox.Show("ขออภัยคุณกรอก Password ไม่ตรงกัน(Admin)", "unsuccessful");
                        return;
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Unsuccessful", "ขออภัยUsernameนี้มีคนใช้แล้ว", MessageDialogStyle.Affirmative);
                    //MessageBox.Show("ขออภัยUsernameนี้มีคนใช้แล้ว", "unsuccessful");
                    return;
                }
            }


            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES(@idkmitl, @name, @nickname, @faculty, @park, @room, @phone, @other)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(addMember_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@name", addMember_name.Text);
                cmd.Parameters.AddWithValue("@nickname", addMember_nicname.Text);
                cmd.Parameters.AddWithValue("@faculty", addMember_fa.Text);
                cmd.Parameters.AddWithValue("@park", addMember_park.Text);
                cmd.Parameters.AddWithValue("@room", addMember_room.Text);
                cmd.Parameters.AddWithValue("@phone", addMember_phone.Text);
                cmd.Parameters.AddWithValue("@other", addMember_other.Text);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
            await this.ShowMessageAsync("Sucessful", "บันทึกการสมัครเรียบร้อย", MessageDialogStyle.Affirmative);

        }

        private void Gen(object sender, RoutedEventArgs e)
        {
            UserControl1 abc = new UserControl1();
            //abc.id = inout_IdKmitl.Text;
            someStackPanel.Children.Add(abc);
            string aa = "";
            foreach (UserControl1 child in someStackPanel.Children)
            {
                aa += child.textBox.Text + " ";
            }
            //abc.textBox.Text
            //MessageBox.Show(aa);
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            List<UserControl1> list = new List<UserControl1>();
            foreach (UserControl1 child in someStackPanel.Children)
            {

                if (child.checkBox.IsChecked == true)
                {
                    //someStackPanel.Children.RemoveAt(i - 1);
                    list.Add(child);
                }



            }

            foreach (UserControl1 c in list)
            {
                //MessageBox.Show(""+c);
                someStackPanel.Children.Remove(c);
            }
        }



        private void inout_IdKmitl_TextChanged(object sender, TextChangedEventArgs e)
        {
            reset();
            addMember_IdKmitl.Text = "";
            searchmember2();
            if (isidkmitl(inout_IdKmitl.Text))
            {
                if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                { }
                else
                {
                    
                    loan.IsChecked = true;
                    
                }
            }

            if (loan.IsChecked == true || @return.IsChecked == true)
            {
                if (isidkmitl(inout_IdKmitl.Text))
                {
                    if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                    {
                        inout_belong_to.Text = "";
                        inout_project.Text = "";
                        inout_datePicker_loan.Text = "";
                        inout_timePicker_loan.Text = "";
                        inout_datePicker_return.Text = "";
                        inout_timePicker_return.Text = "";
                        inout_card.Value = 0;
                        inout_belong_to.IsEnabled = true;
                        inout_project.IsEnabled = true;
                        inout_card.IsEnabled = true;
                        inout_datePicker_loan.IsEnabled = true;
                        inout_timePicker_loan.IsEnabled = true;
                        inout_datePicker_return.IsEnabled = true;
                        inout_timePicker_return.IsEnabled = true;

                    }
                    else
                    {
                        find_project_last(inout_IdKmitl.Text);
                        inout_belong_to.IsEnabled = false;
                        inout_project.IsEnabled = false;
                        inout_card.IsEnabled = false;
                        inout_datePicker_loan.IsEnabled = false;
                        inout_timePicker_loan.IsEnabled = false;
                        inout_datePicker_return.IsEnabled = false;
                        inout_timePicker_return.IsEnabled = false;
                    }
                }
                else {
                    inout_datePicker_loan.Text = "";
                    inout_timePicker_loan.Text = "";
                    inout_datePicker_return.Text = "";
                    inout_timePicker_return.Text = "";
                }
            }
            //inout_datePicker_loan.da
        }

        private void searchmember2()
        {

            if (isidkmitl(inout_IdKmitl.Text))
            {

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                string stm = "SELECT name, faculty, park, room FROM member WHERE idkmitl = '" + inout_IdKmitl.Text + "' ;";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //MessageBox.Show("ss//"+rdr["idkmitl"]);
                            inout_IdKmitl.Foreground = new SolidColorBrush(Colors.Green);
                            inout_name.Text = rdr["name"].ToString();
                            inout_fa.Text = rdr["faculty"].ToString();
                            inout_park.Text = rdr["park"].ToString();
                            inout_room.Text = rdr["room"].ToString();


                        }
                    }
                }

                m_dbConnection.Close();
            }
        }

        private async void tab_change() {
            if (tab_addmember.IsSelected)
            {
                await this.ShowMessageAsync("Tab:", "เพิ่มสมาชิก", MessageDialogStyle.Affirmative);
            }
            if (tab_inout.IsSelected)
            {
                await this.ShowMessageAsync("Tab:", "จอง/ยืม/คืน", MessageDialogStyle.Affirmative);
            }
            if (tab_god.IsSelected)
            {
                await this.ShowMessageAsync("Tab:", "test", MessageDialogStyle.Affirmative);
            }
        }

        private void tab_addmember_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void tab_addmember_Selected_1(object sender, RoutedEventArgs e)
        {
            

                //await this.ShowMessageAsync("Tab:", hash, MessageDialogStyle.Affirmative);
            //addMember_name.Text = "aaa";

        }

        private string md5encrypt(string source) {
            source = "Hello World!";
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, source);
            }
            return hash;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }






        private async void tab_god_Selected(object sender, RoutedEventArgs e)
        {
            LoginDialogData result = await this.ShowLoginAsync("Authentication", "Enter your credentials", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "" });
            if (result == null)
            {
                //tab_addmember.IsSelected = true;
                tab_addmember.IsSelected = true;
            }
            else
            {
                //MessageDialogResult messageResult = await this.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}", result.Username, result.Password));
                if (isgod(result.Username, result.Password))
                {
                    await this.ShowMessageAsync("Sucessful login", "ยินดีต้อนรับคุณgod", MessageDialogStyle.Affirmative);
                }
                else {
                    await this.ShowMessageAsync("Unsucessful login", "ขออภัยคุณไม่มีสิทธิเข้าถึงส่วนนี้ หรือ username, password ผิด", MessageDialogStyle.Affirmative);
                    tab_addmember.IsSelected = true;
                }
            }
        }

        private async void tab_admin_Selected(object sender, RoutedEventArgs e)
        {
            LoginDialogData result = await this.ShowLoginAsync("Authentication", "Enter your credentials", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "" });
            if (result == null)
            {
                //tab_addmember.IsSelected = true;
                tab_addmember.IsSelected = true;
            }
            else
            {
                //MessageDialogResult messageResult = await this.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}", result.Username, result.Password));
                if (isadmin(result.Username, result.Password))
                {
                    await this.ShowMessageAsync("Sucessful login", "ยินดีต้อนรับคุณAdmin", MessageDialogStyle.Affirmative);
                }
                else
                {
                    await this.ShowMessageAsync("Unsucessful login", "ขออภัยคุณไม่มีสิทธิเข้าถึงส่วนนี้ หรือ username, password ผิด", MessageDialogStyle.Affirmative);
                    tab_addmember.IsSelected = true;
                }
            }
        }

        private async void controlthing_button_Click(object sender, RoutedEventArgs e)
        {
            if (isthing(controlthing_idthing.Text))
            {
                updatething(controlthing_idthing.Text);
                await this.ShowMessageAsync("Sucessful login", "บันทึกข้อมูลพัสดุเรียบร้อย", MessageDialogStyle.Affirmative);
            }
            else {
                add_thing();
                await this.ShowMessageAsync("Sucessful login", "บันทึกข้อมูลพัสดุเรียบร้อย", MessageDialogStyle.Affirmative);
            }
        }
        private bool isthing(string idthing) {
            bool iisthing = false;


            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT id_thing FROM thing WHERE id_thing = '" + idthing + "';";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        iisthing = true;
                    }
                }
            }

            m_dbConnection.Close();
            return iisthing;
        }

        private void add_thing() {

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO thing (id_thing, name_thing, all_thing, balance_thing, price, other) VALUES(@id_thing, @name_thing, @all_thing, @balance_thing, @price, @other)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_thing", controlthing_idthing.Text);
                cmd.Parameters.AddWithValue("@name_thing", controlthing_namething.Text);
                cmd.Parameters.AddWithValue("@all_thing", Int32.Parse(controlthing_allthing.Text));
                cmd.Parameters.AddWithValue("@balance_thing", Int32.Parse(controlthing_allthing.Text));
                cmd.Parameters.AddWithValue("@price", Double.Parse(controlthing_pricething.Text));
                cmd.Parameters.AddWithValue("@other", controlthing_otherthing.Text);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void controlthing_idthing_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isthing(controlthing_idthing.Text))
            {
                controlthing_setinput(controlthing_idthing.Text);
            }
            else
            {
                controlthing_setinputnull();
            }
        }
        private void controlthing_setinputnull() {
            controlthing_namething.Text = "";
            controlthing_allthing.Text = "";
            controlthing_pricething.Text = "";
            controlthing_otherthing.Text = "";
        }
        private void controlthing_setinput(string idthing) {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT name_thing, all_thing, price, other FROM thing WHERE id_thing = '" + idthing + "';";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        controlthing_namething.Text = rdr["name_thing"].ToString();
                        controlthing_allthing.Text = rdr["all_thing"].ToString();
                        controlthing_pricething.Text = rdr["price"].ToString();
                        controlthing_otherthing.Text = rdr["other"].ToString();
                    }
                }
            }

            m_dbConnection.Close();
        }
        private void updatething(string id_thing) {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = @"UPDATE thing SET name_thing = @name_thing, balance_thing = (SELECT balance_thing FROM thing WHERE id_thing = @id_thing) - ((SELECT all_thing FROM thing WHERE id_thing = @id_thing) - @all_thing), 
all_thing = @all_thing, price = @price, other = @other WHERE id_thing = @id_thing;";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_thing", id_thing);
                cmd.Parameters.AddWithValue("@name_thing", controlthing_namething.Text);
                cmd.Parameters.AddWithValue("@all_thing", Int32.Parse(controlthing_allthing.Text));
                cmd.Parameters.AddWithValue("@price", Double.Parse(controlthing_pricething.Text));
                cmd.Parameters.AddWithValue("@other", controlthing_otherthing.Text);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private async void inout_submit_Click(object sender, RoutedEventArgs e)
        {
            if (inout_belong_to.Text.Equals("") || inout_project.Equals("")) {
                await this.ShowMessageAsync("Unsucessful", "กรุณากรอกข้อมูลให้ครบ", MessageDialogStyle.Affirmative);
                return;
            }
            
            
            if (isidkmitl(inout_IdKmitl.Text))
            {
                LoginDialogData result = await this.ShowLoginAsync("Login", "กรุณากรอก Username, password(Admin, God)", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "" });
                if (result == null) { }
                else
                {
                    if (!isme(Int32.Parse(inout_IdKmitl.Text), result.Username))
                    {
                        if (isadmin(result.Username, result.Password) || isgod(result.Username, result.Password))
                        {

                            if (res.IsChecked == true)
                            {
                                reservation(result.Username);
                                await this.ShowMessageAsync("Sucessful", "บันทึกการจองเรียบร้อย", MessageDialogStyle.Affirmative);
                            }
                            else if (loan.IsChecked == true)
                            {

                                loaning(result.Username);
                                await this.ShowMessageAsync("Sucessful", "บันทึกการยืมเรียบร้อย", MessageDialogStyle.Affirmative);
                                


                            }
                            else if (@return.IsChecked == true)
                            {

                                foreach (UserControl1 child in someStackPanel.Children)
                                {
                                    //MessageBox.Show(child.textBox.Text+"//"+child.textBox2.Text);
                                    if (check_item(child.textBox.Text)) { }
                                    else
                                    {
                                        await this.ShowMessageAsync("Unscessful", "ตรวจสอบรหัสพัสดุอีกครั้ง(" + child.textBox.Text + ")", MessageDialogStyle.Affirmative);
                                        return;
                                    }
                                    if (check_item_num(Int32.Parse(child.textBox2.Text), child.textBox.Text)) { }
                                    else
                                    {
                                        await this.ShowMessageAsync("Unscessful", "ตรวจสอบจำนวนพัสดุอีกครั้ง("+ child.textBox.Text +")", MessageDialogStyle.Affirmative);
                                        return;
                                    }
                                }

                                    returned(result.Username);
                                await this.ShowMessageAsync("Sucessful", "บันทึกการคืนเรียบร้อย", MessageDialogStyle.Affirmative);
                            }


                            
                        }
                        else {
                            await this.ShowMessageAsync("Unsucessful", "ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", MessageDialogStyle.Affirmative);
                        }
                    }
                    else {
                        await this.ShowMessageAsync("Unsucessful", "ขออภัยคุณไม่สามารถอนุญาติตัวเองได้", MessageDialogStyle.Affirmative);
                    }
                }
            }
            else {
                await this.ShowMessageAsync("Unsucessful", "กรุณาสมัครสมาชิก", MessageDialogStyle.Affirmative);
                return;
            }

        }

        private void reservation(string username) {
            int idkmitl = 0;
            idkmitl = who_admin_or_god(username);
            reservation2(idkmitl);
            int id_res = 0;

            id_res = find_id_res();
            foreach (UserControl1 child in someStackPanel.Children)
            {
                //MessageBox.Show(child.textBox.Text+"//"+child.textBox2.Text);

                try
                {
                    reservation_thing(child.textBox.Text, Int32.Parse(child.textBox2.Text), id_res);
                }
                catch { }
            }
        }

        private int find_id_res() {
            int id_res = 0;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;";

            //SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        id_res = Int32.Parse(rdr["id_res"].ToString());
                    }
                }
            }

            m_dbConnection.Close();

            return id_res;
        }

        private void reservation2(int licensor) {
            string in_or_out = "จัดภายนอกสถาบัน";
            if (indoor.IsChecked == true) {
                in_or_out = "จัดภายในสถาบัน";
            }



            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO reservation (idkmitl, belong_to, project, loan_date, loan_date_time, returned_date, returned_date_time, licensor, place) VALUES(@idkmitl, @belong_to, @project, @loan_date, @loan_date_time, @returned_date, @returned_date_time, @licensor, @place);";
                cmd.Prepare();
                //cmd.Parameters.AddWithValue("@id_res", null);
                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(inout_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@belong_to", inout_belong_to.Text);
                cmd.Parameters.AddWithValue("@project", inout_project.Text);
                cmd.Parameters.AddWithValue("@loan_date", inout_datePicker_loan.Text);
                cmd.Parameters.AddWithValue("@loan_date_time", inout_timePicker_loan.Text);
                cmd.Parameters.AddWithValue("@returned_date", inout_datePicker_return.Text);
                cmd.Parameters.AddWithValue("@returned_date_time", inout_timePicker_return.Text);
                cmd.Parameters.AddWithValue("@licensor", licensor);
                cmd.Parameters.AddWithValue("@place", in_or_out);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void reservation_thing(string idthing, int num, int id_res) {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO res_thing (id_res, id_thing, num_thing) VALUES(@id_res, @id_thing, @num_thing)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_res", id_res);
                cmd.Parameters.AddWithValue("@id_thing", idthing);
                cmd.Parameters.AddWithValue("@num_thing", num);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }



        private void loaning(string username)
        {
            int idkmitl = 0;
            idkmitl = who_admin_or_god(username);
            loaning2(idkmitl);
            int id_loan = 0;

            id_loan = find_id_loan();
            foreach (UserControl1 child in someStackPanel.Children)
            {
                //MessageBox.Show(child.textBox.Text+"//"+child.textBox2.Text);
                try
                {
                    loaning_thing(child.textBox.Text, Int32.Parse(child.textBox2.Text), id_loan);
                    loaning_update_thing(child.textBox.Text, Int32.Parse(child.textBox2.Text));
                }
                catch { }

                
            }
        }

        private int find_id_loan()
        {
            int id_loan = 0;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT id_loan FROM loaning ORDER BY id_loan DESC LIMIT 1;";

            //SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        id_loan = Int32.Parse(rdr["id_loan"].ToString());
                    }
                }
            }

            m_dbConnection.Close();

            return id_loan;
        }

        private void loaning2(int licensor)
        {
            string in_or_out = "จัดภายนอกสถาบัน";
            if (indoor.IsChecked == true)
            {
                in_or_out = "จัดภายในสถาบัน";
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO loaning (idkmitl, belong_to, project, loan_date, loan_date_time, returned_date, returned_date_time, licensor, place, card) VALUES(@idkmitl, @belong_to, @project, @loan_date, @loan_date_time, @returned_date, @returned_date_time, @licensor, @place, @card);";
                cmd.Prepare();
                //cmd.Parameters.AddWithValue("@id_res", null);
                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(inout_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@belong_to", inout_belong_to.Text);
                cmd.Parameters.AddWithValue("@project", inout_project.Text);
                cmd.Parameters.AddWithValue("@loan_date", inout_datePicker_loan.Text);
                cmd.Parameters.AddWithValue("@loan_date_time", inout_timePicker_loan.Text);
                cmd.Parameters.AddWithValue("@returned_date", inout_datePicker_return.Text);
                cmd.Parameters.AddWithValue("@returned_date_time", inout_timePicker_return.Text);
                cmd.Parameters.AddWithValue("@licensor", licensor);
                cmd.Parameters.AddWithValue("@place", in_or_out);
                cmd.Parameters.AddWithValue("@card", inout_card.Value.ToString());

                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void loaning_thing(string idthing, int num, int id_loan)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO loan_thing (id_loan, id_thing, num_thing) VALUES(@id_loan, @id_thing, @num_thing)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_loan", id_loan);
                cmd.Parameters.AddWithValue("@id_thing", idthing);
                cmd.Parameters.AddWithValue("@num_thing", num);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void loaning_update_thing(string idthing, int num) {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "UPDATE thing SET balance_thing = (SELECT balance_thing FROM thing WHERE id_thing = @id_thing) - @num WHERE id_thing = @id_thing;";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_thing", idthing);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }


        private bool check_item(string id_thing) {
            bool c = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = @"select idkmitl , id_thing, num2
from
(
select x.idkmitl, x.id_thing, x.num - IFNULL(y.num, 0) as 'num2', th.id_thing
from
(
select a.idkmitl, a.id_loan, sum(b.num_thing) as 'num', a.project, a.belong_to, b.id_thing
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing
) x
left outer join 
(
select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing
) y

ON x.idkmitl = y.idkmitl AND x.id_thing = y.id_thing

left outer join thing th
ON x.id_thing = th.id_thing
where num2 not like 0
)
where idkmitl = " + Int32.Parse(inout_IdKmitl.Text) + " and id_thing = '" + id_thing + "';";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (rdr["id_thing"].ToString().Equals(id_thing)) {
                            c = true;
                        }
                    }
                }
            }

            m_dbConnection.Close();


            return c;
        }
        private bool check_item_num( int num, string id_thing) {
            bool c = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = @"select idkmitl , id_thing, num2
from
(
select x.idkmitl, x.id_thing, x.num - IFNULL(y.num, 0) as 'num2', th.id_thing
from
(
select a.idkmitl, a.id_loan, sum(b.num_thing) as 'num', a.project, a.belong_to, b.id_thing
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing
) x
left outer join 
(
select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing
) y

ON x.idkmitl = y.idkmitl AND x.id_thing = y.id_thing

left outer join thing th
ON x.id_thing = th.id_thing
where num2 not like 0
)
where idkmitl = " + Int32.Parse(inout_IdKmitl.Text) + " and id_thing = '" + id_thing + "';";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (Int32.Parse(rdr["num2"].ToString())>=num)
                        {
                            c = true;
                        }
                    }
                }
            }

            m_dbConnection.Close();

            return c;
        }

        private void returned(string username)
        {
            int idkmitl = 0;
            idkmitl = who_admin_or_god(username);
            returned2(idkmitl);
            int id_return = 0;

            id_return = find_id_return();
            foreach (UserControl1 child in someStackPanel.Children)
            {
                //MessageBox.Show(child.textBox.Text+"//"+child.textBox2.Text);
               
                try
                {
                    return_thing(child.textBox.Text, Int32.Parse(child.textBox2.Text), id_return);
                    loaning_update_thing_return(child.textBox.Text, Int32.Parse(child.textBox2.Text));
                }
                catch { }
                
            }
        }

        private int find_id_return()
        {
            int id_return = 0;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT id_return FROM returned ORDER BY id_return DESC LIMIT 1;";

            //SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        id_return = Int32.Parse(rdr["id_return"].ToString());
                    }
                }
            }

            m_dbConnection.Close();

            return id_return;
        }

        private void returned2(int licensor)
        {

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO returned (idkmitl, belong_to, project, loan_date, loan_date_time, returned_date, returned_date_time, licensor) VALUES(@idkmitl, @belong_to, @project, @loan_date, @loan_date_time, @returned_date, @returned_date_time, @licensor);";
                cmd.Prepare();
                //cmd.Parameters.AddWithValue("@id_res", null);
                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(inout_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@belong_to", inout_belong_to.Text);
                cmd.Parameters.AddWithValue("@project", inout_project.Text);
                cmd.Parameters.AddWithValue("@loan_date", inout_datePicker_loan.Text);
                cmd.Parameters.AddWithValue("@loan_date_time", inout_timePicker_loan.Text);
                cmd.Parameters.AddWithValue("@returned_date", inout_datePicker_return.Text);
                cmd.Parameters.AddWithValue("@returned_date_time", inout_timePicker_return.Text);
                cmd.Parameters.AddWithValue("@licensor", licensor);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void return_thing(string idthing, int num, int id_return)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO return_thing (id_return, id_thing, num_thing) VALUES(@id_return, @id_thing, @num_thing)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_return", id_return);
                cmd.Parameters.AddWithValue("@id_thing", idthing);
                cmd.Parameters.AddWithValue("@num_thing", num);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void loaning_update_thing_return(string idthing, int num)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "UPDATE thing SET balance_thing = (SELECT balance_thing FROM thing WHERE id_thing = @id_thing) + @num WHERE id_thing = @id_thing;";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id_thing", idthing);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"select idkmitl AS 'รหัส นศ', belong_to AS 'สังกัด',project AS 'งาน',  name_thing AS 'ชื่อพัสดุ', num2 AS 'จำนวน'
from
(
select x.idkmitl, x.id_thing, x.num - IFNULL(y.num, 0) as 'num2', x.belong_to, x.project, th.name_thing
from
(
select a.idkmitl, a.id_loan, sum(b.num_thing) as 'num', a.project, a.belong_to, b.id_thing
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing
) x
left outer join 
(
select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing
) y

ON x.idkmitl = y.idkmitl AND x.id_thing = y.id_thing

left outer join thing th
ON x.id_thing = th.id_thing
where num2 not like 0
)
";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            datagrid.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

       

        private void show_thing_search_name(string s, string name) {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"SELECT id_thing AS 'รหัสพัสดุ', name_thing AS 'ชื่อพัสดุ', 
balance_thing || '/' || all_thing AS 'จำนวน(เหลือ/ทั้งหมด)', price AS 'ราคา' , other AS 'หมายเหตุ'
FROM thing
where " + s +" LIKE '%" + name + "%';";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            see_thing.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

        private void search_thing_Click(object sender, RoutedEventArgs e)
        {
            if (admin_search.Text.Equals("ชื่อพัสดุ"))
            {
                show_thing_search_name("name_thing", search_thing_text.Text);
            }
            else {
                show_thing_search_name("id_thing", search_thing_text.Text);
            }
        }

        private void show_member_search_name(string s, string name)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"select stana AS 'ประเภท', idkmitl AS 'รหัส นศ', name AS 'ชื่อ', surname AS 'นามสกุล', nickname AS 'ชื่อเล่น', faculty AS 'คณะ', park AS 'ภาค', room AS 'ห้อง', phone AS 'เบอร์โทร'
from (

select replace(replace(replace(IFNULL(m2.stana, 0), 0, 'Member'), 1, 'Admin'), 2, 'God') AS 'stana', m.idkmitl AS 'idkmitl', SUBSTR(m.name, 0, instr(m.name, ' ')) AS 'name', substr(m.name, instr(m.name, ' ')) AS 'surname', m.nickname AS 'nickname', m.faculty AS 'faculty', m.park AS 'park', m.room AS 'room', m.phone AS 'phone'
from member m
left outer join member_data m2
on(m.idkmitl = m2.idkmitl))
where " + s + " LIKE '%" + name + "%'";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            see_member.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

        private void search_member_Click(object sender, RoutedEventArgs e)
        {
            if (admin_search_member.Text.Equals("รหัสนักศึกษา"))
            {
                show_member_search_name("idkmitl", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ชื่อ"))
            {
                show_member_search_name("name", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("นามสกุล"))
            {
                show_member_search_name("surname", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ชื่อเล่น"))
            {
                show_member_search_name("nickname", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("คณะ"))
            {
                show_member_search_name("faculty", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ภาควิชา"))
            {
                show_member_search_name("park", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ห้อง"))
            {
                show_member_search_name("room", search_member_text.Text);
            }
            else {
                show_member_search_name("phone", search_member_text.Text);
            }
        


        }

        private bool check_return_end(int idkmitl) {
            bool return_end = false;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = @"select x.idkmitl,  sum(x.num - IFNULL(y.num, 0)) as 'return_end'
from
(
select a.idkmitl, a.id_loan, b.id_thing, sum(b.num_thing) as 'num'
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing
) x
left outer join 
(
select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing
) y

ON x.idkmitl = y.idkmitl AND x.id_thing = y.id_thing
where x.idkmitl = "+ idkmitl +";";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        if (!rdr["return_end"].ToString().Equals(""))
                        {
                            if (Int32.Parse(rdr["return_end"].ToString()) == 0)
                            {
                                return_end = true;
                            }
                        }
                        else { return_end = true; }
                    }
                }
            }

            m_dbConnection.Close();

            return return_end;
        }
        private void find_project_last(string idkmitl) {
            string p = "";
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = @"select place, card, belong_to, project, loan_date,loan_date_time, returned_date, returned_date_time from loaning where idkmitl = " + idkmitl+" order by id_loan DESC LIMIT 1";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        inout_belong_to.Text = rdr["belong_to"].ToString();
                        inout_project.Text = rdr["project"].ToString();
                        inout_datePicker_loan.Text = rdr["loan_date"].ToString();
                        inout_timePicker_loan.Text = rdr["loan_date_time"].ToString();
                        inout_datePicker_return.Text = rdr["returned_date"].ToString();
                       // MessageBox.Show(rdr["card"].ToString());
                        inout_card.Value = Int32.Parse(rdr["card"].ToString());

                        inout_timePicker_return.Text = rdr["returned_date_time"].ToString();
                        p = rdr["place"].ToString();
                    }
                }
            }
            if (p.Equals("จัดภายในสถาบัน"))
            {
                indoor.IsChecked = true;
                outdoor.IsChecked = false;
            }
            else {
                indoor.IsChecked = false;
                outdoor.IsChecked = true;
            }

            m_dbConnection.Close();

        }
        private int find_id_loan_last(int idkmitl) {
            int id_loan = 0;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = @"select id_loan from loaning where idkmitl = " + idkmitl + " order by id_loan DESC LIMIT 1";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        id_loan = Int32.Parse(rdr["id_loan"].ToString());
                    }
                }
            }
            m_dbConnection.Close();
            return id_loan;
        }



        private void show_member_search_name2(string s, string name)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', project AS 'งาน', phone AS 'เบอร์โทร', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม', licensor AS 'ผู้รับทำรายการ'
from
(
select r.id_loan, r.project, r.place, r.idkmitl, r.time_stamp, card as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from loaning r
join loan_thing rt
on r.id_loan = rt.id_loan
left outer join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing, r.id_loan
)
group by idkmitl, id_loan

union

select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', project, phone AS 'phone', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม', licensor AS 'ผู้รับทำรายการ'
from
(
select r.id_return, r.project, '-' as place, r.idkmitl, r.time_stamp, '-' as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from returned r
join return_thing rt
on r.id_return = rt.id_return
left outer join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing, r.id_return
)
group by idkmitl, id_return";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            see_member2.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

        private void search_member_Click2(object sender, RoutedEventArgs e)
        {
            if (admin_search_member.Text.Equals("รหัสนักศึกษา"))
            {
                show_member_search_name2("idkmitl", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ชื่อ นามสกุล"))
            {
                show_member_search_name2("name", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ชื่อเล่น"))
            {
                show_member_search_name2("nickname", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("คณะ"))
            {
                show_member_search_name2("faculty", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ภาควิชา"))
            {
                show_member_search_name2("park", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ห้อง"))
            {
                show_member_search_name2("room", search_member_text.Text);
            }
            else
            {
                show_member_search_name2("phone", search_member_text.Text);
            }



        }

        private void show_member_search_name2_res(string s, string name)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"select time_stamp AS 'ว_ด_ป', loan_date AS 'วันที่ยืม', returned_date AS 'วันที่คืน', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', project AS 'งาน', phone AS 'เบอร์โทร', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม',licensor AS 'ผู้รับทำรายการ'
from
(
select r.project, r.loan_date || ' ' || r.loan_date_time AS 'loan_date',r.returned_date || ' ' || r.returned_date_time AS 'returned_date', r.id_res, r.place, r.idkmitl, r.time_stamp, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from reservation r
join res_thing rt
on r.id_res = rt.id_res
left outer join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing, r.id_res
)
group by idkmitl, id_res";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            see_member2_res.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

        private void search_member_Click2_res(object sender, RoutedEventArgs e)
        {
            if (admin_search_member.Text.Equals("รหัสนักศึกษา"))
            {
                show_member_search_name2_res("idkmitl", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ชื่อ นามสกุล"))
            {
                show_member_search_name2_res("name", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ชื่อเล่น"))
            {
                show_member_search_name2_res("nickname", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("คณะ"))
            {
                show_member_search_name2_res("faculty", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ภาควิชา"))
            {
                show_member_search_name2_res("park", search_member_text.Text);
            }
            else if (admin_search_member.Text.Equals("ห้อง"))
            {
                show_member_search_name2_res("room", search_member_text.Text);
            }
            else
            {
                show_member_search_name2_res("phone", search_member_text.Text);
            }



        }


        private void save_god() {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = @"UPDATE member SET idkmitl = @idkmitl, name = @name, nickname= @nickname, faculty = @faculty, park = @park, room = @room, phone = @phone, other = @other
                    WHERE idkmitl = @idkmitl;";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(fixgod_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@name", fixgod_name.Text);
                cmd.Parameters.AddWithValue("@nickname", fixgod_nicname.Text);
                cmd.Parameters.AddWithValue("@faculty", fixgod_fa.Text);
                cmd.Parameters.AddWithValue("@park", fixgod_park.Text);
                cmd.Parameters.AddWithValue("@room", fixgod_room.Text);
                cmd.Parameters.AddWithValue("@phone", fixgod_phone.Text);
                cmd.Parameters.AddWithValue("@other", fixgod_other.Text);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void del_god() {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "DELETE FROM member_data WHERE stana = 2";
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void user_pass_god_update() {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO member_data VALUES(@idkmitl, @username, @password, 2)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(fixgod_IdKmitl.Text));
                cmd.Parameters.AddWithValue("@username", fixgod_username.Text);
                cmd.Parameters.AddWithValue("@password", fixgod_password.Password);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private async void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (!fixgod_password.Password.Equals(fixgod_conpassword.Password)) {
                await this.ShowMessageAsync("Unscessful login", "ตรวจสอบ passwordให้ตรงกัน", MessageDialogStyle.Affirmative);
                return;
            }
            save_god();
            del_god();
            user_pass_god_update();
            await this.ShowMessageAsync("Sucessful login", "บันทึกข้อมูลใหม่เรียบร้อย", MessageDialogStyle.Affirmative);
        }

        private void button_show_god_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = @"select b.*
from member_data a
join member b
on (a.idkmitl = b.idkmitl)
where a.stana = 2";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        fixgod_IdKmitl.Text = rdr["idkmitl"].ToString();
                        fixgod_name.Text = rdr["name"].ToString();
                        fixgod_nicname.Text = rdr["nickname"].ToString();
                        fixgod_fa.Text = rdr["faculty"].ToString();
                        fixgod_park.Text = rdr["park"].ToString();
                        fixgod_room.Text = rdr["room"].ToString();
                        fixgod_phone.Text = rdr["phone"].ToString();
                        fixgod_other.Text = rdr["other"].ToString();
                    }
                }
            }

            m_dbConnection.Close();
        }

        private async void dell_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);
            //MessageBox.Show(dell_member.Text+"");
            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON; DELETE FROM member WHERE idkmitl = @idkmitl;";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(dell_member.Text));

                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
            await this.ShowMessageAsync("Sucessful Delete", "ลบข้อมูล" + dell_member.Text + "เรียบร้อย", MessageDialogStyle.Affirmative);
        }
        

        private async void dell2_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON; DELETE FROM member WHERE idkmitl>= @idkmitl_start AND idkmitl<=@idkmitl_stop";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idkmitl_start", Int32.Parse(dell_member_start.Text));
                cmd.Parameters.AddWithValue("@idkmitl_stop", Int32.Parse(dell_member_stop.Text));
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
            await this.ShowMessageAsync("Sucessful Delete", "ลบข้อมูล" + dell_member_start.Text + "-" + dell_member_stop + "เรียบร้อย", MessageDialogStyle.Affirmative);
        }
        
        private void inout_datePicker_loan_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (res.IsChecked == true) { inout_datePicker_return.Text = ""; }
            
            //inout_datePicker_loan.BlackoutDates.Clear();
            //MessageBox.Show(";;;"+ inout_datePicker_loan.SelectedDate.Value.ToString());
            try
            {
                CalendarDateRange cdr2 = new CalendarDateRange(DateTime.MinValue, inout_datePicker_loan.SelectedDate.Value.AddDays(-1));
                inout_datePicker_return.BlackoutDates.Clear();
                inout_datePicker_return.BlackoutDates.Add(cdr2);
            }
            catch {
                CalendarDateRange cdr2 = new CalendarDateRange(DateTime.MinValue, DateTime.Now);
                inout_datePicker_return.BlackoutDates.Clear();
                inout_datePicker_return.BlackoutDates.Add(cdr2);
            }
        }

        private async void res_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("จอง");
            if (isidkmitl(inout_IdKmitl.Text))
            {
                if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                { }
                else {
                    await this.ShowMessageAsync("Unsucessful", "คุณต้องคืนของทั้งหมดก่อน", MessageDialogStyle.Affirmative);
                    loan.IsChecked = true;
                    return;
                }
            }
                    try
            {
                inout_card.Visibility = Visibility.Collapsed;
                inout_tcard.Visibility = Visibility.Collapsed;
                inout_belong_to.IsEnabled = true;
                inout_project.IsEnabled = true;
                inout_card.IsEnabled = true;
                inout_datePicker_loan.IsEnabled = true;
                inout_timePicker_loan.IsEnabled = true;
                inout_datePicker_return.IsEnabled = true;
                inout_timePicker_return.IsEnabled = true;

                inout_datePicker_loan.Text = "";
                inout_timePicker_loan.Text = "";
                indoor.IsEnabled = true;
                outdoor.IsEnabled = true;
                CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Now);
                inout_datePicker_loan.BlackoutDates.Add(cdr);



            }

            catch {
                inout_datePicker_loan.Text = "";
                inout_timePicker_loan.Text = "";
                CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Now);
                inout_datePicker_loan.BlackoutDates.Add(cdr);
                
            }
            
        }

        private void loan_Checked(object sender, RoutedEventArgs e)
        {
            //inout_datePicker_loan.IsEnabled = false;
            //inout_timePicker_loan.IsEnabled = false;
            //inout_datePicker_loan.DisplayDate = DateTime.Now;

            try
            {
                inout_card.Visibility = Visibility.Visible;
                inout_tcard.Visibility = Visibility.Visible;
            }
            catch { }
            if (isidkmitl(inout_IdKmitl.Text))
            {
                if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                {
                    inout_datePicker_return.BlackoutDates.Clear();
                    inout_datePicker_loan.BlackoutDates.Clear();
                    //MessageBox.Show("test");
                    inout_belong_to.Text = "";
                    inout_project.Text = "";
                    inout_datePicker_loan.Text = "";
                    inout_timePicker_loan.Text = "";
                    inout_datePicker_return.Text = "";
                    inout_timePicker_return.Text = "";
                    inout_card.Value = 0;
                    inout_belong_to.IsEnabled = true;
                    inout_project.IsEnabled = true;
                    inout_card.IsEnabled = true;
                    //inout_datePicker_loan.IsEnabled = true;
                    //inout_timePicker_loan.IsEnabled = true;
                    inout_datePicker_return.IsEnabled = true;
                    inout_timePicker_return.IsEnabled = true;
                    CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Now);
                    inout_datePicker_loan.BlackoutDates.Add(cdr);

                    indoor.IsEnabled = true;
                    outdoor.IsEnabled = true;

                }
                else
                {
                    inout_datePicker_loan.BlackoutDates.Clear();
                    inout_datePicker_return.BlackoutDates.Clear();
                    find_project_last(inout_IdKmitl.Text);
                    inout_belong_to.IsEnabled = false;
                    inout_project.IsEnabled = false;
                    inout_card.IsEnabled = false;
                    //inout_datePicker_loan.IsEnabled = false;
                    //inout_timePicker_loan.IsEnabled = false;
                    inout_datePicker_return.IsEnabled = false;
                    inout_timePicker_return.IsEnabled = false;
                    indoor.IsEnabled = false;
                    outdoor.IsEnabled = false;
                }
            }
            else {
                //inout_datePicker_loan.BlackoutDates.Clear();
                //inout_datePicker_return.BlackoutDates.Clear();
                //inout_datePicker_loan.SelectedDate = DateTime.Now;
                indoor.IsEnabled = true;
                outdoor.IsEnabled = true;
            }
        }

       
        private void return_Checked(object sender, RoutedEventArgs e)
        {
            indoor.IsEnabled = false;
            outdoor.IsEnabled = false;
            try
            {
                inout_card.Visibility = Visibility.Visible;
                inout_tcard.Visibility = Visibility.Visible;
            }
            catch { }
            if (isidkmitl(inout_IdKmitl.Text))
            {
                if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                {
                    inout_datePicker_return.BlackoutDates.Clear();
                    inout_datePicker_loan.BlackoutDates.Clear();
                    inout_belong_to.Text = "";
                    inout_project.Text = "";
                    inout_datePicker_loan.Text = "";
                    inout_timePicker_loan.Text = "";
                    inout_datePicker_return.Text = "";
                    inout_timePicker_return.Text = "";
                    inout_card.Value = 0;
                    inout_belong_to.IsEnabled = true;
                    inout_project.IsEnabled = true;
                    inout_card.IsEnabled = true;
                    inout_datePicker_loan.IsEnabled = true;
                    inout_timePicker_loan.IsEnabled = true;
                    inout_datePicker_return.IsEnabled = true;
                    inout_timePicker_return.IsEnabled = true;
                    CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Now);
                    inout_datePicker_loan.BlackoutDates.Add(cdr);

                }
                else
                {
                    inout_datePicker_loan.BlackoutDates.Clear();
                    inout_datePicker_return.BlackoutDates.Clear();
                    find_project_last(inout_IdKmitl.Text);
                    inout_belong_to.IsEnabled = false;
                    inout_project.IsEnabled = false;
                    inout_card.IsEnabled = false;
                    inout_datePicker_loan.IsEnabled = false;
                    inout_timePicker_loan.IsEnabled = false;
                    inout_datePicker_return.IsEnabled = false;
                    inout_timePicker_return.IsEnabled = false;
                }
            }
        }

        private void clear_all_tab() {
            con_admin_user.Text = "";
            addMember_IdKmitl.Text = "";
            addMember_name.Text = "";
            addMember_nicname.Text = "";
            addMember_fa.SelectedIndex = 0;
            addMember_park.Text = "";
            addMember_room.SelectedIndex = 0;
            //addMember_room.Text = "";
            addMember_user_admin.Text = "";
            addMember_pass_admin.Password = "";
            addMember_pass_admin_con.Password = "";
            addMember_other.Text = "";
            inout_IdKmitl.Text = "";
            someStackPanel.Children.Clear();
            inout_card.Value=0;
            controlthing_allthing.Text = "";
        }

        private void test_cha_Click(object sender, RoutedEventArgs e)
        {
            clear_all_tab();
        }


        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!tab_addmember.IsSelected) { 
                clear_all_tab();}
            }
            catch { }
        }

        private void button_del_thing_Click(object sender, RoutedEventArgs e)
        {
            dell_thing_button();

        }
        private void dell_thing_button() {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);
            //MessageBox.Show(dell_member.Text + "");
            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "DELETE FROM thing WHERE id_thing = @id_thing;";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_thing", dell_thing.Text);

                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void show_thing_search_name_god(string s, string name)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"SELECT id_thing AS 'รหัสพัสดุ', name_thing AS 'ชื่อพัสดุ', 
balance_thing || '/' || all_thing AS 'จำนวน(เหลือ/ทั้งหมด)', price AS 'ราคา' , other AS 'หมายเหตุ'
FROM thing
where " + s + " LIKE '%" + name + "%';";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            see_thing_god.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

        private void search_thing_Click_god(object sender, RoutedEventArgs e)
        {
            if (admin_search_god.Text.Equals("ชื่อพัสดุ"))
            {
                show_thing_search_name_god("name_thing", search_thing_text_god.Text);
            }
            else
            {
                show_thing_search_name_god("id_thing", search_thing_text_god.Text);
            }
        }

        private void show_member_search_name_god(string s, string name)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string Query = @"select stana AS 'ประเภท', idkmitl AS 'รหัส นศ', name AS 'ชื่อ', surname AS 'นามสกุล', nickname AS 'ชื่อเล่น', faculty AS 'คณะ', park AS 'ภาค', room AS 'ห้อง', phone AS 'เบอร์โทร'
from (

select replace(replace(replace(IFNULL(m2.stana, 0), 0, 'Member'), 1, 'Admin'), 2, 'God') AS 'stana', m.idkmitl AS 'idkmitl', SUBSTR(m.name, 0, instr(m.name, ' ')) AS 'name', substr(m.name, instr(m.name, ' ')) AS 'surname', m.nickname AS 'nickname', m.faculty AS 'faculty', m.park AS 'park', m.room AS 'room', m.phone AS 'phone'
from member m
left outer join member_data m2
on(m.idkmitl = m2.idkmitl))
where " + s + " LIKE '%" + name + "%'";
            SQLiteCommand createCommand = new SQLiteCommand(Query, m_dbConnection);

            SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
            DataTable dt = new DataTable("test");
            dataAdp.Fill(dt);
            see_member_god.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);


            m_dbConnection.Close();
        }

        private void search_member_Click_god(object sender, RoutedEventArgs e)
        {
            if (admin_search_member_god.Text.Equals("รหัสนักศึกษา"))
            {
                show_member_search_name_god("idkmitl", search_member_text.Text);
            }
            else if (admin_search_member_god.Text.Equals("ชื่อ"))
            {
                show_member_search_name_god("name", search_member_text.Text);
            }
            else if (admin_search_member_god.Text.Equals("นามสกุล"))
            {
                show_member_search_name_god("surname", search_member_text.Text);
            }
            else if (admin_search_member_god.Text.Equals("ชื่อเล่น"))
            {
                show_member_search_name_god("nickname", search_member_text.Text);
            }
            else if (admin_search_member_god.Text.Equals("คณะ"))
            {
                show_member_search_name_god("faculty", search_member_text.Text);
            }
            else if (admin_search_member_god.Text.Equals("ภาควิชา"))
            {
                show_member_search_name_god("park", search_member_text.Text);
            }
            else if (admin_search_member_god.Text.Equals("ห้อง"))
            {
                show_member_search_name_god("room", search_member_text.Text);
            }
            else
            {
                show_member_search_name_god("phone", search_member_text.Text);
            }



        }
        private void Button_Click_windows2(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            //this.Close();
        }

        private async void con_admin_user_pass_Click(object sender, RoutedEventArgs e)
        {
            if (isadmin(con_admin_user.Text, con_admin_pass_old.Password))
            {
                if (con_admin_pass_new.Password.Equals(con_admin_pass_new_con.Password))
                {
                    update_pass_admin();
                    await this.ShowMessageAsync("Sucessful", "บันทึกรหัสผ่านใหม่เรียบร้อย", MessageDialogStyle.Affirmative);
                }
                else {
                    await this.ShowMessageAsync("Unsucessful", "ขออภัยคุณกรอก password ใหม่ไม่ตรงกัน", MessageDialogStyle.Affirmative);
                }
            }
            else {
                await this.ShowMessageAsync("Unsucessful", "ขออภัยคุณกรอก username หรือ password ผิด", MessageDialogStyle.Affirmative);
            }
        }

        private void update_pass_admin() {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "UPDATE member_data SET password = @password WHERE username = @username";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@password", con_admin_pass_new.Password);
                cmd.Parameters.AddWithValue("@username", con_admin_user.Text);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private void con_admin_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            con_admin_idkmitl.Text = "";
            con_admin_pass_old.Password = "";
            con_admin_pass_new.Password = "";
            con_admin_pass_new_con.Password = "";
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT idkmitl FROM member_data where username = '"+con_admin_user.Text+"' and stana = 1;";

            //SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        con_admin_idkmitl.Text = rdr["idkmitl"].ToString();
                    }
                }
            }

            m_dbConnection.Close();
        }

        private async void add_admin_button_Click(object sender, RoutedEventArgs e)
        {
            if (isidkmitl(god_add_admin_idkmitl.Text))
            {

            }
            else {
                await this.ShowMessageAsync("Unsucessful", "กรุณาสมัครสมาชิกก่อน", MessageDialogStyle.Affirmative);
                return;
            }

            if (isadmin2(god_add_admin_idkmitl.Text)) {
                await this.ShowMessageAsync("Unsucessful", "รหัสนักศึกษานี้เป็น admin, god อยู่แล้ว", MessageDialogStyle.Affirmative);
                return;
            }

            if (isUsernameUnix(god_add_admin_username.Text))
            {
                if (con_admin_pass_new.Password.Equals(con_admin_pass_new_con.Password))
                {
                    add_admin_god();
                    await this.ShowMessageAsync("Sucessful", "บันทึกข้อมูลเรียบร้อย", MessageDialogStyle.Affirmative);
                }
                else
                {
                    await this.ShowMessageAsync("Unsucessful", "ขออภัยคุณกรอก password ใหม่ไม่ตรงกัน", MessageDialogStyle.Affirmative);
                }
            }
            else
            {
                await this.ShowMessageAsync("Unsucessful", "ขออภัยมีคนใช้ username นี้แล้ว", MessageDialogStyle.Affirmative);
            }
        }

        private bool isadmin2(string idkmitl) {
            bool ad = false;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string stm = "SELECT idkmitl FROM member_data ;";

            //SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;

            using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (rdr["idkmitl"].ToString().Equals(idkmitl)) {
                            ad = true;
                        }
                    }
                }
            }

            m_dbConnection.Close();
            return ad;
        }
        private void add_admin_god()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "INSERT INTO member_data (idkmitl, username, password, stana) VALUES(@idkmitl, @username, @password, @stana)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(god_add_admin_idkmitl.Text));
                cmd.Parameters.AddWithValue("@username", god_add_admin_username.Text);
                cmd.Parameters.AddWithValue("@password", god_add_admin_password.Password);
                cmd.Parameters.AddWithValue("@stana", 1);
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();
        }

        private async void dell_admin_button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO member (idkmitl, name, nickname, faculty, park, room, phone, other) VALUES (?,?,?,?,?,?,?,?);", m_dbConnection);

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = "DELETE FROM member_data WHERE idkmitl = @idkmitl";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idkmitl", Int32.Parse(god_dell_admin.Text));
                cmd.ExecuteNonQuery();
            }

            m_dbConnection.Close();

            await this.ShowMessageAsync("Sucessful", "ลบข้อมูลเรียบร้อย", MessageDialogStyle.Affirmative);
        }

        private void god_add_admin_idkmitl_TextChanged(object sender, TextChangedEventArgs e)
        {
            god_add_admin_idkmitl.Foreground = new SolidColorBrush(Colors.Black);
            if (isidkmitl(god_add_admin_idkmitl.Text)) {
                god_add_admin_idkmitl.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
    }
}

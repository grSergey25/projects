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
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml;

namespace GetExchangeRate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string[]> _dictVal = new Dictionary<string, string[]>();
        private DB _dataBase = null;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
               _dataBase = new DB(serv: "MYSQLSERVER\\MYSQLSERVER", log: "sa", psw: "Gfhjkm123", db: "TESTDB");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\nПриложение будет закрыто!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void saveSettings()
        {
            Properties.Settings.Default.Сurrency_1 = ((Label)ComboBox_Сurrency_1.SelectedItem).Content.ToString();
            Properties.Settings.Default.Сurrency_2 = ((Label)ComboBox_Сurrency_2.SelectedItem).Content.ToString();

            Properties.Settings.Default.Save();
        }
        private void loadSettings()
        {
            if(Properties.Settings.Default.Сurrency_1 != "")
                foreach (Label it in ComboBox_Сurrency_1.Items)
                    if (it.Content.ToString() == Properties.Settings.Default.Сurrency_1)
                    {
                        ComboBox_Сurrency_1.SelectedItem = it;
                        break;
                    }
            if (Properties.Settings.Default.Сurrency_2 != "")
                foreach (Label it in ComboBox_Сurrency_2.Items)
                    if (it.Content.ToString() == Properties.Settings.Default.Сurrency_2)
                    {
                        ComboBox_Сurrency_2.SelectedItem = it;
                        break;
                    }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://www.cbr-xml-daily.ru/daily_utf8.xml";

                XmlDocument documentXML = new XmlDocument();
                documentXML.LoadXml(myClasses.getBodyHTML(url));
                XmlElement root = documentXML.DocumentElement;

                ComboBox_Сurrency_1.Items.Add(new Label { Content = "RUB", ToolTip = "Российский рубль" });
                ComboBox_Сurrency_2.Items.Add(new Label { Content = "RUB", ToolTip = "Российский рубль" });

                _dictVal.Add("RUB", new string[] { "Российский рубль", "1" });

                foreach (XmlNode val in root.ChildNodes)
                {
                    string charVal = val.ChildNodes[1].InnerText;
                    string nameVal = val.ChildNodes[3].InnerText;
                    string value = val.ChildNodes[4].InnerText;

                    _dictVal.Add(charVal, new string[] { nameVal, value });

                    ComboBox_Сurrency_1.Items.Add(new Label { Content = charVal, ToolTip = nameVal });
                    ComboBox_Сurrency_2.Items.Add(new Label { Content = charVal, ToolTip = nameVal });
                }

                loadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\nПриложение будет закрыто!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void ComboBox_Сurrency_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ComboBox)sender).ToolTip = _dictVal[((Label)((ComboBox)sender).SelectedItem).Content.ToString()][0];
        }

        private void ComboBox_Сurrency_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ComboBox)sender).ToolTip = _dictVal[((Label)((ComboBox)sender).SelectedItem).Content.ToString()][0];
        }

        private void Button_GetExchangeRate_Click(object sender, RoutedEventArgs e)
        {
            string nameVal1 = ((Label)ComboBox_Сurrency_1.SelectedItem).Content.ToString();
            double valueVal1 = Convert.ToDouble(_dictVal[nameVal1][1]);

            string nameVal2 = ((Label)ComboBox_Сurrency_2.SelectedItem).Content.ToString();
            double valueVal2 = valueVal1/Convert.ToDouble(_dictVal[nameVal2][1]);

            string query = $"INSERT INTO [dbo].[history] ([dt], [currencyPair], [value]) VALUES(N'{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace(" ", "T")}', N'{nameVal1}/{nameVal2}', N'{valueVal2.ToString().Replace(",", ".")}')";
            int countRow = _dataBase.execQuery(query);
            if(countRow > 0)
                MessageBox.Show($"Согласно ЦБ РФ на {DateTime.Now}:\n\n1 {nameVal1} = {valueVal2} {nameVal2}", "Информация", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveSettings();
        }
    }
}

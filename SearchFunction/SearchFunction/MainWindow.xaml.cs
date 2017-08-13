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
using System.IO;
namespace SearchFunction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
        static string pth = @"C:\Users\User\AppData\Local\Searches\";

        public MainWindow()
        {
            InitializeComponent();
            btnSrch.IsEnabled = false;
            lstBxAutoCmplt.Visibility = Visibility.Collapsed;
            //lstBxAutoCmplt.ItemsSource = new List<string>() { "gg   K", "gh" };
        }

        private void txtBxSrch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtBxSrch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtBxSrch_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtBxSrch.Text == "Type your search here...")
            {
                txtBxSrch.Text = "";
            }
        }

        private void txtBxSrch_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtBxSrch.Text == "Type your search here...")
            {
                txtBxSrch.Text = "";
            }
        }

        private void txtBxSrch_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txtBxSrch.Text == "")
            {
                txtBxSrch.Text = "Type your search here...";
            }
        }

        private void btnSrch_Click(object sender, RoutedEventArgs e)
        {
            if (txtBxSrch.Text != "Type your search here...")
            {
                Directory.CreateDirectory(pth);
                using (StreamWriter swr = File.AppendText(pth + "hstryQry.stext"))
                {
                    swr.WriteLine(txtBxSrch.Text);
                }
            }
        }

        private void txtBxSrch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] qryLst = File.ReadAllLines(pth + "hstryQry.txt");
            string qryTxt = txtBxSrch.Text;
            List<string> autoLst = new List<string>();
            autoLst.Clear();
            foreach (var qry in qryLst)
            {
                if (!string.IsNullOrEmpty(txtBxSrch.Text) && txtBxSrch.Text != "Type your search here...")
                {
                    if (qry.ToLower().StartsWith(qryTxt.ToLower()))
                    {
                        autoLst.Add(qry);
                    }
                }

            }
            if (autoLst.Count > 0)
            {
                lstBxAutoCmplt.ItemsSource = autoLst;
                lstBxAutoCmplt.Visibility = Visibility.Visible;
            }
            else if (txtBxSrch.Text.Equals(""))
            {
                lstBxAutoCmplt.Visibility = Visibility.Collapsed;
                lstBxAutoCmplt.ItemsSource = null;
            }
        }
    }
}

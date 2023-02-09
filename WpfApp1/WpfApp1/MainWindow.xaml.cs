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
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _ofd = new OpenFileDialog();
            _ofd.Title = "Kérem válassza ki a betöltendő fájlt!";
            if (_ofd.ShowDialog() == false)
            {
                return;
            }
            StreamReader fajlOlvaso = new StreamReader(_ofd.FileName);
            String? olvasottSor;
            while (!fajlOlvaso.EndOfStream)
            {
                olvasottSor = fajlOlvaso.ReadLine();
                if (olvasottSor!="")
                {
                    lbForras.Items.Add(olvasottSor);
                }
            }
            fajlOlvaso.Close();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog _sfd = new SaveFileDialog();
            if (_sfd.ShowDialog()==true)
            {
                StreamWriter fajlIro = new StreamWriter(_sfd.FileName);
                foreach (Object aktObjektum in lbModositott.Items)
                {
                    fajlIro.WriteLine(aktObjektum.ToString());
                }
                fajlIro.Close();
            }
        }

        private void btnValogat_Click(object sender, RoutedEventArgs e)
        {
            lbModositott.Items.Clear();
            foreach(Object aktObjektum in lbForras.Items)
            {
                if (chkNincsKulonbseg.IsChecked==true)
                {
                    if (aktObjektum.ToString().ToLower().Contains(txtSz))
                    {

                    }
                }
            }
        }
    }
}

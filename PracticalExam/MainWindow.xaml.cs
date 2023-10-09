using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PracticalExam
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

        private void ChooseButton(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog ofd = new CommonOpenFileDialog() { IsFolderPicker = true };
            
            ofd.ShowDialog();
            
            resultFileName.Text = ofd.FileName;
            
            resultFilePath.Text = System.IO.Path.GetFullPath(ofd.FileName);
        }

        private async void SearchButton(object sender, RoutedEventArgs e)
        {
            await SearchMethod(resultFileName.Text);
        }

        public Task SearchMethod(string alpha)
        {
            string str = "";
            return Task.Run(() =>
            {
                List<string> files = Directory.GetFiles(alpha, "*.txt", SearchOption.AllDirectories).ToList();

                foreach (string file in files)
                {
                    str += File.ReadAllText(file) + " ";
                }

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBox.Show(Convert.ToString(str.Split(searchWord.Text).Count()-1));
                }));
            });
        }

    }
}
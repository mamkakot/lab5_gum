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

namespace gum_lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var n = new Note();
            var notes = new List<Note>
            {
                n,
                new(),
                new(),
            };
            NotebookGrid.ItemsSource = notes;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var n = new Note { Name = "Sas" };
            var t = NotebookGrid.ItemsSource;
            Console.WriteLine(n.Name);
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
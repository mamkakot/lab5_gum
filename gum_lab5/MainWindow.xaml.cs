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
        private List<Note> _notes = new()
        {
            new MegaNote(),
            new Note(),
            new Note() {Year = 1995},
            new MegaNote() {Year = 2000},
            new Note() {Year = 1998},
        };

        public MainWindow()
        {
            InitializeComponent();

            NotebookGrid.ItemsSource = _notes;
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var phoneNumber = PhoneTextBox.Text;
            var yearParsed = int.TryParse(YearTextBox.Text, out var year);

            var filtered = _notes;

            if (name != "")
            {
                filtered = filtered.Where(note => note.Name == name).ToList();
            }

            if (phoneNumber != "")
            {
                filtered = filtered.Where(note => note.PhoneNumber == phoneNumber).ToList();
            }

            if (yearParsed)
            {
                filtered = filtered.Where(note => note.Year == year).ToList();
            }

            NotebookGrid.ItemsSource = filtered;
        }

        private void ShowNoteDialog(object sender, MouseButtonEventArgs e)
        {
            if (NotebookGrid.SelectedItem is not MegaNote megaNote)
            {
                var note = (Note)NotebookGrid.SelectedItem;
                MessageBox.Show(note.GetNote());
                return;
            }

            MessageBox.Show(megaNote.GetNote());
        }

        private void Compare_OnClick(object sender, RoutedEventArgs e)
        {
            var items = NotebookGrid.SelectedItems.Cast<Note>();
            var notes = items as Note[] ?? items.ToArray();
            for (int i = 0; i < notes.Length - 1; i++)
            {
                if (notes[i] != notes[i + 1])
                {
                    MessageBox.Show("Selected notes are not the same!");
                    return;
                }

                MessageBox.Show("Selected notes are the same!");
            }
        }

        private void Plus_OnClick(object sender, RoutedEventArgs e)
        {
            if (NotebookGrid.SelectedItem is not MegaNote megaNote)
            {
                var note = (Note)NotebookGrid.SelectedItem;
                _notes.Add(++note);
                return;
            }
            
            _notes.Add(++megaNote);
            
            NotebookGrid.Items.Refresh();
        }

        private void FindBigger_OnClick(object sender, RoutedEventArgs e)
        {
            var items = NotebookGrid.SelectedItems.Cast<Note>();
            var notes = items as Note[] ?? items.ToArray();
            var biggestNote = notes[0];
            for (int i = 0; i < notes.Length - 1; i++)
            {
                if (notes[i] > biggestNote)
                {
                    biggestNote = notes[i];
                }

                MessageBox.Show(
                    $"Biggest note is about: {biggestNote.Name}, " +
                    $"who was born at {biggestNote.Year} " +
                    $"and has this phone number: {biggestNote.PhoneNumber}");
            }
        }
    }
}
using System.Windows;
using ModelLibrary.Models;

namespace MarokkaanseReceptenApp.Windows
{
    public partial class CategorieEditWindow : Window
    {
        public Categorie Result { get; private set; }

        public CategorieEditWindow(Categorie? existing = null)
        {
            InitializeComponent();

            Result = existing == null
                ? new Categorie()
                : new Categorie { Id = existing.Id, Naam = existing.Naam, IsDeleted = existing.IsDeleted };

            DataContext = Result;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Naam))
            {
                MessageBox.Show("Naam is verplicht.");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

using System.Collections.Generic;
using System.Windows;
using ModelLibrary.Models;

namespace MarokkaanseReceptenApp.Windows
{
    public partial class ReceptEditWindow : Window
    {
        public class ReceptEditVm : Recept
        {
            public List<Categorie> Categorieen { get; set; } = new();
        }

        public Recept Result { get; private set; }

        public ReceptEditWindow(List<Categorie> categorieen, Recept? existing = null)
        {
            InitializeComponent();

            var vm = new ReceptEditVm
            {
                Categorieen = categorieen
            };

            if (existing != null)
            {
                vm.Id = existing.Id;
                vm.Naam = existing.Naam;
                vm.CategorieId = existing.CategorieId;
                vm.Bereiding = existing.Bereiding;
                vm.FotoPad = existing.FotoPad;
                vm.Herkomst = existing.Herkomst;
                vm.IsDeleted = existing.IsDeleted;
            }

            DataContext = vm;
            Result = vm;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Naam))
            {
                MessageBox.Show("Naam is verplicht.");
                return;
            }

            if (Result.CategorieId <= 0)
            {
                MessageBox.Show("Kies een categorie.");
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

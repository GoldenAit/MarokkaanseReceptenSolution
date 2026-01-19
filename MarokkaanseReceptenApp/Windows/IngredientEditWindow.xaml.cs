using System.Collections.Generic;
using System.Windows;
using ModelLibrary.Models;

namespace MarokkaanseReceptenApp.Windows
{
    public partial class IngredientEditWindow : Window
    {
        public class IngredientEditVm : Ingredient
        {
            public List<Recept> Recepten { get; set; } = new();
        }

        public Ingredient Result { get; private set; }

        public IngredientEditWindow(List<Recept> recepten, Ingredient? existing = null)
        {
            InitializeComponent();

            var vm = new IngredientEditVm
            {
                Recepten = recepten
            };

            if (existing != null)
            {
                vm.Id = existing.Id;
                vm.Naam = existing.Naam;
                vm.Hoeveelheid = existing.Hoeveelheid;
                vm.ReceptId = existing.ReceptId;
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

            if (Result.ReceptId <= 0)
            {
                MessageBox.Show("Kies een recept.");
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

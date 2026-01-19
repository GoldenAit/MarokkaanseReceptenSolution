using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary;
using ModelLibrary.Identity;
using ModelLibrary.Models;
using MarokkaanseReceptenApp.Windows;

namespace MarokkaanseReceptenApp
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUser _currentUser;

        public MainWindow(AppUser user)
        {
            InitializeComponent();

            _context = App.Services.GetRequiredService<AppDbContext>();
            _userManager = App.Services.GetRequiredService<UserManager<AppUser>>();
            _currentUser = user;

            UserText.Text = $"Ingelogd: {_currentUser.Email}";

            LoadData();
            ApplyRoleUi();
        }

        private async void ApplyRoleUi()
        {
            var isAdmin = await _userManager.IsInRoleAsync(_currentUser, "Admin");
            AdminTab.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void LoadData()
        {
            ReceptenDataGrid.ItemsSource = _context.Recepten
                .Include(r => r.Categorie)
                .OrderBy(r => r.Naam)
                .ToList();

            CategorieenDataGrid.ItemsSource = _context.Categorieen
                .OrderBy(c => c.Naam)
                .ToList();

            IngredientenDataGrid.ItemsSource = _context.Ingredienten
                .Include(i => i.Recept)
                .OrderBy(i => i.Naam)
                .ToList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            Close();
        }

        // =====================================================
        // CRUD CATEGORIE
        // =====================================================
        private void AddCategorie_Click(object sender, RoutedEventArgs e)
        {
            var win = new CategorieEditWindow();
            win.Owner = this;

            if (win.ShowDialog() == true)
            {
                try
                {
                    _context.Categorieen.Add(win.Result);
                    _context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Fout bij opslaan categorie.");
                }
            }
        }

        private void EditCategorie_Click(object sender, RoutedEventArgs e)
        {
            if (CategorieenDataGrid.SelectedItem is not Categorie selected)
            {
                MessageBox.Show("Selecteer een categorie.");
                return;
            }

            var win = new CategorieEditWindow(selected);
            win.Owner = this;

            if (win.ShowDialog() == true)
            {
                try
                {
                    var db = _context.Categorieen.First(c => c.Id == selected.Id);
                    db.Naam = win.Result.Naam;
                    _context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Fout bij wijzigen categorie.");
                }
            }
        }

        private void DeleteCategorie_Click(object sender, RoutedEventArgs e)
        {
            if (CategorieenDataGrid.SelectedItem is not Categorie selected)
            {
                MessageBox.Show("Selecteer een categorie.");
                return;
            }

            if (MessageBox.Show("Categorie verwijderen (soft delete)?",
                "Bevestiging", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            try
            {
                var db = _context.Categorieen.First(c => c.Id == selected.Id);
                db.IsDeleted = true;
                _context.SaveChanges();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Fout bij verwijderen categorie.");
            }
        }

        // =====================================================
        // CRUD RECEPT
        // =====================================================
        private void AddRecept_Click(object sender, RoutedEventArgs e)
        {
            var categorieen = _context.Categorieen.OrderBy(c => c.Naam).ToList();
            var win = new ReceptEditWindow(categorieen);
            win.Owner = this;

            if (win.ShowDialog() == true)
            {
                try
                {
                    _context.Recepten.Add(win.Result);
                    _context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Fout bij opslaan recept.");
                }
            }
        }

        private void EditRecept_Click(object sender, RoutedEventArgs e)
        {
            if (ReceptenDataGrid.SelectedItem is not Recept selected)
            {
                MessageBox.Show("Selecteer een recept.");
                return;
            }

            var categorieen = _context.Categorieen.OrderBy(c => c.Naam).ToList();
            var win = new ReceptEditWindow(categorieen, selected);
            win.Owner = this;

            if (win.ShowDialog() == true)
            {
                try
                {
                    var db = _context.Recepten.First(r => r.Id == selected.Id);
                    db.Naam = win.Result.Naam;
                    db.CategorieId = win.Result.CategorieId;
                    db.Bereiding = win.Result.Bereiding;
                    db.FotoPad = win.Result.FotoPad;
                    db.Herkomst = win.Result.Herkomst;

                    _context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Fout bij wijzigen recept.");
                }
            }
        }

        private void DeleteRecept_Click(object sender, RoutedEventArgs e)
        {
            if (ReceptenDataGrid.SelectedItem is not Recept selected)
            {
                MessageBox.Show("Selecteer een recept.");
                return;
            }

            if (MessageBox.Show("Recept verwijderen (soft delete)?",
                "Bevestiging", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            try
            {
                var db = _context.Recepten.First(r => r.Id == selected.Id);
                db.IsDeleted = true;
                _context.SaveChanges();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Fout bij verwijderen recept.");
            }
        }

        // =====================================================
        // CRUD INGREDIENT
        // =====================================================
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var recepten = _context.Recepten.OrderBy(r => r.Naam).ToList();
            var win = new IngredientEditWindow(recepten);
            win.Owner = this;

            if (win.ShowDialog() == true)
            {
                try
                {
                    _context.Ingredienten.Add(win.Result);
                    _context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Fout bij opslaan ingrediënt.");
                }
            }
        }

        private void EditIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientenDataGrid.SelectedItem is not Ingredient selected)
            {
                MessageBox.Show("Selecteer een ingrediënt.");
                return;
            }

            var recepten = _context.Recepten.OrderBy(r => r.Naam).ToList();
            var win = new IngredientEditWindow(recepten, selected);
            win.Owner = this;

            if (win.ShowDialog() == true)
            {
                try
                {
                    var db = _context.Ingredienten.First(i => i.Id == selected.Id);
                    db.Naam = win.Result.Naam;
                    db.Hoeveelheid = win.Result.Hoeveelheid;
                    db.ReceptId = win.Result.ReceptId;

                    _context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Fout bij wijzigen ingrediënt.");
                }
            }
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientenDataGrid.SelectedItem is not Ingredient selected)
            {
                MessageBox.Show("Selecteer een ingrediënt.");
                return;
            }

            if (MessageBox.Show("Ingrediënt verwijderen (soft delete)?",
                "Bevestiging", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            try
            {
                var db = _context.Ingredienten.First(i => i.Id == selected.Id);
                db.IsDeleted = true;
                _context.SaveChanges();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Fout bij verwijderen ingrediënt.");
            }
        }
    }
}

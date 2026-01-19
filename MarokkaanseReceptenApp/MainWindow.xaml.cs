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

        // -----------------------
        // ROL UI
        // -----------------------
        private async void ApplyRoleUi()
        {
            var isAdmin = await _userManager.IsInRoleAsync(_currentUser, "Admin");
            AdminTab.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        // -----------------------
        // DATA LADEN
        // -----------------------
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
                catch (Exception)
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
                catch (Exception)
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

            if (MessageBox.Show(
                "Categorie verwijderen (soft delete)?",
                "Bevestiging",
                MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            try
            {
                var db = _context.Categorieen.First(c => c.Id == selected.Id);
                db.IsDeleted = true; // soft delete
                _context.SaveChanges();
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Fout bij verwijderen categorie.");
            }
        }
    }
}

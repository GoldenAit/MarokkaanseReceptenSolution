using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary;
using ModelLibrary.Identity;
using ModelLibrary.Models;
using MarokkaanseReceptenApp.Models;
using MarokkaanseReceptenApp.Windows;

namespace MarokkaanseReceptenApp
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppUser _currentUser;

        public MainWindow(AppUser user)
        {
            InitializeComponent();

            _context = App.Services.GetRequiredService<AppDbContext>();
            _userManager = App.Services.GetRequiredService<UserManager<AppUser>>();
            _roleManager = App.Services.GetRequiredService<RoleManager<IdentityRole>>();
            _currentUser = user;

            UserText.Text = $"Ingelogd: {_currentUser.Email}";

            LoadData();
            ApplyRoleUiAsync();
        }

        private async void ApplyRoleUiAsync()
        {
            var isAdmin = await _userManager.IsInRoleAsync(_currentUser, "Admin");
            AdminTab.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;

            if (isAdmin)
                await LoadUsersAsync();
        }

        // =======================
        // DATA LADEN
        // =======================
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

        // =======================
        // ADMIN
        // =======================
        private async Task LoadUsersAsync()
        {
            var users = _userManager.Users.OrderBy(u => u.Email).ToList();
            var rows = new System.Collections.Generic.List<UserRow>();

            foreach (var u in users)
            {
                var isAdmin = await _userManager.IsInRoleAsync(u, "Admin");
                rows.Add(new UserRow
                {
                    Id = u.Id,
                    Email = u.Email ?? "",
                    VolledigeNaam = u.VolledigeNaam,
                    IsBlocked = u.IsBlocked,
                    Role = isAdmin ? "Admin" : "User"
                });
            }

            UsersDataGrid.ItemsSource = rows;
        }

        private async void RefreshUsers_Click(object sender, RoutedEventArgs e)
        {
            await LoadUsersAsync();
        }

        private async void ToggleBlock_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is not UserRow selected)
            {
                MessageBox.Show("Selecteer een user.");
                return;
            }

            if (selected.Id == _currentUser.Id)
            {
                MessageBox.Show("Je kan jezelf niet blokkeren.");
                return;
            }

            var user = await _userManager.FindByIdAsync(selected.Id);
            if (user == null) return;

            user.IsBlocked = !user.IsBlocked;
            await _userManager.UpdateAsync(user);
            await LoadUsersAsync();
        }

        private async void ToggleRole_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is not UserRow selected)
            {
                MessageBox.Show("Selecteer een user.");
                return;
            }

            if (selected.Id == _currentUser.Id)
            {
                MessageBox.Show("Je kan je eigen rol niet wijzigen.");
                return;
            }

            var user = await _userManager.FindByIdAsync(selected.Id);
            if (user == null) return;

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin)
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            await LoadUsersAsync();
        }
    }
}

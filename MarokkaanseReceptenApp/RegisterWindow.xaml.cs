using System.Linq;
using System.Windows;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary.Identity;

namespace MarokkaanseReceptenApp
{
    public partial class RegisterWindow : Window
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterWindow()
        {
            InitializeComponent();
            _userManager = App.Services.GetRequiredService<UserManager<AppUser>>();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            Close();
        }

        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = EmailTextBox.Text.Trim();

                var user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    VolledigeNaam = NameTextBox.Text.Trim(),
                    FavoriteCuisine = "Marokkaans"
                };

                var result = await _userManager.CreateAsync(user, PasswordBox.Password);
                if (!result.Succeeded)
                {
                    MessageBox.Show(string.Join("\n", result.Errors.Select(x => x.Description)));
                    return;
                }

                await _userManager.AddToRoleAsync(user, "User");

                MessageBox.Show("Account aangemaakt. Je kan nu inloggen.");
                var login = new LoginWindow();
                login.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Er ging iets fout bij registratie.");
            }
        }
    }
}

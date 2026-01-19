using System.Windows;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary.Identity;

namespace MarokkaanseReceptenApp
{
    public partial class LoginWindow : Window
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginWindow()
        {
            InitializeComponent();
            _userManager = App.Services.GetRequiredService<UserManager<AppUser>>();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var reg = new RegisterWindow();
            reg.Show();
            Close();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = EmailTextBox.Text.Trim();
                var password = PasswordBox.Password;

                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    MessageBox.Show("Gebruiker niet gevonden.");
                    return;
                }

                if (user.IsBlocked)
                {
                    MessageBox.Show("Deze gebruiker is geblokkeerd.");
                    return;
                }

                var ok = await _userManager.CheckPasswordAsync(user, password);
                if (!ok)
                {
                    MessageBox.Show("Fout wachtwoord.");
                    return;
                }

                var main = new MainWindow(user);
                main.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Er ging iets fout bij het inloggen.");
            }
        }
    }
}

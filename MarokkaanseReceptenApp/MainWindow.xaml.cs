using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModelLibrary.Data;


namespace MarokkaanseReceptenApp
{
    public partial class MainWindow : Window
    {
        private AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();

            // DbContextOptions aanmaken (verbinding met database)
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MarokkaanseReceptenDb;Trusted_Connection=True;");

            _context = new AppDbContext(optionsBuilder.Options);

            // Laad data bij opstarten
            LoadData();
        }

        private void LoadData()
        {
            // Data laden inclusief Categorie
            ReceptenDataGrid.ItemsSource = _context.Recepten
                .Include(r => r.Categorie)
                .ToList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
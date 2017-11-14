using System.Windows;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Manage_Teams(object sender, RoutedEventArgs e)
        {
            var form = new ManageTeams { Owner = this };
            form.Show();
            Hide();
        }

        private void Click_Manage_Brackets(object sender, RoutedEventArgs e)
        {
            var form = new ManageBracket { Owner = this };
            form.Show();
            Hide();
        }
    }
}

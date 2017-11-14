using System.Windows;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for ManageTeams.xaml
    /// </summary>
    public partial class ManageTeams : Window
    {
        public ManageTeams()
        {
            InitializeComponent();
        }

        private void Click_Add_Team(object sender, RoutedEventArgs e)
        {
            var form = new TeamForm();
            form.Show();
            form.Owner = this;
            Hide();
        }

        private void Click_Edit_Team(object sender, RoutedEventArgs e)
        {
            var form = new TeamForm();
            form.Show();
            form.Owner = this;
            Hide();
        }
    }
}

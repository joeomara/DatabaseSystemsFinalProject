using System.ComponentModel;
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
            var form = new TeamForm { Owner = this };
            form.Owner = this;
            Hide();
        }

        private void Click_Edit_Team(object sender, RoutedEventArgs e)
        {
            var form = new TeamForm { Owner = this };
            form.Owner = this;
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }
    }
}

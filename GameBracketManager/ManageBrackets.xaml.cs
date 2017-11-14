using System.ComponentModel;
using System.Windows;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for ManageBracket.xaml
    /// </summary>
    public partial class ManageBracket : Window
    {
        public ManageBracket()
        {
            InitializeComponent();
        }

        private void Click_Edit_Bracket(object sender, RoutedEventArgs e)
        {
            var form = new BracketForm { Owner = this };
            form.Show();
            Hide();
        }

        private void Click_Add_Bracket(object sender, RoutedEventArgs e)
        {
            var form = new BracketForm { Owner = this };
            form.Show();
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }
    }
}

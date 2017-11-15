using System;
using System.ComponentModel;
using System.Windows;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for TeamForm.xaml
    /// </summary>
    public partial class TeamForm : Window
    {
        public TeamForm()
        {
            InitializeComponent();
        }

        private void Click_Add_Player(object sender, RoutedEventArgs e)
        {
            var form = new PlayerForm { Owner = this };
            form.Owner = this;
            Hide();
            form.Show();
        }

        private void Click_Edit_Player(object sender, RoutedEventArgs e)
        {
            var form = new PlayerForm { Owner = this };
            form.Owner = this;
            Hide();
            form.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }
    }
}

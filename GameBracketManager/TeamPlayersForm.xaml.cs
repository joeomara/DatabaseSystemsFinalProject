using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using GameBracketManager.Infrastructure;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for TeamPlayersForm.xaml
    /// </summary>
    public partial class TeamPlayersForm : Window
    {
        private IEnumerable<Player> mPlayers;

        public TeamPlayersForm(IEnumerable<Player> players)
        {
            InitializeComponent();

            mPlayers = players ?? new List<Player>();

            dgPlayers.ItemsSource = mPlayers
                .Select(o => new LimitedPlayer { FirstName = o.FirstName, DisplayName = o.DisplayName, LastName = o.LastName }).ToList();
        }

        private void Click_Add_Player(object sender, RoutedEventArgs args)
        {
            var form = new PlayerForm { Owner = this };
            form.Show();
            Hide();
        }

        private void Click_Remove_Player(object sender, RoutedEventArgs args)
        {
            var selectedItem = dgPlayers.SelectedValue as LimitedPlayer;
            Player result = null;

            if (selectedItem != null)
            {
                result = mPlayers
                    .FirstOrDefault(o => o.FirstName == selectedItem.FirstName && o.DisplayName == selectedItem.DisplayName && o.LastName == selectedItem.LastName);
            }

            if (result == null)
            {
                MessageBox.Show("You must select the team to delete.");
                return;
            }

            using (var context = new CS487Entities())
            {
                context.Players.Remove(result);

                context.SaveChanges();
            }
        }

        private void Click_Edit_Player(object sender, RoutedEventArgs args)
        {
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }
    }

    internal class LimitedPlayer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}

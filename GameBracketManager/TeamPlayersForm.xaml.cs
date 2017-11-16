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

            dgPlayers.ItemsSource = mPlayers.Select(o => new LimitedPlayer { FirstName = o.FirstName, DisplayName = o.DisplayName, LastName = o.LastName });
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

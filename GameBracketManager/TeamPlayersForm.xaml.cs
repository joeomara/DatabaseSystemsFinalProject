using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using GameBracketManager.Infrastructure;

namespace GameBracketManager
{
    /// <summary>
    ///     Interaction logic for TeamPlayersForm.xaml
    /// </summary>
    public partial class TeamPlayersForm : Window
    {
        private readonly IEnumerable<Player> mPlayers;
        private readonly Team mTeam;

        public TeamPlayersForm(Team team, IEnumerable<Player> players)
        {
            InitializeComponent();

            mTeam = team;

            mPlayers = players ?? new List<Player>();

            dgPlayers.ItemsSource = mPlayers
                .Select(o => new LimitedPlayer
                {
                    FirstName = o.FirstName,
                    DisplayName = o.DisplayName,
                    LastName = o.LastName
                }).ToList();
        }

        private void Click_Add_Player(object sender, RoutedEventArgs args)
        {
            var form = new PlayerForm(mTeam) {Owner = this};
            form.Show();
            Hide();
        }

        private void Click_Remove_Player(object sender, RoutedEventArgs args)
        {
            var selectedItem = dgPlayers.SelectedValue as LimitedPlayer;

            if (selectedItem != null)
                using (var context = new CS487Entities())
                {
                    var teamResult = context.Teams.Where(o => o.Id == mTeam.Id).Include(o => o.Players)
                        .FirstOrDefault();
                    var playerResult =
                        context.Players.FirstOrDefault(o => o.FirstName == selectedItem.FirstName &&
                                                            o.LastName == selectedItem.LastName &&
                                                            o.DisplayName == selectedItem.DisplayName);

                    if (playerResult == null) return;

                    var toRemove = teamResult.Players.FirstOrDefault(o => o.Id == playerResult.Id);
                    teamResult.Players.Remove(toRemove);

                    context.Entry(teamResult).State = EntityState.Modified;

                    context.SaveChanges();
                }
        }

        private void Click_Edit_Player(object sender, RoutedEventArgs args)
        {
            var selectedItem = dgPlayers.SelectedValue as LimitedPlayer;
            Player result = null;

            if (selectedItem != null)
                result = mPlayers
                    .FirstOrDefault(o => o.FirstName == selectedItem.FirstName &&
                                         o.DisplayName == selectedItem.DisplayName &&
                                         o.LastName == selectedItem.LastName);

            if (result == null)
            {
                MessageBox.Show("You must select the team to edit.");
                return;
            }

            var form = new PlayerForm(result, mTeam) {Owner = this};
            form.Show();
            Hide();
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
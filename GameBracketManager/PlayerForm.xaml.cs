using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using GameBracketManager.Infrastructure;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for PlayerForm.xaml
    /// </summary>
    public partial class PlayerForm : Window
    {
        public PlayerForm(Team team)
        {
            Player = new Player {Id = Guid.NewGuid(), TeamId = team.Id};
            Team = team;

            InitializeComponent();

            AddOrUpdate = "Add";
        }

        public PlayerForm(Player player, Team team)
        {
            Player = player;
            Team = team;

            InitializeComponent();

            AddOrUpdate = "Update";
        }

        public Player Player { get; }

        public Team Team { get; }

        public string AddOrUpdate { get; set; }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }

        private void Click_AddOrUpdate(object sender, RoutedEventArgs e)
        {
            using (var context = new CS487Entities())
            {
                var player = context.Players.FirstOrDefault(o => o.Id == Player.Id);

                if (player != null)
                {
                    player.DisplayName = Player.DisplayName;
                    player.FirstName = Player.FirstName;
                    player.LastName = Player.LastName;
                    player.TeamId = Team.Id;
                    context.Entry(player).State = EntityState.Modified;
                    context.SaveChanges();
                    Close();
                }
                else
                {
                    Player.Team = context.Teams.FirstOrDefault(o => o.Id == Player.TeamId);
                    context.Players.Add(Player);
                    context.SaveChanges();
                    Close();
                }
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using GameBracketManager.Infrastructure;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for NewTeamForm.xaml
    /// </summary>
    public partial class TeamForm : Window
    {
        public TeamForm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }

        private void Click_Add_Team(object sender, RoutedEventArgs e)
        {
            var team = new Team { Id = Guid.NewGuid(), Name = txtName.Text, GameName = txtGame.Text };

            using (var context = new CS487Entities())
            {
                var game = context.Games.FirstOrDefault(o => o.Name == team.GameName);

                if (game == null)
                {
                    context.Games.Add(new Game {Name = team.GameName});
                }

                context.Teams.Add(team);
                context.SaveChanges();
            }

            Close();
        }
    }
}

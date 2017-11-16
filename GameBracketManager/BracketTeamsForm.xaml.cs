using GameBracketManager.Infrastructure;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for BracketTeamsForm.xaml
    /// </summary>
    public partial class BracketTeamsForm : Window
    {
        private Bracket mBracket;
        private ObservableCollection<Team> mTeams;

        public BracketTeamsForm(Bracket bracket)
        {
            InitializeComponent();

            mBracket = bracket;
            mTeams = new ObservableCollection<Team>();

            using (var context = new CS487Entities())
            {
                var obj = context.Brackets.Where(o => o.Name == mBracket.Name).Include(o => o.Teams).FirstOrDefault();

                if (obj != null)
                {
                    foreach (var team in obj.Teams)
                    {
                        mTeams.Add(team);
                    }
                }
            }

            dgTeams.ItemsSource = mTeams
                .Select(o => new LimitedTeam { Name = o.Name, Score = o.Score, Game = o.GameName });
        }

        private void Click_Add_Team(object sender, RoutedEventArgs e)
        {
            var form = new AddTeamForm(mBracket) { Owner = this };
            form.Show();
            Hide();
        }

        private void Click_Remove_Team(object sender, RoutedEventArgs e)
        {
            var selectedItem = dgTeams.SelectedValue as LimitedTeam;
            Team result = null;

            if (selectedItem != null)
            {
                result = mTeams
                    .FirstOrDefault(o => o.Name == selectedItem.Name && o.GameName == selectedItem.Game && o.Score == selectedItem.Score);
            }

            if (result == null)
            {
                MessageBox.Show("You must select the team to remove.");
                return;
            }

            using (var context = new CS487Entities())
            {
                var toRemove = context.Teams.FirstOrDefault(o => o.Id == result.Id);
                context.Brackets.FirstOrDefault(o => o.Name == mBracket.Name)?.Teams.Remove(toRemove);
                context.Entry(mBracket).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Owner?.Show();
        }
    }
}

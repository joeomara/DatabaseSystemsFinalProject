using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using GameBracketManager.Infrastructure;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for ManageTeams.xaml
    /// </summary>
    public partial class ManageTeams : Window
    {
        private ObservableCollection<Team> mTeams;

        public ManageTeams()
        {
            InitializeComponent();

            mTeams = new ObservableCollection<Team>();

            using (var context = new CS487Entities())
            {
                foreach (var team in context.Teams.Where(o => o.Id != null).Include(o => o.Players))
                {
                    mTeams.Add(team);
                }
            }

            dgTeams.ItemsSource = mTeams
                .Select(o => new LimitedTeam {Name = o.Name, Game = o.GameName, Score = o.Score }).ToList();
        }

        private void Click_Add_Team(object sender, RoutedEventArgs e)
        {
            var form = new TeamForm { Owner = this };
            form.Show();
            Hide();
        }

        private void Click_Edit_Team(object sender, RoutedEventArgs e)
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
                MessageBox.Show("You must select the team to edit.");
                return;
            }

            var form = new TeamPlayersForm(result, result.Players) { Owner = this };
            form.Show();
            Hide();
        }

        private void Click_Delete_Team(object sender, RoutedEventArgs e)
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
                MessageBox.Show("You must select the team to delete.");
                return;
            }

            using (var context = new CS487Entities())
            {
                var toRemove = context.Teams.FirstOrDefault(o => o.Id == result.Id);

                if (toRemove != null) context.Teams.Remove(toRemove);

                // Do a cascade delete here...

                context.SaveChanges();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }
    }

    internal class LimitedTeam
    {
        public string Name { get; set; }
        public string Game { get; set; }
        public int Score { get; set; }
    }
}

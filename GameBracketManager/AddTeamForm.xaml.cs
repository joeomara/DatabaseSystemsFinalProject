using GameBracketManager.Infrastructure;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for AddTeamForm.xaml
    /// </summary>
    public partial class AddTeamForm : Window
    {
        private ObservableCollection<Team> mTeams;
        private Bracket mBracket;

        public AddTeamForm(Bracket bracket)
        {
            InitializeComponent();

            mBracket = bracket;
            mTeams = new ObservableCollection<Team>();

            using (var context = new CS487Entities())
            {
                foreach (var team in context.Teams)
                {
                    mTeams.Add(team);
                }
            }

            dgTeams.ItemsSource = mTeams
                .Select(o => new LimitedTeam { Name = o.Name, Game = o.GameName, Score = o.Score });
        }

        private void Click_Add(object sender, RoutedEventArgs args)
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
                MessageBox.Show("You must select the bracket to edit.");
                return;
            }

            using (var context = new CS487Entities())
            {
                var toAdd = context.Teams.FirstOrDefault(o => o.Id == result.Id);

                var toAddTo = context.Brackets.FirstOrDefault(o => o.Name == mBracket.Name);

                toAddTo.Teams.Add(toAdd);
                context.Entry(toAddTo).State = System.Data.Entity.EntityState.Modified;

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

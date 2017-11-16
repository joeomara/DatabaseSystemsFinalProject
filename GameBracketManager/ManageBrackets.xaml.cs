using GameBracketManager.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for ManageBracket.xaml
    /// </summary>
    public partial class ManageBracket : Window
    {
        private ObservableCollection<Bracket> mBrackets;

        public ManageBracket()
        {
            InitializeComponent();

            mBrackets = new ObservableCollection<Bracket>();

            using (var context = new CS487Entities())
            {
                foreach(var bracket in context.Brackets)
                {
                    mBrackets.Add(bracket);
                }
            }

            if (mBrackets.Count > 0)
                dgBrackets.ItemsSource = mBrackets
                    .Select(o => new LimitedBracket { Name = o.Name, EventDateTime = o.EventDateTime, Game = o.GameName });
        }

        private void Click_Edit_Bracket(object sender, RoutedEventArgs e)
        {
            var selectedItem = dgBrackets.SelectedValue as LimitedBracket;
            Bracket result = null;

            if (selectedItem != null)
            {
                result = mBrackets
                    .FirstOrDefault(o => o.Name == selectedItem.Name && o.GameName == selectedItem.Game && o.EventDateTime == selectedItem.EventDateTime);
            }

            if (result == null)
            {
                MessageBox.Show("You must select the bracket to edit.");
                return;
            }

            var form = new BracketTeamsForm(result) { Owner = this };
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

    internal class LimitedBracket
    {
        public string Name { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Game { get; set; }
    }
}

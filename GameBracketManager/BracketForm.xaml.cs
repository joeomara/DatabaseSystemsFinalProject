using GameBracketManager.Infrastructure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace GameBracketManager
{
    /// <summary>
    /// Interaction logic for BracketForm.xaml
    /// </summary>
    public partial class BracketForm : Window
    {
        public BracketForm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Owner?.Show();
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            var bracket = new Bracket { Name = txtName.Text, GameName = txtGame.Text, EventDateTime = (DateTime)dtpDate.SelectedDate };

            using (var context = new CS487Entities())
            {
                var game = context.Games.FirstOrDefault(o => o.Name == bracket.GameName);

                if (game == null)
                {
                    game = new Game { Name = bracket.GameName };
                    context.Games.Add(game);
                }

                context.Brackets.Add(bracket);
                context.SaveChanges();
            }

            Close();
        }
    }
}

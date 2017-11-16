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
        public PlayerForm()
        {
            InitializeComponent();
        }

        public PlayerForm(Player player)
        {
            Player = player;

            InitializeComponent();
        }

        public Player Player { get; }

        public string AddOrUpdate
        {
            get { return Player == null ? "Add" : "Update"; }
        }

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
                    context.Entry(player).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    context.Players.Add(Player);
                    context.SaveChanges();
                }
            }
        }
    }
}

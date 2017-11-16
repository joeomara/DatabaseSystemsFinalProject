using System.ComponentModel;
using System.Windows;

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
    }
}

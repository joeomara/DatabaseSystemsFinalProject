using System.ComponentModel;
using System.Windows;

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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Owner?.Show();
        }
    }
}

using System.ComponentModel;
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
    }
}

using System.Windows;

namespace PasswordGenerator
{
	public partial class MainWindow : Window
	{
		public MainWindow() => InitializeComponent();

		private void Top_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
	}
}

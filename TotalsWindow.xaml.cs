using MahApps.Metro.Controls;
using ReportsCore.ViewModels;

namespace ReportsCore {
	/// <summary>
	/// Логика взаимодействия для TotalsWindow.xaml
	/// </summary>
	public partial class TotalsWindow : MetroWindow {
		public TotalsWindow() {
			InitializeComponent();
		}
		public TotalsWindow(MainWindowViewModel viewModel) {
			InitializeComponent();
			//this.DataContext = new TotalsWindow(viewModel);
			this.DataContext = viewModel;
;		}
	}
}

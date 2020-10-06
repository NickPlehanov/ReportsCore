using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReportsCore.Helpers {
	/// <summary>
	/// Логика взаимодействия для SearchControl.xaml
	/// </summary>
	public partial class SearchControl : UserControl {
		public SearchControl() {
			InitializeComponent();
			(this.Content as FrameworkElement).DataContext = this;
		}

		public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
		public string Watermark { get => (string)GetValue(WatermarkProperty); set => SetValue(WatermarkProperty, value); }
		public ICommand SearchCommand { get => (ICommand)GetValue(SearchCommandProperty); set => SetValue(SearchCommandProperty, value); }
		public ICommand ClearSearchQuery { get => (ICommand)GetValue(ClearSearchQueryProperty); set => SetValue(ClearSearchQueryProperty, value); }


		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register(nameof(Watermark), typeof(string), typeof(SearchControl), new PropertyMetadata(defaultValue: ""));
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(SearchControl), new PropertyMetadata(defaultValue: ""));
		public static readonly DependencyProperty SearchCommandProperty = DependencyProperty.Register(nameof(SearchCommand), typeof(ICommand), typeof(SearchControl), new PropertyMetadata(defaultValue: null));
		public static readonly DependencyProperty ClearSearchQueryProperty = DependencyProperty.Register(nameof(ClearSearchQuery), typeof(ICommand), typeof(SearchControl), new PropertyMetadata(defaultValue: null));
	}
}

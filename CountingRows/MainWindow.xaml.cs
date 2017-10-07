using System.Windows;

namespace CountingRows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class View : Window
    {
        Controller controller = new Controller();
        public View() => InitializeComponent();

        private void Button1_Click(object sender, RoutedEventArgs e) => Grid1.ItemsSource = controller.AnalyseLogFile();
    }
}

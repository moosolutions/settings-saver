using settings_saver.MVVM.ViewModel;
using System.Windows;

namespace settings_saver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += delegate { DragMove(); };
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is ICloseableWindow vm)
            {
                vm.Close += () => { this.Close(); };
            }
        }
    }
}

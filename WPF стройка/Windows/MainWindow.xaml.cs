using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new MainPage();
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}

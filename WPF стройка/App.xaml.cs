using System.Windows;

namespace WPF_стройка
{
    public partial class App : Application
    {
        public static string Login_Text { get; set; }

        public App()
        {
            Login_Text = "Login";
        }
    }
}

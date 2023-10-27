using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace WPF_стройка
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static string AutorizedLogin;
        public LoginWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private string ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Enter_Click(sender, e);
            }
        }
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Enter_Click(sender, e);
            }
        }


        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var securePassword = PassBox.SecurePassword;
            var passwordInserted = ConvertToUnsecureString(securePassword);
            var loginInserted = LoginBox.Text;
            var LoginData = SqlConnect.UserDatas("Авторизация", "Login", loginInserted);
            bool authenticationSuccessful = false;

            foreach (var item in LoginData)
            {
                if (item.Login == loginInserted && item.Password == passwordInserted)
                {
                    var window = new MainWindow();
                    window.Show();
                    Close();
                    authenticationSuccessful = true;
                    AutorizedLogin = loginInserted;
                    Data.CurrentLogin = loginInserted;
                    break;
                }
            }

            if (!authenticationSuccessful)
            {
                WrongText.Visibility = Visibility.Visible;
            }
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var window = new Registration_Window();
            window.Show();
            Close();
        }
    }
}
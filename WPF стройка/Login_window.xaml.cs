using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;

namespace WPF_стройка
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Login_Window : Window
    {
        public Login_Window()
        {
            InitializeComponent();
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

        }
        private void LoginBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
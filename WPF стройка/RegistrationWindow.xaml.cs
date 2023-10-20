using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;

namespace WPF_стройка
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Registration_Window : Window
    {
        public Registration_Window()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var loginInserted = LoginBox.Text;
            var passwordInserted1 = ConvertToUnsecureString(PassBox.SecurePassword);
            var passwordInserted2 = ConvertToUnsecureString(PassBoxConfirm.SecurePassword);

            if (string.IsNullOrWhiteSpace(loginInserted) || string.IsNullOrWhiteSpace(passwordInserted1) || string.IsNullOrWhiteSpace(passwordInserted2))
            {
                WrongText.Text = "Пожалуйста, заполните все поля.";
                WrongText.Visibility = Visibility.Visible;
            }
            else
            {
                var LoginData = SqlConnect.UserDatas("Авторизация", "Login", loginInserted);

                if (LoginData.Any(item => item.Login == loginInserted))
                {
                    WrongText.Text = "Пользователь с таким логином уже существует";
                    WrongText.Visibility = Visibility.Visible;
                }
                else if (passwordInserted1 == passwordInserted2)
                {
                    SqlConnect.RegisterUser(loginInserted, passwordInserted2);
                    var window = new MainWindow();
                    window.Show();
                    Close();
                }
                else
                {
                    WrongText.Text = "Пароли не совпадают";
                    WrongText.Visibility = Visibility.Visible;
                }
            }
        }

    }
}
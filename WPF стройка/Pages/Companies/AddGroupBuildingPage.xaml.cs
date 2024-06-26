﻿using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBuildingPage.xaml
    /// </summary>
    public partial class AddCompanyPage : Page
    {
        public AddCompanyPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
            {
                Error.Text = ("Название компании должно состоять только из букв, цифр и пробелов.");
                return;
            }

            var CompanyData = ListActions.CompaniesData();
            if (CompanyData.Any(item => item.Name == name))
            {
                Error.Text = ("Такая компания уже существует!");
            }
            else
            {
                CompaniesActions.AddCompany(name, Location.Text);
                Error.Text = "Компания добавлена";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new CompaniesActionsPage();
        }
    }
}
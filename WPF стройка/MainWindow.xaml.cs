using System;
using System.Collections.Generic;
using System.Windows;

namespace YourNamespace
{
    public class Entity
    {
        public string Name { get; set; }
    }
    public class Building : Entity
    {
        private int floors;
        private double height;
        private bool isResidential;

        public Building(string name, int floors, double height, bool isResidential)
        {
            Name = name;
            this.floors = floors;
            this.height = height;
            this.isResidential = isResidential;
        }


        public int Floors
        {
            get { return floors; }
            set { floors = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public bool IsResidential
        {
            get { return isResidential; }
            set { isResidential = value; }
        }

        public void DisplayBuildingInfo()
        {
            Console.WriteLine("Название строения: " + Name);
            Console.WriteLine("Число этажей: " + Floors);
            Console.WriteLine("Высота: " + Height + " метров");
            Console.WriteLine("Жилой: " + IsResidential);
        }

        public void DisplayBuildingInfo(bool isTrue)
        {
            if (isTrue)
            {
                Console.WriteLine(Name);
            }
        }


    }
    public class BuildingStorage
    {
        private List<Building> buildings = new List<Building>();

        public BuildingStorage()
        {
            buildings = new List<Building>();
        }

        public void AddBuilding(Building building)
        {
            buildings.Add(building);
        }

        public void RemoveBuilding(Building building)
        {
            buildings.Remove(building);
        }

        public Building FindBuilding(string name)
        {
            return buildings.Find(b => b.Name == name);
        }
        public void DisplayAllBuildingsNames(Boolean isTrue)
        {
            foreach (Building building in buildings)
            {
                building.DisplayBuildingInfo(isTrue);
            }
        }
        public void DisplayAllBuildingsInfo()
        {
            foreach (Building building in buildings)
            {
                building.DisplayBuildingInfo();
                Console.WriteLine("\t");
            }
        }
    }
    public class BuildingGroup : Entity
    {
        public List<Building> buildings;

        public BuildingGroup(string name)
        {
            Name = name;
            buildings = new List<Building>();
        }

        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public void AddBuilding(Building building)
        {
            buildings.Add(building);
        }

        public void DisplayGroupInfo()
        {
            Console.WriteLine("Название группы строений: " + Name);
            Console.WriteLine("Кол-во строений: " + buildings.Count);

            foreach (Building building in buildings)
            {
                Console.WriteLine("\nНазвание строения: " + building.Name);
                Console.WriteLine("Кол-во этажей: " + building.Floors);
                Console.WriteLine("Высота: " + building.Height + " метров");
                Console.WriteLine("Жилой: " + building.IsResidential);
            }
        }
    }
    public class BuildingGroupStorage
    {
        private List<BuildingGroup> groups = new List<BuildingGroup>();

        public BuildingGroupStorage()
        {
            groups = new List<BuildingGroup>();
        }

        public void AddGroup(BuildingGroup group)
        {
            groups.Add(group);
        }

        public void RemoveGroup(BuildingGroup group)
        {
            groups.Remove(group);
        }

        public BuildingGroup FindGroup(string name)
        {
            return groups.Find(b => b.Name == name);
        }

        public void DisplayAllGroupsInfo()
        {
            foreach (BuildingGroup group in groups)
            {
                group.DisplayGroupInfo();
                Console.WriteLine("\t");
            }
        }
    }
    public class Company : Entity
    {
        private string location;
        private List<BuildingGroup> groups = new List<BuildingGroup>();

        public Company(string name, string location)
        {
            Name = name;
            this.location = location;
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public List<BuildingGroup> Groups
        {
            get { return groups; }
            set { groups = value; }
        }

        public void AddBuildingGroup(BuildingGroup group)
        {
            Groups.Add(group);
        }

        public void RemoveBuildingGroup(BuildingGroup group)
        {
            groups.Remove(group);
        }
        public BuildingGroup FindBuildingGroup(string name)
        {
            return groups.Find(b => b.Name == name);
        }
        public void DisplayCompanyInfo()
        {
            Console.WriteLine("Компания: " + Name);
            Console.WriteLine("Местоположение: " + Location);
            foreach (BuildingGroup group in groups)
            {
                group.DisplayGroupInfo();
                Console.WriteLine("\t");
            }
        }

    }
    public class CompanyStorage
    {
        private List<Company> companies = new List<Company>();

        public CompanyStorage()
        {
            companies = new List<Company>();
        }

        public void AddCompany(Company company)
        {
            companies.Add(company);
        }

        public void RemoveCompany(Company company)
        {
            companies.Remove(company);
        }

        public Company FindCompany(string name)
        {
            return companies.Find(b => b.Name == name);
        }

        public void DisplayAllCompaniesInfo()
        {
            foreach (Company company in companies)
            {
                company.DisplayCompanyInfo();
                Console.WriteLine("\t");
            }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuildingAction_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text += "Выберите действие:\n";
            OutputTextBox.Text += "1. Добавить строение.\n";
            OutputTextBox.Text += "2. Удалить строение.\n";
        }

        private void GroupAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Работа с группами строений"
            // Добавьте код для работы с данными о группах строений
        }

        private void CompanyAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Работа с компаниями"
            // Добавьте код для работы с данными о компаниях
        }

        private void DisplayAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Вывести список"
            // Добавьте код для отображения списков строений, компаний и групп строений
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WPF_стройка
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
    class Program
    {
        static void main(string[] args)
        {
            BuildingGroupStorage groups = new BuildingGroupStorage();
            BuildingStorage storage = new BuildingStorage();
            CompanyStorage companies = new CompanyStorage();

            Building building2 = new Building("BurjKhalifa", 163, 828.0, false);
            storage.AddBuilding(building2);
            BuildingGroup group1 = new BuildingGroup("Skyscrapers");
            groups.AddGroup(group1);
            Company companyka = new Company("tim", "tom");
            companies.AddCompany(companyka);
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Работа со строениями.");
                Console.WriteLine("2. Работа с группами строений.");
                Console.WriteLine("3. Работа с компаниями.");
                Console.WriteLine("4. Вывести список.");
                Console.WriteLine("5. Выйти из программы.");
                var input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить строение.");
                        Console.WriteLine("2. Удалить строение.");
                        Console.WriteLine("3. Обновить строение.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        var buildingAction = Console.ReadLine();
                        Console.Clear();

                        switch (buildingAction)
                        {
                            case "1":
                                Console.WriteLine("Введите название строения:");
                                string name = Console.ReadLine();
                                if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
                                {
                                    Console.WriteLine("Неверный ввод. Название строения должно состоять только из букв, цифр и пробелов.");
                                    continue;
                                }

                                Console.WriteLine("Введите количество этажей:");
                                int floors;
                                string floorsInput = Console.ReadLine();
                                if (!Regex.IsMatch(floorsInput, @"^\d+$") || !int.TryParse(floorsInput, out floors))
                                {
                                    Console.WriteLine("Неверный ввод. Количество этажей должно быть положительным целым числом.");
                                    continue;
                                }

                                Console.WriteLine("Введите высоту строения:");
                                float height;
                                string heightInput = Console.ReadLine();
                                if (!Regex.IsMatch(heightInput, @"^\d+(\.\d+)?$") || !float.TryParse(heightInput, out height))
                                {
                                    Console.WriteLine("Неверный ввод. Высота строения должна быть числом.");
                                    continue;
                                }

                                Console.WriteLine("Это жилой дом? (Y/N)");
                                bool isResidential = Console.ReadLine().ToLower() == "y";

                                Building building = new Building(name, floors, height, isResidential);
                                storage.AddBuilding(building);
                                Console.Clear();
                                Console.WriteLine("Строение добавлено.");
                                break;

                            case "2":
                                Console.WriteLine("Введите название строения, которое нужно удалить:");
                                string buildingName = Console.ReadLine();
                                Building buildingToRemove = storage.FindBuilding(buildingName);
                                Console.Clear();
                                if (buildingToRemove != null)
                                {
                                    storage.RemoveBuilding(buildingToRemove);
                                    Console.WriteLine("Строение удалено.");
                                }
                                else
                                {
                                    Console.WriteLine("Строение не найдено.");
                                }
                                break;

                            case "3":
                                Console.WriteLine("Введите название строения, которое нужно обновить:");
                                string buildingToUpdate = Console.ReadLine();
                                Building build = storage.FindBuilding(buildingToUpdate);
                                Console.Clear();
                                if (build != null)
                                {
                                    Console.WriteLine("Выберите свойство для обновления:");
                                    Console.WriteLine("1. Название");
                                    Console.WriteLine("2. Количество этажей");
                                    Console.WriteLine("3. Высота");
                                    Console.WriteLine("4. Тип (жилой/нежилой)");

                                    string updateProperty = Console.ReadLine();
                                    Console.Clear();

                                    switch (updateProperty)
                                    {
                                        case "1":
                                            Console.WriteLine("Введите новое название строения:");
                                            string newName = Console.ReadLine();
                                            build.Name = newName;
                                            Console.WriteLine("Название строения обновлено.");
                                            break;

                                        case "2":
                                            Console.WriteLine("Введите новое количество этажей:");
                                            int newFloors;
                                            if (!int.TryParse(Console.ReadLine(), out newFloors))
                                            {
                                                Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                                break;
                                            }
                                            build.Floors = newFloors;
                                            Console.WriteLine("Количество этажей обновлено.");
                                            break;

                                        case "3":
                                            Console.WriteLine("Введите новую высоту строения:");
                                            double newHeight;
                                            if (!double.TryParse(Console.ReadLine(), out newHeight))
                                            {
                                                Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                                break;
                                            }
                                            build.Height = newHeight;
                                            Console.WriteLine("Высота строения обновлена.");
                                            break;
                                        case "4":
                                            Console.WriteLine("Это жилой дом? (Y/N)");
                                            bool newIsResidential = Console.ReadLine().ToLower() == "y";
                                            build.IsResidential = newIsResidential;
                                            Console.WriteLine("Тип строения обновлен.");
                                            break;

                                        default:
                                            Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                            break;
                                    }
                                    Console.WriteLine("Строение обновлено.");
                                }
                                else
                                {
                                    Console.WriteLine("Строение не найдено.");
                                }
                                break;

                            case "4":
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить группу строений.");
                        Console.WriteLine("2. Удалить группу строений.");
                        Console.WriteLine("3. Обновить группу строений.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        var groupAction = Console.ReadLine();
                        Console.Clear();

                        switch (groupAction)
                        {
                            case "1":
                                Console.WriteLine("Введите название группы строений:");
                                string groupName = Console.ReadLine();
                                BuildingGroup group = new BuildingGroup(groupName);
                                groups.AddGroup(group);
                                Console.Clear();
                                Console.WriteLine("Группа строений добавлена.");
                                break;
                            case "2":
                                Console.WriteLine("Введите название группы строений, которую нужно удалить:");
                                string groupToDelete = Console.ReadLine();
                                BuildingGroup groupToRemove = groups.FindGroup(groupToDelete);
                                Console.Clear();
                                if (groupToRemove != null)
                                {
                                    groups.RemoveGroup(groupToRemove);
                                    Console.WriteLine("Группа строений удалена.");
                                }
                                else
                                {
                                    Console.WriteLine("Группа строений не найдена.");
                                }
                                break;
                            case "3":
                                Console.WriteLine("Выберите действие:");
                                Console.WriteLine("1. Переименовать группу строений.");
                                Console.WriteLine("2. Добавить строение в группу.");
                                Console.WriteLine("3. Удалить строение из группы.");
                                Console.WriteLine("4. Вернуться в главное меню.");
                                var groupSubAction = Console.ReadLine();
                                Console.Clear();

                                switch (groupSubAction)
                                {
                                    case "1":
                                        Console.WriteLine("Введите название группы строений, которую нужно переименовать:");
                                        string groupToUpdateName = Console.ReadLine();
                                        BuildingGroup groupToUpdate = groups.FindGroup(groupToUpdateName);
                                        Console.Clear();
                                        if (groupToUpdate != null)
                                        {
                                            Console.WriteLine("Введите новое название для группы строений:");
                                            string newGroupName = Console.ReadLine();
                                            groupToUpdate.Name = newGroupName;
                                            Console.WriteLine("Группа строений переименована.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Группа строений не найдена.");
                                        }
                                        break;

                                    case "2":
                                        Console.WriteLine("Введите название строения:");
                                        string buildingName = Console.ReadLine();
                                        Console.WriteLine("Введите название группы строений, в которую нужно добавить строение:");
                                        string groupNameToAddBuilding = Console.ReadLine();
                                        BuildingGroup groupToAddBuilding = groups.FindGroup(groupNameToAddBuilding);
                                        Building buildingToAdd = storage.FindBuilding(buildingName);
                                        Console.Clear();
                                        if (groupToAddBuilding != null && buildingToAdd != null)
                                        {
                                            groupToAddBuilding.Buildings.Add(buildingToAdd);
                                            Console.WriteLine("Строение добавлено в группу.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Группа строений или строение не найдены.");
                                        }
                                        break;

                                    case "3":
                                        Console.WriteLine("Введите название строения:");
                                        string buildingNameToRemove = Console.ReadLine();
                                        Console.WriteLine("Введите название группы строений, из которой нужно удалить строение:");
                                        string groupNameToRemoveBuilding = Console.ReadLine();
                                        BuildingGroup groupToRemoveBuilding = groups.FindGroup(groupNameToRemoveBuilding);
                                        Building buildingToRemove = groupToRemoveBuilding?.Buildings.Find(building => building.Name == buildingNameToRemove);
                                        Console.Clear();
                                        if (groupToRemoveBuilding != null && buildingToRemove != null)
                                        {
                                            groupToRemoveBuilding.Buildings.Remove(buildingToRemove);
                                            Console.WriteLine("Строение удалено из группы.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Группа строений или строение не найдены.");
                                        }
                                        break;

                                    case "4":
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                        break;
                                }
                                break;


                        }
                        break;
                    case "3":
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить компанию.");
                        Console.WriteLine("2. Удалить компанию.");
                        Console.WriteLine("3. Обновить компанию.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        var companyAction = Console.ReadLine();
                        Console.Clear();
                        switch (companyAction)
                        {
                            case "1":
                                Console.WriteLine("Введите название компании:");
                                string companyName = Console.ReadLine();
                                Console.WriteLine("Введите местоположение компании:");
                                string companyLocation = Console.ReadLine();
                                Company company = new Company(companyName, companyLocation);
                                companies.AddCompany(company);
                                Console.Clear();
                                Console.WriteLine("Компания добавлена.");
                                break;

                            case "2":
                                Console.WriteLine("Введите название компании, которую нужно удалить:");
                                string companyToDelete = Console.ReadLine();
                                Company companyToRemove = companies.FindCompany(companyToDelete);
                                Console.Clear();
                                if (companyToRemove != null)
                                {
                                    companies.RemoveCompany(companyToRemove);
                                    Console.WriteLine("Компания удалена.");
                                }
                                else
                                {
                                    Console.WriteLine("Компания не найдена.");
                                }
                                break;

                            case "3":
                                Console.WriteLine("Введите название компании, которую нужно обновить:");
                                Company company1 = companies.FindCompany(name: Console.ReadLine());
                                Console.Clear();
                                if (company1 != null)
                                {
                                    Console.WriteLine("Выберите действие:");
                                    Console.WriteLine("1. Изменить название компании.");
                                    Console.WriteLine("2. Изменить местоположение компании.");
                                    Console.WriteLine("3. Добавить группу строений.");
                                    Console.WriteLine("4. Удалить группу строений.");
                                    Console.WriteLine("5. Вернуться в главное меню.");

                                    var companyUpdateAction = Console.ReadLine();
                                    Console.Clear();
                                    switch (companyUpdateAction)
                                    {
                                        case "1":
                                            Console.WriteLine("Введите новое название компании:");
                                            string newCompanyName = Console.ReadLine();
                                            company1.Name = newCompanyName;
                                            Console.WriteLine("Название компании обновлено.");
                                            break;

                                        case "2":
                                            Console.WriteLine("Введите новое местоположение компании:");
                                            string newCompanyLocation = Console.ReadLine();
                                            company1.Location = newCompanyLocation;
                                            Console.WriteLine("Местоположение компании обновлено.");
                                            break;

                                        case "3":
                                            Console.WriteLine("Введите название группы строений:");
                                            BuildingGroup group = groups.FindGroup(name: Console.ReadLine());
                                            company1.AddBuildingGroup(group);
                                            Console.WriteLine("Группа строений добавлена в компанию.");
                                            break;

                                        case "4":
                                            Console.WriteLine("Введите название группы строений, которую нужно удалить:");
                                            string groupToDelete = Console.ReadLine();
                                            BuildingGroup groupToRemove = company1.FindBuildingGroup(groupToDelete);
                                            Console.Clear();
                                            if (groupToRemove != null)
                                            {
                                                groups.RemoveGroup(groupToRemove);
                                                Console.WriteLine("Группа строений удалена из компании.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Группа строений не найдена в компании.");
                                            }
                                            break;
                                        case "5":
                                            Console.Clear();
                                            break;

                                        default:
                                            Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                            break;
                                    }
                                    Console.WriteLine("Компания обновлена.");
                                }
                                else
                                {
                                    Console.WriteLine("Компания не найдена.");
                                }
                                break;

                            case "4":
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Вывести список строений.");
                        Console.WriteLine("2. Вывести список компаний.");
                        Console.WriteLine("3. Вывести список групп строений.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        var displayAction = Console.ReadLine();
                        Console.Clear();

                        switch (displayAction)
                        {
                            case "1":
                                Console.WriteLine("Вывести краткую информацию?(Y/N)");
                                bool isTrue = Console.ReadLine().ToLower() == "y";
                                if (isTrue)
                                {
                                    Console.WriteLine("Список строений:");
                                    storage.DisplayAllBuildingsNames(isTrue);
                                }
                                else
                                {
                                    Console.WriteLine("Список строений:");
                                    storage.DisplayAllBuildingsInfo();
                                }
                                break;

                            case "2":
                                Console.WriteLine("Список компаний:");
                                companies.DisplayAllCompaniesInfo();
                                break;

                            case "3":
                                Console.WriteLine("Список групп строений:");
                                groups.DisplayAllGroupsInfo();
                                break;
                            case "4":
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                                break;
                        }
                        break;

                    case "5":
                        Console.WriteLine("Выход из программы...");
                        return;

                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте еще раз.\n");
                        break;
                }
                Console.WriteLine("\n");
            }
        }
    }
}

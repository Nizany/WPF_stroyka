namespace WPF_стройка { 
    public class Companies
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Companies(string id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}
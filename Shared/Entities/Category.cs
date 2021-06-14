namespace Shared
{
    public class Category : Identity<Category, int>
    {
        public Category()
        {
        }

        public Category(int id) 
        {
            base.Id = id;
        }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public Category Parent { get; set; }
        public string Description { get; set; }
    }
}
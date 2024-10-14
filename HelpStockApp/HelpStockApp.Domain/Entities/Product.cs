using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }


        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExeceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExeceptionValidation.When(price < 0, "Invalid Price, price negative value is unlikely!");
            DomainExeceptionValidation.When(stock < 0, "Invalid Stock, stock negative value is unlikely!");
            DomainExeceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required!");
            DomainExeceptionValidation.When(name.Length < 3, "Invalid name, too short. minimum 3 characters!");
            DomainExeceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required!");
            DomainExeceptionValidation.When(description.Length < 5, "Invalid description, too short. minimum 5 characters!");
            DomainExeceptionValidation.When(image.Length > 250, "Invalid image URL, too long. maximum 250 characters!");
            DomainExeceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image URL, URL not a found or no exist");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
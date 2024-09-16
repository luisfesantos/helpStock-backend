using HelpStockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            DomainExeceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExeceptionValidation.When(price < 0, "Invalid price, price negative is improbable");
            DomainExeceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required!");
            DomainExeceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters!");
            DomainExeceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required!");
            DomainExeceptionValidation.When(description.Length < 5, "Invalid description, too short. Minimum 5 characters!");
            DomainExeceptionValidation.When(stock < 0, "Invalid stock, stock negative is improbable");
            DomainExeceptionValidation.When(image.Length > 250, "Invalid image URL, too big. Maximum 250 characters!");

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

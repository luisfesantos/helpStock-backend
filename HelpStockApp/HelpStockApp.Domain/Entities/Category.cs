using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name) 
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExeceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name) 
        {
            DomainExeceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required!");
            DomainExeceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters!");

            Name = name;
        }
    }

}

using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Reflection;

namespace HelpStockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos de Categoria
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectsValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Name Parameter Alone")]
        public void CreateCategory_WithNameAloneParameters_ResultException()
        {
            Action action = () => new Category("Eletronics");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Categoria
        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidParameters_ResultException()
        {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Name Too Short")]
        public void CreateCategory_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Category(1, "AB");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Category With Name Null")]
        public void CreateCategory_WithNameNullParameter_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Category With Name Missing")]
        public void CreateCategory_WithNameMissingParameter_ResultException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        #endregion
    }

}

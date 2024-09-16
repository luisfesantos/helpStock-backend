using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;
using Newtonsoft.Json.Linq;

namespace HelpStockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos de Categoria
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectsValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<DomainExeceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Categoria
        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidParameters_ResultException()
        {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExeceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        #endregion
    }

}

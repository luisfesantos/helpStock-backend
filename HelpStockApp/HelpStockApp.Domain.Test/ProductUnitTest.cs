using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Reflection;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos de Categoria
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectsValidState()
        {
            Action action = () => new Product(1, "Product name", "Description", 10, 1, "Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Image Null")]
        public void CreateProduct_WithImageNullParameter_ResultException()
        {
            Action action = () => new Product(1, "Product name", "lalala", 10, 1, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Categoria
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidIdParameters_ResultException()
        {
            Action action = () => new Product(-1, "Product name", "lalala", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Name Invalid")]
        public void CreateProduct_WithNameInvalidParameter_ResultException()
        {
            Action action = () => new Product(1, null, "lalala", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Image Too Long")]
        public void CreateProduct_WithImageTooLongParameter_ResultException()
        {
            Action action = () => new Product(1, "Product name", "lalala", 10, 1, "https://www.google.com/search?q=url+com++de+251+caracteres&sca_esv=60dc7b8df89f0db7&sca_upv=1&rlz=1C1GCEU_pt-BRBR1123BR1123&ei=dXPxZta5IvDc5OUP2Jem6Aw&ved=0ahUKEwiWyJKAnNmIAxVwLrkGHdiLCc0Q4dUDCA8&uact=5&oq=url+com++de+251+caracteres&gs_lp=Egxnd3Mtd2l6LXNlcnAiGnVybCBjb20gIGRlIDI1MSBjYXJhY3RlcmVzMggQIRigARjDBEi9D1CuA1jFDXADeAGQAQCYAbIBoAG_BqoBAzAuNrgBA8gBAPgBAZgCCKACoAXCAgoQABiwAxjWBBhHwgIIEAAYgAQYogTCAgQQIRgKmAMAiAYBkAYIkgcDMy41oAesDw&sclient=gws-wiz-serp");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Image Empty")]
        public void CreateProduct_WithImageEmptyParameter_ResultException()
        {
            Action action = () => new Product(1, "Product name", "lalala", 10, 1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, URL not a found or no exist");
        }

        [Fact(DisplayName = "Create Product With Stock Negative")]
        public void CreateProduct_WithStockNegativeParameter_ResultException()
        {
            Action action = () => new Product(1, "Product name", "lalala", 10, -1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Price Negative")]
        public void CreateProduct_WithPriceNegativeParameter_ResultException()
        {
            Action action = () => new Product(1, "Product name", "lalala", -10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikely!");
        }

        /* 4 Adicionais */
        [Fact(DisplayName = "Create Category With Name Too Short")]
        public void CreateCategory_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Product(1, "Pr", "description", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Name Empty")]
        public void CreateProduct_WithNameNullParameter_ResultException()
        {
            Action action = () => new Product(1, "", "lalala", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Description Too Short")]
        public void CreateProduct_WithDescriptionTooShortParameter_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Bolo", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too short. minimum 5 characters!");
        }

        [Fact(DisplayName = "Create Product With Description Invalid")]
        public void CreateProduct_WithDescriptionInvalidParameter_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");
        }
        #endregion
    }
}

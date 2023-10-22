using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Məhsul adını qeyd edin")
                .MaximumLength(100)
                .MinimumLength(5)
                    .WithMessage("Məhsul adı min 5 max 100 simvoldan ibarət ola bilər!");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull().
                    WithMessage("Məhsul sayını qey edin")
                .Must(s => s >= 0)
                    .WithMessage("Məhsul sayını doğru qeyd edin!");
            RuleFor(p => p.Price)
               .NotEmpty()
               .NotNull().
                   WithMessage("Məhsul qiymətini qeyd edin")
               .Must(s => s >= 0)
                   .WithMessage("Məhsul qiymətini doğru qeyd edin!");
        }
    }
}

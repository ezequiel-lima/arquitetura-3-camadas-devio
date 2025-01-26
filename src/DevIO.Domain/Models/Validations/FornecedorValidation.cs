using DevIO.Domain.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Domain.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(x => x.TipoFornecedor == ETipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(x => x.Documento)
                    .Must(x => CpfValidacao.Validar(x))
                    .WithMessage("O {PropertyName} fornecido é inválido");
            });

            When(x => x.TipoFornecedor == ETipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(x => x.Documento)
                    .Must(x => CnpjValidacao.Validar(x)) 
                    .WithMessage("O {PropertyName} fornecido é inválido");
            });
        }
    }
}

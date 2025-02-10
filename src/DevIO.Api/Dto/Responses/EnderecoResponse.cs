using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.Dto.Responses
{
    public class EnderecoResponse
    {
        public Guid Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }

        public Guid FornecedorId { get; set; }
    }
}

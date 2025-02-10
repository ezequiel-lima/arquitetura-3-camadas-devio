using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.Dto.Responses
{
    public class FornecedorResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
    }
}

namespace DevIO.Domain.Models
{
    public class Fornecedor : Entity
    {
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public ETipoFornecedor TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
        public Endereco? Endereco { get; set; }
    }
}

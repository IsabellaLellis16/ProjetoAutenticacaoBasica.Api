namespace ProjetoAutenticacaoBasica.Api.Models.DTOs
{
    public class PassagemDto
    {
    }

    public class CriarPassagemDto
    {
        public int Id { get; set; }
        public int PassageiroId { get; set; }
        public int Assento { get; set; }
    }

    public class PassagemDetalhesDto
    {
        public int Id { get; set; }
        public int CodigoVoo { get; set; }
        public string Trajeto { get; set; }
        public string NomePassageiro { get; set; }
        public int Assento { get; set; }
    }
}

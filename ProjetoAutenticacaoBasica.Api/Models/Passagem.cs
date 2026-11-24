using System.Text.Json.Serialization;

namespace ProjetoAutenticacaoBasica.Api.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public int Assento { get; set; }
        public int VooId { get; set; }
        public int PassageiroId { get; set; }

        [JsonIgnore]
        public Voo ? Voo { get; set; }
        public Passageiro ? Passageiro { get; set; }
    }
}

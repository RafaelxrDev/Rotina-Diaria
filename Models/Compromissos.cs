namespace RotinaDiaria.Models
{
    public class Compromisso
    {
            public int Id { get;set; } //Identificador Unico do compromisso
            public string Nome { get; set; } = string.Empty;
            public string Tipo { get; set; } = string.Empty;
            public string Hora { get; set; } = string.Empty;
            public int Duracao { get;set; } //Duração em Minutos
      
    }
}
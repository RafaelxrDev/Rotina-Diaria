namespace RotinaDiaria.Models
{
    public class Compromissos
    {
        public int id { get;set; } //Identificador Unico do compromisso
        public string Nome { get;set; } //Nome do COmpromisso (ex: Treino de pernas)
        public string Tipo { get;set; } // Tipo: "Academia" "Refeição" " Estudo" 
        public string Hora { get;set; } // Horario (07:00)
        public int Duracao { get;set; } //Duração em Minutos
      
    }
}
namespace Domain.Entidades
{
    public class Tarefa
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public int Prioridade { get; private set; }
        public List<string> Etiquetas { get; private set; } = new List<string>();

        public Tarefa(string titulo, string descricao, DateTime dataVencimento, int prioridade, List<string> etiquetas)
        {
            Titulo = titulo ?? throw new ArgumentException(nameof(titulo));
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            Etiquetas = etiquetas;
        }

    }
}

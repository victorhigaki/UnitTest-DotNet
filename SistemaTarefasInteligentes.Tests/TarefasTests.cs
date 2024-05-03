using Domain.Entidades;

namespace SistemaTarefasInteligentes.Tests
{
    public class TarefasTests
    {
        [Fact]
        public void CriarTarefaComSucesso()
        {
            //Arrange
            var titulo = "Teste";
            var descricao = "Descrição";
            var dataVencimento = DateTime.Now;
            var prioridade = 1;
            var etiquetas = new List<string>() { "Teste1", "Teste2" };

            //Act
            var tarefa = new Tarefa(titulo, descricao, dataVencimento, prioridade, etiquetas);

            //Assert
            Assert.Equal(tarefa.Titulo, titulo);
            Assert.Equal(tarefa.Descricao, descricao);
            Assert.Equal(tarefa.DataVencimento, dataVencimento);
        }
    }
}
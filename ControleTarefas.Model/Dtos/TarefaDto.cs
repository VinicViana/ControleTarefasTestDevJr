namespace ControleTarefas.Model.Dtos
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public int Status { get; set; }
    }
}

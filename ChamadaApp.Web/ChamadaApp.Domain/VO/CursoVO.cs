namespace ChamadaApp.Domain.VO
{
    class CursoVO
    {
        public CursoVO()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public bool Ativo { get; set; }
    }
}

namespace ChamadaApp.Domain.VO
{
    class ModuloVO
    {
        public ModuloVO()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public bool Ativo { get; set; }
        public int CursoId { get; set; }
    }
}

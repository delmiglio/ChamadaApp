namespace ChamadaApp.Domain.VO
{
    class SitTurmaVO
    {
        public SitTurmaVO()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public bool Ativo { get; set; }
    }
}

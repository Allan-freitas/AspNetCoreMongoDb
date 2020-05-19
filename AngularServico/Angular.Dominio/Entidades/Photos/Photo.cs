namespace Angular.Dominio.Entidades.Photos
{
    public class Photo : EntidadeBase
    {
        public string Url { get; set; }

        public string Description { get; set; }
        
        public bool IsMain { get; set; }
    }
}

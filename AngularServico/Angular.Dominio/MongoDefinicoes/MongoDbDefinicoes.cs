namespace Angular.Dominio.MongoDefinicoes
{
    public class MongoDbDefinicoes : IMongoDbDefinicoes
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}

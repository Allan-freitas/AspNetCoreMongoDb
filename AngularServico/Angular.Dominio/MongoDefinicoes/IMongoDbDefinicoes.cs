namespace Angular.Dominio.MongoDefinicoes
{
    public interface IMongoDbDefinicoes
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}

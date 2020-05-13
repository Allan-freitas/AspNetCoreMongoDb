using Angular.Dominio.Entidades;
using Angular.Dominio.Interfaces.Repositorios;
using Angular.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Servicos
{
    public class ServicoBase<TDocument> : IServicoBase<TDocument> where TDocument : EntidadeBase
    {
        readonly IRepositorioBase<TDocument> _repositorioBase;

        public ServicoBase(IRepositorioBase<TDocument> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public IQueryable<TDocument> AsQueryable()
        {
            return _repositorioBase.AsQueryable();
        }

        public void DeleteById(string id)
        {
            _repositorioBase.DeleteById(id);
        }

        public Task DeleteByIdAsync(string id)
        {
            return _repositorioBase.DeleteByIdAsync(id);
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _repositorioBase.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _repositorioBase.DeleteManyAsync(filterExpression);
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            _repositorioBase.DeleteOne(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _repositorioBase.DeleteOneAsync(filterExpression);
        }

        public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _repositorioBase.FilterBy(filterExpression);
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _repositorioBase.FilterBy(filterExpression, projectionExpression);
        }

        public TDocument FindById(string id)
        {
            return _repositorioBase.FindById(id);
        }

        public Task<TDocument> FindByIdAsync(string id)
        {
            return _repositorioBase.FindByIdAsync(id);
        }

        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _repositorioBase.FindOne(filterExpression);
        }

        public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _repositorioBase.FindOneAsync(filterExpression);
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _repositorioBase.InsertMany(documents);
        }

        public Task InsertManyAsync(ICollection<TDocument> documents)
        {
            return _repositorioBase.InsertManyAsync(documents);
        }

        public void InsertOne(TDocument document)
        {
            _repositorioBase.InsertOne(document);
        }

        public Task InsertOneAsync(TDocument document)
        {
            return _repositorioBase.InsertOneAsync(document);
        }

        public void ReplaceOne(TDocument document)
        {
            _repositorioBase.ReplaceOne(document);
        }

        public Task ReplaceOneAsync(TDocument document)
        {
            return _repositorioBase.ReplaceOneAsync(document);
        }
    }
}

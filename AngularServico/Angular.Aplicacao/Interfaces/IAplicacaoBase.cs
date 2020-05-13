using Angular.Aplicacao.DTO;
using Angular.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Interfaces
{
    public interface IAplicacaoBase<TDocument, TDocumentDTO>
        where TDocument : EntidadeBase
        where TDocumentDTO : DTOBase
    {
        IList<TDocumentDTO> AsQueryable();

        IEnumerable<TDocumentDTO> FilterBy(Expression<Func<TDocumentDTO, bool>> filterExpression);

        IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocumentDTO, bool>> filterExpression, Expression<Func<TDocumentDTO, TProjected>> projectionExpression);

        TDocumentDTO FindOne(Expression<Func<TDocumentDTO, bool>> filterExpression);

        Task<TDocumentDTO> FindOneAsync(Expression<Func<TDocumentDTO, bool>> filterExpression);

        TDocumentDTO FindById(string id);

        Task<TDocumentDTO> FindByIdAsync(string id);

        void InsertOne(TDocumentDTO document);

        Task InsertOneAsync(TDocumentDTO document);

        void InsertMany(ICollection<TDocumentDTO> documents);

        Task InsertManyAsync(ICollection<TDocumentDTO> documents);

        void ReplaceOne(TDocumentDTO document);

        Task ReplaceOneAsync(TDocumentDTO document);

        void DeleteOne(Expression<Func<TDocumentDTO, bool>> filterExpression);

        Task DeleteOneAsync(Expression<Func<TDocumentDTO, bool>> filterExpression);

        void DeleteById(string id);

        Task DeleteByIdAsync(string id);

        void DeleteMany(Expression<Func<TDocumentDTO, bool>> filterExpression);

        Task DeleteManyAsync(Expression<Func<TDocumentDTO, bool>> filterExpression);
    }
}

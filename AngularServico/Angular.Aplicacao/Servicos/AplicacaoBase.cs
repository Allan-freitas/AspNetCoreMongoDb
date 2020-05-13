using Angular.Aplicacao.DTO;
using Angular.Aplicacao.Interfaces;
using Angular.Dominio.Entidades;
using Angular.Dominio.Interfaces.Servicos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Servicos
{
    public class AplicacaoBase<TDocument, TDocumentDTO> : IAplicacaoBase<TDocument, TDocumentDTO>
        where TDocument : EntidadeBase
        where TDocumentDTO : DTOBase
    {
        readonly IServicoBase<TDocument> _servicoBase;
        readonly IMapper _mapper;
        public AplicacaoBase(IMapper mapper, IServicoBase<TDocument> servicoBase)
        {
            _mapper = mapper;
            _servicoBase = servicoBase;
        }

        public IList<TDocumentDTO> AsQueryable()
        {
            return _mapper.Map<IList<TDocumentDTO>>(_servicoBase.AsQueryable().ToList());
        }
        public void DeleteById(string id)
        {
            _servicoBase.DeleteById(id);
        }
        public Task DeleteByIdAsync(string id)
        {
            return _servicoBase.DeleteByIdAsync(id);
        }
        public void DeleteMany(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            _servicoBase.DeleteMany(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression));
        }
        public Task DeleteManyAsync(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            return _servicoBase.DeleteManyAsync(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression));
        }
        public void DeleteOne(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            _servicoBase.DeleteOne(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression));
        }
        public Task DeleteOneAsync(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            return _servicoBase.DeleteOneAsync(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression));
        }
        public IEnumerable<TDocumentDTO> FilterBy(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            return _mapper.Map<IEnumerable<TDocumentDTO>>(_servicoBase.FilterBy(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression)));
        }
        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocumentDTO, bool>> filterExpression, Expression<Func<TDocumentDTO, TProjected>> projectionExpression)
        {
            return _servicoBase.FilterBy(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression), _mapper.Map<Expression<Func<TDocument, TProjected>>>(projectionExpression));
        }
        public TDocumentDTO FindById(string id)
        {
            return _mapper.Map<TDocumentDTO>(_servicoBase.FindById(id));
        }
        public Task<TDocumentDTO> FindByIdAsync(string id)
        {
            return _mapper.Map<Task<TDocumentDTO>>(_servicoBase.FindById(id));
        }
        public TDocumentDTO FindOne(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            return _mapper.Map<TDocumentDTO>(_servicoBase.FindOne(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression)));
        }
        public Task<TDocumentDTO> FindOneAsync(Expression<Func<TDocumentDTO, bool>> filterExpression)
        {
            return _mapper.Map<Task<TDocumentDTO>>(_servicoBase.FindOneAsync(_mapper.Map<Expression<Func<TDocument, bool>>>(filterExpression)));
        }
        public void InsertMany(ICollection<TDocumentDTO> documents)
        {
            _servicoBase.InsertMany(_mapper.Map<ICollection<TDocument>>(documents));
        }
        public Task InsertManyAsync(ICollection<TDocumentDTO> documents)
        {
            return _servicoBase.InsertManyAsync(_mapper.Map<ICollection<TDocument>>(documents));
        }
        public void InsertOne(TDocumentDTO document)
        {
            _servicoBase.InsertOne(_mapper.Map<TDocument>(document));
        }
        public Task InsertOneAsync(TDocumentDTO document)
        {
            return _servicoBase.InsertOneAsync(_mapper.Map<TDocument>(document));
        }
        public void ReplaceOne(TDocumentDTO document)
        {
            _servicoBase.ReplaceOne(_mapper.Map<TDocument>(document));
        }
        public Task ReplaceOneAsync(TDocumentDTO document)
        {
            return _servicoBase.ReplaceOneAsync(_mapper.Map<TDocument>(document));
        }
    }
}

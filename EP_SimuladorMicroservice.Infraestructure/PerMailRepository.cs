using Dapper;
using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using EP_SimuladorMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Infraestructure
{
    [Export(typeof(IPerMailRepository))]
    public class PerMailRepository : BaseRepository, IPerMailRepository
    {
        #region Constructor
        [ImportingConstructor]
        public PerMailRepository(IConnectionFactory cn) : base(cn)
        {

        }
        #endregion
        #region Public Methods
        public long Insert(PerMailEntity item)
        {
            long id = 0;
            var query = "SP_PerMailCreate";
            var param = new DynamicParameters();
            param.Add("@cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@nPerMaiTipo", item.nPerMaiTipo, System.Data.DbType.Int32);
            param.Add("@cPerMaiNombre", item.cPerMaiNombre, System.Data.DbType.String);
            param.Add("@nPerEstado", item.nPerEstado, System.Data.DbType.Int32);
            param.Add("@dPerMaiFecRegistro", item.dPerMaiFecRegistro, System.Data.DbType.DateTime);
            id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query,
                param, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }

        public bool Update(PerMailEntity item)
        {
            var query = "SP_PerMailEdit";
            var param = new DynamicParameters();
            param.Add("@cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@nPerMaiTipo", item.nPerMaiTipo, System.Data.DbType.Int32);
            param.Add("@cPerMaiNombre", item.cPerMaiNombre, System.Data.DbType.String);
            param.Add("@nPerEstado", item.nPerEstado, System.Data.DbType.Int32);
            param.Add("@dPerMaiFecRegistro", item.dPerMaiFecRegistro, System.Data.DbType.DateTime);
            param.Add("@nuevoPerMaiTipo", item.nuevoPerMaiTipo, System.Data.DbType.String);
            return (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure) > 0;
        }
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool delete(string cPerCodigo, string cPerMaiNombre)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "SP_PerMailDelete";
            var param = new DynamicParameters();
            param.Add("@cPerCodigo", cPerCodigo);
            param.Add("@cPerMaiNombre", cPerMaiNombre);
            regAfectados = (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure);
            exito = regAfectados > 0;
            return exito;
        }

        public PerMailEntity GetItem(PerMailFilter filter, PerMailFilterItemType filterType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PerMailEntity> GetLstItem(PerMailFilter filter, PerMailFilterListType filterType, Pagination pagination)
        {
            int rowTotal = 0;
            IEnumerable<PerMailEntity> lstItemFound = new List<PerMailEntity>();
            switch (filterType)
            {
                case PerMailFilterListType.BycPerCodigo:
                    lstItemFound = this.getByList(filter.cPerCodigo);
                    break;
                //case PerMailFilterListType.ByListID:
                //    lstItemFound = this.ByListID(filter.nConstCodigo);
                //    break;
                default:
                    break;
            }
            return lstItemFound;
        }

        #endregion
        #region Private Methods Item
        private IEnumerable<PerMailEntity> getByList(string cPerCodigo)
        {
            IEnumerable<PerMailEntity> lstfound = new List<PerMailEntity>();
            var query = "SP_PerMailGet";
            var param = new DynamicParameters();
            param.Add("@cPerCodigo", cPerCodigo);
            lstfound = SqlMapper.Query<PerMailEntity>(this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }
        #endregion
    }
}

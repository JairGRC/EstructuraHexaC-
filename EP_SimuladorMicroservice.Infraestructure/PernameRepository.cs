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
    [Export(typeof(IPernameRepository))]
    public class PernameRepository : BaseRepository, IPernameRepository
    {
        #region Constructor
        [ImportingConstructor]
        public PernameRepository(IConnectionFactory cn) : base(cn)
        {

        }
        #endregion
        #region Public Methods
        public long Insert(PernameEntity item)
        {
            long id = 0;
            var query = "USP_Pername_Create";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_dPerFecEfectiva", item.dPerFecEfectiva, System.Data.DbType.DateTime);
            param.Add("@MP_cPerApellPaterno", item.cPerApellPaterno, System.Data.DbType.String);
            param.Add("@MP_cPerApellMaterno", item.cPerApellMaterno, System.Data.DbType.String);
            param.Add("@MP_cPerPriNombre", item.cPerPriNombre, System.Data.DbType.String);
            param.Add("@MP_cPerSegNombre", item.cPerSegNombre, System.Data.DbType.String);
            param.Add("@MP_cPerTerNombre", item.cPerTerNombre, System.Data.DbType.String);
            param.Add("@MP_nPerTratamiento", item.nPerTratamiento, System.Data.DbType.Int32);
            id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query,
                param, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "USP_Pername_Delete";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", id);
            regAfectados = (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure);
            exito = regAfectados > 0;
            return exito;
        }
        public bool Update(PernameEntity item)
        {
            var query = "USP_Pername_Update";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_dPerFecEfectiva", item.dPerFecEfectiva, System.Data.DbType.DateTime);
            param.Add("@MP_cPerApellPaterno", item.cPerApellPaterno, System.Data.DbType.String);
            param.Add("@MP_cPerApellMaterno", item.cPerApellMaterno, System.Data.DbType.String);
            param.Add("@MP_cPerPriNombre", item.cPerPriNombre, System.Data.DbType.String);
            param.Add("@MP_cPerSegNombre", item.cPerSegNombre, System.Data.DbType.String);
            param.Add("@MP_cPerTerNombre", item.cPerTerNombre, System.Data.DbType.String);
            param.Add("@MP_nPerTratamiento", item.nPerTratamiento, System.Data.DbType.Int32);
            return (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure) > 0;
        }
        public PernameEntity GetItem(PernameFilter filter, PernameFilterItemType filterType)
        {
            PernameEntity itemfound = null;
            switch (filterType)
            {
                case PernameFilterItemType.Undefined:
                    break;
                case PernameFilterItemType.BycPerCodigo:
                    itemfound = this.BycPerCodigo(filter.nConstCodigo);
                    break;
                //case PernameFilterItemType.ByList:
                //    //itemfound = this.BycPerList();
                //    break;
                default:
                    break;
            }
            return itemfound;
        }

        public IEnumerable<PernameEntity> GetLstItem(PernameFilter filter, PernameFilterListType filterType, Pagination pagination)
        {
            int rowTotal = 0;
            IEnumerable<PernameEntity> lstItemFound = new List<PernameEntity>();
            switch (filterType)
            {
                case PernameFilterListType.ByList:
                    lstItemFound = this.getByList();
                    break;
                case PernameFilterListType.ByListID:
                    lstItemFound = this.ByListID(filter.nConstCodigo);
                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion
        #region Private Methods Item
        private IEnumerable<PernameEntity> getByList()
        {
            IEnumerable<PernameEntity> lstfound = new List<PernameEntity>();
            var query = "USP_Pername_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", null);
            lstfound = SqlMapper.Query<PernameEntity>(this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }
        private PernameEntity BycPerCodigo(string nConstCodigo)
        {
            PernameEntity itemfound = null;
            var query = "USP_Pername_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", nConstCodigo);
            itemfound = SqlMapper.QueryFirstOrDefault<PernameEntity>
                (this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return itemfound;
        }
        private IEnumerable<PernameEntity> ByListID(string nConstCodigo)
        {
            IEnumerable<PernameEntity> lstfound = new List<PernameEntity>();
            var query = "USP_Pername_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", nConstCodigo);
            lstfound = SqlMapper.Query<PernameEntity>(this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }
        #endregion
    }
}

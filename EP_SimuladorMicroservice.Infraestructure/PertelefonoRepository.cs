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
    [Export(typeof(IPertelefonoRepository))]
    class PertelefonoRepository:BaseRepository,IPertelefonoRepository
    {
        #region Constructor
        [ImportingConstructor]
        public PertelefonoRepository(IConnectionFactory cn) : base(cn)
        {

        }
        #endregion
        #region Public Methods
        public long Insert(PertelefonoEntity item)
        {
            long id = 0;
            var query = "USP_Pertelefono_Create";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_nPerTelTipo", item.nPerTelTipo, System.Data.DbType.Int32);
            param.Add("@MP_cPerTelNumero", item.cPerTelNumero, System.Data.DbType.String);
            param.Add("@MP_nPerTelStatus", item.nPerTelStatus, System.Data.DbType.Int32);
            param.Add("@MP_dPerTelFecRegistro", item.dPerTelFecRegistro, System.Data.DbType.DateTime);
            id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query,
                param, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }
        public bool Delete(string id)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "USP_Pertelefono_Delete";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", id);
            regAfectados = (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure);
            exito = regAfectados > 0;
            return exito;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }
        public bool Update(PertelefonoEntity item)
        {
            var query = "USP_Pertelefono_Update";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_nPerTelTipo", item.nPerTelTipo, System.Data.DbType.Int32);
            param.Add("@MP_cPerTelNumero", item.cPerTelNumero, System.Data.DbType.String);
            param.Add("@MP_nPerTelStatus", item.nPerTelStatus, System.Data.DbType.Int32);
            param.Add("@MP_dPerTelFecRegistro", item.dPerTelFecRegistro, System.Data.DbType.DateTime);
            return (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure) > 0;
        }


        //public PertelefonoEntity GetItem(PertelefonoFilter filter, PertelefonoFilterItemType filterType)
        //{
        //    PertelefonoEntity itemfound = null;
        //    switch (filterType)
        //    {
        //        case PertelefonoFilterItemType.Undefined:
        //            break;
        //        case PertelefonoFilterItemType.BycPerCodigo:
        //            itemfound = this.BycPerCodigo(filter.nConstCodigo);
        //            break;
        //        //case PertelefonoFilterItemType.ByList:
        //        //    //itemfound = this.BycPerList();
        //        //    break;
        //        default:
        //            break;
        //    }
        //    return itemfound;
        //}

        public IEnumerable<PertelefonoEntity> GetLstItem(PertelefonoFilter filter, PertelefonoFilterListType filterType, Pagination pagination)
        {
            int rowTotal = 0;
            IEnumerable<PertelefonoEntity> lstItemFound = new List<PertelefonoEntity>();
            switch (filterType)
            {
                case PertelefonoFilterListType.ByList:
                    lstItemFound = this.getByList();
                    break;
                case PertelefonoFilterListType.BycPerCodigo:
                    lstItemFound = this.BycPerCodigo(filter.nConstCodigo);
                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion
        #region Private Methods Item
        private IEnumerable<PertelefonoEntity> getByList()
        {
            IEnumerable<PertelefonoEntity> lstfound = new List<PertelefonoEntity>();
            var query = "USP_Pertelefono_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", null);
            lstfound = SqlMapper.Query<PertelefonoEntity>(this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }
        private IEnumerable<PertelefonoEntity> BycPerCodigo(string nConstCodigo)
        {
            IEnumerable<PertelefonoEntity> lstfound = new List<PertelefonoEntity>();
            var query = "USP_Pertelefono_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", nConstCodigo);
            lstfound = SqlMapper.Query<PertelefonoEntity>
                (this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }

        public PertelefonoEntity GetItem(PertelefonoFilter filter, PertelefonoFilterItemType filterType)
        {
            throw new NotImplementedException();
        }
        //private IEnumerable PertelefonoEntity BycPerList()
        //{
        //    IEnumerable<PertelefonoEntity> itemfound = new List<PertelefonoEntity>();
        //    //PertelefonoEntity itemfound = null;
        //    var query = "USP_Pertelefono_Get";
        //    var param = new DynamicParameters();
        //    param.Add("@MP_cPerCodigo", null);
        //    itemfound = SqlMapper.Query<PertelefonoEntity>
        //        (this._connectionFactory.GetConnection, query, param,
        //        commandType: System.Data.CommandType.StoredProcedure);
        //    return itemfound;
        //}
        #endregion

    }
}

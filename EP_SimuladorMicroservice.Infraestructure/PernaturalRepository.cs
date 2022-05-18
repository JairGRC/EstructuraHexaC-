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
    [Export(typeof(IPernaturalRepository))]
    class PernaturalRepository:BaseRepository,IPernaturalRepository
    {
        #region Constructor
        [ImportingConstructor]
        public PernaturalRepository(IConnectionFactory cn) : base(cn)
        {

        }
        #endregion
        #region Public Methods
        public long Insert(PernaturalEntity item)
        {
            long id = 0;
            var query = "USP_Pernatural_Create";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_nPerNatSexo", item.nPerNatSexo, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatEstCivil", item.nPerNatEstCivil, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatTipResidencia", item.nPerNatTipResidencia, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatSitLaboral", item.nPerNatSitLaboral, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatOcupacion", item.nPerNatOcupacion, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatCondicion", item.nPerNatCondicion, System.Data.DbType.Int32);
            param.Add("@MP_dPerFecEfectiva", item.dPerFecEfectiva, System.Data.DbType.DateTime);
            id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query,
                param, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }
        public bool Delete(string id)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "USP_Pernatural_Delete";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", id);
            regAfectados = (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure);
            exito = regAfectados > 0;
            return exito;
        }
        public bool Update(PernaturalEntity item)
        {
            var query = "USP_Pernatural_Update";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_nPerNatSexo", item.nPerNatSexo, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatEstCivil", item.nPerNatEstCivil, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatTipResidencia", item.nPerNatTipResidencia, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatSitLaboral", item.nPerNatSitLaboral, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatOcupacion", item.nPerNatOcupacion, System.Data.DbType.Int32);
            param.Add("@MP_nPerNatCondicion", item.nPerNatCondicion, System.Data.DbType.Int32);
            param.Add("@MP_dPerFecEfectiva", item.dPerFecEfectiva, System.Data.DbType.DateTime);
            return (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure) > 0;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        

        public PernaturalEntity GetItem(PernaturalFilter filter, PernaturalFilterItemType filterType)
        {
            PernaturalEntity itemfound = null;
            switch (filterType)
            {
                case PernaturalFilterItemType.Undefined:
                    break;
                case PernaturalFilterItemType.BycPerCodigo:
                    itemfound = this.BycPerCodigo(filter.nConstCodigo);
                    break;
                //case PernaturalFilterItemType.ByList:
                //    //itemfound = this.BycPerList();
                //    break;
                default:
                    break;
            }
            return itemfound;
        }

        public IEnumerable<PernaturalEntity> GetLstItem(PernaturalFilter filter, PernaturalFilterListType filterType, Pagination pagination)
        {
            //int rowTotal = 0;
            IEnumerable<PernaturalEntity> lstItemFound = new List<PernaturalEntity>();
            switch (filterType)
            {
                case PernaturalFilterListType.ByList:
                    lstItemFound = this.getByList();
                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion
        #region  Private Methods Item
        private IEnumerable<PernaturalEntity> getByList()
        {
            IEnumerable<PernaturalEntity> lstfound = new List<PernaturalEntity>();
            var query = "USP_Pernatural_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", null);
            lstfound = SqlMapper.Query<PernaturalEntity>(this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }
        private PernaturalEntity BycPerCodigo(string nConstCodigo)
        {
            PernaturalEntity itemfound = null;
            var query = "USP_Pernatural_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", nConstCodigo);
            itemfound = SqlMapper.QueryFirstOrDefault<PernaturalEntity>
                (this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return itemfound;
        }
        //private IEnumerable PernaturalEntity BycPerList()
        //{
        //    IEnumerable<PernaturalEntity> itemfound = new List<PernaturalEntity>();
        //    //PernaturalEntity itemfound = null;
        //    var query = "USP_Pernatural_Get";
        //    var param = new DynamicParameters();
        //    param.Add("@MP_cPerCodigo", null);
        //    itemfound = SqlMapper.Query<PernaturalEntity>
        //        (this._connectionFactory.GetConnection, query, param,
        //        commandType: System.Data.CommandType.StoredProcedure);
        //    return itemfound;
        //}
        #endregion
    }
}

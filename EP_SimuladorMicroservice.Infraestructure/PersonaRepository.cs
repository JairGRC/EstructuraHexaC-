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
    [Export(typeof(IPersonaRepository))]
    public class PersonaRepository:BaseRepository,IPersonaRepository
    {
        #region Constructor
        [ImportingConstructor]
        public PersonaRepository(IConnectionFactory cn) : base(cn)
        {

        }
        #endregion
        #region Public Methods
        public long Insert(PersonaEntity item)
        {
            long id = 0;
            var query = "USP_Persona_Create";
            var param = new DynamicParameters();
            //param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_CPerApellido", item.cPerApellido, System.Data.DbType.String);
            param.Add("@MP_CPerApellPat", item.cPerApellPat, System.Data.DbType.String);
            param.Add("@MP_cPerNombre", item.cPerNombre, System.Data.DbType.String);
            param.Add("@MP_dPerNacimiento", item.dPerNacimiento, System.Data.DbType.DateTime);
            param.Add("@MP_nPerTipo", item.nPerTipo, System.Data.DbType.Int32);
            param.Add("@MP_nPerEstado", item.nPerEstado, System.Data.DbType.Int32);
            param.Add("@MP_cUbiGeoCodigo", item.cUbiGeoCodigo, System.Data.DbType.String);
            param.Add("@MP_nUbiGeoCodigo", item.nUbiGeoCodigo, System.Data.DbType.Int32);
            id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query,
                param, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }
        public bool Delete(string id)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "USP_Persona_Delete";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", id);
            regAfectados = (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query,param,commandType:System.Data.CommandType.StoredProcedure);
            exito = regAfectados > 0;
            return exito;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }
        public bool Update(PersonaEntity item)
        {
            var query = "USP_Persona_Update";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", item.cPerCodigo, System.Data.DbType.String);
            param.Add("@MP_CPerApellido", item.cPerApellido, System.Data.DbType.String);
            param.Add("@MP_CPerApellPat", item.cPerApellPat, System.Data.DbType.String);
            param.Add("@MP_cPerNombre", item.cPerNombre, System.Data.DbType.String);
            param.Add("@MP_dPerNacimiento", item.dPerNacimiento, System.Data.DbType.DateTime);
            param.Add("@MP_nPerTipo", item.nPerTipo, System.Data.DbType.Int32);
            param.Add("@MP_nPerEstado", item.nPerEstado, System.Data.DbType.Int32);
            param.Add("@MP_cUbiGeoCodigo", item.cUbiGeoCodigo, System.Data.DbType.String);
            param.Add("@MP_nUbiGeoCodigo", item.nUbiGeoCodigo, System.Data.DbType.Int32);
            return (int)SqlMapper.Execute(this._connectionFactory.GetConnection,
                query, param, commandType: System.Data.CommandType.StoredProcedure)>0;
        }
        

        

        public PersonaEntity GetItem(PersonaFilter filter, PersonaFilterItemType filterType)
        {
            PersonaEntity itemfound = null;
            switch(filterType)
            {
                case PersonaFilterItemType.Undefined:
                    break;
                case PersonaFilterItemType.BycPerCodigo:
                    itemfound = this.BycPerCodigo(filter.nConstCodigo);
                    break;
                //case PersonaFilterItemType.ByList:
                //    //itemfound = this.BycPerList();
                //    break;
                default:
                    break;
            }
            return itemfound;
        }

        public IEnumerable<PersonaEntity> GetLstItem(PersonaFilter filter, PersonaFilterListType filterType, Pagination pagination)
        {
            int rowTotal = 0;
            IEnumerable<PersonaEntity> lstItemFound = new List<PersonaEntity>();
            switch(filterType)
            {
                case PersonaFilterListType.ByList:
                    lstItemFound = this.getByList();
                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion
        #region Private Methods Item
        private IEnumerable<PersonaEntity> getByList()
        {
            IEnumerable<PersonaEntity> lstfound = new List<PersonaEntity>();
            var query = "USP_Persona_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", null);
            lstfound = SqlMapper.Query<PersonaEntity>(this._connectionFactory.GetConnection, query, param,
                commandType: System.Data.CommandType.StoredProcedure);
            return lstfound;
        }
        private PersonaEntity BycPerCodigo(string nConstCodigo)
        {
            PersonaEntity itemfound = null;
            var query = "USP_Persona_Get";
            var param = new DynamicParameters();
            param.Add("@MP_cPerCodigo", nConstCodigo);
            itemfound = SqlMapper.QueryFirstOrDefault<PersonaEntity>
                (this._connectionFactory.GetConnection, query, param, 
                commandType: System.Data.CommandType.StoredProcedure);
            return itemfound;
        }
        //private IEnumerable PersonaEntity BycPerList()
        //{
        //    IEnumerable<PersonaEntity> itemfound = new List<PersonaEntity>();
        //    //PersonaEntity itemfound = null;
        //    var query = "USP_Persona_Get";
        //    var param = new DynamicParameters();
        //    param.Add("@MP_cPerCodigo", null);
        //    itemfound = SqlMapper.Query<PersonaEntity>
        //        (this._connectionFactory.GetConnection, query, param,
        //        commandType: System.Data.CommandType.StoredProcedure);
        //    return itemfound;
        //}
        #endregion
    }
}

using System;
using System.Collections.Generic;
using EP_SimuladorMicroservice.Repository;
using Dapper;
using EP_SimuladorMicroservice.Entities;
using System.Linq;
using System.Data;
using System.Composition;
namespace EP_SimuladorMicroservice.Infraestructure
{
[Export(typeof(IInterfaceRepository))]
public class InterfaceRepository : BaseRepository, IInterfaceRepository
{
#region Constructor
[ImportingConstructor]
public InterfaceRepository(IConnectionFactory cn) : base(cn)
{
}
#endregion
#region Public Methods
public long Insert(InterfaceEntity item)
{
long id = 0;
var query = "usp_Interface_Insert";
var param = new DynamicParameters();
id = (long)SqlMapper.ExecuteScalar(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
return id;
}
     regAfectados = (int)SqlMapper.ExecuteScalar(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
     exito = regAfectados > 0;
     return exito;
 }
 public bool Delete(string id)
 {
      throw new NotImplementedException();
}
public bool Update(InterfaceEntity item)
{
    var query = "usp_Interface_Update";
    var param = new DynamicParameters();
    return (int)SqlMapper.ExecuteScalar(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure)>0;
}


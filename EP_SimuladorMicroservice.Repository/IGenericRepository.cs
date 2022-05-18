using System;
using System.Collections.Generic;
using System.Text;

namespace EP_SimuladorMicroservice.Repository
{
    public interface IGenericRepository<T> where T: class
    {   
        bool Update(T item);
        bool Delete(string id);
        
   }
}

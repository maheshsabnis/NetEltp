using CS_Gen_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Gen_App.Models
{
    /// <summary>
    /// The 'in' means input parameter 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IDbOperations<TEntity, in TPk> where TEntity : Staff
    {
        List<TEntity> GetAll();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id,TEntity entity);
        TEntity Delete(TPk id); 
    }
}

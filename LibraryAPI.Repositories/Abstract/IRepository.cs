using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Abstract
{
  public interface IRepository<T>
  {
    Task<List<T>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<T> GetById(int Id);
  }
}

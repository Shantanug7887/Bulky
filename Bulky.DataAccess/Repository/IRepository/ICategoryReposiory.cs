using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
  public interface ICategoryReposiory : IRepository<Category>
    {
        void Update(Category obj);
        
        // Additional methods specific to Category can be added here if needed
    }
}

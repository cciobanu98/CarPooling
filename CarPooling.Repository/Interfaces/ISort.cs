using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface ISort<TEntity>
    {
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetSortFunc(string sort);
    }
}

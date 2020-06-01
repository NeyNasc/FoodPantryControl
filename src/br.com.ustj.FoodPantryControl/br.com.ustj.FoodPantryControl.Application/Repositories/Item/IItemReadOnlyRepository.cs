using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace br.com.ustj.FoodPantryControl.Application.Repositories.Item
{
    public interface IItemReadOnlyRepository
    {
        Domain.Item.Item GetItemRepository(Expression<Func<Domain.Item.Item, bool>> expression);
       List<Domain.Item.Item> GetAllItemRepository();
    }
}

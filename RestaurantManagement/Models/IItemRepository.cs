using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public interface IItemRepository
    {
        ItemModel GetItem(int id);

        IEnumerable<ItemModel> GetAllItem();

        ItemModel Add(ItemModel item);

        ItemModel UpdateItem(ItemModel itemChanges);
        ItemModel Delete(int id);
    }
}

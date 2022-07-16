namespace RestaurantManagement.Models
{
    public class SQLItemRepository : IItemRepository
    {
        private readonly AppDbContext context;
        public SQLItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ItemModel Delete(int id)
        {
            ItemModel item = context.itemModels.Find(id);
            if(item != null)
            {
                context.itemModels.Remove(item);
                context.SaveChanges();
            }
            return item;
        }

        public ItemModel UpdateItem(ItemModel itemChanges)
        {
            var item = context.itemModels.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return itemChanges;
        }

        public IEnumerable<ItemModel> GetAllItem()
        {
            return context.itemModels;
        }

        public ItemModel GetItem(int id)
        {
            return context.itemModels.Find(id);
        }

        public  ItemModel Add(ItemModel item)
        {
            context.itemModels.Add(item);
            context.SaveChanges();
            return item;
        }
    }
}

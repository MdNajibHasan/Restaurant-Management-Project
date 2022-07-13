namespace RestaurantManagement.Models
{
    public class SQLItemRepository : IItemRepository
    {
        private readonly AppDbContext context;
        public SQLItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        /*public ItemModel Update(ItemModel itemChanges)
        {
            var item = context.itemModels.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return itemChanges;
        }*/

        public IEnumerable<ItemModel> GetAllItem()
        {
            return context.itemModels;
        }

        public ItemModel GetItem(int id)
        {
            return context.itemModels.Find(id);
        }
    }
}

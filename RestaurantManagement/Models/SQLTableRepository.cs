namespace RestaurantManagement.Models
{
    public class SQLTableRepository : ITableRepository
    {

        private readonly AppDbContext context;
        public SQLTableRepository(AppDbContext context)
        {
            this.context = context;
        }


        public TableModel Add(TableModel item)
        {
            context.tableModels.Add(item);
            context.SaveChanges();
            return item;
        }

        public TableModel Delete(int id)
        {
            TableModel item = context.tableModels.Find(id);
            if (item != null)
            {
                context.tableModels.Remove(item);
                context.SaveChanges();
            }
            return item;
        }

        public IEnumerable<TableModel> GetAllItem()
        {
            return context.tableModels;
        }

        public TableModel GetItem(int id)
        {
            return context.tableModels.Find(id);
        }

        public TableModel UpdateItem(TableModel itemChanges)
        {
            var item = context.tableModels.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return itemChanges;
        }
    }
}

namespace RestaurantManagement.Models
{
    public interface ITableRepository
    {
        TableModel GetItem(int id);

        IEnumerable<TableModel> GetAllItem();

        TableModel Add(TableModel item);

        TableModel UpdateItem(TableModel itemChanges);
        TableModel Delete(int id);
    }
}

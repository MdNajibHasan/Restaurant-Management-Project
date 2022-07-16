namespace RestaurantManagement.Models
{
    public interface IOrderStatusRepository
    {
        OrderStatusModel GetOrderStatus(int id);

        IEnumerable<OrderStatusModel> GetAllOrderStatus();

        OrderStatusModel Add(OrderStatusModel item);

        OrderStatusModel UpdateOrderStatus(OrderStatusModel orderStatusChanges);
        OrderStatusModel DeleteOrder(int id);
    }
}

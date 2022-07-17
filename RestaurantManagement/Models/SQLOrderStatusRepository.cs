namespace RestaurantManagement.Models
{
    public class SQLOrderStatusRepository : IOrderStatusRepository
    {
        private readonly AppDbContext context;

        public SQLOrderStatusRepository(AppDbContext context)
        {
            this.context = context;
        }


        public OrderStatusModel Add(OrderStatusModel item)
        {
            context.orderStatusModels.Add(item);
            context.SaveChanges();
            return item;
        }

        public OrderStatusModel DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderStatusModel> GetAllOrderStatus()
        {
            return context.orderStatusModels;
        }

        public OrderStatusModel GetOrderStatus(int id)
        {
            return context.orderStatusModels.Find(id);
        }

        public OrderStatusModel UpdateOrderStatus(OrderStatusModel orderStatusChanges)
        {
            throw new NotImplementedException();
        }
    }
}

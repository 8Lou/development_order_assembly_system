namespace OrderAssemblySystem
{
    public class OrderManager
    {
        public string CancelOrder(int orderId)
        {
            // Логика отмены заказа, помечение его как отмененный в базе данных
            OrderManager orderManager = new OrderManager();
            int orderIdToCancel = 123; // Пример ID отменяемого заказа
            string cancelResult = orderManager.CancelOrder(orderIdToCancel);
            return "Заказ успешно отменен.";
        }
    }
}

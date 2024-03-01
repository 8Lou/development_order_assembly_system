namespace OrderAssemblySystem
{
    public class ReportManager
    {
        public void GenerateOrderReport(int orderId)
        {
            // Логика генерации отчета по конкретному заказу
            ReportManager reportManager = new ReportManager();
            int orderIdForReport = 789; // Пример ID заказа для отчета
            reportManager.GenerateOrderReport(orderIdForReport);
        }
    }
}

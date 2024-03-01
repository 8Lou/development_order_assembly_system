namespace OrderAssemblySystem
{
    public class InventoryManager
    {
        public void UpdateInventory(int inventoryId, int newQuantity)
        {
            // Логика обновления остатков запчастей на складе
            InventoryManager inventoryManager = new InventoryManager();
            int inventoryIdToUpdate = 456; // Пример ID запчасти на складе
            int newQuantity = 20; // Новое количество запчастей
            inventoryManager.UpdateInventory(inventoryIdToUpdate, newQuantity);
            // Действия после обновления остатков
        }
    }
}

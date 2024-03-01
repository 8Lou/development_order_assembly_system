using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            // Загрузка информации о свободных остатках на сборочных площадках из базы данных
            // Пример загрузки данных из базы данных и отображения в DataGridView
            // dgvInventory.Rows.Add("Сборочная площадка 1", "Запчасть A", 10);

                DatabaseManager dbManager = new DatabaseManager();
                DataTable inventoryTable = dbManager.LoadInventoryData();

                dgvInventory.DataSource = inventoryTable;
        }
    }
}

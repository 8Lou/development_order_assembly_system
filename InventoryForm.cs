using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            // Загрузка информации о свободных остатках на сборочных площадках из базы данных
            // Пример загрузки данных из базы данных в DataGridView
            dgvInventory.Rows.Add("Сборочная площадка 1", "Запчасть A", 10);
            dgvInventory.Rows.Add("Сборочная площадка 1", "Запчасть B", 5);
            dgvInventory.Rows.Add("Сборочная площадка 2", "Комплект X", 2);
        }
    }
}

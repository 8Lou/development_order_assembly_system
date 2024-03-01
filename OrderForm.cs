using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class OrderForm : Form
    {
        private DatabaseManager dbManager;
        public OrderForm()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            LoadNomenclatureData();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string nomenclatureName = cboNomenclature.SelectedItem.ToString();
            int quantity = (int)numQuantity.Value;

            try
            {
                dbManager.AddOrderItem(nomenclatureName, quantity);
                MessageBox.Show($"Добавлена номенклатура: {nomenclatureName}, в количестве: {quantity}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении номенклатуры в заказ: {ex.Message}");
            }

            //DatabaseManager dbManager = new DatabaseManager();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            // Добавить логику для сохранения заказа в базе данных
                        try
            {
                // Логика для сохранения всего заказа
                MessageBox.Show("Заказ сохранен");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении заказа: {ex.Message}");
            }
        }
    private void LoadNomenclatureData()
        {
            try
            {
                // Логика загрузки доступных номенклатур из базы данных
                cboNomenclature.Items.Add("Запчасть 1");
                cboNomenclature.Items.Add("Запчасть 2");
                cboNomenclature.Items.Add("Комплект 1");
                cboNomenclature.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке номенклатур: {ex.Message}");
            }
        }
    }
}
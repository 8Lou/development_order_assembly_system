using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            LoadNomenclatureData();
        }

        private void LoadNomenclatureData()
        {
            cboNomenclature.Items.Add("Запчасть 1");
            cboNomenclature.Items.Add("Запчасть 2");
            cboNomenclature.Items.Add("Комплект 1");
            cboNomenclature.SelectedIndex = 0;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string nomenclatureName = cboNomenclature.SelectedItem.ToString();
            int quantity = (int)numQuantity.Value;

            // Добавить логику для сохранения номенклатуры в заказ в базе данных
            // Пример: добавление номенклатуры в заказ
            MessageBox.Show($"Добавлена номенклатура: {nomenclatureName}, в количестве: {quantity}");
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            // Добавить логику для сохранения заказа в базе данных
            MessageBox.Show("Заказ сохранен");
        }
    }
}

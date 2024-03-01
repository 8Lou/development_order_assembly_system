using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Добавление выбранного товара в заказ
            string nomenclatureName = cboNomenclature.SelectedItem.ToString();
            int quantity = (int)numQuantity.Value;

            // Добавление данных в базу данных или другое действие
            // Пример добавления номенклатуры в заказ
            MessageBox.Show($"Добавлена номенклатура: {nomenclatureName}, в количестве: {quantity}");
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            // Сохранение заказа в базе данных или другое действие
            MessageBox.Show("Заказ сохранен");
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Загрузка доступных номенклатур
            cboNomenclature.Items.Add("Запчасть 1");
            cboNomenclature.Items.Add("Запчасть 2");
            cboNomenclature.Items.Add("Комплект 1");
            cboNomenclature.SelectedIndex = 0;
        }
    }
}


using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class AssemblyPlanningForm : Form
    {
        public AssemblyPlanningForm()
        {
            InitializeComponent();
        }

        private void btnPlanAssembly_Click(object sender, EventArgs e)
        {
            // Логика планирования сборки
            string assemblySite = cboAssemblySite.SelectedItem.ToString();
            string nomenclature = cboNomenclature.SelectedItem.ToString();
            int quantity = (int)numQuantity.Value;

            // Ваша логика для планирования сборок - просто пример
            MessageBox.Show($"Запланирована сборка для {assemblySite} номенклатуры {nomenclature} в количестве {quantity}");
        }

        private void AssemblyPlanningForm_Load(object sender, EventArgs e)
        {
            // Загрузка доступных площадок и номенклатур для планирования сборок
            cboAssemblySite.Items.Add("Сборочная площадка 1");
            cboAssemblySite.Items.Add("Сборочная площадка 2");
            cboAssemblySite.SelectedIndex = 0;

            cboNomenclature.Items.Add("Запчасть А");
            cboNomenclature.Items.Add("Комплект X");
            cboNomenclature.SelectedIndex = 0;
        }
    }
}

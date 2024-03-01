using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    public partial class AssemblyPlanningForm : Form
    {
                private DatabaseManager dbManager;

        public AssemblyPlanningForm()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            LoadAssemblySitesData();
        }

        private void LoadPlanningData()
        {
                        try
            {
                // Логика загрузки доступных площадок сборки из базы данных
                cboAssemblySite.Items.Add("Сборочная площадка 1");
                cboAssemblySite.Items.Add("Сборочная площадка 2");
                cboAssemblySite.SelectedIndex = 0;
                        cboNomenclature.Items.Add("Запчасть A");
            cboNomenclature.Items.Add("Комплект X");
            cboNomenclature.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке площадок сборки: {ex.Message}");
            }
        }
private void btnPlanAssembly_Click(object sender, EventArgs e)
        {
            string assemblySite = cboAssemblySite.SelectedItem.ToString();
            string nomenclature = cboNomenclature.SelectedItem.ToString();
            int quantity = (int)numQuantity.Value;

            try
            {
                // Логика планирования сборки
                MessageBox.Show($"Запланирована сборка для {assemblySite} номенклатуры {nomenclature} в количестве {quantity}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при планировании сборки: {ex.Message}");
            }
        }
    }
}
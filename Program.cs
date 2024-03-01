using System;
using System.Windows.Forms;

namespace OrderAssemblySystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Создание и отображение формы ввода заказов
            OrderForm orderForm = new OrderForm();
            Application.Run(orderForm);
        }
    }
}

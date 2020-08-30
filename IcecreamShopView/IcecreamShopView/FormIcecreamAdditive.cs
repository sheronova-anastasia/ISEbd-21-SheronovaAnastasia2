using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace IcecreamShopView
{
    public partial class FormIcecreamAdditive : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxAdditive.SelectedValue); }
            set { comboBoxAdditive.SelectedValue = value; }
        }
        public string AdditiveName { get { return comboBoxAdditive.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormIcecreamAdditive(IAdditiveLogic logic)
        {
            InitializeComponent();
            List<AdditiveViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxAdditive.DisplayMember = "AdditiveName";
                comboBoxAdditive.ValueMember = "Id";
                comboBoxAdditive.DataSource = list;
                comboBoxAdditive.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAdditive.SelectedValue == null)
            {
                MessageBox.Show("Выберите добавку", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

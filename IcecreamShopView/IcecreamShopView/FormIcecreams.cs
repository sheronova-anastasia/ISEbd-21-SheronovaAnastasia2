using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.Interfaces;
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
    public partial class FormIcecreams : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IIcecreamLogic logic;
        public FormIcecreams(IIcecreamLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormIcecreams_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewIcecreams.DataSource = list;
                    dataGridViewIcecreams.Columns[0].Visible = false;
                    dataGridViewIcecreams.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewIcecreams.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonIcecreamsAdd(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIcecream>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void ButtonIcecreamsChange(object sender, EventArgs e)
        {
            if (dataGridViewIcecreams.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormIcecream>();
                form.Id = Convert.ToInt32(dataGridViewIcecreams.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonIcecreamsDelete(object sender, EventArgs e)
        {
            if (dataGridViewIcecreams.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewIcecreams.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new IcecreamBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonIcecreamsUpdate(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

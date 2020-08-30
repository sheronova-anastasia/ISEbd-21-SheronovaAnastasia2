using IcecreamShopBusinessLogic.BindingModels;
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
    public partial class FormIcecream : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IIcecreamLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> icecreamAdditives;
        public FormIcecream(IIcecreamLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormIcecream_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    IcecreamViewModel view = logic.Read(new IcecreamBindingModel
                    {
                        Id =
                   id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.IcecreamName;
                        textBoxPrice.Text = view.Price.ToString();
                        icecreamAdditives = view.IcecreamAdditives;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                icecreamAdditives = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (icecreamAdditives != null)
                {
                    dataGridViewAdditives.Rows.Clear();
                    foreach (var pc in icecreamAdditives)
                    {
                        dataGridViewAdditives.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
                        pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIcecreamAdditive>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (icecreamAdditives.ContainsKey(form.Id))
                {
                    icecreamAdditives[form.Id] = (form.AdditiveName, form.Count);
                }
                else
                {
                    icecreamAdditives.Add(form.Id, (form.AdditiveName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdditives.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormIcecreamAdditive>();
                int id = Convert.ToInt32(dataGridViewAdditives.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = icecreamAdditives[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    icecreamAdditives[form.Id] = (form.AdditiveName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdditives.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        icecreamAdditives.Remove(Convert.ToInt32(dataGridViewAdditives.SelectedRows[0].Cells[0].Value));
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
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (icecreamAdditives == null || icecreamAdditives.Count == 0)
            {
                MessageBox.Show("Заполните добавки", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new IcecreamBindingModel
                {
                    Id = id,
                    IcecreamName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    IcecreamAdditives = icecreamAdditives
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

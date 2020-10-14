﻿using IcecreamShopBusinessLogic.BindingModels;
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
    public partial class FormAdditives : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IAdditiveLogic logic;
        public FormAdditives(IAdditiveLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormAdditives_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridViewAdditives);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonAdditivesAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAdditive>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void ButtonAdditivesChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdditives.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAdditive>();
                form.Id = Convert.ToInt32(dataGridViewAdditives.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonAdditivesDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdditives.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridViewAdditives.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new AdditiveBindingModel { Id = id });
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
        private void ButtonAdditivesUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}

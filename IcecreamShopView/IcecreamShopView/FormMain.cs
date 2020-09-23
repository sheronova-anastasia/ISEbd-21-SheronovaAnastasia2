﻿using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.BusinessLogics;
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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic report;
        private readonly WorkModeling work;
        public FormMain(MainLogic logic, IOrderLogic orderLogic, WorkModeling work, ReportLogic report)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.report = report;
            this.work = work;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                if (list != null)
                {
                    dataGridViewMain.DataSource = list;
                    dataGridViewMain.Columns[0].Visible = false;
                    dataGridViewMain.Columns[1].Visible = false;
                    dataGridViewMain.Columns[2].Visible = false;
                    dataGridViewMain.Columns[3].Visible = false;
                    dataGridViewMain.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ДобавкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAdditives>();
            form.ShowDialog();
        }
        private void МороженоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIcecreams>();
            form.ShowDialog();
        }
        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }
        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            work.DoWork();
            LoadData();
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        private void ButtonOrderIsPaid_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewMain.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void списокДобавокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    report.SaveIcecreamsToWordFile(new ReportBindingModel
                    {
                        FileName =
                   dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }
        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void добавкиПоМороженомуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportIcecreamAdditives>();
            form.ShowDialog();
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }
    }
}

namespace IcecreamShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мороженоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonStartDoingAnOrder = new System.Windows.Forms.Button();
            this.buttonOrderIsReady = new System.Windows.Forms.Button();
            this.buttonOrderIsPaid = new System.Windows.Forms.Button();
            this.buttonUpdateList = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(819, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавкиToolStripMenuItem,
            this.мороженоеToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // добавкиToolStripMenuItem
            // 
            this.добавкиToolStripMenuItem.Name = "добавкиToolStripMenuItem";
            this.добавкиToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.добавкиToolStripMenuItem.Text = "Добавки";
            this.добавкиToolStripMenuItem.Click += new System.EventHandler(this.ДобавкиToolStripMenuItem_Click);
            // 
            // мороженоеToolStripMenuItem
            // 
            this.мороженоеToolStripMenuItem.Name = "мороженоеToolStripMenuItem";
            this.мороженоеToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.мороженоеToolStripMenuItem.Text = "Мороженое";
            this.мороженоеToolStripMenuItem.Click += new System.EventHandler(this.МороженоеToolStripMenuItem_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.Size = new System.Drawing.Size(637, 341);
            this.dataGridViewMain.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(659, 53);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(148, 23);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonStartDoingAnOrder
            // 
            this.buttonStartDoingAnOrder.Location = new System.Drawing.Point(659, 99);
            this.buttonStartDoingAnOrder.Name = "buttonStartDoingAnOrder";
            this.buttonStartDoingAnOrder.Size = new System.Drawing.Size(148, 23);
            this.buttonStartDoingAnOrder.TabIndex = 3;
            this.buttonStartDoingAnOrder.Text = "Отдать на выполнение";
            this.buttonStartDoingAnOrder.UseVisualStyleBackColor = true;
            this.buttonStartDoingAnOrder.Click += new System.EventHandler(this.ButtonStartDoingAnOrder_Click);
            // 
            // buttonOrderIsReady
            // 
            this.buttonOrderIsReady.Location = new System.Drawing.Point(659, 146);
            this.buttonOrderIsReady.Name = "buttonOrderIsReady";
            this.buttonOrderIsReady.Size = new System.Drawing.Size(148, 23);
            this.buttonOrderIsReady.TabIndex = 4;
            this.buttonOrderIsReady.Text = "Заказ готов";
            this.buttonOrderIsReady.UseVisualStyleBackColor = true;
            this.buttonOrderIsReady.Click += new System.EventHandler(this.ButtonOrderIsReady_Click);
            // 
            // buttonOrderIsPaid
            // 
            this.buttonOrderIsPaid.Location = new System.Drawing.Point(659, 194);
            this.buttonOrderIsPaid.Name = "buttonOrderIsPaid";
            this.buttonOrderIsPaid.Size = new System.Drawing.Size(148, 23);
            this.buttonOrderIsPaid.TabIndex = 5;
            this.buttonOrderIsPaid.Text = "Заказ оплачен";
            this.buttonOrderIsPaid.UseVisualStyleBackColor = true;
            this.buttonOrderIsPaid.Click += new System.EventHandler(this.ButtonOrderIsPaid_Click);
            // 
            // buttonUpdateList
            // 
            this.buttonUpdateList.Location = new System.Drawing.Point(659, 241);
            this.buttonUpdateList.Name = "buttonUpdateList";
            this.buttonUpdateList.Size = new System.Drawing.Size(148, 23);
            this.buttonUpdateList.TabIndex = 6;
            this.buttonUpdateList.Text = "Обновить список";
            this.buttonUpdateList.UseVisualStyleBackColor = true;
            this.buttonUpdateList.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 368);
            this.Controls.Add(this.buttonUpdateList);
            this.Controls.Add(this.buttonOrderIsPaid);
            this.Controls.Add(this.buttonOrderIsReady);
            this.Controls.Add(this.buttonStartDoingAnOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "Магазин мороженого";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мороженоеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonStartDoingAnOrder;
        private System.Windows.Forms.Button buttonOrderIsReady;
        private System.Windows.Forms.Button buttonOrderIsPaid;
        private System.Windows.Forms.Button buttonUpdateList;
    }
}
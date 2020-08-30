namespace IcecreamShopView
{
    partial class FormIcecreams
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
            this.dataGridViewIcecreams = new System.Windows.Forms.DataGridView();
            this.buttonIcecreamsAdd = new System.Windows.Forms.Button();
            this.buttonIcecreamsChange = new System.Windows.Forms.Button();
            this.buttonIcecreamsDelete = new System.Windows.Forms.Button();
            this.buttonIcecreamsUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIcecreams)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIcecreams
            // 
            this.dataGridViewIcecreams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIcecreams.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewIcecreams.Name = "dataGridViewIcecreams";
            this.dataGridViewIcecreams.Size = new System.Drawing.Size(557, 423);
            this.dataGridViewIcecreams.TabIndex = 0;
            // 
            // buttonIcecreamsAdd
            // 
            this.buttonIcecreamsAdd.Location = new System.Drawing.Point(640, 38);
            this.buttonIcecreamsAdd.Name = "buttonIcecreamsAdd";
            this.buttonIcecreamsAdd.Size = new System.Drawing.Size(115, 46);
            this.buttonIcecreamsAdd.TabIndex = 1;
            this.buttonIcecreamsAdd.Text = "Добавить";
            this.buttonIcecreamsAdd.UseVisualStyleBackColor = true;
            this.buttonIcecreamsAdd.Click += new System.EventHandler(this.ButtonIcecreamsAdd);
            // 
            // buttonIcecreamsChange
            // 
            this.buttonIcecreamsChange.Location = new System.Drawing.Point(641, 120);
            this.buttonIcecreamsChange.Name = "buttonIcecreamsChange";
            this.buttonIcecreamsChange.Size = new System.Drawing.Size(113, 47);
            this.buttonIcecreamsChange.TabIndex = 2;
            this.buttonIcecreamsChange.Text = "Изменить";
            this.buttonIcecreamsChange.UseVisualStyleBackColor = true;
            this.buttonIcecreamsChange.Click += new System.EventHandler(this.ButtonIcecreamsChange);
            // 
            // buttonIcecreamsDelete
            // 
            this.buttonIcecreamsDelete.Location = new System.Drawing.Point(639, 208);
            this.buttonIcecreamsDelete.Name = "buttonIcecreamsDelete";
            this.buttonIcecreamsDelete.Size = new System.Drawing.Size(114, 49);
            this.buttonIcecreamsDelete.TabIndex = 3;
            this.buttonIcecreamsDelete.Text = "Удалить";
            this.buttonIcecreamsDelete.UseVisualStyleBackColor = true;
            this.buttonIcecreamsDelete.Click += new System.EventHandler(this.ButtonIcecreamsDelete);
            // 
            // buttonIcecreamsUpdate
            // 
            this.buttonIcecreamsUpdate.Location = new System.Drawing.Point(652, 297);
            this.buttonIcecreamsUpdate.Name = "buttonIcecreamsUpdate";
            this.buttonIcecreamsUpdate.Size = new System.Drawing.Size(113, 56);
            this.buttonIcecreamsUpdate.TabIndex = 4;
            this.buttonIcecreamsUpdate.Text = "Обновить";
            this.buttonIcecreamsUpdate.UseVisualStyleBackColor = true;
            this.buttonIcecreamsUpdate.Click += new System.EventHandler(this.ButtonIcecreamsUpdate);
            // 
            // FormIcecreams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonIcecreamsUpdate);
            this.Controls.Add(this.buttonIcecreamsDelete);
            this.Controls.Add(this.buttonIcecreamsChange);
            this.Controls.Add(this.buttonIcecreamsAdd);
            this.Controls.Add(this.dataGridViewIcecreams);
            this.Name = "FormIcecreams";
            this.Text = "Мороженое";
            this.Load += new System.EventHandler(this.FormIcecreams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIcecreams)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewIcecreams;
        private System.Windows.Forms.Button buttonIcecreamsAdd;
        private System.Windows.Forms.Button buttonIcecreamsChange;
        private System.Windows.Forms.Button buttonIcecreamsDelete;
        private System.Windows.Forms.Button buttonIcecreamsUpdate;
    }
}
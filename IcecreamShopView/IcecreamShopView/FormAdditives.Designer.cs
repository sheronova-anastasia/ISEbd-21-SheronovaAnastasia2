namespace IcecreamShopView
{
    partial class FormAdditives
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
            this.dataGridViewAdditives = new System.Windows.Forms.DataGridView();
            this.buttonAdditivesAdd = new System.Windows.Forms.Button();
            this.buttonAdditivesChange = new System.Windows.Forms.Button();
            this.buttonAdditivesDelete = new System.Windows.Forms.Button();
            this.buttonAdditivesUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdditives)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAdditives
            // 
            this.dataGridViewAdditives.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewAdditives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdditives.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAdditives.Name = "dataGridViewAdditives";
            this.dataGridViewAdditives.Size = new System.Drawing.Size(350, 350);
            this.dataGridViewAdditives.TabIndex = 0;
            // 
            // buttonAdditivesAdd
            // 
            this.buttonAdditivesAdd.Location = new System.Drawing.Point(378, 12);
            this.buttonAdditivesAdd.Name = "buttonAdditivesAdd";
            this.buttonAdditivesAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdditivesAdd.TabIndex = 1;
            this.buttonAdditivesAdd.Text = "Добавить";
            this.buttonAdditivesAdd.UseVisualStyleBackColor = true;
            this.buttonAdditivesAdd.Click += new System.EventHandler(this.ButtonAdditivesAdd_Click);
            // 
            // buttonAdditivesChange
            // 
            this.buttonAdditivesChange.Location = new System.Drawing.Point(378, 50);
            this.buttonAdditivesChange.Name = "buttonAdditivesChange";
            this.buttonAdditivesChange.Size = new System.Drawing.Size(75, 23);
            this.buttonAdditivesChange.TabIndex = 2;
            this.buttonAdditivesChange.Text = "Изменить";
            this.buttonAdditivesChange.UseVisualStyleBackColor = true;
            this.buttonAdditivesChange.Click += new System.EventHandler(this.ButtonAdditivesChange_Click);
            // 
            // buttonAdditivesDelete
            // 
            this.buttonAdditivesDelete.Location = new System.Drawing.Point(378, 90);
            this.buttonAdditivesDelete.Name = "buttonAdditivesDelete";
            this.buttonAdditivesDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonAdditivesDelete.TabIndex = 3;
            this.buttonAdditivesDelete.Text = "Удалить";
            this.buttonAdditivesDelete.UseVisualStyleBackColor = true;
            this.buttonAdditivesDelete.Click += new System.EventHandler(this.ButtonAdditivesDelete_Click);
            // 
            // buttonAdditivesUpdate
            // 
            this.buttonAdditivesUpdate.Location = new System.Drawing.Point(378, 131);
            this.buttonAdditivesUpdate.Name = "buttonAdditivesUpdate";
            this.buttonAdditivesUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonAdditivesUpdate.TabIndex = 4;
            this.buttonAdditivesUpdate.Text = "Обновить";
            this.buttonAdditivesUpdate.UseVisualStyleBackColor = true;
            this.buttonAdditivesUpdate.Click += new System.EventHandler(this.ButtonAdditivesUpdate_Click);
            // 
            // FormAdditives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 351);
            this.Controls.Add(this.buttonAdditivesUpdate);
            this.Controls.Add(this.buttonAdditivesDelete);
            this.Controls.Add(this.buttonAdditivesChange);
            this.Controls.Add(this.buttonAdditivesAdd);
            this.Controls.Add(this.dataGridViewAdditives);
            this.Name = "FormAdditives";
            this.Text = "Добавки";
            this.Load += new System.EventHandler(this.FormAdditives_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdditives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAdditives;
        private System.Windows.Forms.Button buttonAdditivesAdd;
        private System.Windows.Forms.Button buttonAdditivesChange;
        private System.Windows.Forms.Button buttonAdditivesDelete;
        private System.Windows.Forms.Button buttonAdditivesUpdate;
    }
}
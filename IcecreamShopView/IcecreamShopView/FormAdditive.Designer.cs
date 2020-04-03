namespace IcecreamShopView
{
    partial class FormAdditive
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAdditiveName = new System.Windows.Forms.TextBox();
            this.labelAdditiveName = new System.Windows.Forms.Label();
            this.buttonAdditiveSave = new System.Windows.Forms.Button();
            this.buttonAdditiveCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAdditiveName
            // 
            this.textBoxAdditiveName.Location = new System.Drawing.Point(89, 11);
            this.textBoxAdditiveName.Name = "textBoxAdditiveName";
            this.textBoxAdditiveName.Size = new System.Drawing.Size(177, 20);
            this.textBoxAdditiveName.TabIndex = 0;
            // 
            // labelAdditiveName
            // 
            this.labelAdditiveName.AutoSize = true;
            this.labelAdditiveName.Location = new System.Drawing.Point(23, 14);
            this.labelAdditiveName.Name = "labelAdditiveName";
            this.labelAdditiveName.Size = new System.Drawing.Size(60, 13);
            this.labelAdditiveName.TabIndex = 1;
            this.labelAdditiveName.Text = "Название:";
            // 
            // buttonAdditiveSave
            // 
            this.buttonAdditiveSave.Location = new System.Drawing.Point(100, 45);
            this.buttonAdditiveSave.Name = "buttonAdditiveSave";
            this.buttonAdditiveSave.Size = new System.Drawing.Size(75, 23);
            this.buttonAdditiveSave.TabIndex = 2;
            this.buttonAdditiveSave.Text = "Сохранить";
            this.buttonAdditiveSave.UseVisualStyleBackColor = true;
            this.buttonAdditiveSave.Click += new System.EventHandler(this.ButtonAdditiveSave_Click);
            // 
            // buttonAdditiveCancel
            // 
            this.buttonAdditiveCancel.Location = new System.Drawing.Point(191, 45);
            this.buttonAdditiveCancel.Name = "buttonAdditiveCancel";
            this.buttonAdditiveCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonAdditiveCancel.TabIndex = 3;
            this.buttonAdditiveCancel.Text = "Отмена";
            this.buttonAdditiveCancel.UseVisualStyleBackColor = true;
            this.buttonAdditiveCancel.Click += new System.EventHandler(this.ButtonAdditiveCancel_Click);
            // 
            // FormAdditive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 80);
            this.Controls.Add(this.buttonAdditiveCancel);
            this.Controls.Add(this.buttonAdditiveSave);
            this.Controls.Add(this.labelAdditiveName);
            this.Controls.Add(this.textBoxAdditiveName);
            this.Name = "FormAdditive";
            this.Text = "Добавка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAdditiveName;
        private System.Windows.Forms.Label labelAdditiveName;
        private System.Windows.Forms.Button buttonAdditiveSave;
        private System.Windows.Forms.Button buttonAdditiveCancel;
    }
}


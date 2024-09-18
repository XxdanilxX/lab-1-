namespace lab_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// Очищення ресурсів.
        /// </summary>
        /// <param name="disposing">Чи потрібно видалити керовані ресурси.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код для побудови інтерфейсу

        /// <summary>
        /// Метод для ініціалізації компонентів форми
        /// </summary>
        private void InitializeComponent()
        {
            btnSort = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSort
            // 
            btnSort.Location = new Point(12, 15);
            btnSort.Margin = new Padding(3, 4, 3, 4);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(160, 50);
            btnSort.TabIndex = 0;
            btnSort.Text = "Запустити сортування";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 88);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(416, 275);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 31);
            label1.Name = "label1";
            label1.Size = new Size(228, 20);
            label1.TabIndex = 2;
            label1.Text = "Результати сортування (масив):";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 389);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnSort);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Алгоритм зовнішнього сортування";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

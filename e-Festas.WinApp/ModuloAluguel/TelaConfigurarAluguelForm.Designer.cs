namespace e_Festas.WinApp.ModuloAluguel
{
    partial class TelaConfigurarAluguelForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            txtDescontoMaximo = new NumericUpDown();
            label8 = new Label();
            txtDesconto = new NumericUpDown();
            label9 = new Label();
            txtSinal = new NumericUpDown();
            label2 = new Label();
            cbDesconto = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)txtDescontoMaximo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDesconto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSinal).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(213, 123);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(132, 123);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 16;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtDescontoMaximo
            // 
            txtDescontoMaximo.DecimalPlaces = 1;
            txtDescontoMaximo.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            txtDescontoMaximo.Location = new Point(142, 84);
            txtDescontoMaximo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtDescontoMaximo.Name = "txtDescontoMaximo";
            txtDescontoMaximo.ReadOnly = true;
            txtDescontoMaximo.Size = new Size(54, 23);
            txtDescontoMaximo.TabIndex = 31;
            txtDescontoMaximo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 86);
            label8.Name = "label8";
            label8.Size = new Size(109, 15);
            label8.TabIndex = 30;
            label8.Text = "Desconto Limite% :";
            // 
            // txtDesconto
            // 
            txtDesconto.DecimalPlaces = 1;
            txtDesconto.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            txtDesconto.Location = new Point(220, 44);
            txtDesconto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtDesconto.Name = "txtDesconto";
            txtDesconto.ReadOnly = true;
            txtDesconto.Size = new Size(54, 23);
            txtDesconto.TabIndex = 29;
            txtDesconto.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(142, 46);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 28;
            label9.Text = "Desconto% :";
            // 
            // txtSinal
            // 
            txtSinal.Location = new Point(81, 42);
            txtSinal.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            txtSinal.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
            txtSinal.Name = "txtSinal";
            txtSinal.ReadOnly = true;
            txtSinal.Size = new Size(54, 23);
            txtSinal.TabIndex = 25;
            txtSinal.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 44);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 26;
            label2.Text = "Sinal% :";
            // 
            // cbDesconto
            // 
            cbDesconto.AutoSize = true;
            cbDesconto.Location = new Point(27, 12);
            cbDesconto.Name = "cbDesconto";
            cbDesconto.Size = new Size(116, 19);
            cbDesconto.TabIndex = 27;
            cbDesconto.Text = "Aplicar Desconto";
            cbDesconto.UseVisualStyleBackColor = true;
            // 
            // TelaConfigurarAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 176);
            Controls.Add(txtDescontoMaximo);
            Controls.Add(label8);
            Controls.Add(txtDesconto);
            Controls.Add(label9);
            Controls.Add(txtSinal);
            Controls.Add(label2);
            Controls.Add(cbDesconto);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaConfigurarAluguelForm";
            Text = "Configuração de Aluguéis";
            ((System.ComponentModel.ISupportInitialize)txtDescontoMaximo).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDesconto).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSinal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private NumericUpDown txtDescontoMaximo;
        private Label label8;
        private NumericUpDown txtDesconto;
        private Label label9;
        private NumericUpDown txtSinal;
        private Label label2;
        private CheckBox cbDesconto;
    }
}
namespace e_Festas.WinApp.ModuloAluguel
{
    partial class TelaFiltroAluguelForm
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
            cmbFiltros = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // cmbFiltros
            // 
            cmbFiltros.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltros.FormattingEnabled = true;
            cmbFiltros.Location = new Point(12, 37);
            cmbFiltros.Name = "cmbFiltros";
            cmbFiltros.Size = new Size(320, 23);
            cmbFiltros.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 9);
            label1.Name = "label1";
            label1.Size = new Size(146, 15);
            label1.TabIndex = 22;
            label1.Text = "Selecione o modo de filtro";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(190, 68);
            button1.Name = "button1";
            button1.Size = new Size(75, 41);
            button1.TabIndex = 21;
            button1.Text = "Filtrar";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(271, 68);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Fechar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 118);
            Controls.Add(cmbFiltros);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnCancelar);
            Name = "TelaFiltroAluguelForm";
            Text = "Filtro de aluguéis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFiltros;
        private Label label1;
        private Button button1;
        private Button btnCancelar;
    }
}
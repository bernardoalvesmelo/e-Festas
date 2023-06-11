namespace e_Festas.WinApp.ModuloAluguel
{
    partial class TelaVisualizarAluguelForm
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
            button1 = new Button();
            label1 = new Label();
            cmbVisualizacoes = new ComboBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(195, 87);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Fechar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(114, 87);
            button1.Name = "button1";
            button1.Size = new Size(75, 41);
            button1.TabIndex = 17;
            button1.Text = "Selecionar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 13);
            label1.Name = "label1";
            label1.Size = new Size(188, 15);
            label1.TabIndex = 18;
            label1.Text = "Selecionar campos de visualização";
            // 
            // cmbVisualizacoes
            // 
            cmbVisualizacoes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVisualizacoes.FormattingEnabled = true;
            cmbVisualizacoes.Location = new Point(65, 40);
            cmbVisualizacoes.Name = "cmbVisualizacoes";
            cmbVisualizacoes.Size = new Size(162, 23);
            cmbVisualizacoes.TabIndex = 19;
            // 
            // TelaVisualizarAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 140);
            Controls.Add(cmbVisualizacoes);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnCancelar);
            Name = "TelaVisualizarAluguelForm";
            Text = "Visualização";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button button1;
        private Label label1;
        private ComboBox cmbVisualizacoes;
    }
}
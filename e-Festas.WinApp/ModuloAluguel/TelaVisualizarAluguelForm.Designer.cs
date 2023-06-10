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
            panel1 = new Panel();
            gridEnderecos = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEnderecos).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(694, 229);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Fechar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(gridEnderecos);
            panel1.Location = new Point(21, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(736, 202);
            panel1.TabIndex = 17;
            // 
            // gridEnderecos
            // 
            gridEnderecos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEnderecos.Dock = DockStyle.Fill;
            gridEnderecos.Location = new Point(0, 0);
            gridEnderecos.Name = "gridEnderecos";
            gridEnderecos.RowTemplate.Height = 25;
            gridEnderecos.Size = new Size(736, 202);
            gridEnderecos.TabIndex = 0;
            // 
            // TelaVisualizarAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 282);
            Controls.Add(panel1);
            Controls.Add(btnCancelar);
            Name = "TelaVisualizarAluguelForm";
            Text = "Visualização de Endereços";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEnderecos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancelar;
        private Panel panel1;
        private DataGridView gridEnderecos;
    }
}
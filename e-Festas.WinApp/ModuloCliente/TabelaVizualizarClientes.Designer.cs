namespace e_Festas.WinApp.ModuloCliente
{
    partial class TabelaVizualizarClientes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GridClienteVizualizar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)GridClienteVizualizar).BeginInit();
            SuspendLayout();
            // 
            // GridClienteVizualizar
            // 
            GridClienteVizualizar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridClienteVizualizar.Dock = DockStyle.Fill;
            GridClienteVizualizar.Location = new Point(0, 0);
            GridClienteVizualizar.Name = "GridClienteVizualizar";
            GridClienteVizualizar.RowTemplate.Height = 25;
            GridClienteVizualizar.Size = new Size(439, 511);
            GridClienteVizualizar.TabIndex = 0;
            // 
            // TabelaVizualizarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GridClienteVizualizar);
            Name = "TabelaVizualizarClientes";
            Size = new Size(439, 511);
            ((System.ComponentModel.ISupportInitialize)GridClienteVizualizar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GridClienteVizualizar;
    }
}

namespace e_Festas.WinApp.ModuloTema
{
    partial class TabelaItemTemaControl
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
            gridItem = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridItem).BeginInit();
            SuspendLayout();
            // 
            // gridItem
            // 
            gridItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItem.Dock = DockStyle.Fill;
            gridItem.Location = new Point(0, 0);
            gridItem.Name = "gridItem";
            gridItem.RowTemplate.Height = 25;
            gridItem.Size = new Size(485, 386);
            gridItem.TabIndex = 0;
            // 
            // TabelaItemTemaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridItem);
            Name = "TabelaItemTemaControl";
            Size = new Size(485, 386);
            ((System.ComponentModel.ISupportInitialize)gridItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridItem;
    }
}

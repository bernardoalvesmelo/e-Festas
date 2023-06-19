namespace e_Festas.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            cadastrosMenuItem = new ToolStripMenuItem();
            alugueisToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            temasToolStripMenuItem = new ToolStripMenuItem();
            itensToolStripMenuItem = new ToolStripMenuItem();
            itensToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            barraFerramentas = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnFiltrar = new ToolStripButton();
            btnVisualizar = new ToolStripButton();
            btnConcluir = new ToolStripButton();
            btnConfigurar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator1 = new ToolStripSeparator();
            labelTipoCadastro = new ToolStripLabel();
            panelRegistros = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            barraFerramentas.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosMenuItem
            // 
            cadastrosMenuItem.DropDownItems.AddRange(new ToolStripItem[] { alugueisToolStripMenuItem, clientesToolStripMenuItem, temasToolStripMenuItem });
            cadastrosMenuItem.Name = "cadastrosMenuItem";
            cadastrosMenuItem.Size = new Size(71, 20);
            cadastrosMenuItem.Text = "Cadastros";
            // 
            // alugueisToolStripMenuItem
            // 
            alugueisToolStripMenuItem.Name = "alugueisToolStripMenuItem";
            alugueisToolStripMenuItem.Size = new Size(120, 22);
            alugueisToolStripMenuItem.Text = "Aluguéis";
            alugueisToolStripMenuItem.Click += alugueisToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(120, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click_1;
            // 
            // temasToolStripMenuItem
            // 
            temasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itensToolStripMenuItem, itensToolStripMenuItem1 });
            temasToolStripMenuItem.Name = "temasToolStripMenuItem";
            temasToolStripMenuItem.Size = new Size(120, 22);
            temasToolStripMenuItem.Text = "Temas";
            // 
            // itensToolStripMenuItem
            // 
            itensToolStripMenuItem.Name = "itensToolStripMenuItem";
            itensToolStripMenuItem.Size = new Size(107, 22);
            itensToolStripMenuItem.Text = "Temas";
            itensToolStripMenuItem.Click += itensToolStripMenuItem_Click;
            // 
            // itensToolStripMenuItem1
            // 
            itensToolStripMenuItem1.Name = "itensToolStripMenuItem1";
            itensToolStripMenuItem1.Size = new Size(107, 22);
            itensToolStripMenuItem1.Text = "Itens";
            itensToolStripMenuItem1.Click += itensToolStripMenuItem1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(0, 17);
            // 
            // barraFerramentas
            // 
            barraFerramentas.Enabled = false;
            barraFerramentas.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator2, btnFiltrar, btnVisualizar, btnConcluir, btnConfigurar, toolStripSeparator3, toolStripSeparator1, labelTipoCadastro });
            barraFerramentas.Location = new Point(0, 24);
            barraFerramentas.Name = "barraFerramentas";
            barraFerramentas.Size = new Size(800, 45);
            barraFerramentas.TabIndex = 2;
            barraFerramentas.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Image = Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz24;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(7);
            btnInserir.Size = new Size(42, 42);
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz24;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(7);
            btnEditar.Size = new Size(42, 42);
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = Properties.Resources.delete_FILL0_wght400_GRAD0_opsz24;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(7);
            btnExcluir.Size = new Size(42, 42);
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 45);
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Image = Properties.Resources.outline_filter_alt_black_24dp;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(7);
            btnFiltrar.Size = new Size(42, 42);
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnVisualizar
            // 
            btnVisualizar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnVisualizar.Image = Properties.Resources.apps_FILL0_wght400_GRAD0_opsz24;
            btnVisualizar.ImageScaling = ToolStripItemImageScaling.None;
            btnVisualizar.ImageTransparentColor = Color.Magenta;
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Padding = new Padding(7);
            btnVisualizar.Size = new Size(42, 42);
            btnVisualizar.Click += btnVisualizar_Click;
            // 
            // btnConcluir
            // 
            btnConcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnConcluir.Image = Properties.Resources.check_box_FILL0_wght400_GRAD0_opsz24;
            btnConcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnConcluir.ImageTransparentColor = Color.Magenta;
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Padding = new Padding(7);
            btnConcluir.Size = new Size(42, 42);
            btnConcluir.Click += btnConcluir_Click;
            // 
            // btnConfigurar
            // 
            btnConfigurar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnConfigurar.Image = Properties.Resources.settings_FILL0_wght400_GRAD0_opsz24;
            btnConfigurar.ImageScaling = ToolStripItemImageScaling.None;
            btnConfigurar.ImageTransparentColor = Color.Magenta;
            btnConfigurar.Name = "btnConfigurar";
            btnConfigurar.Padding = new Padding(7);
            btnConfigurar.Size = new Size(42, 42);
            btnConfigurar.Click += btnConfigurar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 45);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 45);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(0, 42);
            // 
            // panelRegistros
            // 
            panelRegistros.BorderStyle = BorderStyle.FixedSingle;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 69);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(800, 359);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelRegistros);
            Controls.Add(barraFerramentas);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "e-Festas 1.0";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            barraFerramentas.ResumeLayout(false);
            barraFerramentas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelRodape;
        private ToolStrip barraFerramentas;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private Panel panelRegistros;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel labelTipoCadastro;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem alugueisToolStripMenuItem;
        private ToolStripButton btnVisualizar;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem temasToolStripMenuItem;
        private ToolStripButton btnFiltrar;
        private ToolStripMenuItem itensToolStripMenuItem;
        private ToolStripMenuItem itensToolStripMenuItem1;
        private ToolStripButton btnConcluir;
        private ToolStripButton btnConfigurar;
    }
}
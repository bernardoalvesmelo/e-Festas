namespace e_Festas.WinApp.ModuloTema
{
    partial class TelaAdicionarItemForm
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
            btnGravarItem = new Button();
            btnCancelar = new Button();
            listTema = new ListBox();
            lbNomeItem = new Label();
            lbValorItem = new Label();
            lbId = new Label();
            txtId = new TextBox();
            TxtItem = new TextBox();
            btnAdicionar = new Button();
            txtValorItem = new MaskedTextBox();
            SuspendLayout();
            // 
            // btnGravarItem
            // 
            btnGravarItem.DialogResult = DialogResult.OK;
            btnGravarItem.Location = new Point(205, 295);
            btnGravarItem.Name = "btnGravarItem";
            btnGravarItem.Size = new Size(90, 36);
            btnGravarItem.TabIndex = 0;
            btnGravarItem.Text = "Gravar";
            btnGravarItem.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(301, 295);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 36);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // listTema
            // 
            listTema.FormattingEnabled = true;
            listTema.ItemHeight = 15;
            listTema.Location = new Point(41, 133);
            listTema.Name = "listTema";
            listTema.Size = new Size(309, 139);
            listTema.TabIndex = 2;
            // 
            // lbNomeItem
            // 
            lbNomeItem.AutoSize = true;
            lbNomeItem.Location = new Point(43, 58);
            lbNomeItem.Name = "lbNomeItem";
            lbNomeItem.Size = new Size(34, 15);
            lbNomeItem.TabIndex = 3;
            lbNomeItem.Text = "Item:";
            // 
            // lbValorItem
            // 
            lbValorItem.AutoSize = true;
            lbValorItem.Location = new Point(41, 95);
            lbValorItem.Name = "lbValorItem";
            lbValorItem.Size = new Size(36, 15);
            lbValorItem.TabIndex = 4;
            lbValorItem.Text = "Valor:";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(57, 25);
            lbId.Name = "lbId";
            lbId.Size = new Size(20, 15);
            lbId.TabIndex = 5;
            lbId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(82, 17);
            txtId.Name = "txtId";
            txtId.Size = new Size(27, 23);
            txtId.TabIndex = 6;
            // 
            // TxtItem
            // 
            TxtItem.Location = new Point(83, 50);
            TxtItem.Name = "TxtItem";
            TxtItem.Size = new Size(206, 23);
            TxtItem.TabIndex = 7;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(234, 87);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 9;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // txtValorItem
            // 
            txtValorItem.Location = new Point(83, 87);
            txtValorItem.Mask = "0000000";
            txtValorItem.Name = "txtValorItem";
            txtValorItem.Size = new Size(100, 23);
            txtValorItem.TabIndex = 10;
            txtValorItem.ValidatingType = typeof(int);
            // 
            // TelaAdicionarItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 343);
            Controls.Add(txtValorItem);
            Controls.Add(btnAdicionar);
            Controls.Add(TxtItem);
            Controls.Add(txtId);
            Controls.Add(lbId);
            Controls.Add(lbValorItem);
            Controls.Add(lbNomeItem);
            Controls.Add(listTema);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravarItem);
            Name = "TelaAdicionarItemForm";
            ShowIcon = false;
            Text = "Cadastro de Itens";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravarItem;
        private Button btnCancelar;
        private ListBox listTema;
        private Label lbNomeItem;
        private Label lbValorItem;
        private Label lbId;
        private TextBox txtId;
        private TextBox TxtItem;
        private Button btnAdicionar;
        private MaskedTextBox txtValorItem;
    }
}
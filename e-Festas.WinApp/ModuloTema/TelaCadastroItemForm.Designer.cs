namespace e_Festas.WinApp.ModuloTema
{
    partial class TelaCadastroItemForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            lbId = new Label();
            lbNome = new Label();
            lblValor = new Label();
            txtIditem = new TextBox();
            maskedValor = new MaskedTextBox();
            this.txtNome = new TextBox();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(170, 113);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(88, 40);
            btnGravar.TabIndex = 0;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(264, 113);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 40);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(102, 20);
            lbId.Name = "lbId";
            lbId.Size = new Size(20, 15);
            lbId.TabIndex = 2;
            lbId.Text = "Id:";
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(79, 49);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 3;
            lbNome.Text = "Nome:";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(86, 81);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(36, 15);
            lblValor.TabIndex = 4;
            lblValor.Text = "Valor:";
            // 
            // txtIditem
            // 
            txtIditem.Enabled = false;
            txtIditem.Location = new Point(131, 12);
            txtIditem.Name = "txtIditem";
            txtIditem.Size = new Size(24, 23);
            txtIditem.TabIndex = 5;
            txtIditem.Text = "0";
            // 
            // maskedValor
            // 
            maskedValor.Location = new Point(131, 73);
            maskedValor.Mask = "00000";
            maskedValor.Name = "maskedValor";
            maskedValor.Size = new Size(67, 23);
            maskedValor.TabIndex = 6;
            maskedValor.ValidatingType = typeof(int);
            // 
            // txtNome
            // 
            this.txtNome.Location = new Point(131, 44);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new Size(84, 23);
            this.txtNome.TabIndex = 9;
            // 
            // TelaCadastroItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 161);
            Controls.Add(this.txtNome);
            Controls.Add(maskedValor);
            Controls.Add(txtIditem);
            Controls.Add(lblValor);
            Controls.Add(lbNome);
            Controls.Add(lbId);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaCadastroItemForm";
            Text = "Cadastro de Itens";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private Label lbId;
        private Label lbNome;
        private Label lblValor;
        private TextBox txtIditem;
        private MaskedTextBox maskedValor;     
        private TextBox txtNome;
    }
}
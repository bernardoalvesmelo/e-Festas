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
            txtId = new TextBox();
            maskedValor = new MaskedTextBox();
            txtNome = new TextBox();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(239, 153);
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
            btnCancelar.Location = new Point(339, 153);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 40);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(131, 46);
            lbId.Name = "lbId";
            lbId.Size = new Size(20, 15);
            lbId.TabIndex = 2;
            lbId.Text = "Id:";
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(108, 75);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 3;
            lbNome.Text = "Nome:";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(115, 105);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(36, 15);
            lblValor.TabIndex = 4;
            lblValor.Text = "Valor:";
            // 
            // txtId
            // 
            txtId.Location = new Point(157, 38);
            txtId.Name = "txtId";
            txtId.Size = new Size(24, 23);
            txtId.TabIndex = 5;
            // 
            // maskedValor
            // 
            maskedValor.Location = new Point(157, 97);
            maskedValor.Mask = "00000";
            maskedValor.Name = "maskedValor";
            maskedValor.Size = new Size(67, 23);
            maskedValor.TabIndex = 6;
            maskedValor.ValidatingType = typeof(int);
            // 
            // txtNome
            // 
            txtNome.Location = new Point(157, 67);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(116, 23);
            txtNome.TabIndex = 7;
            // 
            // TelaCadastroItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 205);
            Controls.Add(txtNome);
            Controls.Add(maskedValor);
            Controls.Add(txtId);
            Controls.Add(lblValor);
            Controls.Add(lbNome);
            Controls.Add(lbId);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaCadastroItemForm";
            ShowIcon = false;
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
        private TextBox txtId;
        private MaskedTextBox maskedValor;
        private TextBox txtNome;
    }
}
namespace e_Festas.WinApp.ModuloTema
{
    partial class TelaCadastroTemaForm
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
            lbIdTema = new Label();
            lbValorTema = new Label();
            lbNomeTema = new Label();
            txtIdTema = new TextBox();
            txtNomeTema = new TextBox();
            txtValorTema = new MaskedTextBox();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(241, 145);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(91, 38);
            btnGravar.TabIndex = 0;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(338, 145);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(91, 38);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbIdTema
            // 
            lbIdTema.AutoSize = true;
            lbIdTema.Location = new Point(126, 20);
            lbIdTema.Name = "lbIdTema";
            lbIdTema.Size = new Size(20, 15);
            lbIdTema.TabIndex = 2;
            lbIdTema.Text = "Id:";
            // 
            // lbValorTema
            // 
            lbValorTema.AutoSize = true;
            lbValorTema.Location = new Point(110, 50);
            lbValorTema.Name = "lbValorTema";
            lbValorTema.Size = new Size(36, 15);
            lbValorTema.TabIndex = 3;
            lbValorTema.Text = "Valor:";
            // 
            // lbNomeTema
            // 
            lbNomeTema.AutoSize = true;
            lbNomeTema.Location = new Point(58, 79);
            lbNomeTema.Name = "lbNomeTema";
            lbNomeTema.Size = new Size(94, 15);
            lbNomeTema.TabIndex = 4;
            lbNomeTema.Text = "Nome do Tema: ";
            // 
            // txtIdTema
            // 
            txtIdTema.Enabled = false;
            txtIdTema.Location = new Point(152, 12);
            txtIdTema.Multiline = true;
            txtIdTema.Name = "txtIdTema";
            txtIdTema.Size = new Size(21, 23);
            txtIdTema.TabIndex = 5;
            txtIdTema.Text = "0";
            // 
            // txtNomeTema
            // 
            txtNomeTema.Location = new Point(152, 71);
            txtNomeTema.Name = "txtNomeTema";
            txtNomeTema.Size = new Size(224, 23);
            txtNomeTema.TabIndex = 7;
            // 
            // txtValorTema
            // 
            txtValorTema.Location = new Point(152, 41);
            txtValorTema.Mask = "00000000";
            txtValorTema.Name = "txtValorTema";
            txtValorTema.Size = new Size(100, 23);
            txtValorTema.TabIndex = 8;
            txtValorTema.ValidatingType = typeof(int);
            // 
            // TelaCadastroTemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 195);
            Controls.Add(txtValorTema);
            Controls.Add(txtNomeTema);
            Controls.Add(txtIdTema);
            Controls.Add(lbNomeTema);
            Controls.Add(lbValorTema);
            Controls.Add(lbIdTema);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaCadastroTemaForm";
            ShowIcon = false;
            Text = "Cadastro de Temas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private Label lbIdTema;
        private Label lbValorTema;
        private Label lbNomeTema;
        private TextBox txtIdTema;
        private TextBox txtNomeTema;
        private MaskedTextBox txtValorTema;
    }
}
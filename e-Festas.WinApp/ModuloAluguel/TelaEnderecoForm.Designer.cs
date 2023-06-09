namespace e_Festas.WinApp.ModuloAluguel
{
    partial class TelaEnderecoForm
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtCep = new TextBox();
            txtBairro = new TextBox();
            txtNumero = new TextBox();
            txtCidade = new TextBox();
            txtPais = new TextBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtComplemento = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtEstado = new TextBox();
            txtRua = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(59, 102);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 27;
            label6.Text = "Número";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(289, 102);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 26;
            label5.Text = "CEP:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(281, 44);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 25;
            label4.Text = "Bairro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 44);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 24;
            label3.Text = "Cidade:";
            // 
            // txtCep
            // 
            txtCep.Location = new Point(326, 99);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(149, 23);
            txtCep.TabIndex = 23;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(326, 41);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(149, 23);
            txtBairro.TabIndex = 22;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(116, 99);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(149, 23);
            txtNumero.TabIndex = 21;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(116, 41);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(149, 23);
            txtCidade.TabIndex = 20;
            // 
            // txtPais
            // 
            txtPais.Location = new Point(116, 12);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(149, 23);
            txtPais.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 16);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 18;
            label2.Text = "País:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(453, 162);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(372, 162);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtComplemento
            // 
            txtComplemento.Location = new Point(116, 128);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(359, 23);
            txtComplemento.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 131);
            label7.Name = "label7";
            label7.Size = new Size(87, 15);
            label7.TabIndex = 28;
            label7.Text = "Complemento:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(277, 16);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 31;
            label8.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(326, 13);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(149, 23);
            txtEstado.TabIndex = 30;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(116, 70);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(359, 23);
            txtRua.TabIndex = 33;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(80, 73);
            label9.Name = "label9";
            label9.Size = new Size(30, 15);
            label9.TabIndex = 32;
            label9.Text = "Rua:";
            // 
            // TelaEnderecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 215);
            Controls.Add(txtRua);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtEstado);
            Controls.Add(txtComplemento);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtCep);
            Controls.Add(txtBairro);
            Controls.Add(txtNumero);
            Controls.Add(txtCidade);
            Controls.Add(txtPais);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaEnderecoForm";
            Text = "Cadastro de Endereços";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtCep;
        private TextBox txtBairro;
        private TextBox txtNumero;
        private TextBox txtCidade;
        private TextBox txtPais;
        private Label label2;
        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtComplemento;
        private Label label7;
        private Label label8;
        private TextBox txtEstado;
        private TextBox txtRua;
        private Label label9;
    }
}
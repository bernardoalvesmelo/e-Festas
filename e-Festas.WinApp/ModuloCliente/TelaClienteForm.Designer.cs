﻿namespace e_Festas.WinApp.ModuloCliente
{
    partial class TelaClienteForm
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
            label4 = new Label();
            label3 = new Label();
            txtEmailCliente = new TextBox();
            txtNomeCliente = new TextBox();
            label2 = new Label();
            txtIdCliente = new TextBox();
            label1 = new Label();
            btnGravarCliente = new Button();
            btnCancelarCliente = new Button();
            txtTelefoneCliente = new MaskedTextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 94);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 19;
            label4.Text = "E-mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 68);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 18;
            label3.Text = "Telefone:";
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(96, 94);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.Size = new Size(159, 23);
            txtEmailCliente.TabIndex = 17;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(98, 37);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(157, 23);
            txtNomeCliente.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 40);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 14;
            label2.Text = "Nome:";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(98, 11);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(100, 23);
            txtIdCliente.TabIndex = 13;
            txtIdCliente.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 14);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 12;
            label1.Text = "Id:";
            // 
            // btnGravarCliente
            // 
            btnGravarCliente.DialogResult = DialogResult.OK;
            btnGravarCliente.Location = new Point(130, 132);
            btnGravarCliente.Name = "btnGravarCliente";
            btnGravarCliente.Size = new Size(75, 45);
            btnGravarCliente.TabIndex = 20;
            btnGravarCliente.Text = "Gravar";
            btnGravarCliente.UseVisualStyleBackColor = true;
            btnGravarCliente.Click += btnGravarCliente_Click;
            // 
            // btnCancelarCliente
            // 
            btnCancelarCliente.DialogResult = DialogResult.Cancel;
            btnCancelarCliente.Location = new Point(211, 132);
            btnCancelarCliente.Name = "btnCancelarCliente";
            btnCancelarCliente.Size = new Size(75, 45);
            btnCancelarCliente.TabIndex = 21;
            btnCancelarCliente.Text = "Cancelar";
            btnCancelarCliente.UseVisualStyleBackColor = true;
            // 
            // txtTelefoneCliente
            // 
            txtTelefoneCliente.Location = new Point(98, 66);
            txtTelefoneCliente.Mask = "(99) 0000-00000";
            txtTelefoneCliente.Name = "txtTelefoneCliente";
            txtTelefoneCliente.Size = new Size(157, 23);
            txtTelefoneCliente.TabIndex = 22;
            // 
            // TelaClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 188);
            Controls.Add(txtTelefoneCliente);
            Controls.Add(btnCancelarCliente);
            Controls.Add(btnGravarCliente);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtEmailCliente);
            Controls.Add(txtNomeCliente);
            Controls.Add(label2);
            Controls.Add(txtIdCliente);
            Controls.Add(label1);
            Name = "TelaClienteForm";
            Text = "Cadastro de Clientes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private TextBox txtEmailCliente;

        private TextBox txtNomeCliente;
        private Label label2;
        private TextBox txtIdCliente;
        private Label label1;
        private Button btnGravarCliente;
        private Button btnCancelarCliente;
        private MaskedTextBox txtTelefoneCliente;
    }
}
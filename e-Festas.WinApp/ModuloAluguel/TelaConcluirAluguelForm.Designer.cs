namespace e_Festas.WinApp.ModuloAluguel
{
    partial class TelaConcluirAluguelForm
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
            txtDataQuitacao = new DateTimePicker();
            label8 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // txtDataQuitacao
            // 
            txtDataQuitacao.Enabled = false;
            txtDataQuitacao.Format = DateTimePickerFormat.Short;
            txtDataQuitacao.Location = new Point(12, 50);
            txtDataQuitacao.Name = "txtDataQuitacao";
            txtDataQuitacao.Size = new Size(200, 23);
            txtDataQuitacao.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 22);
            label8.Name = "label8";
            label8.Size = new Size(157, 15);
            label8.TabIndex = 33;
            label8.Text = "Selecione a data de quitação";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(140, 89);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 36;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(59, 89);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 35;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaConcluirAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 142);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtDataQuitacao);
            Controls.Add(label8);
            Name = "TelaConcluirAluguelForm";
            Text = "Conclusão de Aluguéis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker txtDataQuitacao;
        private Label label8;
        private Button btnCancelar;
        private Button btnGravar;
    }
}
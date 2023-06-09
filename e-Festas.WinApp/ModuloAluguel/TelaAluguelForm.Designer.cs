namespace e_Festas.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
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
            txtId = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtSinal = new NumericUpDown();
            label2 = new Label();
            cbDesconto = new CheckBox();
            txtHorarioInicio = new DateTimePicker();
            txtHorarioTermino = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtData = new DateTimePicker();
            cmbClientes = new ComboBox();
            cmbTemas = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            txtDataQuitacao = new DateTimePicker();
            label8 = new Label();
            cbDataQuitacao = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)txtSinal).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(84, 12);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 17;
            txtId.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 20);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 16;
            label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(247, 314);
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
            btnGravar.Location = new Point(166, 314);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // txtSinal
            // 
            txtSinal.Location = new Point(84, 274);
            txtSinal.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            txtSinal.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
            txtSinal.Name = "txtSinal";
            txtSinal.ReadOnly = true;
            txtSinal.Size = new Size(54, 23);
            txtSinal.TabIndex = 18;
            txtSinal.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 276);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 19;
            label2.Text = "Sinal% :";
            // 
            // cbDesconto
            // 
            cbDesconto.AutoSize = true;
            cbDesconto.Location = new Point(176, 278);
            cbDesconto.Name = "cbDesconto";
            cbDesconto.Size = new Size(116, 19);
            cbDesconto.TabIndex = 20;
            cbDesconto.Text = "Aplicar Desconto";
            cbDesconto.UseVisualStyleBackColor = true;
            // 
            // txtHorarioInicio
            // 
            txtHorarioInicio.CustomFormat = "HH:mm";
            txtHorarioInicio.Format = DateTimePickerFormat.Custom;
            txtHorarioInicio.ImeMode = ImeMode.NoControl;
            txtHorarioInicio.Location = new Point(84, 86);
            txtHorarioInicio.Name = "txtHorarioInicio";
            txtHorarioInicio.ShowUpDown = true;
            txtHorarioInicio.Size = new Size(54, 23);
            txtHorarioInicio.TabIndex = 21;
            // 
            // txtHorarioTermino
            // 
            txtHorarioTermino.CustomFormat = "HH:mm";
            txtHorarioTermino.Format = DateTimePickerFormat.Custom;
            txtHorarioTermino.ImeMode = ImeMode.NoControl;
            txtHorarioTermino.Location = new Point(230, 86);
            txtHorarioTermino.Name = "txtHorarioTermino";
            txtHorarioTermino.ShowUpDown = true;
            txtHorarioTermino.Size = new Size(54, 23);
            txtHorarioTermino.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 92);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 23;
            label3.Text = "Início:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 92);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 24;
            label4.Text = "Término:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 63);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 25;
            label5.Text = "Data: ";
            // 
            // txtData
            // 
            txtData.Format = DateTimePickerFormat.Short;
            txtData.Location = new Point(84, 57);
            txtData.Name = "txtData";
            txtData.Size = new Size(200, 23);
            txtData.TabIndex = 26;
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(84, 202);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(200, 23);
            cmbClientes.TabIndex = 27;
            // 
            // cmbTemas
            // 
            cmbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTemas.FormattingEnabled = true;
            cmbTemas.Location = new Point(84, 231);
            cmbTemas.Name = "cmbTemas";
            cmbTemas.Size = new Size(200, 23);
            cmbTemas.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 205);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 29;
            label6.Text = "Cliente: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 234);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 30;
            label7.Text = "Tema:";
            // 
            // txtDataQuitacao
            // 
            txtDataQuitacao.Enabled = false;
            txtDataQuitacao.Format = DateTimePickerFormat.Short;
            txtDataQuitacao.Location = new Point(84, 155);
            txtDataQuitacao.Name = "txtDataQuitacao";
            txtDataQuitacao.Size = new Size(200, 23);
            txtDataQuitacao.TabIndex = 32;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 161);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 31;
            label8.Text = "Quitação: ";
            // 
            // cbDataQuitacao
            // 
            cbDataQuitacao.AutoSize = true;
            cbDataQuitacao.Location = new Point(84, 130);
            cbDataQuitacao.Name = "cbDataQuitacao";
            cbDataQuitacao.Size = new Size(103, 19);
            cbDataQuitacao.TabIndex = 33;
            cbDataQuitacao.Text = "Quitar Aluguel";
            cbDataQuitacao.UseVisualStyleBackColor = true;
            cbDataQuitacao.CheckedChanged += cbDataQuitacao_CheckedChanged;
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 367);
            Controls.Add(cbDataQuitacao);
            Controls.Add(txtDataQuitacao);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbTemas);
            Controls.Add(cmbClientes);
            Controls.Add(txtData);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtHorarioTermino);
            Controls.Add(txtHorarioInicio);
            Controls.Add(cbDesconto);
            Controls.Add(label2);
            Controls.Add(txtSinal);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaAluguelForm";
            Text = "Cadastro de Aluguéis";
            ((System.ComponentModel.ISupportInitialize)txtSinal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label1;
        private Button btnCancelar;
        private Button btnGravar;
        private NumericUpDown txtSinal;
        private Label label2;
        private CheckBox cbDesconto;
        private DateTimePicker txtHorarioInicio;
        private DateTimePicker txtHorarioTermino;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker txtData;
        private ComboBox cmbClientes;
        private ComboBox cmbTemas;
        private Label label6;
        private Label label7;
        private DateTimePicker txtDataQuitacao;
        private Label label8;
        private CheckBox cbDataQuitacao;
    }
}
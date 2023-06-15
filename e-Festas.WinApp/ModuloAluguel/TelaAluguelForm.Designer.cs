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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label12 = new Label();
            txtNumero = new TextBox();
            txtRua = new TextBox();
            label11 = new Label();
            label10 = new Label();
            txtCidade = new TextBox();
            tabPage3 = new TabPage();
            txtDesconto = new NumericUpDown();
            label9 = new Label();
            txtDescontoMaximo = new NumericUpDown();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtSinal).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDesconto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescontoMaximo).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(68, 3);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 17;
            txtId.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 11);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 16;
            label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(238, 222);
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
            btnGravar.Location = new Point(157, 222);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtSinal
            // 
            txtSinal.Location = new Point(84, 74);
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
            label2.Location = new Point(30, 76);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 19;
            label2.Text = "Sinal% :";
            // 
            // cbDesconto
            // 
            cbDesconto.AutoSize = true;
            cbDesconto.Location = new Point(30, 30);
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
            txtHorarioInicio.Location = new Point(68, 61);
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
            txtHorarioTermino.Location = new Point(214, 61);
            txtHorarioTermino.Name = "txtHorarioTermino";
            txtHorarioTermino.ShowUpDown = true;
            txtHorarioTermino.Size = new Size(54, 23);
            txtHorarioTermino.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 67);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 23;
            label3.Text = "Início:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(160, 67);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 24;
            label4.Text = "Término:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 38);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 25;
            label5.Text = "Data: ";
            // 
            // txtData
            // 
            txtData.Format = DateTimePickerFormat.Short;
            txtData.Location = new Point(68, 32);
            txtData.Name = "txtData";
            txtData.Size = new Size(200, 23);
            txtData.TabIndex = 26;
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(68, 103);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(200, 23);
            cmbClientes.TabIndex = 27;
            // 
            // cmbTemas
            // 
            cmbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTemas.FormattingEnabled = true;
            cmbTemas.Location = new Point(68, 132);
            cmbTemas.Name = "cmbTemas";
            cmbTemas.Size = new Size(200, 23);
            cmbTemas.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 106);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 29;
            label6.Text = "Cliente: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 135);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 30;
            label7.Text = "Tema:";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(301, 200);
            tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cmbClientes);
            tabPage1.Controls.Add(cmbTemas);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(txtData);
            tabPage1.Controls.Add(txtId);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtHorarioInicio);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtHorarioTermino);
            tabPage1.Location = new Point(4, 27);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(293, 169);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Aluguel";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(txtNumero);
            tabPage2.Controls.Add(txtRua);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(txtCidade);
            tabPage2.Location = new Point(4, 27);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(293, 169);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Endereço";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(10, 122);
            label12.Name = "label12";
            label12.Size = new Size(54, 15);
            label12.TabIndex = 37;
            label12.Text = "Número:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(67, 119);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(202, 23);
            txtNumero.TabIndex = 36;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(67, 75);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(202, 23);
            txtRua.TabIndex = 35;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(31, 78);
            label11.Name = "label11";
            label11.Size = new Size(30, 15);
            label11.TabIndex = 34;
            label11.Text = "Rua:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 29);
            label10.Name = "label10";
            label10.Size = new Size(47, 15);
            label10.TabIndex = 26;
            label10.Text = "Cidade:";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(67, 26);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(202, 23);
            txtCidade.TabIndex = 25;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txtDescontoMaximo);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(txtDesconto);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(txtSinal);
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(cbDesconto);
            tabPage3.Location = new Point(4, 27);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(293, 169);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Configuração";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtDesconto
            // 
            txtDesconto.DecimalPlaces = 1;
            txtDesconto.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            txtDesconto.Location = new Point(222, 74);
            txtDesconto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtDesconto.Name = "txtDesconto";
            txtDesconto.ReadOnly = true;
            txtDesconto.Size = new Size(54, 23);
            txtDesconto.TabIndex = 22;
            txtDesconto.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(144, 76);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 21;
            label9.Text = "Desconto% :";
            // 
            // txtDescontoMaximo
            // 
            txtDescontoMaximo.DecimalPlaces = 1;
            txtDescontoMaximo.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            txtDescontoMaximo.Location = new Point(146, 118);
            txtDescontoMaximo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtDescontoMaximo.Name = "txtDescontoMaximo";
            txtDescontoMaximo.ReadOnly = true;
            txtDescontoMaximo.Size = new Size(54, 23);
            txtDescontoMaximo.TabIndex = 24;
            txtDescontoMaximo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 120);
            label8.Name = "label8";
            label8.Size = new Size(109, 15);
            label8.TabIndex = 23;
            label8.Text = "Desconto Limite% :";
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 275);
            Controls.Add(tabControl1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaAluguelForm";
            Text = "Cadastro de Aluguéis";
            ((System.ComponentModel.ISupportInitialize)txtSinal).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtDesconto).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescontoMaximo).EndInit();
            ResumeLayout(false);
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private NumericUpDown txtDesconto;
        private Label label9;
        private Label label10;
        private TextBox txtCidade;
        private TextBox txtRua;
        private Label label11;
        private Label label12;
        private TextBox txtNumero;
        private NumericUpDown txtDescontoMaximo;
        private Label label8;
    }
}
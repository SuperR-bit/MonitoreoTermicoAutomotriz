namespace HMI_Temperatura_Solucion
{
    partial class Form1
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
        /// 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxConexion = new System.Windows.Forms.GroupBox();
            this.buttonDisconect = new System.Windows.Forms.Button();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.comboBoxRaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.labelRaudRate = new System.Windows.Forms.Label();
            this.labelComPort = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBoxTemperaturaActual = new System.Windows.Forms.GroupBox();
            this.labelTemperatura = new System.Windows.Forms.Label();
            this.groupBoxGrafico = new System.Windows.Forms.GroupBox();
            this.chartTemperatura = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxConfiguracionMargen = new System.Windows.Forms.GroupBox();
            this.buttonGuardarRango = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericMin = new System.Windows.Forms.NumericUpDown();
            this.numericMax = new System.Windows.Forms.NumericUpDown();
            this.groupBoxTabla = new System.Windows.Forms.GroupBox();
            this.dataGridViewTemperatura = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEstado = new System.Windows.Forms.GroupBox();
            this.labelAlerta = new System.Windows.Forms.Label();
            this.labelRango = new System.Windows.Forms.Label();
            this.checkBoxSonido = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBoxConexion.SuspendLayout();
            this.groupBoxTemperaturaActual.SuspendLayout();
            this.groupBoxGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).BeginInit();
            this.groupBoxConfiguracionMargen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).BeginInit();
            this.groupBoxTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemperatura)).BeginInit();
            this.groupBoxEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConexion
            // 
            this.groupBoxConexion.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxConexion.Controls.Add(this.buttonDisconect);
            this.groupBoxConexion.Controls.Add(this.buttonConnection);
            this.groupBoxConexion.Controls.Add(this.comboBoxRaudRate);
            this.groupBoxConexion.Controls.Add(this.comboBoxComPort);
            this.groupBoxConexion.Controls.Add(this.labelRaudRate);
            this.groupBoxConexion.Controls.Add(this.labelComPort);
            this.groupBoxConexion.Controls.Add(this.progressBar1);
            this.groupBoxConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConexion.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConexion.Name = "groupBoxConexion";
            this.groupBoxConexion.Size = new System.Drawing.Size(462, 315);
            this.groupBoxConexion.TabIndex = 0;
            this.groupBoxConexion.TabStop = false;
            this.groupBoxConexion.Text = "CONEXIÓN DE HARDWARE";
            // 
            // buttonDisconect
            // 
            this.buttonDisconect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconect.ForeColor = System.Drawing.Color.Black;
            this.buttonDisconect.Location = new System.Drawing.Point(254, 194);
            this.buttonDisconect.Name = "buttonDisconect";
            this.buttonDisconect.Size = new System.Drawing.Size(190, 41);
            this.buttonDisconect.TabIndex = 6;
            this.buttonDisconect.Text = "DESCONECTAR";
            this.buttonDisconect.UseVisualStyleBackColor = true;
            this.buttonDisconect.Click += new System.EventHandler(this.buttonDisconect_Click);
            // 
            // buttonConnection
            // 
            this.buttonConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnection.ForeColor = System.Drawing.Color.Black;
            this.buttonConnection.Location = new System.Drawing.Point(13, 194);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(190, 41);
            this.buttonConnection.TabIndex = 5;
            this.buttonConnection.Text = "CONECTAR";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // comboBoxRaudRate
            // 
            this.comboBoxRaudRate.FormattingEnabled = true;
            this.comboBoxRaudRate.Items.AddRange(new object[] {
            "9600",
            "38400",
            "57600",
            "115200"});
            this.comboBoxRaudRate.Location = new System.Drawing.Point(202, 119);
            this.comboBoxRaudRate.Name = "comboBoxRaudRate";
            this.comboBoxRaudRate.Size = new System.Drawing.Size(229, 28);
            this.comboBoxRaudRate.TabIndex = 4;
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.comboBoxComPort.Location = new System.Drawing.Point(202, 50);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(229, 28);
            this.comboBoxComPort.TabIndex = 3;
            // 
            // labelRaudRate
            // 
            this.labelRaudRate.AutoSize = true;
            this.labelRaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRaudRate.Location = new System.Drawing.Point(39, 125);
            this.labelRaudRate.Name = "labelRaudRate";
            this.labelRaudRate.Size = new System.Drawing.Size(136, 22);
            this.labelRaudRate.TabIndex = 2;
            this.labelRaudRate.Text = "RAUD RATE: ";
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComPort.Location = new System.Drawing.Point(39, 56);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(121, 22);
            this.labelComPort.TabIndex = 1;
            this.labelComPort.Text = "COM PORT:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 260);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 49);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // groupBoxTemperaturaActual
            // 
            this.groupBoxTemperaturaActual.Controls.Add(this.labelTemperatura);
            this.groupBoxTemperaturaActual.Location = new System.Drawing.Point(647, 21);
            this.groupBoxTemperaturaActual.Name = "groupBoxTemperaturaActual";
            this.groupBoxTemperaturaActual.Size = new System.Drawing.Size(311, 347);
            this.groupBoxTemperaturaActual.TabIndex = 1;
            this.groupBoxTemperaturaActual.TabStop = false;
            this.groupBoxTemperaturaActual.Text = "TEMPERATURA ACTUAL";
            // 
            // labelTemperatura
            // 
            this.labelTemperatura.AutoSize = true;
            this.labelTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperatura.Location = new System.Drawing.Point(139, 142);
            this.labelTemperatura.Name = "labelTemperatura";
            this.labelTemperatura.Size = new System.Drawing.Size(35, 38);
            this.labelTemperatura.TabIndex = 0;
            this.labelTemperatura.Text = "0";
            this.labelTemperatura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxGrafico
            // 
            this.groupBoxGrafico.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxGrafico.Controls.Add(this.chartTemperatura);
            this.groupBoxGrafico.Controls.Add(this.groupBoxTemperaturaActual);
            this.groupBoxGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGrafico.Location = new System.Drawing.Point(492, 12);
            this.groupBoxGrafico.Name = "groupBoxGrafico";
            this.groupBoxGrafico.Size = new System.Drawing.Size(964, 379);
            this.groupBoxGrafico.TabIndex = 1;
            this.groupBoxGrafico.TabStop = false;
            this.groupBoxGrafico.Text = "GRÁFICA DE TENDENCIAS EN TIEMPO REAL";
            // 
            // chartTemperatura
            // 
            chartArea6.Name = "ChartArea1";
            this.chartTemperatura.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartTemperatura.Legends.Add(legend6);
            this.chartTemperatura.Location = new System.Drawing.Point(20, 41);
            this.chartTemperatura.Name = "chartTemperatura";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartTemperatura.Series.Add(series6);
            this.chartTemperatura.Size = new System.Drawing.Size(608, 326);
            this.chartTemperatura.TabIndex = 2;
            this.chartTemperatura.Text = "chart1";
            // 
            // groupBoxConfiguracionMargen
            // 
            this.groupBoxConfiguracionMargen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxConfiguracionMargen.Controls.Add(this.buttonGuardarRango);
            this.groupBoxConfiguracionMargen.Controls.Add(this.label5);
            this.groupBoxConfiguracionMargen.Controls.Add(this.label4);
            this.groupBoxConfiguracionMargen.Controls.Add(this.numericMin);
            this.groupBoxConfiguracionMargen.Controls.Add(this.numericMax);
            this.groupBoxConfiguracionMargen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConfiguracionMargen.Location = new System.Drawing.Point(492, 407);
            this.groupBoxConfiguracionMargen.Name = "groupBoxConfiguracionMargen";
            this.groupBoxConfiguracionMargen.Size = new System.Drawing.Size(393, 302);
            this.groupBoxConfiguracionMargen.TabIndex = 1;
            this.groupBoxConfiguracionMargen.TabStop = false;
            this.groupBoxConfiguracionMargen.Text = "CONFIGURACIÓN DE MÁRGENES";
            // 
            // buttonGuardarRango
            // 
            this.buttonGuardarRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardarRango.Location = new System.Drawing.Point(76, 194);
            this.buttonGuardarRango.Name = "buttonGuardarRango";
            this.buttonGuardarRango.Size = new System.Drawing.Size(222, 62);
            this.buttonGuardarRango.TabIndex = 7;
            this.buttonGuardarRango.Text = "GUARDAR RANGOS";
            this.buttonGuardarRango.UseVisualStyleBackColor = true;
            this.buttonGuardarRango.Click += new System.EventHandler(this.buttonGuardarRango_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "MÁXIMO (°C):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "MÍNIMO (°C):";
            // 
            // numericMin
            // 
            this.numericMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMin.Location = new System.Drawing.Point(218, 51);
            this.numericMin.Name = "numericMin";
            this.numericMin.Size = new System.Drawing.Size(120, 34);
            this.numericMin.TabIndex = 1;
            this.numericMin.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // numericMax
            // 
            this.numericMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMax.Location = new System.Drawing.Point(218, 113);
            this.numericMax.Name = "numericMax";
            this.numericMax.Size = new System.Drawing.Size(120, 34);
            this.numericMax.TabIndex = 0;
            this.numericMax.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // groupBoxTabla
            // 
            this.groupBoxTabla.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxTabla.Controls.Add(this.dataGridViewTemperatura);
            this.groupBoxTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTabla.Location = new System.Drawing.Point(908, 407);
            this.groupBoxTabla.Name = "groupBoxTabla";
            this.groupBoxTabla.Size = new System.Drawing.Size(542, 302);
            this.groupBoxTabla.TabIndex = 2;
            this.groupBoxTabla.TabStop = false;
            this.groupBoxTabla.Text = "HISTORIAL DE EVENTOS Y REGISTRO";
            // 
            // dataGridViewTemperatura
            // 
            this.dataGridViewTemperatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemperatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora,
            this.Temp,
            this.Estado});
            this.dataGridViewTemperatura.Location = new System.Drawing.Point(15, 36);
            this.dataGridViewTemperatura.Name = "dataGridViewTemperatura";
            this.dataGridViewTemperatura.RowHeadersWidth = 51;
            this.dataGridViewTemperatura.RowTemplate.Height = 24;
            this.dataGridViewTemperatura.Size = new System.Drawing.Size(521, 260);
            this.dataGridViewTemperatura.TabIndex = 0;
            this.dataGridViewTemperatura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.MinimumWidth = 6;
            this.Hora.Name = "Hora";
            this.Hora.Width = 125;
            // 
            // Temp
            // 
            this.Temp.HeaderText = "Temp";
            this.Temp.MinimumWidth = 6;
            this.Temp.Name = "Temp";
            this.Temp.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.Width = 125;
            // 
            // groupBoxEstado
            // 
            this.groupBoxEstado.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxEstado.Controls.Add(this.labelAlerta);
            this.groupBoxEstado.Controls.Add(this.labelRango);
            this.groupBoxEstado.Controls.Add(this.checkBoxSonido);
            this.groupBoxEstado.Controls.Add(this.label6);
            this.groupBoxEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEstado.Location = new System.Drawing.Point(25, 359);
            this.groupBoxEstado.Name = "groupBoxEstado";
            this.groupBoxEstado.Size = new System.Drawing.Size(449, 350);
            this.groupBoxEstado.TabIndex = 2;
            this.groupBoxEstado.TabStop = false;
            this.groupBoxEstado.Text = "ESTADO Y SEÑALIZACIÓN";
            // 
            // labelAlerta
            // 
            this.labelAlerta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlerta.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelAlerta.Location = new System.Drawing.Point(6, 23);
            this.labelAlerta.Name = "labelAlerta";
            this.labelAlerta.Size = new System.Drawing.Size(437, 167);
            this.labelAlerta.TabIndex = 3;
            this.labelAlerta.Text = "OFF";
            this.labelAlerta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAlerta.Click += new System.EventHandler(this.labelAlerta_Click);
            // 
            // labelRango
            // 
            this.labelRango.AutoSize = true;
            this.labelRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRango.Location = new System.Drawing.Point(249, 216);
            this.labelRango.Name = "labelRango";
            this.labelRango.Size = new System.Drawing.Size(135, 29);
            this.labelRango.TabIndex = 2;
            this.labelRango.Text = "18°C - 24°C";
            // 
            // checkBoxSonido
            // 
            this.checkBoxSonido.AutoSize = true;
            this.checkBoxSonido.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSonido.Location = new System.Drawing.Point(30, 288);
            this.checkBoxSonido.Name = "checkBoxSonido";
            this.checkBoxSonido.Size = new System.Drawing.Size(227, 33);
            this.checkBoxSonido.TabIndex = 1;
            this.checkBoxSonido.Text = "Sonido Habilitado";
            this.checkBoxSonido.UseVisualStyleBackColor = true;
            this.checkBoxSonido.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "RANGO OBJETIVO: ";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1468, 721);
            this.Controls.Add(this.groupBoxEstado);
            this.Controls.Add(this.groupBoxTabla);
            this.Controls.Add(this.groupBoxConfiguracionMargen);
            this.Controls.Add(this.groupBoxGrafico);
            this.Controls.Add(this.groupBoxConexion);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "SISTEMA HMI MONITORE DE TEMEPRATURA EN TIEMPO REAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxConexion.ResumeLayout(false);
            this.groupBoxConexion.PerformLayout();
            this.groupBoxTemperaturaActual.ResumeLayout(false);
            this.groupBoxTemperaturaActual.PerformLayout();
            this.groupBoxGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).EndInit();
            this.groupBoxConfiguracionMargen.ResumeLayout(false);
            this.groupBoxConfiguracionMargen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).EndInit();
            this.groupBoxTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemperatura)).EndInit();
            this.groupBoxEstado.ResumeLayout(false);
            this.groupBoxEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConexion;
        private System.Windows.Forms.Button buttonDisconect;
        private System.Windows.Forms.ComboBox comboBoxRaudRate;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Label labelRaudRate;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBoxTemperaturaActual;
        private System.Windows.Forms.GroupBox groupBoxGrafico;
        private System.Windows.Forms.GroupBox groupBoxConfiguracionMargen;
        private System.Windows.Forms.Label labelTemperatura;
        private System.Windows.Forms.Button buttonGuardarRango;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericMin;
        private System.Windows.Forms.NumericUpDown numericMax;
        private System.Windows.Forms.GroupBox groupBoxTabla;
        private System.Windows.Forms.GroupBox groupBoxEstado;
        private System.Windows.Forms.CheckBox checkBoxSonido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelRango;
        private System.Windows.Forms.DataGridView dataGridViewTemperatura;
        private System.Windows.Forms.Label labelAlerta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperatura;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace HMI_Temperatura_Solucion
{
    public partial class Form1 : Form
    {
        // Ruta fija y directa a la carpeta donde quiero que se guarde el CVS
        private string rutaArchivoCSV = @"C:\Proyectos\registro_temperatura.csv";


        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxComPort.Text == "")
                {
                    MessageBox.Show("Por favor, selecciona un puerto COM válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                serialPort1.PortName = comboBoxComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBoxRaudRate.Text);
                serialPort1.Open();
                serialPort1.WriteLine("$On");

                //Nuevo: Pausa de 100 milisegundos para que el Arduino procese el encendido
                // Recuerda que el sensor digital tiene un retraso de 750 a 150 milisegundos
                System.Threading.Thread.Sleep(100);

                //Nuevo:Para solucionar el problema de guardado incorrecto de datos en el Arduino al desconectar y reconectar
                // Sincronzamos los rangos iniciales automaticamente al conectar
                // Se toman los valores que tengan el numericMin y numericMax
                string min = numericMin.Value.ToString("F1");
                string max = numericMax.Value.ToString("F1");
                serialPort1.WriteLine($"RANGOS:{min},{max}");

                // Cambiar estados de la interfaz
                buttonConnection.Enabled = false;
                buttonDisconect.Enabled = true;
                buttonGuardarRango.Enabled = true;
                progressBar1.Value = 100;
                comboBoxComPort.Enabled = false;
                comboBoxRaudRate.Enabled = false;

            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo abrir el puerto serial: " + error.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarConexionSerial();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuración inicial de los controles de conexión
                buttonConnection.Enabled = true;
                buttonDisconect.Enabled = false;
                buttonGuardarRango.Enabled = false;
                comboBoxRaudRate.Text = "9600";
                progressBar1.Value = 0;

                // Cargar puertos COM de forma dinámica para no depender de la lista fija
                // PENDIENTE: RESOLVER PORQUE LA LISTA YA NO SE VE
                comboBoxComPort.Items.Clear();
                string[] portList = SerialPort.GetPortNames();
                comboBoxComPort.Items.AddRange(portList);
                if (portList.Length > 0) comboBoxComPort.SelectedIndex = 0;

                // Configurar valores por defecto en los selectores de margen
                numericMin.Value = 18;
                numericMax.Value = 24;
                // Configuración de grafica de temperatura tipo lineas
                chartTemperatura.Series.Clear();
                var serie = chartTemperatura.Series.Add("Temperatura");
                serie.ChartType = SeriesChartType.Line;
                serie.XValueType = ChartValueType.String;
                serie.BorderWidth = 3;
                serie.Color = Color.Orange;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttonDisconect_Click(object sender, EventArgs e)
        {
             if (serialPort1.IsOpen)
            {
                try
                {
                    CerrarConexionSerial();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

        }

        private void CerrarConexionSerial()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$Off");
                    serialPort1.Close();
                }

                buttonConnection.Enabled = true;
                buttonDisconect.Enabled = false;
                buttonGuardarRango.Enabled = false;
                progressBar1.Value = 0;
                comboBoxComPort.Enabled = true;
                comboBoxRaudRate.Enabled = true;
                labelAlerta.Text = "OFF";
                labelAlerta.BackColor = SystemColors.ControlDarkDark;
                labelAlerta.ForeColor = Color.Black;

                labelTemperatura.Text = "0.0 °C";
                labelRango.Text = "18°C - 24°C";
                chartTemperatura.Series["Temperatura"].Points.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cerrar el puerto: " + error.Message);
            }
        }

        private void buttonGuardarRango_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    if (numericMin.Value >= numericMax.Value)
                    {
                        MessageBox.Show("El límite mínimo debe ser menor que el límite máximo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Enviar tramas formateadas a Arduino
                    string min = numericMin.Value.ToString("F1");
                    string max = numericMax.Value.ToString("F1");

                    /*
                    serialPort1.WriteLine("L:" + min);
                    System.Threading.Thread.Sleep(50); // Pequeña pausa de estabilidad
                    serialPort1.WriteLine("H:" + max);
                    */

                    //Nueva versió: Envio del rango en una sola linea separada por coma
                    //Previene la sobrecarga en el Buffer
                    serialPort1.WriteLine($"RANGOS:{min},{max}");

                    MessageBox.Show($"Rangos actualizados en Arduino:\nMínimo: {min}°C\nMáximo: {max}°C", "Configuración Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al transmitir los rangos: " + error.Message);
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string cadenaRecibida = serialPort1.ReadLine();

                // Mover los datos del hilo secundario al hilo principal del formulario
                this.Invoke(new MethodInvoker(delegate
                {
                    ProcesarDatosArduino(cadenaRecibida);
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en recepción serial: " + ex.Message);
            }
        }

        private void ProcesarDatosArduino(string datos)
        {
            datos = datos.Trim();
            string[] partes = datos.Split(',');

            if (partes.Length == 4)
            {
                string temperatura = partes[0];
                string estado = partes[1];
                string min = partes[2];
                string max = partes[3];

                string horaActual = DateTime.Now.ToString("HH:mm:ss");
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");

                // Mostrar la temperatura en la etiqueta principal
                // PENDIENTE: VOLVERLA MAS ESTETICA
                labelTemperatura.Text = temperatura + " °C";
                labelRango.Text = $"{min}°C - {max}°C";

                // Control de los indicadores de Alerta visuales y sonoros
                switch (estado)
                {
                    case "ALTA":
                        labelAlerta.Text = "¡ALERTA: TEMPERATURA ALTA!";
                        labelAlerta.BackColor = Color.Red;
                        labelAlerta.ForeColor = Color.White;
                        if (checkBoxSonido.Checked) System.Media.SystemSounds.Exclamation.Play();
                        break;

                    case "BAJA":
                        labelAlerta.Text = "¡ALERTA: TEMPERATURA BAJA!";
                        labelAlerta.BackColor = Color.Blue;
                        labelAlerta.ForeColor = Color.White;
                        if (checkBoxSonido.Checked) System.Media.SystemSounds.Exclamation.Play();
                        break;

                    case "NORMAL":
                        labelAlerta.Text = "TEMPERATURA ESTABLE";
                        labelAlerta.BackColor = Color.Green;
                        labelAlerta.ForeColor = Color.White;
                        break;
                }

                // Registrar los datos en la tabla (DataGridView)
                dataGridViewTemperatura.Rows.Add(horaActual, temperatura + " °C", estado);

                // Auto-desplazar la tabla hacia la última fila agregada
                if (dataGridViewTemperatura.RowCount > 0)
                {
                    dataGridViewTemperatura.FirstDisplayedScrollingRowIndex = dataGridViewTemperatura.RowCount - 1;
                }

                // Graficar los datos en tiempo real
                chartTemperatura.Series["Temperatura"].Points.AddXY(horaActual, Convert.ToDouble(temperatura));

                // Se Limita el gráfico a los últimos 20 registros para que no se sature visualmente
                if (chartTemperatura.Series["Temperatura"].Points.Count > 20)
                {
                    chartTemperatura.Series["Temperatura"].Points.RemoveAt(0);
                }

                GuardarFilaEnCSV(fechaActual, horaActual, temperatura, estado, min, max);
            }
        }

        private void GuardarFilaEnCSV(string fecha, string hora, string temp, string est, string mn, string mx)
        {
            try
            {
                // Extrae la ruta de la carpeta (C:\Proyectos) de la ruta completa del archivo
                string carpeta = Path.GetDirectoryName(rutaArchivoCSV);

                // Si la carpeta "Proyectos" no existe en el disco C, el programa la crea sola
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                // Si el archivo CSV no existe, lo creamos e insertamos los encabezados
                if (!File.Exists(rutaArchivoCSV))
                {
                    using (StreamWriter sw = new StreamWriter(rutaArchivoCSV, true))
                    {
                        sw.WriteLine("Fecha,Hora,Temperatura(C),Estado,MinimoConfig,MaximoConfig");
                    }
                }

                // Construimos la línea de texto separada por comas
                string lineaData = $"{fecha},{hora},{temp},{est},{mn},{mx}";

                // Escribimos la fila al final del archivo
                using (StreamWriter sw = new StreamWriter(rutaArchivoCSV, true))
                {
                    sw.WriteLine(lineaData);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al guardar fila en CSV: " + ex.Message);
            }
        }

        private void labelAlerta_Click(object sender, EventArgs e)
        {

        }
    }
}

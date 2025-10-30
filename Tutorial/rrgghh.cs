using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial
{
    public partial class rrgghh : Form
    {
        public rrgghh()
        {
            InitializeComponent();
        }
        SqlConnection conexion = ConexionDB.ObtenerConexion();
        private void button1_Click(object sender, EventArgs e)
        {
            if (R_user.Checked)
            {
                if (string.IsNullOrEmpty(textBox1.Text) ||
                    string.IsNullOrEmpty(textBox2.Text) ||
                    string.IsNullOrEmpty(textBox3.Text) ||
                    string.IsNullOrEmpty(textBox4.Text) ||
                    string.IsNullOrEmpty(textBox5.Text))

                {
                    MessageBox.Show("Por favor, complete todos los campos");
                    return;
                }
                else
                {
                    if (textBox5.Text.Length < 8 || !textBox5.Text.Any(char.IsUpper) || !textBox5.Text.Any(char.IsDigit))

                    {
                        MessageBox.Show("La contraseña debe tener al menos 8 caracteres, una mayuscula y un numero");
                        return;
                    }
                    else
                    {
                        if (textBox1.Text.Length != 4)

                        {
                            MessageBox.Show("La cedula debe tener exactamente 4 digitos");
                            return;
                        }

                        conexion.Open();

                        string consultaExistencia = "SELECT COUNT(*) FROM iniciar WHERE cedula = @Cedula";
                        SqlCommand comandoExistencia = new SqlCommand(consultaExistencia, conexion);
                        comandoExistencia.Parameters.AddWithValue("@Cedula", textBox1.Text);

                        int cantidad = (int)comandoExistencia.ExecuteScalar();
                        if (cantidad > 0)
                        {
                            MessageBox.Show("La cedula ingresada ya existe en la base de datos");
                            conexion.Close();
                            return;
                        }

                        string consulta = "INSERT INTO iniciar VALUES (@Valor1, @Valor2 ,@Valor3 ,@Valor4 ,@Valor5)";
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@Valor1", textBox1.Text);
                        comando.Parameters.AddWithValue("@Valor2", textBox2.Text);
                        comando.Parameters.AddWithValue("@Valor3", textBox3.Text);
                        comando.Parameters.AddWithValue("@Valor4", textBox4.Text);
                        comando.Parameters.AddWithValue("@Valor5", textBox5.Text);

                        comando.ExecuteNonQuery();

                        conexion.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";

                        MessageBox.Show("Usuario agregado correctamente");
                    }

                }
            }
            else if (R_admin.Checked)
            {
                if (string.IsNullOrEmpty(textBox1.Text) ||
                  string.IsNullOrEmpty(textBox2.Text) ||
                  string.IsNullOrEmpty(textBox3.Text) ||
                  string.IsNullOrEmpty(textBox4.Text) ||
                  string.IsNullOrEmpty(textBox5.Text))

                {
                    MessageBox.Show("Por favor, complete todos los campos");
                    return;
                }
                else
                {
                    if (textBox5.Text.Length < 8 || !textBox5.Text.Any(char.IsUpper) || !textBox5.Text.Any(char.IsDigit))

                    {
                        MessageBox.Show("La contraseña debe tener al menos 8 caracteres, una mayuscula y un numero");
                        return;
                    }
                    else
                    {
                        if (textBox1.Text.Length != 4)

                        {
                            MessageBox.Show("La cedula debe tener exactamente 4 digitos");
                            return;
                        }

                        conexion.Open();

                        string consultaExistencia = "SELECT COUNT(*) FROM inciarAdmin WHERE cedula = @Cedula";
                        SqlCommand comandoExistencia = new SqlCommand(consultaExistencia, conexion);
                        comandoExistencia.Parameters.AddWithValue("@Cedula", textBox1.Text);

                        int cantidad = (int)comandoExistencia.ExecuteScalar();
                        if (cantidad > 0)
                        {
                            MessageBox.Show("La cedula ingresada ya existe en la base de datos");
                            conexion.Close();
                            return;
                        }

                        string consulta = "INSERT INTO in-ciarAdmin VALUES (@Valor1, @Valor2 ,@Valor3 ,@Valor4 ,@Valor5)";
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@Valor1", textBox1.Text);
                        comando.Parameters.AddWithValue("@Valor2", textBox2.Text);
                        comando.Parameters.AddWithValue("@Valor3", textBox3.Text);
                        comando.Parameters.AddWithValue("@Valor4", textBox4.Text);
                        comando.Parameters.AddWithValue("@Valor5", textBox5.Text);

                        comando.ExecuteNonQuery();

                        conexion.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";

                        MessageBox.Show("Usuario agregado correctamente");
                    }

                }
            }
        }
    }
}


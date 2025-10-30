using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tutorial
{
    public partial class bombo : Form
    {
        public bombo()
        {
            InitializeComponent();
        }

        SqlConnection conexion = ConexionDB.ObtenerConexion();
        private void button1_Click(object sender, EventArgs e)
        {
            //Hollaaaa
            conexion.Open();
            string consultaUsuario = "SELECT * FROM iniciar WHERE usuario = @usuario AND contraseña = @contraseña";
            SqlCommand comandoUsuario = new SqlCommand(consultaUsuario, conexion);
            comandoUsuario.Parameters.AddWithValue("@usuario", textBox1.Text);
            comandoUsuario.Parameters.AddWithValue("@contraseña", textBox2.Text);

            SqlDataReader lector = comandoUsuario.ExecuteReader();

            bool usuarioEncontrado = false;

            if (lector.HasRows)

            {
                lector.Read();
                string usuarioBD = lector["usuario"].ToString();
                string contraseñaBD = lector["contraseña"].ToString();

                if (string.Equals(textBox1.Text, usuarioBD, StringComparison.Ordinal) && string.Equals(textBox2.Text, contraseñaBD, StringComparison.Ordinal))
                {
                    string Nusuario = lector["nombre"].ToString();
                    Usuario inicio = new Usuario(Nusuario);
                    inicio.Show();
                    this.Hide();
                    usuarioEncontrado = true;
                }
            }

            lector.Close();
            if (!usuarioEncontrado)
            {
                string consultaAdmin = "SELECT * FROM inciarAdmin WHERE usuario = @usuario AND contraseña = @contraseña";
                SqlCommand comandoAdmin = new SqlCommand(consultaAdmin, conexion);
                comandoAdmin.Parameters.AddWithValue("@usuario", textBox1.Text);
                comandoAdmin.Parameters.AddWithValue("@contraseña", textBox2.Text);

                lector = comandoAdmin.ExecuteReader();

                if (lector.HasRows)
                {
                    lector.Read();
                    string usuarioDB = lector["usuario"].ToString();
                    string contraseñaBD = lector["contraseña"].ToString();

                    if (!string.Equals(textBox1.Text, usuarioDB, StringComparison.Ordinal) && string.Equals(textBox2.Text, contraseñaBD, StringComparison.Ordinal))
                    {
                        string Nusuario = lector["nombre"].ToString();
                        Admin iniAdmin = new Admin(Nusuario);
                        iniAdmin.Show();
                        this.Hide();
                        usuarioEncontrado = true;
                    }
                }

                lector.Close();
            }

            if (!usuarioEncontrado)
            {
                MessageBox.Show("Usuario o contraseña incorrecta");

            }

            conexion.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;

            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}

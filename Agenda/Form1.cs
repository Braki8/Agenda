using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            
            MessageBox.Show("Coneccion Exitosa");
            dataGridView1.DataSource = LLenarGrilla();
           
        }
        public DataTable LLenarGrilla()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "Select * From Contactos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
           
            string insertar = "Insert Into Contactos(Nombre,Apellido,FechaNacimiento,Direccion,Genero,EstadoCivil,NumeroMovil,Telefono,Correo)\n" +
                " Values(@Nombre,@Apellido,@FechaNacimiento,@Direccion,@Genero,@EstadoCivil,@NumeroMovil,@Telefono,@Correo)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            cmd1.Parameters.AddWithValue("@FechaNacimiento", txtFecha.Text);
            cmd1.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
            cmd1.Parameters.AddWithValue("@Genero", txtGenero.Text);
            cmd1.Parameters.AddWithValue("@EstadoCivil", txtEstadoCivil.Text);
            cmd1.Parameters.AddWithValue("@NumeroMovil", txtMovil1.Text);
            cmd1.Parameters.AddWithValue("@Telefono", txtTelefono1.Text);
            cmd1.Parameters.AddWithValue("@Correo", txtCorreo.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("El contacto fue agendado correctamente");
            dataGridView1.DataSource = LLenarGrilla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtFecha.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtGenero.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtEstadoCivil.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtMovil1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtTelefono1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch { }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string actualizar = "Update Contactos set Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento,Direccion=@Direccion,\n" +
                "Genero=@Genero,EstadoCivil=@EstadoCivil,NumeroMovil=@NumeroMovil,Telefono=@Telefono,Correo=@Correo where idcontacto=@idcontacto"; 


            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@idcontacto", txtid.Text);
            cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            cmd2.Parameters.AddWithValue("@FechaNacimiento", txtFecha.Text);
            cmd2.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
            cmd2.Parameters.AddWithValue("@Genero", txtGenero.Text);
            cmd2.Parameters.AddWithValue("@EstadoCivil", txtEstadoCivil.Text);
            cmd2.Parameters.AddWithValue("@NumeroMovil", txtMovil1.Text);
            cmd2.Parameters.AddWithValue("@Telefono", txtTelefono1.Text);
            cmd2.Parameters.AddWithValue("@Correo", txtCorreo.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron modificados exitosamente");
            dataGridView1.DataSource = LLenarGrilla();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear(); 
            txtApellido.Clear(); 
            txtDireccion.Clear();
            txtMovil1.Clear();
            txtTelefono1.Clear();
            txtCorreo.Clear();
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "Delete From Contactos where Nombre=@Nombre";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("Nombre", txtNombre.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados exitosamente");
            dataGridView1.DataSource = LLenarGrilla();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            


                    Conexion.Conectar();



                    SqlConnection conex = new SqlConnection(Properties.Settings.Default.Conexion);
                    String query = "select * from Contactos where " + comboBox1.Text + " like '%" + txtBuscar.Text + "%'";
                    SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.Conectar());


                    DataSet data = new DataSet();

                    ada.Fill(data, "contactos");

                    dataGridView1.DataSource = data;
                    dataGridView1.DataMember = "contactos";

                }
                
        }

      
    }


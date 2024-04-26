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

namespace queSql
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }
        public void Conectar()
        {
            conn.ConnectionString = @"Data Source=ACADEMICA-10;Initial Catalog=victorGay;User ID=sa;Password=utn";
            try
            {
                conn.Open();
                MessageBox.Show("Conectada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Desconectar()
        {
            conn.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                string sel = "SELECT * FROM Clientes";
                SqlDataAdapter da = new SqlDataAdapter(sel, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                string sel = "INSERT INTO Clientes (Nombre, Apellido, Direccion, Telefono, Email)" +
                    "VALUES(" + 
                    "'" + txtNombre.Text.Trim() + "'," +
                    "'" + txtApellido.Text.Trim() + "'," +
                    "'" + txtDireccion.Text.Trim() + "'," +
                    "'" + txtTelefono.Text.Trim() + "'," +
                    "'" + txtEmail.Text.Trim() + "')";
                SqlDataAdapter da = new SqlDataAdapter(sel, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                string id = "SELECT * FROM Clientes WHERE Id = " + Convert.ToInt64(txtId.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(id, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    txtNombre.Text = dt.Rows[0].Field<string>("Nombre");
                    txtApellido.Text = dt.Rows[0].Field<string>("Apellido");
                    txtDireccion.Text = dt.Rows[0].Field<string>("Direccion");
                    txtTelefono.Text = dt.Rows[0].Field<string>("Telefono");
                    txtEmail.Text = dt.Rows[0].Field<string>("Email");
                } else
                {
                    MessageBox.Show("No se encontró.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                string sel = "DELETE FROM Clientes";
                SqlDataAdapter da = new SqlDataAdapter(sel, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Tabla vaciada.");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                string id = "DELETE FROM Clientes WHERE Id = " + Convert.ToInt64(txtId.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(id, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show(txtId.Text.Trim() + " Eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}

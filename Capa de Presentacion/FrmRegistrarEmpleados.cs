using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using CapaLogicaNegocio;

namespace Capa_de_Presentacion
{
    public partial class FrmRegistrarEmpleados : DevComponents.DotNetBar.Metro.MetroForm
    {
        clsCargo C = new clsCargo();
        clsEmpleado E = new clsEmpleado();
        int Listado = 0;
        public FrmRegistrarEmpleados()
        {
            InitializeComponent();
        }

        private void FrmRegistrarEmpleados_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            CargarComboBox();
        }

        private void CargarComboBox(){
            comboBox1.DataSource = C.Listar();
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "IdCargo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCargo C = new FrmRegistrarCargo();
            //C.Show();
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRegistrarCargo);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmRegistrarCargo();
            frm.Show();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Char EstadoCivil = 'S';
                try //CDA05 si el IdEmpleado no posee un valor entonces generamos uno nuevo en el catch.
                {
                    E.IdEmpleado = Convert.ToInt32(txtIdE.Text);
                }
                catch (Exception)
                {
                    string numero = E.GenerarIdEmpleado();
                    txtIdE.Text = numero;
                    E.IdEmpleado = Convert.ToInt32(txtIdE.Text);
                }
                
                E.IdCargo = Convert.ToInt32(comboBox1.SelectedValue);
                E.Dni = txtDni.Text;
                E.Apellidos = txtApellidos.Text;
                E.Nombres = txtNombres.Text;
                E.Sexo = rbnMasculino.Checked == true ? 'M' : 'F';
                E.FechaNac = Convert.ToDateTime(dateTimePicker1.Value);
                switch (cbxEstadoCivil.SelectedIndex)
                {
                    case 1: EstadoCivil = 'S'; break;
                    case 2: EstadoCivil = 'C'; break;
                    case 3: EstadoCivil = 'D'; break;
                    case 4: EstadoCivil = 'V'; break;
                }
                E.EstadoCivil = EstadoCivil;
                E.Direccion = txtDireccion.Text;
                DevComponents.DotNetBar.MessageBoxEx.Show(E.MantenimientoEmpleados(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Limpiar();
                this.Close();//cerramos la ventana una vez que se realizo el guardado del empleado.
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
            
        }

        private void Limpiar() {
            cbxEstadoCivil.SelectedIndex = 0;
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtDni.Clear();
            txtNombres.Clear();
            rbnMasculino.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            txtIdE.Clear();
            Program.IdCargo = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Listado) {
                case 0: CargarComboBox(); break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void FrmRegistrarEmpleados_Activated(object sender, EventArgs e)
        {
            if (Program.IdCargo != 0)
                comboBox1.SelectedValue = Program.IdCargo;
            else
                cbxEstadoCivil.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Eliminar este Empleado.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                try
                {
                    Char EstadoCivil = 'S';
                    try //CDA05 si el IdEmpleado no posee un valor entonces mostramos el mensaje de que hay que seleccionar un empleado para eliminarlo.
                    {
                        E.IdEmpleado = Convert.ToInt32(txtIdE.Text);
                    }
                    catch (Exception)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Seleccione un empleado para eliminar (No se encontro el IdEmpleado). Reintente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }

                    E.IdCargo = Convert.ToInt32(comboBox1.SelectedValue);
                    E.Dni = txtDni.Text;
                    E.Apellidos = txtApellidos.Text;
                    E.Nombres = txtNombres.Text;
                    E.Sexo = rbnMasculino.Checked == true ? 'M' : 'F';
                    E.FechaNac = Convert.ToDateTime(dateTimePicker1.Value);
                    switch (cbxEstadoCivil.SelectedIndex)
                    {
                        case 1: EstadoCivil = 'S'; break;
                        case 2: EstadoCivil = 'C'; break;
                        case 3: EstadoCivil = 'D'; break;
                        case 4: EstadoCivil = 'V'; break;
                    }
                    E.EstadoCivil = EstadoCivil;
                    E.Direccion = txtDireccion.Text;
                    DevComponents.DotNetBar.MessageBoxEx.Show(E.EliminarEmpleado(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Limpiar();
                    this.Close();//cerramos la ventana una vez que se realizo el eliminado del empleado.
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}

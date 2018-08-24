using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEnlaceDatos;
using DevComponents.DotNetBar;

namespace Capa_de_Presentacion
{
    public partial class FrmMenuPrincipal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static string variable; //variable que nos permitira obtener el nombre del usuario de aca al FormTal.

        int EnviarFecha = 0;
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Activated(object sender, EventArgs e)
        {
            lblUsuario.Text = Program.NombreEmpleadoLogueado;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            string usuarioLogueado = Program.NombreEmpleadoLogueado.ToString(); //otra forma de limitar el acceso a usuarios que no son administradores
            if (usuarioLogueado != "admin, admin")//ACA LIMITAMOS EL ACCESO A USUARIOS QUE NO SEAN EL ADMINISTRADOR.
            {
                btnEmpleados.Enabled = false;
                btnProductos.Enabled = false;
                btnUsuarios.Enabled = false;
                btnConsultaVentas.Enabled = false;
            }

            timer1.Interval = 500;
            timer1.Start();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //FrmListadoProductos P = new FrmListadoProductos();
            //P.Show();
            //ESTO ES PARA AVITAR QUE UNA VENTANA SE DUPLIQUE, SI YA ESTA ABIERTA LA TRAE AL FRENTE.
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListadoProductos);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmListadoProductos();
            frm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //FrmListadoClientes C = new FrmListadoClientes();
            //C.Show();
            //ESTO ES PARA AVITAR QUE UNA VENTANA SE DUPLIQUE, SI YA ESTA ABIERTA LA TRAE AL FRENTE.
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListadoClientes);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmListadoClientes();
            frm.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //FrmRegistroVentas V = new FrmRegistroVentas();
            //V.Show();
            //ESTO ES PARA AVITAR QUE UNA VENTANA SE DUPLIQUE, SI YA ESTA ABIERTA LA TRAE AL FRENTE.
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRegistroVentas);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmRegistroVentas();
            frm.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //FrmRegistrarUsuarios U = new FrmRegistrarUsuarios();
            //U.Show();
            //ESTO ES PARA AVITAR QUE UNA VENTANA SE DUPLIQUE, SI YA ESTA ABIERTA LA TRAE AL FRENTE.
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRegistrarUsuarios);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmRegistrarUsuarios();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(EnviarFecha){
                case 0: CapturarFechaSistema(); break;
            }
        }

        private void CapturarFechaSistema() {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            //FrmListadoEmpleados E = new FrmListadoEmpleados();
            //E.Show();
            //ESTO ES PARA AVITAR QUE UNA VENTANA SE DUPLIQUE, SI YA ESTA ABIERTA LA TRAE AL FRENTE.
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListadoEmpleados);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmListadoEmpleados();
            frm.Show();
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmConsultaVentas);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new FrmConsultaVentas();
            frm.Show();
        }
    }
}

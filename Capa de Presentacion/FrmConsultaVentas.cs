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
    public partial class FrmConsultaVentas : DevComponents.DotNetBar.Metro.MetroForm
    {

        private clsConsulta C = new clsConsulta();

        public FrmConsultaVentas()
        {
            InitializeComponent();
            ListarElementos();
        }

        private void FrmConsultaVentas_Load(object sender, EventArgs e)
        {
            ListarElementos();
        }

        private void ListarElementos()
        {
            if (IdC.Text.Trim() != "")
            {
                comboBoxUsuarios.DisplayMember = "Usuario";
                comboBoxUsuarios.ValueMember = "IdUsuario";
                comboBoxUsuarios.DataSource = C.Listar();
                comboBoxUsuarios.SelectedValue = IdC.Text;
            }
            else
            {
                comboBoxUsuarios.DisplayMember = "Usuario";
                comboBoxUsuarios.ValueMember = "IdUsuario";
                comboBoxUsuarios.DataSource = C.Listar();
            }
        }

        private void buttonVentaTotalDia_Click(object sender, EventArgs e)
        {
            C.FechaVenta = Convert.ToDateTime(dateTimePicker1.Value);
            DevComponents.DotNetBar.MessageBoxEx.Show(C.ReporteTotalVentaDia(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            C.FechaVenta = Convert.ToDateTime(dateTimePicker2.Value);
            C.Usuario = comboBoxUsuarios.Text;
            DevComponents.DotNetBar.MessageBoxEx.Show(C.ReporteVentaConFiltro(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void buttonVentaTotalMes_Click(object sender, EventArgs e)
        {
            C.FechaVenta = Convert.ToDateTime(dateTimePicker3.Value);
            DevComponents.DotNetBar.MessageBoxEx.Show(C.ConsultaVentaTotalMes(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

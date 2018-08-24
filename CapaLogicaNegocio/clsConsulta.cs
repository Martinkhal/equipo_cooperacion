using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
    public class clsConsulta
    {
        clsManejador R = new clsManejador();

        public DateTime FechaVenta { get; set; }
        public string Usuario { get; set; }

        public DataTable Listar()
        {
            return R.Listado("ListarUsuarios", null);
        }

        public String ReporteTotalVentaDia()
        {
            String Mensaje = "";
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@FechaVenta", FechaVenta));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                R.EjecutarSP("ConsultaTotalVentaDia", ref lst);

                //VERIFICAMOS QUE EL MENSAJE DEVUELVA ALGO, SI NO LO HACE LANZAMOS EL MENSAJE DE QUE NO HAY VENTAS PARA LA FECHA ESPECIFICADA.
                string mensaje = lst[1].Valor.ToString();
                if (mensaje == "")
                {
                    return Mensaje = "No se encontraron ventas en la fecha especificada.";
                }
                else
                {
                    return Mensaje = lst[1].Valor.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String ReporteVentaConFiltro()
        {
            String Mensaje = "";
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@FechaVenta", FechaVenta));
                lst.Add(new clsParametro("@Usuario", Usuario));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                R.EjecutarSP("ConsultaTotalVentaConFiltro", ref lst);

                //VERIFICAMOS QUE EL MENSAJE DEVUELVA ALGO, SI NO LO HACE LANZAMOS EL MENSAJE DE QUE NO HAY VENTAS PARA LA FECHA ESPECIFICADA.
                string mensaje = lst[2].Valor.ToString();
                if (mensaje == "")
                {
                    return Mensaje = "No se encontraron ventas de este usuario en la fecha especificada.";
                }
                else
                {
                    return Mensaje = lst[2].Valor.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String ConsultaVentaTotalMes()
        {
            String Mensaje = "";
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@FechaVenta", FechaVenta));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                R.EjecutarSP("ConsultaTotalVentaMes", ref lst);

                //VERIFICAMOS QUE EL MENSAJE DEVUELVA ALGO, SI NO LO HACE LANZAMOS EL MENSAJE DE QUE NO HAY VENTAS PARA LA FECHA ESPECIFICADA.
                string mensaje = lst[1].Valor.ToString();
                if (mensaje == "")
                {
                    return Mensaje = "No se encontraron ventas para el mes especificado.";
                }
                else
                {
                    return Mensaje = lst[1].Valor.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

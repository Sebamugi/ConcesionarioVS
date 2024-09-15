using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCV.clases
{
    public class Concesionario
    {
        public string Nombre { get; set; }
        public Inventario Inventario { get; set; } = new Inventario();
        public List<Venta> VentasRealizadas = new List<Venta>();

        public void RegistrarVenta(Vehiculo vehiculo, Cliente cliente)
        {
            if (cliente.DineroDisponible >= vehiculo.Precio)
            {
                Venta nuevaVenta = new Venta()
                {
                    VehiculoVendido = vehiculo,
                    Cliente = cliente,
                    PrecioVenta = vehiculo.Precio,
                    FechaVenta = DateTime.Now

                };

                VentasRealizadas.Add(nuevaVenta);
                cliente.ComprarVehiculo(vehiculo, Inventario);
                Inventario.EliminarVehiculo(vehiculo);
            }  
            else
            {
                MessageBox.Show("El Cliente no tiene suficiente dinero.");
            }
        }

        public void MostrarHistorialVentas()
        {
            foreach (var venta in VentasRealizadas)
            {
                venta.MostrarDetalleVenta();
            }
        }
    }
}

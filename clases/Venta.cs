using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemoCV.clases
{
    public class Venta
    {
        public Guid IdVenta { get; set; }
        public Vehiculo VehiculoVendido { get; set; }
        public Cliente Cliente { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaVenta { get; set; }

        public Venta()
        {
            IdVenta = Guid.NewGuid();
        }

        public string[] itemView()
        {
            string[] data = {
                IdVenta.ToString(),
                $"{VehiculoVendido.Marca} {VehiculoVendido.Modelo}",
                $"{Cliente.Nombre} {Cliente.Apellidos}",
                PrecioVenta.ToString("C"),
                FechaVenta.ToString("dd/MM/yyyy")
            };
            return data;
        }

        public void MostrarDetalleVenta()
        {
            Console.WriteLine($"{FechaVenta} : {Cliente.Nombre} {Cliente.Apellidos} " +
                $"compró {VehiculoVendido.Marca} en ${PrecioVenta} ");
        }


    }
}

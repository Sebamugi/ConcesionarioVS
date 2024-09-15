using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCV.clases
{
    public class Cliente
    {
        public string Id { get; set; }
        public  string Nombre { get; set; }
        public string Apellidos { get; set; }
        public decimal DineroDisponible { get; set; }


        public Cliente()
        {
            Guid guid = Guid.NewGuid();
            Id = guid.ToString();
        }
        public string[] itemView()
        {
            string[] data = {Id, Nombre,
                    Apellidos, Convert.ToString(DineroDisponible) };
            return data;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Apellidos}";
        }

        public string mostrarDatos()
        {
            return $"{Nombre} - {Apellidos} - {DineroDisponible}";
        }
        public void ComprarVehiculo(Vehiculo vehiculo, Inventario inventario)
        {
            if (DineroDisponible>=vehiculo.Precio)
            {
                inventario.EliminarVehiculo(vehiculo);
                DineroDisponible = DineroDisponible - vehiculo.Precio;
                Console.WriteLine($"{Nombre} {Apellidos} compró el auto {vehiculo.Marca} {vehiculo.Modelo}" );
            }
            else
            {
                Console.WriteLine("Compra Fallida. Verifica el inventario o el dinero disponible");
            }
        }

    }
}

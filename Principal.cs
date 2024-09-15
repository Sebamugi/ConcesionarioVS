using DemoCV.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes formcliente = new Clientes();
            formcliente.MdiParent = this.MdiParent;
            formcliente.Show();





        }

        private void Principal_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "The quick brown fox. Jump!";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Alert!";
            notifyIcon1.ShowBalloonTip(2000);
            notifyIcon1.Visible = true;

            AgregarClientesPorDefecto();
            AgregarVehiculosPorDefecto();

        }

        public void AgregarVehiculosPorDefecto()
        {
            List<Vehiculo> vehiculosPorDefecto = new List<Vehiculo>()
            {
                new Vehiculo { Id = Guid.NewGuid(), Marca = "Toyota", Modelo = "Corolla", Año = 2020, Kilometraje = 15000, Precio = 20000 },
                new Vehiculo { Id = Guid.NewGuid(), Marca = "Honda", Modelo = "Civic", Año = 2018, Kilometraje = 30000, Precio = 18000 },
                new Vehiculo { Id = Guid.NewGuid(), Marca = "Ford", Modelo = "Focus", Año = 2019, Kilometraje = 20000, Precio = 17500 }
            };
            foreach (var vehiculo in vehiculosPorDefecto)
            {
                GlobalVar.Inventario.AgregarVehiculo(vehiculo);
            }
        }

        private void AgregarClientesPorDefecto()
        {
            List<Cliente> clientesPorDefecto = new List<Cliente>()
            {
                new Cliente { Id = Guid.NewGuid().ToString(), Nombre = "Carlos", Apellidos = "Gradin", DineroDisponible = 20000 },
                new Cliente { Id = Guid.NewGuid().ToString(), Nombre = "Roberto", Apellidos = "Bolaño", DineroDisponible = 18000},
                new Cliente { Id = Guid.NewGuid().ToString(), Nombre = "Fernanda", Apellidos = "Melchor", DineroDisponible = 300000}
            };

            foreach (var cliente in clientesPorDefecto)
            {
                GlobalVar.clientes.Add(cliente);
            }
        }

        private void crearVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas form = new Ventas();
            form.MdiParent = this.MdiParent;
            form.Show();

        }

        private void concesionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehiculos form = new Vehiculos();
            form.MdiParent= this.MdiParent;
            form.Show();
        }
    }
}

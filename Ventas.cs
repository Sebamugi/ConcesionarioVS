using DemoCV.clases;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Ventas : Form
    {
        private Guid ventaIdOriginal = Guid.Empty; 
        public Ventas()
        {
            InitializeComponent();
            if (GlobalVar.Inventario == null)
            {
                GlobalVar.Inventario = new Inventario();
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            cargaClientes();
            cargaVehiculos();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Cliente", 150);
            listView1.Columns.Add("Vehículo", 150);
            listView1.Columns.Add("Precio", 150);
            listView1.Columns.Add("Fecha", 150);
        }

        void cargaClientes()
        {
            cb_clientes.Items.AddRange(GlobalVar.clientes.ToArray());
        }

        void cargaVehiculos()
        {
            cb_vehiculo.Items.AddRange(GlobalVar.Inventario.Lista().ToArray());
        }

        private void cb_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehiculo vehiculoSeleccionado = cb_vehiculo.SelectedItem as Vehiculo;

            if (vehiculoSeleccionado != null)
            {
                tx_precio.Text = $"Precio: {vehiculoSeleccionado.Precio:C}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = cb_clientes.SelectedItem as Cliente;
            Vehiculo vehiculoSeleccionado = cb_vehiculo.SelectedItem as Vehiculo;

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Debes seleccionar un cliente.");
                return;
            }

            if (vehiculoSeleccionado == null)
            {
                MessageBox.Show("Debes seleccionar un vehículo.");
                return;
            }

            if (clienteSeleccionado.DineroDisponible < vehiculoSeleccionado.Precio)
            {
                MessageBox.Show("El cliente no tiene suficiente dinero para comprar este vehículo.");
                return;
            }

            Venta venta = new Venta()
            {
                IdVenta = Guid.NewGuid(), 
                Cliente = clienteSeleccionado,
                VehiculoVendido = vehiculoSeleccionado,
                PrecioVenta = vehiculoSeleccionado.Precio,
                FechaVenta = DateTime.Now 
            };

            if (ventaIdOriginal != Guid.Empty)
            {
                Venta ventaModificar = GlobalVar.concesionario.VentasRealizadas.FirstOrDefault(v => v.IdVenta == ventaIdOriginal);
                if (ventaModificar != null)
                {
                    ventaModificar.Cliente = clienteSeleccionado;
                    ventaModificar.VehiculoVendido = vehiculoSeleccionado;
                    ventaModificar.PrecioVenta = vehiculoSeleccionado.Precio;
                    ventaModificar.FechaVenta = DateTime.Now;

                    MessageBox.Show("Venta modificada con éxito.");
                }
                ventaIdOriginal = Guid.Empty;
            }
            else
            {
                GlobalVar.concesionario.RegistrarVenta(vehiculoSeleccionado, clienteSeleccionado);
                MessageBox.Show("Venta registrada con éxito.");
            }

            ListarVentas();
        }

        private void ListarVentas()
        {
            listView1.Items.Clear();

            foreach (var venta in GlobalVar.concesionario.VentasRealizadas)
            {
                ListViewItem item = new ListViewItem(venta.Cliente.Nombre + " " + venta.Cliente.Apellidos);
                item.SubItems.Add(venta.VehiculoVendido.Marca + " " + venta.VehiculoVendido.Modelo);
                item.SubItems.Add(venta.PrecioVenta.ToString("C"));
                item.SubItems.Add(venta.FechaVenta.ToString("dd/MM/yyyy"));

                item.Tag = venta.IdVenta;

                listView1.Items.Add(item);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Guid id = (Guid)listView1.SelectedItems[0].Tag;
                Venta ventaEliminar = GlobalVar.concesionario.VentasRealizadas.FirstOrDefault(v => v.IdVenta == id);

                if (ventaEliminar != null)
                {
                    GlobalVar.concesionario.VentasRealizadas.Remove(ventaEliminar);
                    ListarVentas();
                    MessageBox.Show("Venta eliminada exitosamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una venta para eliminar.");
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Guid id = (Guid)listView1.SelectedItems[0].Tag;
                Venta ventaModificar = GlobalVar.concesionario.VentasRealizadas.FirstOrDefault(v => v.IdVenta == id);

                if (ventaModificar != null)
                {
                    cb_clientes.SelectedItem = ventaModificar.Cliente;
                    cb_vehiculo.SelectedItem = ventaModificar.VehiculoVendido;
                    tx_precio.Text = ventaModificar.PrecioVenta.ToString("C");

                    ventaIdOriginal = ventaModificar.IdVenta;
                }
            }
            else
            {
                MessageBox.Show("Selecciona una venta para modificar.");
            }
        }
    }
}

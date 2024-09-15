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

namespace WinFormsApp1
{
    public partial class Vehiculos : Form
    {
        private Guid vehiculoIdOriginal = Guid.Empty;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        public Vehiculos()
        {
            InitializeComponent();
        }

        private void VehiculosForms_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Marca");
            listView1.Columns.Add("Modelo");
            listView1.Columns.Add("Año");
            listView1.Columns.Add("Kilometraje");
            listView1.Columns.Add("Precio");


            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = 100;
            }
            ListarVehiculos();

        }


        void ListarVehiculos()
        {
            listView1.Items.Clear();
            foreach (Vehiculo vehiculo in GlobalVar.Inventario.Lista())
            {
                ListViewItem item = new ListViewItem(vehiculo.itemView());
                item.Tag = vehiculo.Id;  
                listView1.Items.Add(item);
            }
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tx_año.Text))
            {
                MessageBox.Show("Debes ingresar el año del vehiculo");
                tx_año.Focus();
                return;
            }

            int año;
            if (!int.TryParse(tx_año.Text, out año))
            {
                MessageBox.Show("El año debe ser un número válido");
                tx_año.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tx_km.Text))
            {
                MessageBox.Show("Debes ingresar el kilometraje");
                tx_km.Focus();
                return;
            }

            int kilometraje;
            if (!int.TryParse(tx_km.Text, out kilometraje))
            {
                MessageBox.Show("El kilometraje debe ser un número válido");
                tx_km.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tx_precio.Text))
            {
                MessageBox.Show("Debes ingresar el precio");
                tx_precio.Focus();
                return;
            }

            decimal precio;
            if (!decimal.TryParse(tx_precio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un valor numérico válido");
                tx_precio.Focus();
                return;
            }

            Vehiculo vehiculo = new Vehiculo()
            {
                Año = año,
                Kilometraje = kilometraje,
                Precio = precio,
                Marca = tx_marca.Text,
                Modelo = tx_modelo.Text
            };

            if (vehiculoIdOriginal != Guid.Empty)
            {
                Vehiculo vehiculo_modificar = GlobalVar.Inventario.Lista().FirstOrDefault(v => v.Id == new Guid(vehiculoIdOriginal.ToString()));

                vehiculo_modificar.Marca = vehiculo.Marca;
                vehiculo_modificar.Modelo = vehiculo.Modelo;
                vehiculo_modificar.Año = vehiculo.Año;
                vehiculo_modificar.Kilometraje = vehiculo.Kilometraje;
                vehiculo_modificar.Precio = vehiculo.Precio;
                MessageBox.Show("Vehículo modificado");
            }
            else
            {
                vehiculo.Id = Guid.NewGuid(); 
                GlobalVar.Inventario.AgregarVehiculo(vehiculo);
                MessageBox.Show("Vehículo almacenado");
            }

            vehiculoIdOriginal = Guid.Empty;
            ListarVehiculos();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idText = listView1.SelectedItems[0].SubItems[0].Text;
            Guid id = new Guid(idText);
            Vehiculo vehiculoEliminar = GlobalVar.Inventario.Lista().FirstOrDefault(v => v.Id == id);


            GlobalVar.Inventario.EliminarVehiculo(vehiculoEliminar);
            ListarVehiculos();
            MessageBox.Show("Vehículo eliminado");
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guid id = (Guid)listView1.SelectedItems[0].Tag;
            Vehiculo vehiculoModificar = GlobalVar.Inventario.Lista().FirstOrDefault(v => v.Id == id);

            tx_marca.Text = vehiculoModificar.Marca;
            tx_modelo.Text = vehiculoModificar.Modelo;
            tx_año.Text = Convert.ToString(vehiculoModificar.Año);
            tx_km.Text = Convert.ToString(vehiculoModificar.Kilometraje);
            tx_precio.Text = Convert.ToString(vehiculoModificar.Precio);

            vehiculoIdOriginal = vehiculoModificar.Id;
        }
    }
}

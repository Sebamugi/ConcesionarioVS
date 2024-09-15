using DemoCV.clases;

namespace WinFormsApp1
{
    public partial class Clientes : Form
    {

        string IdGlobal = "";
        public Clientes()
        {
            InitializeComponent();
        }

        void ListarClientes()
        {
            listView1.Items.Clear();
            foreach (Cliente cliente in GlobalVar.clientes)
            {
                var item = new ListViewItem(new[] { cliente.Nombre, cliente.Apellidos, cliente.DineroDisponible.ToString() });

                item.Tag = cliente.Id;
                listView1.Items.Add(item);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tx_nombre.Text))
            {
                MessageBox.Show("Debes ingresar un nombre");
                tx_nombre.Focus();
                return;
            }
            if (String.IsNullOrEmpty(tx_apellido.Text))
            {
                MessageBox.Show("Debes ingresar un apellido");
                tx_apellido.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tx_dinero.Text))
            {
                MessageBox.Show("Debes ingresar un dinerillo");
                tx_dinero.Focus();
                return;
            }

            decimal lukas;

            bool isOk = decimal.TryParse(tx_dinero.Text, out lukas);
            if (!isOk)
            {
                MessageBox.Show("Ingresa dinero valido");
                tx_dinero.Focus();
                return;
            }

            Cliente cliente = new Cliente()
            {
                Nombre = tx_nombre.Text,
                Apellidos = tx_apellido.Text,
                DineroDisponible = lukas
            };
            if (String.IsNullOrEmpty(IdGlobal))
            {
                GlobalVar.clientes.Add(cliente);
                MessageBox.Show("Cliente Almacenado");

            }
            else
            {
                Cliente cliente_modificar 
                    = GlobalVar.clientes.Where(x => x.Id == IdGlobal).FirstOrDefault()!;
                cliente_modificar.Nombre = tx_nombre.Text;
                cliente_modificar.Apellidos = tx_apellido.Text;
                cliente_modificar.DineroDisponible = Convert.ToDecimal(tx_dinero.Text);
                IdGlobal = "";
            }
           
            ListarClientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;

            listView1.Columns.Add("Nombre");
            listView1.Columns.Add("Apellido");
            listView1.Columns.Add("Dinero");


            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = 100;
            }
            ListarClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = listView1.SelectedItems[0].Tag.ToString();
            Cliente cliente_eliminar = GlobalVar.clientes.Where(x => x.Id == id).FirstOrDefault()!;
            GlobalVar.clientes.Remove(cliente_eliminar);
            ListarClientes();
            MessageBox.Show("Elemento eliminado");

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = listView1.SelectedItems[0].Tag.ToString();
            IdGlobal = id;
            Cliente cliente_modificar = GlobalVar.clientes.Where(x => x.Id == id).FirstOrDefault()!;
            tx_nombre.Text = cliente_modificar.Nombre;
            tx_apellido.Text = cliente_modificar.Apellidos;
            tx_dinero.Text = Convert.ToString(cliente_modificar.DineroDisponible);


        }
    }
}

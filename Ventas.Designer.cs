namespace WinFormsApp1
{
    partial class Ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cb_clientes = new ComboBox();
            cb_vehiculo = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btn_guardar = new Button();
            label3 = new Label();
            tx_precio = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            listView1 = new ListView();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cb_clientes
            // 
            cb_clientes.FormattingEnabled = true;
            cb_clientes.Location = new Point(37, 62);
            cb_clientes.Margin = new Padding(4, 5, 4, 5);
            cb_clientes.Name = "cb_clientes";
            cb_clientes.Size = new Size(260, 33);
            cb_clientes.TabIndex = 0;
            // 
            // cb_vehiculo
            // 
            cb_vehiculo.FormattingEnabled = true;
            cb_vehiculo.Location = new Point(325, 62);
            cb_vehiculo.Margin = new Padding(4, 5, 4, 5);
            cb_vehiculo.Name = "cb_vehiculo";
            cb_vehiculo.Size = new Size(317, 33);
            cb_vehiculo.TabIndex = 1;
            cb_vehiculo.SelectedIndexChanged += cb_vehiculo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(325, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 2;
            label1.Text = "Vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 3;
            label2.Text = "Cliente";
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(325, 150);
            btn_guardar.Margin = new Padding(4, 5, 4, 5);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(317, 38);
            btn_guardar.TabIndex = 4;
            btn_guardar.Text = "Guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 120);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 5;
            label3.Text = "Precio";
            // 
            // tx_precio
            // 
            tx_precio.Location = new Point(37, 150);
            tx_precio.Margin = new Padding(4, 5, 4, 5);
            tx_precio.Name = "tx_precio";
            tx_precio.Size = new Size(260, 31);
            tx_precio.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarToolStripMenuItem, modificarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(160, 68);
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(159, 32);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(159, 32);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // listView1
            // 
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Location = new Point(37, 239);
            listView1.Name = "listView1";
            listView1.Size = new Size(605, 376);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 655);
            Controls.Add(listView1);
            Controls.Add(tx_precio);
            Controls.Add(label3);
            Controls.Add(btn_guardar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cb_vehiculo);
            Controls.Add(cb_clientes);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Ventas";
            Text = "Ventas";
            Load += Ventas_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_clientes;
        private ComboBox cb_vehiculo;
        private Label label1;
        private Label label2;
        private Button btn_guardar;
        private Label label3;
        private TextBox tx_precio;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ListView listView1;
    }
}
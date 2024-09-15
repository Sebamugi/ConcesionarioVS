namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            GlobalVar.Inventario = new DemoCV.clases.Inventario();
            GlobalVar.clientes = new List<DemoCV.clases.Cliente>();
            GlobalVar.concesionario = new DemoCV.clases.Concesionario();

            Application.Run(new Principal());
        }
    }
}
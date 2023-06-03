using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyectofinal
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        internal string usuario;

        public Window1()
        {
            InitializeComponent();
        }
        private SqlConnection CrearConexion()
        {
            return new SqlConnection("C:\\Users\\Windows 10\\Desktop\\3 semestre ingenieria\\progra I\\Proyectofinal\\Database2.mdf");
        }
      
        public string Contraseña { get; internal set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Windows 10\\Desktop\\3 semestre ingenieria\\progra I\\Proyectofinal\\Database2.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string codigos = codigo.Text;

                string query = "SELECT descripcion, producto, precio FROM Producto WHERE Codigo = @Codigo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigos);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descripcion = reader["descripcion"].ToString();
                            string producto = reader["producto"].ToString();
                            string precio = reader["precio"].ToString();

                            desc.Text = descripcion;
                            produc.Text = producto;
                            prec.Text = precio;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el código.");
                        }
                    }
                }
            }

        }
        private void codigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cant_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tot_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tot.Text = (Convert.ToInt64(prec.Text) * Convert.ToInt64(cant.Text)).ToString();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {


            // crear variables
            string cantida = cant.Text;
            string nombress = produc.Text;
            string descrip = desc.Text;
            string precioss = prec.Text;
            string totall = tot.Text;

            // Acceder a la instancia de la segunda ventana (Window2)
            Window2 window2 = Application.Current.Windows.OfType<Window2>().FirstOrDefault();

            // Verificar si la ventana ya está abierta o no
            if (window2 != null)
            {
               
                window2.listproducto.Items.Add(cantida);
                window2.listnombre.Items.Add(nombress);
                window2.listdescrip.Items.Add(descrip);
                window2.listprecio.Items.Add(precioss);
                window2.listtotal.Items.Add(totall);
                codigo.Text = "";
                produc.Text = "";
                desc.Text = "";
                prec.Text = "";
                cant.Text = "";
                tot.Text = "";
            }
            else
            {
               
                window2 = new Window2();
                window2.listproducto.Items.Add(cantida);
                window2.listnombre.Items.Add(nombress);
                window2.listdescrip.Items.Add(descrip);
                window2.listprecio.Items.Add(precioss);
                window2.listtotal.Items.Add(totall);
                window2.Show();
                codigo.Text = "";
                produc.Text = "";
                desc.Text = "";
                prec.Text = "";
                cant.Text = "";
                tot.Text = "";

            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Nos pregunta primero si estamos seguros
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Verificar la respuesta del usuario
            if (resultado == MessageBoxResult.Yes)
            {
                // Cierra todas las ventanas abiertas
                Application.Current.Shutdown();
            }
        }
    }
}


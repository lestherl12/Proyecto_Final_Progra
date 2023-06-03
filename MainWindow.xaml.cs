using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Proyectofinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
  
        public class USUARIO
        {
            public string? Usuario { get; set; }
            public string? Contraseña { get; set; }
        }


        private SqlConnection CrearConexion()
        {
            return new SqlConnection("C:\\Users\\Windows 10\\Desktop\\3 semestre ingenieria\\progra I\\Proyectofinal\\Database1.mdf");
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                string usuarioText = usuarios.Text;
                string contraseña = contrase.Text;

                // Realizar la verificación en la base de datos
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Windows 10\Desktop\3 semestre ingenieria\progra I\Proyectofinal\Database1.mdf;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM USUARIO WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuarioText);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // si los datos coinciden, abrir la ventana de window1.xaml
                            Window1 window1 = new Window1();
                            window1.usuario = usuarioText;
                            window1.Contraseña = contraseña;
                            window1.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña o usuario incorrectos");
                        usuarios.Text = "";
                        contrase.Text = "";
                        }

                    }
                }   
        }
    }
}

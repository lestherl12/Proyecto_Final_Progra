using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
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
    public partial class Window2 : Window
    {
        public ObservableCollection<string> ListProductos { get; set; }
        public ObservableCollection<string> ListNombres { get; set; }
        public ObservableCollection<string> ListPrecios { get; set; }

        public Window2()
        {
            InitializeComponent();
            ListProductos = new ObservableCollection<string>();
            ListNombres = new ObservableCollection<string>();
            ListPrecios = new ObservableCollection<string>();
            DataContext = this;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lógica del evento ListBox_SelectionChanged
        }

        private void listtotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lógica del evento listtotal_SelectionChanged
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Impresión");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
         


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int suma = 0;
            foreach (var valor in listtotal.Items)
            {
                if (int.TryParse(valor.ToString(), out int numero))
                {
                    suma += numero;
                }
            }

            // Mostrar la suma en el TextBox "SUMAA"
            SUMAA.Text = suma.ToString();
        }
    }

    public class Datos
    {
        public string Producto { get; set; }
        public int Precio { get; set; }
    }
}
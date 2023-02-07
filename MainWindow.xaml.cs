using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diccionario_DDi.Traductor;

namespace Diccionario_DDi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   // Inicializamos la clase traductor
        TraductorIE ob = new TraductorIE();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {   // metodo que vacia el campo de escritura
            txtBoxEscribir.Text = "";
        }

        // Método para el boton de traducir
        private void Button_Click(object sender, RoutedEventArgs e)
        {   // Llamamos a nuestro objeto.y llamamos a la propiedad entrada=valor del textBox
            ob.Entrada = txtBoxEscribir.Text;
            labelTraduccion.Content = ob.Traduceme(); // el control de traduccion(label) Llame al método y lo muestre

        }

        // Método para el boton de borrar 
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            // Llamamos a los controles
            txtBoxEscribir.Text = string.Empty;
            labelTraduccion.Content = string.Empty;

        }
    }
}

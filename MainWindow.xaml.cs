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

namespace Diccionario_DDi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<String, String> palabrasIngles_Espanol = null;
        private Dictionary<String, String> palabrasEspanol_Ingles = null;

        public MainWindow()
        {
            InitializeComponent();
            crearDiccionario();
        }

        private void crearDiccionario()
        {
            palabrasEspanol_Ingles = new Dictionary<string, string>() {
                {"Negro","Black"},{"Gato","Cat"},{"Perro","Dog"},{"Casa","House"},{"Blanco","White"},
                {"Naranja","Orange"},{"Flor","Flower"},{"Ventana","Window"},{"Ordenador","Computer"},{"Verde","Green"}
            };
            palabrasIngles_Espanol = new Dictionary<string, string>();
            foreach(var clave in palabrasEspanol_Ingles)
            {
                if (!palabrasIngles_Espanol.ContainsKey(clave.Value))
                {
                    palabrasIngles_Espanol.Add(clave.Value, clave.Key);
                }
            }
        }

        private void traducirPalabras(object sender, RoutedEventArgs e)
        {

        }

        private void cambiaVentana2(object sender, RoutedEventArgs e)
        {

        }

        private void cambiaVentana1(object sender, RoutedEventArgs e)
        {

        }
    }
}

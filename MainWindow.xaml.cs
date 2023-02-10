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
        private String palabraAdivinar = null;
        private List<int> numerosusados = null;
        private Random random = new Random();
        private int numeroRandom = 0;
        private int numAciertos = 0;
        private int numFallos = 0;

        public MainWindow()
        {
            InitializeComponent();
            crearDiccionarioEspanol_Ingles();
            crearDiccionarioIngles_Espanol();
            cargarListView();
            txtEspanol1.IsReadOnly = true;
            txtIngles2.IsReadOnly = true;
            btnComprobarPalabra.Visibility = Visibility.Hidden;
            btnSiguientePalabra.Visibility = Visibility.Hidden;
        }
        /* ============= MÉTODOS GENERALES ============= */
        private void cargarListView()
        {
            listViewPalabras.Items.Clear();
            foreach(var elemento in palabrasIngles_Espanol)
            {
                listViewPalabras.Items.Add(elemento.Key + " = " +elemento.Value );
            }
        }

        private void limpiarCampos()
        {
            txtIngles2.Text = string.Empty;
            txtEspanol2.Text = string.Empty;
            txtIngles1.Text = string.Empty;
            txtEspanol1.Text = string.Empty;
            txtEspanol3.Text = string.Empty;
            txtIngles3.Text = string.Empty;
        }

        private void crearDiccionarioEspanol_Ingles()
        {
            palabrasEspanol_Ingles = new Dictionary<string, string>() {
                {"Negro","Black"},{"Gato","Cat"},{"Perro","Dog"},{"Casa","House"},{"Blanco","White"},
                {"Naranja","Orange"},{"Flor","Flower"},{"Ventana","Window"},{"Ordenador","Computer"},{"Verde","Green"}
            };
        }

        private void crearDiccionarioIngles_Espanol()
        {
            palabrasIngles_Espanol = new Dictionary<string, string>();
            foreach (var clave in palabrasEspanol_Ingles)
            {
                if (!palabrasIngles_Espanol.ContainsKey(clave.Value))
                {
                    palabrasIngles_Espanol.Add(clave.Value, clave.Key);
                }
            }
        }
        

        private void insertarPalabra(string ingles, string espanol) {
            palabrasEspanol_Ingles.Add(espanol, ingles);
            palabrasIngles_Espanol.Add(ingles, espanol);
        }
        /* =============  ============= */

        /* ============= VENTANA INGLÉS - ESPAÑOL ============= */
        private void traducirInglesEspanol(object sender, RoutedEventArgs e)
        {

            foreach (var elemento in palabrasIngles_Espanol)
            {
                if (txtIngles1.Text.ToUpper() == elemento.Key.ToUpper())
                {
                    txtEspanol1.Text = elemento.Value;
                }
            }
        }
        private void cambiaVentana2(object sender, RoutedEventArgs e)
        {
            controlPestanas.SelectedIndex = 1;
            limpiarCampos();
        }

        private void txtIngles1_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEspanol1.Text = string.Empty;
        }
        /* =============  ============= */

        /* ============= VENTANA ESPAÑOL - INGLÉS ============= */
        private void traducirEspanolIngles(object sender, RoutedEventArgs e)
        {
            foreach(var elemento in palabrasEspanol_Ingles)
            {
                if (txtEspanol2.Text.ToUpper() == elemento.Key.ToUpper()) 
                { 
                    txtIngles2.Text = elemento.Value;
                }
            }
        }
        private void cambiaVentana1(object sender, RoutedEventArgs e)
        {
            controlPestanas.SelectedIndex = 0;
            limpiarCampos();
        }

        private void txtEspanol2_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtIngles2.Text = string.Empty;
        }
        /* =============  ============= */

        /* ============= VENTANA JUEGO ============= */
        private void empezarJuego(object sender, RoutedEventArgs e)
        {
            numFallos = 0;
            numAciertos = 0;
            panelTaparPalabra.Visibility = Visibility.Visible;
            btnComprobarPalabra.Visibility = Visibility.Visible;
            txtAdivinarJuego.IsReadOnly = true;
            numerosusados = new List<int>();
            numeroRandom = random.Next(0, palabrasEspanol_Ingles.Count);
            numerosusados.Add(numeroRandom);
            palabraAdivinar =  palabrasEspanol_Ingles.ElementAt(numeroRandom).Value;
            txtAdivinarJuego.Text = palabraAdivinar.Trim();
            txtRespuestaJuego.Text = string.Empty;
            txtnumAciertos.Text = numAciertos.ToString();
            txtnumFallos.Text = numFallos.ToString();
        }

        private void comprobarPalabra(object sender, RoutedEventArgs e)
        {
            panelTaparPalabra.Visibility = Visibility.Hidden;
            if (txtAdivinarJuego.Text.Trim().ToUpper() == txtRespuestaJuego.Text.Trim().ToUpper())
            {
                numAciertos++;
            }else { numFallos++; }

            txtnumAciertos.Text = numAciertos.ToString().Trim();
            txtnumFallos.Text = numFallos.ToString().Trim();
            if (numAciertos+numFallos != palabrasEspanol_Ingles.Count)
            {
                btnComprobarPalabra.Visibility = Visibility.Hidden;
                btnSiguientePalabra.Visibility = Visibility.Visible;
            }else
            {
                btnComprobarPalabra.Visibility = Visibility.Hidden;
            }
            
        }

        private void siguientePalabra(object sender, RoutedEventArgs e)
        {
            Boolean comprobar = true;
            btnSiguientePalabra.Visibility = Visibility.Hidden;
            btnComprobarPalabra.Visibility = Visibility.Visible;
            txtRespuestaJuego.Text = string.Empty;
            numeroRandom = random.Next(0, palabrasEspanol_Ingles.Count);
            do {
                if (numerosusados.Contains(numeroRandom))
                {
                    numeroRandom = random.Next(0, palabrasEspanol_Ingles.Count);
                }else { numerosusados.Add(numeroRandom); comprobar = false; }
            } while (comprobar);
            panelTaparPalabra.Visibility = Visibility.Visible;
            palabraAdivinar = palabrasEspanol_Ingles.ElementAt(numeroRandom).Value;
            txtAdivinarJuego.Text = palabraAdivinar.Trim();
        }

        private void reiniciarJuego(object sender, RoutedEventArgs e)
        {
            empezarJuego(sender, e);
        }
        /* =============  ============= */

        /* ============= VENTANA LISTADO ORDENADO ============= */
        private void anadirPalabra(object sender, RoutedEventArgs e)
        {
            insertarPalabra(txtIngles3.Text, txtEspanol3.Text);
            cargarListView();
            limpiarCampos();
        }

        private void eliminarPalabra(object sender, RoutedEventArgs e)
        {
            listViewPalabras.Items.Remove(listViewPalabras.SelectedItem);   
            palabrasEspanol_Ingles.Remove(txtEspanol3.Text);
            palabrasIngles_Espanol.Remove(txtIngles3.Text);
            cargarListView();
            limpiarCampos();
        }

        private void cogerPalabras(object sender, SelectionChangedEventArgs e)
        {
            int posicion = 0;
            if (listViewPalabras.SelectedItem != null)
            {
                posicion = listViewPalabras.SelectedItem.ToString().IndexOf("= ");
                string palabraIngles = listViewPalabras.SelectedItem.ToString().Substring(0, posicion);
                string palabraEspanol = listViewPalabras.SelectedItem.ToString().Substring(posicion + 1);
                txtIngles3.Text = palabraIngles.Trim();
                txtEspanol3.Text = palabraEspanol.Trim();
            }
            
        }

        private void limpiarCamposVentana4(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
        }
    }
}

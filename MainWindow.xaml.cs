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
            crearDiccionarioEspanol_Ingles();
            crearDiccionarioIngles_Espanol();
            cargarListView();
            txtEspanol1.IsReadOnly = true;
            txtIngles2.IsReadOnly = true;
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
            palabrasIngles_Espanol = new Dictionary<string, string>();
            foreach(var clave in palabrasEspanol_Ingles)
            {
                if (!palabrasIngles_Espanol.ContainsKey(clave.Value))
                {
                    palabrasIngles_Espanol.Add(clave.Value, clave.Key);
                }
            }
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
        /* =============  ============= */

        /* ============= VENTANA JUEGO ============= */

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

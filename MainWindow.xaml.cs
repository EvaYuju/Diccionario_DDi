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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Añadir(object sender, RoutedEventArgs e)
        {
           
            if (textIngles.Text.Length != 0 || textEsp.Text.Length != 0)
            {
                string ing = textIngles.Text.ToString();
                string esp = textEsp.Text.ToString();
                lista.Items.Add(ing + " = " + esp);

                textIngles.Clear();
                textEsp.Clear();

            } else
            {
                MessageBox.Show("Debe rellenar todos los campos", "Añadir a lista ordenada");
            }
           
            
        } 

        private void Eliminar(object sender, RoutedEventArgs e)
        {
            lista.Items.RemoveAt(lista.Items.IndexOf(lista.SelectedItem));
        }

    
    }
}

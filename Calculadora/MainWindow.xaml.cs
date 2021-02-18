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

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float primera_parte=int.MinValue;
        private float segunda_parte = 0;
        private string operacon_guardada;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            lbl_pantalla.Content =(lbl_pantalla.Content.ToString()!="0")? lbl_pantalla.Content+""+ bt.Content: bt.Content;

        }

        private void Operacion(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            if (operacon_guardada == null) {
                operacon_guardada = bt.Content.ToString();
                primera_parte = float.Parse(lbl_pantalla.Content.ToString());
                lbl_pantalla.Content = "0";
                lbl_resumen.Content = primera_parte.ToString() + " " + operacon_guardada;
            }
            else
            {
                realizar_operacion();
                lbl_resumen.Content = "0";
                operacon_guardada = bt.Content.ToString();
                lbl_resumen.Content = lbl_resumen.Content.ToString() + " " + segunda_parte.ToString() + " " + operacon_guardada;
            }

        }

        private void Resultado(object sender, RoutedEventArgs e)
        {

            if (operacon_guardada != null)
            {
                realizar_operacion();
            }
        }

        private void realizar_operacion()
        {
            segunda_parte = float.Parse(lbl_pantalla.Content.ToString());
            switch (operacon_guardada)
            {
                case "+":
                    lbl_pantalla.Content = primera_parte + segunda_parte;
                    primera_parte = float.Parse(lbl_pantalla.Content.ToString());
                    break;
                case "-":
                    lbl_pantalla.Content = primera_parte - segunda_parte;
                    primera_parte = float.Parse(lbl_pantalla.Content.ToString());
                    break;
                case "x":
                    lbl_pantalla.Content = primera_parte * segunda_parte;
                    primera_parte = float.Parse(lbl_pantalla.Content.ToString());
                    break;
                case "/":
                    lbl_pantalla.Content = (float)primera_parte / segunda_parte;
                    primera_parte = float.Parse(lbl_pantalla.Content.ToString());
                    break;
            }
        }

        private void Reseteo_Completo(object sender, RoutedEventArgs e)
        {
            primera_parte = 0;
            segunda_parte = 0;
            lbl_pantalla.Content = "0";
            operacon_guardada = null;
            lbl_resumen.Content = "";
        }

        private void Añadir_coma(object sender, RoutedEventArgs e)
        {
            lbl_pantalla.Content =  lbl_pantalla.Content + ",";
        }

        private void Cambiar_signo(object sender, RoutedEventArgs e)
        {
            lbl_pantalla.Content = float.Parse(lbl_pantalla.Content.ToString())*(-1);

        }

        private void BorrarNumero(object sender, RoutedEventArgs e)
        {

        }
    }
}

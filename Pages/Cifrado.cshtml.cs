using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class CifradoModel : PageModel
    {
        [BindProperty]
        public string mensaje { get; set; } = "";

        [BindProperty]
        public string clave { get; set; } = "";

        public string cifrado { get; set; } = "";

        public void OnPost()
        {
            // Convertir el mensaje a may�sculas para asegurar consistencia
            string mensaje = this.mensaje.ToUpper();

            // Convertir la clave a un n�mero entero
            int desplazamiento = int.Parse(this.clave);

            // Iterar sobre cada car�cter del mensaje
            foreach (char caracter in mensaje)
            {
                if (caracter == ' ')
                {
                    // Si el car�cter es un espacio, simplemente lo agregamos al cifrado
                    cifrado += ' ';
                }
                else
                {
                    // Calcular el desplazamiento del car�cter seg�n la clave
                    int ascii = (int)caracter;
                    int cifradoAscii = (ascii - 65 + desplazamiento) % 26 + 65;

                    // Convertir el valor ASCII cifrado de vuelta a un car�cter y agregarlo al cifrado
                    cifrado += (char)cifradoAscii;
                }
            }
        }
    }

}

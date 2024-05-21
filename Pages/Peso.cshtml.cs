using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class PesoModel : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";

        public double imc = 0;

        public String clasificacion = "";
        public void OnPost()
        {
            double p = Double.Parse(peso);
            double a = Double.Parse(altura);
            imc = p / (Math.Pow(a, 2));

            clasificacion = imc switch
            {
                < 18 => "Peso Bajo",
                >= 18 and < 25 => "Peso Normal",
                >= 25 and < 27 => "Sobrepeso",
                >= 27 and < 30 => "Obesidad grado I",
                >= 30 and < 40 => "Obesidad grado II",
                >= 40 => "Obesidad grado III",
                _ => "Clasificación no definida" // Default case, which is optional here
            };
        }
    }
}

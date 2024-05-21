using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class EstadisticaModel : PageModel
    {
        public int[] arregloAleatorio { get; private set; } = Array.Empty<int>();
        public int[] arregloOrdenado { get; private set; } = Array.Empty<int>();
        public int suma { get; private set; } = 0;
        public double promedio { get; private set; } = 0;
        public int[] moda { get; private set; } = Array.Empty<int>();
        public double mediana { get; private set; } = 0;

        public void OnPost()
        {
            // Generar un arreglo de números aleatorios
            Random random = new Random();
            arregloAleatorio = new int[20];
            for (int i = 0; i < arregloAleatorio.Length; i++)
            {
                arregloAleatorio[i] = random.Next(0, 100);
            }

            // Ordenar el arreglo
            arregloOrdenado = arregloAleatorio.OrderBy(x => x).ToArray();

            // Calcular la suma de los elementos
            suma = arregloAleatorio.Sum();

            // Calcular el promedio de los elementos
            promedio = arregloAleatorio.Average();

            // Calcular la moda
            var conteo = arregloAleatorio.GroupBy(x => x)
                                         .Select(x => new { x.Key, Count = x.Count() })
                                         .OrderByDescending(x => x.Count)
                                         .ToList();
            var maxCount = conteo.Max(x => x.Count);
            moda = conteo.Where(x => x.Count == maxCount)
                         .Select(x => x.Key)
                         .ToArray();

            // Calcular la mediana
            if (arregloOrdenado.Length % 2 == 0)
            {
                mediana = (arregloOrdenado[(arregloOrdenado.Length / 2) - 1] + arregloOrdenado[arregloOrdenado.Length / 2]) / 2.0;
            }
            else
            {
                mediana = arregloOrdenado[arregloOrdenado.Length / 2];
            }
        }
    }

}

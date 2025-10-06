using System; // para usar Console

public class GestionTurnosClinica // nombre de la clase
{
    public static void Main(string[] args) // punto de entrada del programa
    {
        Console.WriteLine(": Gestión de turnos en una clínica");
        Console.WriteLine("Se registrarán las edades de 20 pacientes.\n");

        //  Arreglo para guardar las 20 edades
        int[] edades = new int[20];

        //  Variables para conteo por grupo
        int nNinos = 0;    // 0–12
        int nJovenes = 0;  // 13–25
        int nAdultos = 0;  // 26–60
        int nMayores = 0;  // >60

        //  Variables para sumar edades (sirven para sacar promedios)
        int sumaTotal = 0;
        int sumaNinos = 0;
        int sumaJovenes = 0;
        int sumaAdultos = 0;
        int sumaMayores = 0;

        //  Pedimos y clasificamos las 20 edades
        for (int i = 0; i < edades.Length; i++) // usamos for para recorrer las 20 posiciones
        {
            Console.Write("Edad del paciente " + (i + 1) + ": ");
            int edad = Convert.ToInt32(Console.ReadLine()); // leemos y convertimos a int

            edades[i] = edad; // guardamos en el arreglo
            sumaTotal += edad; // sumamos para el promedio general

            // Clasificación según rangos del enunciado
            if (edad >= 0 && edad <= 12)
            {
                nNinos++;
                sumaNinos += edad;
            }
            else if (edad >= 13 && edad <= 25)
            {
                nJovenes++;
                sumaJovenes += edad;
            }
            else if (edad >= 26 && edad <= 60)
            {
                nAdultos++;
                sumaAdultos += edad;
            }
            else // > 60
            {
                nMayores++;
                sumaMayores += edad;
            }
        }

        //  Cálculo de promedios
        // Usamos cast a double para que salga con decimales.
        double promedioGeneral = sumaTotal / 20.0;

        // Para cada grupo: si no hay elementos en el grupo, el promedio es 0.0 (para evitar dividir entre cero)
        double promNinos   = (nNinos   > 0) ? (sumaNinos   / (double)nNinos)   : 0.0;
        double promJovenes = (nJovenes > 0) ? (sumaJovenes / (double)nJovenes) : 0.0;
        double promAdultos = (nAdultos > 0) ? (sumaAdultos / (double)nAdultos) : 0.0;
        double promMayores = (nMayores > 0) ? (sumaMayores / (double)nMayores) : 0.0;

        //  Resultados: cuántos hay en cada grupo
        Console.WriteLine("\n--- Resultados ---");
        Console.WriteLine("Niños (0–12): " + nNinos);
        Console.WriteLine("Jóvenes (13–25): " + nJovenes);
        Console.WriteLine("Adultos (26–60): " + nAdultos);
        Console.WriteLine("Mayores (>60): " + nMayores);

        //  Alerta si hay más de 5 mayores
        if (nMayores > 5)
        {
            Console.WriteLine("\nALERTA: hay más de 5 personas mayores (>60). Riesgo alto.");
        }

        //  Promedios: general y por grupo
        Console.WriteLine("\nPromedio de edad (general): " + promedioGeneral.ToString("0.00"));
        Console.WriteLine("Promedio Niños:   " + (nNinos   > 0 ? promNinos.ToString("0.00")   : "N/A"));
        Console.WriteLine("Promedio Jóvenes: " + (nJovenes > 0 ? promJovenes.ToString("0.00") : "N/A"));
        Console.WriteLine("Promedio Adultos: " + (nAdultos > 0 ? promAdultos.ToString("0.00") : "N/A"));
        Console.WriteLine("Promedio Mayores: " + (nMayores > 0 ? promMayores.ToString("0.00") : "N/A"));

        Console.WriteLine("\nFin del programa!!");
    }
}

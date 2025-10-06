// Descripcion: reto de registrar las edades de 20 pacientes.
        // Después, los clasificamos por grupo de edad y analizamos la distribución.


using System; // Asegúrate de que el espacio de nombres sea correcto según tu estructura de carpetas.

public class GestionTurnosClinica
{
    public static void Main(string[] args)
    {
Console.WriteLine("=== Gestión de turnos en una clínica ===\n");

const int totalPacientes = 20; // número fijo de pacientes

        // Acá creamos el arreglo para guardar las edades.
        int[] edades = new int[totalPacientes];

        // Estas variables contarán cuántos pacientes hay en cada grupo.
        int ninos = 0, jovenes = 0, adultos = 0, mayores = 0;

        // También vamos a guardar las sumas para calcular los promedios.
        int sumaGeneral = 0, sumaNinos = 0, sumaJovenes = 0, sumaAdultos = 0, sumaMayores = 0;

        Console.WriteLine("Ingrese la edad de los 20 pacientes:");
        for (int i = 0; i < totalPacientes; i++)
        {
            
            edades[i] = LeerEntero($"  Edad del paciente #{i + 1}: ", 0, 120);

            // Clasificamos según la edad.
            int edad = edades[i];
            sumaGeneral += edad; // acumulamos para el promedio total

            // Acá vamos agrupando cada edad en su categoría.
            if (edad <= 12)
            {
                ninos++;
                sumaNinos += edad;
            }
            else if (edad <= 25)
            {
                jovenes++;
                sumaJovenes += edad;
            }
            else if (edad <= 60)
            {
                adultos++;
                sumaAdultos += edad;
            }
            else
            {
                mayores++;
                sumaMayores += edad;
            }
        }

        // Mostramos cuántos hay en cada grupo.
        Console.WriteLine("\n=== Distribución por grupo de edad ===");
        Console.WriteLine($"Niños (0-12): {ninos}");
        Console.WriteLine($"Jóvenes (13-25): {jovenes}");
        Console.WriteLine($"Adultos (26-60): {adultos}");
        Console.WriteLine($"Mayores (>60): {mayores}");

        // Acá verificamos si hay más de 5 personas mayores.
        if (mayores > 5)
        {
            Console.WriteLine("\n⚠ Alerta: hay más de 5 personas mayores (alto riesgo).");
        }

        // Calculamos el promedio general y por grupo (solo si el grupo tiene personas).
        double promedioGeneral = (double)sumaGeneral / totalPacientes;
        Console.WriteLine("\n=== Promedios de edad ===");
        Console.WriteLine($"Promedio general: {promedioGeneral:F2}");

        if (ninos > 0)
            Console.WriteLine($"Promedio de niños: {(double)sumaNinos / ninos:F2}");
        if (jovenes > 0)
            Console.WriteLine($"Promedio de jóvenes: {(double)sumaJovenes / jovenes:F2}");
        if (adultos > 0)
            Console.WriteLine($"Promedio de adultos: {(double)sumaAdultos / adultos:F2}");
        if (mayores > 0)
            Console.WriteLine($"Promedio de mayores: {(double)sumaMayores / mayores:F2}");

        Console.WriteLine("\n✅ Análisis completado.");
    }

    // Función auxiliar para leer enteros con validación y rango.
    static int LeerEntero(string mensaje, int minimo, int maximo)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                if (valor >= minimo && valor <= maximo)
                    return valor;

                Console.WriteLine($"  Ingresa un valor entre {minimo} y {maximo}.\n");
            }
            else
            {
                Console.WriteLine(" Entrada inválida. Ingresa un número entero.\n");
            }
        }
    }
}
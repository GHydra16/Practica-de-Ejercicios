// Descripcion: reto de registrar las edades de 20 pacientes.
// Después, los clasificamos por grupo de edad y analizamos la distribución.

// se usaron arreglos: uno para guardar las edades y otro para contar cuántos hay en cada grupo. 
//la cantidad de arreglos usados fueron 1, el cual fue un arreglo para guardar las edades de los pacientes.


using System; // Asegúrate de que el espacio de nombres sea correcto según tu estructura de carpetas.

public class GestionTurnosClinica // Clase principal del programa
{
    public static void Main(string[] args) // Método principal, punto de entrada del programa
    {
Console.WriteLine("//// Gestión de turnos en una clínica /////\n");

const int totalPacientes = 20; // Número total de pacientes a registrar

        // Acá creamos el arreglo para guardar las edades.
        int[] edades = new int[totalPacientes]; // arreglo para las edades, tamaño fijo de 20

        // Estas variables contarán cuántos pacientes hay en cada grupo.
        int ninos = 0, jovenes = 0, adultos = 0, mayores = 0; // contadores por grupo

        // También vamos a guardar las sumas para calcular los promedios.
        int sumaGeneral = 0, sumaNinos = 0, sumaJovenes = 0, sumaAdultos = 0, sumaMayores = 0; // sumas por grupo

        Console.WriteLine("Ingrese la edad de los 20 pacientes:");
        for (int i = 0; i < totalPacientes; i++)
        // i va de 0 a 19, i<totalPacientes e i++ es lo mismo que i=i+1, y es para incrementar i en 1 cada vez
        // quiere decir que se repite 20 veces (0, 1, 2, ..., 19)
        {
            
            edades[i] = LeerEntero($"  Edad del paciente #{i + 1}: ", 0, 120);
            // se usa i+1 para mostrar al usuario índices desde 1, o sea que el primer paciente es #1
            //EL 0 y 120 son los valores mínimo y máximo permitidos para la edad.

            // Clasificamos según la edad.
            int edad = edades[i];
            sumaGeneral += edad;
            // acumulamos para el promedio total, EL += es lo mismo que sumaGeneral = sumaGeneral + edad
            // se interpreta como "sumaGeneral más igual edad" Lo que sig que se acumula la edad en sumaGeneral
            // cada vez que se ingresa una edad, se suma a la variable sumaGeneral

            // Acá vamos agrupando cada edad en su categoría.
            if (edad <= 12)
            {
                ninos++; // incrementa el contador de niños en 1
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
            Console.WriteLine("\nAlerta: hay más de 5 personas mayores (alto riesgo).");
        }

        // Calculamos el promedio general y por grupo (solo si el grupo tiene personas).
        double promedioGeneral = (double)sumaGeneral / totalPacientes;
        Console.WriteLine("\n//// Promedios de edad ////");
        Console.WriteLine($"Promedio general: {promedioGeneral:F2}");

        if (ninos > 0)
            Console.WriteLine($"Promedio de niños: {(double)sumaNinos / ninos:F2}");
        if (jovenes > 0)
            Console.WriteLine($"Promedio de jóvenes: {(double)sumaJovenes / jovenes:F2}");
        if (adultos > 0)
            Console.WriteLine($"Promedio de adultos: {(double)sumaAdultos / adultos:F2}");
        if (mayores > 0)
            Console.WriteLine($"Promedio de mayores: {(double)sumaMayores / mayores:F2}");

        Console.WriteLine("\n Análisis completado.");
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
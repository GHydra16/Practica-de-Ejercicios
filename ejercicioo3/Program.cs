// Programa: IntercalarArreglos
// Combina dos arreglos intercalando sus valores.
// Muestra el resultado y el origen de cada dato.
// Incluye validación básica de entradas.

// los arreglos utilizados fueron 3, dos para guardar los valores ingresados por 
//el usuario y uno para guardar el resultado de la mezcla de ambos arreglos.


using System; // Necesario para usar Console y otras funcionalidades básicas de el sistema
public class IntercalarArreglos // Clase principal del programa 
{
    public static void Main(string[] args) // Método principal, punto de entrada del programa
    {
        Console.WriteLine("=== Programa para intercalar dos arreglos ===\n");

        int n; // número de elementos en cada arreglo

        // Acá pedimos el tamaño de los arreglos. Ambos tendrán el mismo número de elementos.
        // Uso TryParse para que no se caiga si alguien escribe una letra.

        // Para pedir tamaño de los arreglos con validación de entrada
        while (true)
        {
            Console.Write("¿Cuántos elementos tendrá cada arreglo? ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                // si se pudo convertir y es positivo
                // out n asigna el valor convertido a n
                // el operador && es "y lógico", ambas condiciones deben ser verdaderas
                // el operador > compara si n es mayor que 0
                break;

            Console.WriteLine(" Por favor, ingresa un número entero positivo!.\n");
        }

        // los arreglos con el tamaño solicitado
        int[] arr1 = new int[n]; // primer arreglo
        int[] arr2 = new int[n]; // segundo arreglo

        // Capturar los valores del primer arreglo
        Console.WriteLine("\nIntroduce los valores del primer arreglo:(enter para el siguiente valor)");
        for (int i = 0; i < n; i++)
        {
            arr1[i] = LeerEntero($"  arr1[{i + 1}]: "); // se usa i+1 para mostrar al usuario índices desde 1
        }

        // Capturar los valores del segundo arreglo
        Console.WriteLine("\nIntroduce los valores del segundo arreglo:(enter para el siguiente valor)");
        for (int i = 0; i < n; i++)
        // i va de 0 a n-1
        // quiere decir que se repite n veces (0, 1, 2, ..., n-1)
        {
            arr2[i] = LeerEntero($"  arr2[{i + 1}]: ");
            // se usa i+1 para mostrar al usuario índices desde 1
        }

        // Acá creamos el tercer arreglo que guardará la mezcla de ambos.
        // Es del doble de tamaño porque contiene todos los valores de arr1 y arr2.
        int[] resultado = new int[n * 2];
        int indiceResultado = 0; // Este índice lo usamos para movernos dentro del arreglo nuevo.


        // Este for intercalará los valores.
        // Básicamente: un valor de arr1, luego uno de arr2, y así sucesivamente.
        for (int i = 0; i < n; i++)
        {
            // Intercalamos un elemento de arr1 y luego uno de arr2
            resultado[indiceResultado++] = arr1[i]; // ahi se mete uno de arr1
            resultado[indiceResultado++] = arr2[i]; // y acá uno de arr2
        }

        // Mostrar el arreglo intercalado
        Console.WriteLine("\n//// Arreglo intercalado ////");
        Console.WriteLine("[{0}]", string.Join(", ", resultado));

        // Mostrar el origen de cada valor
        Console.WriteLine("\n=== Origen de cada valor ===");
        for (int i = 0; i < resultado.Length; i++)
        {
            string origen = (i % 2 == 0) ? "arr1" : "arr2";
            Console.WriteLine($"{resultado[i]} → {origen}");
        }

        Console.WriteLine("\n :) Programa finalizado correctamente.");
    }

    // Método auxiliar para leer enteros con manejo de errores
    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine(" Entrada inválida!. Ingrese un número entero.\n");
        }
    }
}
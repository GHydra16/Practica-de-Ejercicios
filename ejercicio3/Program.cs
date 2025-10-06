using System; // se usa para poder usar la clase Console

public class IntercalarArreglos // nombre de la clase
{
    public static void Main(string[] args) // punto de entrada del programa, método Main
    {
        Console.WriteLine("Programa para intercalar dos arreglos.");

        // Primero, se va a pedir el tamaño de los arreglos.
        // Asumimos que ambos arreglos tendrán el mismo tamaño para que sea más sencillo.
        int n;
        Console.Write("¿De qué tamaño quieres que sean los arreglos? (Introduce un número): ");
        n = Convert.ToInt32(Console.ReadLine());

        // Creamos los dos arreglos, arr1 y arr2, con el tamaño que nos dieron.
        // Usamos 'int' para que sean arreglos de enteros.
        int[] arr1 = new int[n];
        int[] arr2 = new int[n];

        // Ahora, vamos a pedir los valores para el primer arreglo.
        Console.WriteLine("\nIntroduce los " + n + " valores para el PRIMER arreglo:");
        for (int i = 0; i < n; i++) // i++ para avanzar en el ciclo
        // usamos un ciclo for para recorrer cada posición del arreglo
        {
            Console.Write("Valor para arr1 en la posición " + i + ": ");
            arr1[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Y ahora, los valores para el segundo arreglo.
        Console.WriteLine("\nIntroduce los " + n + " valores para el SEGUNDO arreglo:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Valor para arr2 en la posición " + i + ": ");
            arr2[i] = Convert.ToInt32(Console.ReadLine());
            //array2[i] accede a la posición i del arreglo arr2 la cual se llena con el valor leído
        }

        // El tercer arreglo, 'resultado', tendrá el doble de tamaño
        // porque vamos a meter todos los elementos de arr1 y arr2.
        // n * 2 es para duplicar el tamaño.
        int[] resultado = new int[n * 2];

        // Esta variable ayudará a saber en qué posición del arreglo 'resultado' vamos.
        int indiceResultado = 0;

        // Aquí es donde hacemos la "intercalación".
        // Vamos a recorrer los arreglos originales.
        for (int i = 0; i < n; i++)
        {
            // Primero, ponemos un elemento de arr1 en 'resultado'.
            resultado[indiceResultado] = arr1[i];
            indiceResultado++; // Avanzamos a la siguiente posición.

            // Luego, ponemos un elemento de arr2 en 'resultado'.
            resultado[indiceResultado] = arr2[i];
            indiceResultado++; // Avanzamos de nuevo.
        }

        // ¡Listo! Ya tenemos el arreglo intercalado. Ahora lo mostramos.
        Console.WriteLine("\nEl arreglo intercalado es:");
        Console.Write("[");
        for (int i = 0; i < resultado.Length; i++)
        {
            Console.Write(resultado[i]);
            if (i < resultado.Length - 1) // Para no poner la coma al final.
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        // Ahora viene la segunda parte: identificar el origen de cada valor.
        Console.WriteLine("\nOrigen de cada valor en el arreglo intercalado:");
        for (int i = 0; i < resultado.Length; i++)
        {
            // Para saber si viene de arr1 o arr2, podemos ver la posición original.
            // Si la posición en el arreglo 'resultado' es par (0, 2, 4...),
            // significa que ese valor vino de arr1.
            // Si es impar (1, 3, 5...), vino de arr2.
            if (i % 2 == 0) // El operador '%' nos da el "resto" de una división. Si el resto es 0, es par.
            {
                Console.WriteLine(resultado[i] + " (arr1)");
            }
            else
            {
                Console.WriteLine(resultado[i] + " (arr2)");
            }
        }

        Console.WriteLine("\nFin del programa!!");
    }
}

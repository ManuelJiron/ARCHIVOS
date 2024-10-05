using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_1_archivos_binarios
{
    internal class Program
    {
        static void Main(string[] args)
        /*Desarrolla un programa que permita al usuario ingresar varias cadenas (nombres,
por ejemplo) y las guarde en un archivo binario. Luego, lee las cadenas del archivo
y muéstralas en la consola*/
        {
            string rutaArchivo = "nombres.dat"; // Ruta del archivo binario

            // Escritura de los nombres en el archivo binario
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Create))
            {
                using (BinaryWriter Escritor = new BinaryWriter(mArchivo, Encoding.UTF8))
                {
                    Console.WriteLine("Ingrese el número de nombres a registrar:");
                    int cantidad = int.Parse(Console.ReadLine());

                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine("Ingrese un nombre:");
                        string nombre = Console.ReadLine();
                        Escritor.Write(nombre); // Guardar cada nombre en el archivo
                    }
                }
            }

            // Lectura de los nombres desde el archivo binario
            Console.WriteLine("\nNombres almacenados:");
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Open))
            {
                using (BinaryReader Lector = new BinaryReader(mArchivo, Encoding.UTF8))
                {
                    while (mArchivo.Position < mArchivo.Length)
                    {
                        string nombre = Lector.ReadString(); // Leer cada nombre del archivo
                        Console.WriteLine(nombre); // Mostrar el nombre en la consola
                    }
                }
            }
            Console.ReadKey();
        }
    } 
}

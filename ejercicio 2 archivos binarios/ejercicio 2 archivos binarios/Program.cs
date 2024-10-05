using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ejercicio_2_archivos_binarios
{
    internal class Program
    {
        static void Main(string[] args)
        /*Crea un programa que escriba una serie de números pares (por ejemplo, del 2 al
20) en un archivo binario. Luego, lee esos enteros y muéstralos en la consola.*/
        {
            string rutaArchivo = "numeros_pares.dat"; // Ruta del archivo binario

            // Escritura de los números pares en el archivo binario
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Create))
            {
                using (BinaryWriter Escritor = new BinaryWriter(mArchivo, Encoding.UTF8))
                {
                    Console.WriteLine("Escribiendo números pares del 2 al 20 en el archivo...");

                    for (int i = 2; i <= 20; i += 2) // Genera números pares del 2 al 20
                    {
                        Escritor.Write(i); // Guardar cada número par en el archivo
                    }
                }
            }

            // Lectura de los números pares desde el archivo binario
            Console.WriteLine("\nNúmeros pares almacenados:");
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Open))
            {
                using (BinaryReader Lector = new BinaryReader(mArchivo, Encoding.UTF8))
                {
                    while (mArchivo.Position < mArchivo.Length)
                    {
                        int numero = Lector.ReadInt32(); // Leer cada número par del archivo
                        Console.WriteLine(numero); // Mostrar el número en la consola
                    }
                }
            }
            Console.ReadKey();
        }



    }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static EJERCICIO3PRACTICAARCHIVOS.Program;

namespace EJERCICIO3PRACTICAARCHIVOS
{
    internal class Program
    {

        // Definimos una estructura para representar un producto
        public struct Producto
        {
            // Campos de la estructura
            public string Idprod;
            public string Nombre;
            public float Precio;

            // Constructor de la estructura
            public Producto(string idprod, string nombre, float precio)
            {

                Idprod = idprod;
                Nombre = nombre;
                Precio = precio;
            }
        }

        static void Main(string[] args)
        {
            // Ruta del archivo donde se almacenarán los productos
            string rutaArchivo = "Productos.dat";

            // Creamos un archivo binario para almacenar los productos
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Create))
            using (BinaryWriter Escritor = new BinaryWriter(mArchivo, Encoding.UTF8))
            {
                // Pedimos al usuario que ingrese la cantidad de productos que desea agregar
                Console.WriteLine("Dime cuantos productos deseas agregar");
                int cantidad = int.Parse(Console.ReadLine());

                // Creamos un arreglo para almacenar los productos
                Producto[] productos = new Producto[cantidad];

                // Recorremos el arreglo para agregar los productos
                for (int i = 0; i < cantidad; i++)
                {

                    Console.WriteLine("Ingresa el id del producto: ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Ingresa el nombre del producto");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa el precio del producto");
                    float precio = float.Parse(Console.ReadLine());

                    // Creamos un nuevo producto con los datos ingresados
                    productos[i] = new Producto(id, nombre, precio);

                    // Escribimos los datos del producto en el archivo
                    Escritor.Write(productos[i].Idprod);
                    Escritor.Write(productos[i].Nombre);
                    Escritor.Write(productos[i].Precio);

                    Console.Clear();
                }
            }

            // Limpiamos la pantalla
            Console.Clear();

            //Mostrar productos
            Console.WriteLine("Mostrar Productos");

            // Abrimos el archivo para leer los productos
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Open))
            using (BinaryReader Lector = new BinaryReader(mArchivo, Encoding.UTF8))
            {
                // Leemos los productos del archivo hasta que lleguemos al final
                while (mArchivo.Position < mArchivo.Length)
                {

                    string id = Lector.ReadString();
                    string nombre = Lector.ReadString();
                    float precio = Lector.ReadSingle();

                    // Mostramos los datos del producto
                    Console.WriteLine($"ID: {id}, Nombre: {nombre}, Precio: {precio}");
                }
            }


            Console.ReadKey();
        }
    }
}


using Lector.Directorio.Archivos;
using System.IO;
using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        string elPath = "";

        do
        {
            Console.WriteLine("Ingrese el path:");
            elPath = Console.ReadLine(); //Ejemplo : C:\Users\

            if (Directory.Exists(elPath))
            {
                System.Console.WriteLine("----Subcarpetas");
                manejoDirectorios.MostrarDirectorio(elPath);

                System.Console.WriteLine("\n----Archivos");
                manejoDirectorios.MostrarArchivos(elPath);

                break;
            }
            else
                Console.WriteLine("La carpeta no existe, Ingrese una valida:");
        } while (true);

        manejoDirectorios.EscribirArchivos(elPath);
    }
}

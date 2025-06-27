
using Lector.Direcorio.Archivos;

internal class Program
{
    private static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Ingrese el path:");
            string elPath = Console.ReadLine(); //C:\Users\

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
    }
}

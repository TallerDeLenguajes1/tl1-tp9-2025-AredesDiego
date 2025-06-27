using System;
using System.IO;
using System.Text;

namespace Lector.Directorio.Archivos
{
    public class manejoDirectorios
    {
        public static void MostrarDirectorio(string elPath)
        {
            string[] carpetas = Directory.GetDirectories(elPath);
            foreach (string carpeta in carpetas)
            {
                Console.WriteLine("      " + Path.GetFileName(carpeta));
            }
        }
        public static void MostrarArchivos(string elPath)
        {
            string[] archivos = Directory.GetFiles(elPath);

            foreach (var archivo in archivos)
            {
                FileInfo fileInfo = new FileInfo(archivo);

                Console.WriteLine("      " + Path.GetFileName(archivo) + $" -----------------------------SIZE: {fileInfo.Length}KB");
            }
        }  
        public static void EscribirArchivos(string elPath)
        {
            string relativePath = @"FolderData\reporte_archivos.csv";
            string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));

            string[] archivos = Directory.GetFiles(elPath);

            using (StreamWriter writer = new StreamWriter(absolutePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Nombre;Tamanio (bytes);Ultima modificacion");

                foreach (var archivo in archivos)
                {
                    FileInfo infoArchivo = new FileInfo(archivo);
                    writer.WriteLine($"{infoArchivo.Name};{infoArchivo.Length};{infoArchivo.LastWriteTime}");
                }
            }
            Console.WriteLine($"Reporte generado en: {absolutePath}");
        }       
    }
}

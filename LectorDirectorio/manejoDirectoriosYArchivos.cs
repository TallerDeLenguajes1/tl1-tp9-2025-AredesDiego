using System;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Lector.Direcorio.Archivos
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
                long fileSizeBytes = fileInfo.Length;

                Console.WriteLine("      " + Path.GetFileName(archivo) + $" -----------------------------SIZE: {fileSizeBytes}");
            }
        }     
    }
}

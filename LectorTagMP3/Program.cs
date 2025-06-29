using System;
using System.IO;
using System.Text;

namespace LectorTagMP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la ruta completa del archivo MP3:");
            string rutaArchivo = Console.ReadLine();

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo no existe.");
                return;
            }

            Id3v1Tag tag = LeerTagID3v1(rutaArchivo);

            if (tag != null)
            {
                Console.WriteLine("\nInformación del MP3:");
                Console.WriteLine("Título: " + tag.Titulo);
                Console.WriteLine("Artista: " + tag.Artista);
                Console.WriteLine("Álbum: " + tag.Album);
                Console.WriteLine("Año: " + tag.Anio);
            }
            else
            {
                Console.WriteLine("El archivo no contiene un tag ID3v1 válido.");
            }
        }

        static Id3v1Tag LeerTagID3v1(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length < 128)
                    return null;

                fs.Seek(-128, SeekOrigin.End);
                byte[] tagBytes = new byte[128];
                fs.Read(tagBytes, 0, 128);

                string header = Encoding.ASCII.GetString(tagBytes, 0, 3);
                if (header != "TAG")
                    return null;

                Encoding encoding = Encoding.GetEncoding("latin1");

                string titulo = encoding.GetString(tagBytes, 3, 30).TrimEnd('\0', ' ');
                string artista = encoding.GetString(tagBytes, 33, 30).TrimEnd('\0', ' ');
                string album = encoding.GetString(tagBytes, 63, 30).TrimEnd('\0', ' ');
                string anio = encoding.GetString(tagBytes, 93, 4).TrimEnd('\0', ' ');

                return new Id3v1Tag
                {
                    Titulo = titulo,
                    Artista = artista,
                    Album = album,
                    Anio = anio
                };
            }
        }
    }
}


do
{
    Console.WriteLine("Ingrese el path:");
    string elPath = @"C:\Users\" + Console.ReadLine();

    if (Directory.Exists(elPath))
    {
        Console.WriteLine("La carpeta existe."); 

        string[] carpetas = Directory.GetDirectories(elPath);

        foreach (string carpeta in carpetas)
        {
            Console.WriteLine(Path.GetFileName(carpeta));
            var nombreDelArchivo = Directory.GetDirectories(elPath);
        }
        break;
    }
    else
        Console.WriteLine("La carpeta no existe, Ingrese una valida:");
    

} while (true); 





//      ..//casita/




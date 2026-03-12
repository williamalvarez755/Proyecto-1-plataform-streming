int contadorpublicados = 0;
int contadorrechazados = 0;
int contadorenrevision = 0;
int contadorimpactoalto = 0;
int contadorimpactomedio = 0;
int contadorimpactobajo = 0;

void funcion_principal()
{
    int contadordeevaluaciones = 0;
    int opcion = 0;
    do
    {
        Console.WriteLine("\nBienvenido al sistema de clasificacion de contenido");
        Console.WriteLine("1. Evaluar contenido");
        Console.WriteLine("2. Mostrar reglas");
        Console.WriteLine("3. Mostrar estadisticas de la seccion");
        Console.WriteLine("4. Reiniciar estadisticas");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opcion: ");
        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Entrada invalida. Debe ingresar un numero.");
            opcion = 0;
        }
        switch (opcion)
        {
            case 1:
                pantalladecarga();
                pedirdatos();
                contadordeevaluaciones++;
                break;
            case 2:
                mostrarreglas();
                break;
            case 3:
                mostrarestadisticas(contadordeevaluaciones, contadorpublicados, contadorrechazados, contadorenrevision);
                break;
            case 4:
                contadorpublicados = 0;
                contadorrechazados = 0;
                contadorenrevision = 0;
                contadorimpactoalto = 0;
                contadorimpactomedio = 0;
                contadorimpactobajo = 0;
                contadordeevaluaciones = 0;
                Console.WriteLine("Estadisticas reiniciadas correctamente.");
                break;
            case 5:
                Console.WriteLine("Saliendo del sistema...");
                Console.WriteLine("Resumen final de la sesion:");
                mostrarestadisticas(contadordeevaluaciones, contadorpublicados, contadorrechazados, contadorenrevision);
                break;
            default:
                Console.WriteLine("Opcion no valida. Por favor, seleccione una opcion del 1 al 5.");
                break;
        }
    } while (opcion != 5);
}
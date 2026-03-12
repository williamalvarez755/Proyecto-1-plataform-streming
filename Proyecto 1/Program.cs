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

void pedirdatos()
{
    int edadrecomendada = 0;
    int horaprogramada = -1;
    int tipo = 0;
    int duracion = 0;
    int nivelproduccion = 0;
    Console.WriteLine("Evaluando datos....");
    Console.Write("Ingrese el nombre del contenido: ");
    string titulo = Console.ReadLine();
    Console.WriteLine("Ingrese tipo de contenido");
    Console.WriteLine("1. Pelicula\n2. Serie\n3. Documental\n4. Transmision en vivo");
    Console.Write("Opcion: ");
    string entradaTipo = Console.ReadLine();
    while (!int.TryParse(entradaTipo, out tipo) || tipo < 1 || tipo > 4)
    {
        Console.WriteLine("Tipo invalido. Ingrese un numero entre 1 y 4.");
        Console.Write("Opcion: ");
        entradaTipo = Console.ReadLine();
    }
    Console.Write("Ingrese la duracion en minutos: ");
    string entradaDuracion = Console.ReadLine();
    while (!int.TryParse(entradaDuracion, out duracion) || duracion <= 0)
    {
        Console.WriteLine("Duracion invalida. Debe ser un numero mayor a 0.");
        Console.Write("Ingrese la duracion en minutos: ");
        entradaDuracion = Console.ReadLine();
    }
    Console.WriteLine("Ingrese la edad recomendada");
    Console.WriteLine("1. Todo publico\n2. +13\n3. +18");
    Console.Write("Opcion: ");
    string entradaEdad = Console.ReadLine();
    while (!int.TryParse(entradaEdad, out edadrecomendada) || edadrecomendada < 1 || edadrecomendada > 3)
    {
        Console.WriteLine("Opcion invalida. Ingrese un numero entre 1 y 3.");
        Console.Write("Opcion: ");
        entradaEdad = Console.ReadLine();
    }
    Console.Write("Ingrese hora programada (0-23): ");
    string entradaHora = Console.ReadLine();
    while (!int.TryParse(entradaHora, out horaprogramada) || horaprogramada < 0 || horaprogramada > 23)
    {
        Console.WriteLine("Hora invalida. Ingrese un numero entre 0 y 23.");
        Console.Write("Ingrese hora programada (0-23): ");
        entradaHora = Console.ReadLine();
    }
    Console.WriteLine("Ingrese nivel de produccion");
    Console.WriteLine("1. Alto\n2. Medio\n3. Bajo");
    Console.Write("Opcion: ");
    string entradaProduccion = Console.ReadLine();
    while (!int.TryParse(entradaProduccion, out nivelproduccion) || nivelproduccion < 1 || nivelproduccion > 3)
    {
        Console.WriteLine("Opcion invalida. Ingrese un numero entre 1 y 3.");
        Console.Write("Opcion: ");
        entradaProduccion = Console.ReadLine();
    }
    Console.WriteLine("Contenido recibido. Iniciando evaluacion....");




    bool apruebahorario = reglasclasificacionHorario(edadrecomendada, horaprogramada);
    bool apruebaduracion = reglasduracionportipo(tipo, duracion);
    bool apruebaproduccion = reglasproduccion(nivelproduccion, edadrecomendada);
    decisionfinal(titulo, apruebahorario, apruebaduracion, apruebaproduccion, nivelproduccion, duracion, horaprogramada);
}

bool reglasclasificacionHorario(int edadRecomendada, int horaProgramada)
{
    bool apruebahorario = false;
    if (edadRecomendada == 1 && horaProgramada >= 0 && horaProgramada <= 23)
    {
        apruebahorario = true;
    }
    else if (edadRecomendada == 2 && horaProgramada >= 6 && horaProgramada <= 22)
    {
        apruebahorario = true;
    }
    else if (edadRecomendada == 3 && (horaProgramada >= 22 || horaProgramada <= 5))
    {
        apruebahorario = true;
    }
    else
    {
        Console.WriteLine("OJO: El contenido no cumple las normas de clasificacion de horario.");
        apruebahorario = false;
    }

    return apruebahorario;
}

bool reglasduracionportipo(int tipoContenido, int duracion)
{
    bool apruebaduracion = false;

    if (tipoContenido == 1 && duracion >= 60 && duracion <= 180)
    {
        apruebaduracion = true;
    }
    else if (tipoContenido == 2 && duracion >= 20 && duracion <= 90)
    {
        apruebaduracion = true;
    }
    else if (tipoContenido == 3 && duracion >= 30 && duracion <= 120)
    {
        apruebaduracion = true;
    }
    else if (tipoContenido == 4 && duracion >= 30 && duracion <= 240)
    {
        apruebaduracion = true;
    }
    else
    {
        Console.WriteLine("OJO: La duracion no esta dentro del rango permitido para su tipo.");
        apruebaduracion = false;
    }
    return apruebaduracion;
}

bool reglasproduccion(int nivelProduccion, int edadRecomendada)
{
    bool apruebaproduccion = false;

    if (nivelProduccion == 3 && edadRecomendada == 3)
    {
        Console.WriteLine("Produccion baja no es valida para contenido +18.");
        apruebaproduccion = false;
    }
    else
    {
        apruebaproduccion = true;
    }

    return apruebaproduccion;
}

int clasificacionimpacto(int nivelProduccion, int duracion, int horaProgramada)
{
    int impacto = 3;

    if (nivelProduccion == 3 && duracion < 60)
    {
        impacto = 3;
    }

    if (nivelProduccion == 2 || (duracion >= 60 && duracion <= 120))
    {
        if (impacto > 2)
            impacto = 2;
    }

    if (nivelProduccion == 1 || duracion > 120 || (horaProgramada >= 20 && horaProgramada <= 23))
    {
        impacto = 1;
    }

    return impacto;
}
void pantalladecarga()
{
    Console.WriteLine();
    for (int i = 3; i >= 1; i--)
    {
        Console.WriteLine("CARGANDO EN ...." + i);

        if (i == 1)
        {
            Console.WriteLine("CARGA COMPLETA.....");
        }
    }
}
void decisionfinal(string titulo, bool apruebahorario, bool apruebaduracion, bool apruebaproduccion, int nivelproduccion, int duracion, int horaprogramada)
{
    Console.WriteLine("Resultados de evaluacion:");

    if (!apruebahorario || !apruebaduracion || !apruebaproduccion)
    {
            pantalladecarga();
        Console.WriteLine("El titulo '" + titulo + "' fue RECHAZADO.");
        if (!apruebahorario)
            Console.WriteLine("No cumple la clasificacion de horario.");
        if (!apruebaduracion)
            Console.WriteLine(" La duracion no corresponde al rango permitido para su tipo.");
        if (!apruebaproduccion)
            Console.WriteLine("El nivel de produccion no es valido para su clasificacion de edad.");
        contadorrechazados++;
    }
    else
    {
        int impacto = clasificacionimpacto(nivelproduccion, duracion, horaprogramada);

        if (impacto == 1)
        {
            pantalladecarga();
            Console.WriteLine("El titulo '" + titulo + "' fue ENVIADO A REVISION.");
            Console.WriteLine("Cumple las reglas tecnicas pero tiene impacto ALTO.");
            contadorenrevision++;
            contadorimpactoalto++;
        }
        else if (impacto == 2)
        {
            pantalladecarga();
                Console.WriteLine("El titulo '" + titulo + "' fue PUBLICADO CON AJUSTES.");
            Console.WriteLine("Cumple las reglas tecnicas con impacto MEDIO. Requiere ajustes menores.");
            contadorpublicados++;
            contadorimpactomedio++;
        }
        else
        {
            pantalladecarga();
            Console.WriteLine("El titulo '" + titulo + "' fue PUBLICADO exitosamente.");
            Console.WriteLine("Cumple todas las reglas tecnicas con impacto BAJO.");
            contadorpublicados++;
            contadorimpactobajo++;
        }
    }
}


funcion_principal();
// See https://aka.ms/new-console-template for more information
using AgenciaViajes;
while (true)
{
Console.WriteLine(@"Bienvenido a la plataforma de Project 2R
Escriba la opcion de lo que desea hacer:
1. Registrar un nuevo viaje
2. Actualizar un viaje
3. Ver lista de viajes
4. Ver informacion de un viaje en especifico
5. Guardar viajes en CSV
6. Cargar viajes desde CSV
7. Generar informacion de finanzas
8. Salir");
switch (Console.ReadLine())
{
    case "1":
        //string destination, string duration, int capacity, string month, string day, string year, int reservedSeats)
        List<String> values = new();
        Console.WriteLine(@"Vamos a crear un nuevo viaje. Introduzca el destino de su viaje:");
        values.Add(Console.ReadLine()!);
        Console.WriteLine(@"Introduzca la duracion de su viaje:");
        values.Add(Console.ReadLine()!);
        Console.WriteLine(@"Introduzca la capacidad de su viaje:");
        values.Add(Console.ReadLine()!);
        while (true)
        {
            Console.WriteLine(@"Conoce en que fecha se efectuara el viaje?[Si/No]");
            switch (Console.ReadLine().ToLower())
            {
                case "si":
                    Console.WriteLine(@"Introduzca el mes de su viaje:");
                    values.Add(Console.ReadLine()!);
                    Console.WriteLine(@"Introduzca el dia de su viaje:");
                    values.Add(Console.ReadLine()!);
                    Console.WriteLine(@"Introduzca el año de su viaje:");
                    values.Add(Console.ReadLine()!);
                break;
                case "no":
                    values.Add("0");
                    values.Add("0");
                    values.Add("0");
                break;
                default:
                Console.WriteLine(@"Esta no es una de las opciones");
                continue;
            }
            break;
            // if (Console.ReadLine().ToLower() == "si")
            // {
            //     Console.WriteLine(@"Introduzca el mes de su viaje:");
            //     values.Add(Console.ReadLine()!);
            //     Console.WriteLine(@"Introduzca el dia de su viaje:");
            //     values.Add(Console.ReadLine()!);
            //     Console.WriteLine(@"Introduzca el año de su viaje:");
            //     values.Add(Console.ReadLine()!);
            //     break;
            // } else if (Console.ReadLine().ToLower() == "no")
            // {
            //     values.Add("0");
            //     values.Add("0");
            //     values.Add("0");
            //     break;
            // } else
            // {
            //     Console.WriteLine(@"Esta no es una de las opciones");
            // }
        }
        
        Console.WriteLine(@"Introduzca el la cantidad de asientos reservados hasta la fecha:");
        values.Add(Console.ReadLine()!);

      while (true)
        {
            Console.WriteLine(@"Conoce los costos del viaje?[Si/No]");
            switch (Console.ReadLine().ToLower())
            {
                case "si":
                    Console.WriteLine(@"Introduzca el precio por persona. Ponga 0 si no sabe aun.");
                    values.Add(Console.ReadLine()!);
                    Console.WriteLine(@"Introduzca el costo de la actividad. Ponga 0 si no lo sabe aun.");
                    values.Add(Console.ReadLine()!);
                    Console.WriteLine(@"Introduzca el costo de transporte. Ponga 0 si no lo sabe aun.");
                    values.Add(Console.ReadLine()!);
                break;
                case "no":
                    values.Add("0");
                    values.Add("0");
                    values.Add("0");
                break;
                default:
                Console.WriteLine(@"Esta no es una de las opciones");
                continue;
            }
            break;
            // if (Console.ReadLine().ToLower() == "si")
            // {
            //     Console.WriteLine(@"Introduzca el precio por persona. Ponga 0 si no sabe aun.");
            //     values.Add(Console.ReadLine()!);
            //     Console.WriteLine(@"Introduzca el costo de la actividad. Ponga 0 si no lo sabe aun.");
            //     values.Add(Console.ReadLine()!);
            //     Console.WriteLine(@"Introduzca el costo de transporte. Ponga 0 si no lo sabe aun.");
            //     values.Add(Console.ReadLine()!);
            //     break;
            // } else if (Console.ReadLine().ToLower() == "no")
            // {
            //     values.Add("0");
            //     values.Add("0");
            //     values.Add("0");
            //     break;
            // } else
            // {
            //     Console.WriteLine(@"Esta no es una de las opciones");
            // }
            }

            new Trip(values[0], values[1], int.Parse(values[2]), values[3], values[4], values[5], int.Parse(values[6]), double.Parse(values[7]), double.Parse(values[8]), double.Parse(values[9]));
            Console.WriteLine(@"Se registro el viaje exitosamente
            
            ");
    break;

    case "2":
        Console.WriteLine(@$"Que viaje desea actualizar?
        {Trip.GenerateList()}");
        Trip.ExportList(out List<Trip> tripList);
        Trip tripToUpdate = tripList[int.Parse(Console.ReadLine()!)-1];

         Console.WriteLine(@$"Usted selecciono {tripToUpdate.Destination}
         Que va a actualizar?
         1. Fecha
         2. Asientos reservados
         3. Precio por persona
         4. Costo de la actividad
         5. Costo de transporte");

         switch (Console.ReadLine())
         {
            case "1":

                Console.WriteLine(@"Introduzca el mes de su viaje:");
                tripToUpdate.Month = Console.ReadLine()!;
                Console.WriteLine(@"Introduzca el dia de su viaje:");
                tripToUpdate.Day = Console.ReadLine()!;
                Console.WriteLine(@"Introduzca el año de su viaje:");
                tripToUpdate.Year = Console.ReadLine()!;
            break;
            case "2":
                Console.WriteLine(@"Introduzca el la cantidad de asientos reservados hasta la fecha:");
                tripToUpdate.ReservedSeats = int.Parse(Console.ReadLine()!);
            break;
            case "3":
                Console.WriteLine(@"Introduzca el precio por persona.");
                tripToUpdate.PricePerPerson = double.Parse(Console.ReadLine()!);
            break;
            case "4":
                Console.WriteLine(@"Introduzca el costo de la actividad.");
                tripToUpdate.ActivityCost = double.Parse(Console.ReadLine()!);
            break;
            case "5":
                Console.WriteLine(@"Introduzca el costo de transporte.");
                tripToUpdate.TransportCost = double.Parse(Console.ReadLine()!);
            break;
            default:
                Console.WriteLine(@"Esta no es una de las opciones");
                break;

         }
    break;
    case "3":
        Console.WriteLine(Trip.GenerateList());
    break;
    case "4":
        Console.WriteLine(@$"Que viaje desea actualizar?
        {Trip.GenerateList()}");
        Trip.ExportList(out List<Trip> tripListView);
        Trip tripToView = tripListView[int.Parse(Console.ReadLine()!)-1];

        Console.WriteLine(@$"Destino: {tripToView.Destination}
        Duracion: {tripToView.Duration}
        Fecha [MM/DD/YY]: {tripToView.Date}
        Cupo: {tripToView.Capacity}
        Asientos Reservados: {tripToView.ReservedSeats}
        Precio Por Persona: RD${tripToView.PricePerPerson}
        Costo Actividad: RD${tripToView.ActivityCost}
        Costo Transporte: RD${tripToView.TransportCost}
        Dinero Viaje: RD${tripToView.TripMoney}");
    break;
    case "5":
        Trip.ExportList(out List<Trip> tripListExport);
        CSVHelper.ToCSV(tripListExport, "./CSVFile.csv");
    break;
    case "6":
        CSVHelper.FromCSV("./CSVFile.csv");
    break;
    case "7":
        var earnings = Trip.TotalCreditMoney;
        var cost = Trip.TotalCost;
        Console.WriteLine(@$"Reporte Financiero:
        Credito Total: RD${earnings}
        Costo Total: RD${cost}
        Ganancia: RD${earnings - cost}

        Desglose de gastos------------------------
        Costo Transporte: RD${Trip.TotalTransportCost}
        Costo Actividades: RD${Trip.TotalActivityCost}");
    break;
    case "8":
    return;
    default:
        Console.WriteLine(@"Esta no es una de las opciones");
    break;
}
}


namespace AgenciaViajes;
using System.Text;

public class CSVHelper
{
    public static void ToCSV(List<Trip> trips, string pathToSave){
        var csv = new StringBuilder();
        csv.AppendLine("Destination,Duration,Capacity,Date,Reserved Seats,Price Per Person,Activity Cost,Transport Cost");
        foreach (var trip in trips)
        {
            var newLine = string.Format($"{trip.Destination},{trip.Duration},{trip.Capacity},{trip.Date},{trip.ReservedSeats},{trip.PricePerPerson},{trip.ActivityCost},{trip.TransportCost}");
            csv.AppendLine(newLine);
        }
        File.WriteAllText(pathToSave, csv.ToString());
    }

    public static void FromCSV(string pathToFile){

        using (StreamReader reader = new StreamReader(pathToFile))
        {   
            var info = new FileInfo(pathToFile);
            if ((!info.Exists) || info.Length == 0)
            {
                Console.WriteLine("Primero debe crear un CSV");
                return;  
            }
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(",");

                if (values[0] == "Destination"){
                    continue;
                }


                var date = values[3].Split("/");

                 new Trip(values[0],values[1],int.Parse(values[2]),date[0],date[1],date[2],int.Parse(values[4]),double.Parse(values[5]),double.Parse(values[6]),double.Parse(values[7]));

            }
        }

    }
}

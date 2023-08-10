namespace AgenciaViajes;

public class Trip
{  
    private int _capacity;
    private string _destination;
    private string _duration;
    private string _day;
    private string _month;
    private string _year;
    private int _reservedSeats;
    private double _pricePerPerson;
    private double _tripMoney;
    private double _activityCost;
    private double _transportCost;
    private static List<Trip> _tripList = new();

    public Trip(string destination, string duration, int capacity, string month, string day, string year, int reservedSeats, double pricePerPerson, double activityCost, double transportCost){
        this.Destination = destination;
        this.Duration = duration;
        this.Capacity = capacity;
        this.Day = day;
        this.Month = month;
        this.Year = year;
        this.ReservedSeats = reservedSeats;
        this.PricePerPerson = pricePerPerson;
        this.ActivityCost = activityCost;
        this.TransportCost = transportCost;
        this.Id = Trip.IndexTrip(this);
    }

    public int Id{get; set;}

    public string Destination{
        get{return _destination;}
        set{
            if (string.IsNullOrEmpty(value))
            {
                _destination = "Not set";
            }else{
                _destination = value;
            }
        }
    }

    public int Capacity{
        get{return _capacity;}
        set{
           if (value < 0)
           {
            _capacity = 0;
           } else {_capacity = value;}
        }
    }

    public string Duration{
        get{return _duration;}
        set{
            if (string.IsNullOrEmpty(value))
            {
                _duration = "0 hours";
            }else{
                _duration = value + " hours";
            }
        }
    }

    public string Date{
        get{
            return $"{_month}/{_day}/{_year}";
        }
        }

    public string Day{set{
        if (int.Parse(value) > 31)
        {
            _day = "0";
        }else
        {
            _day = value;
        }
    }}
    public string Month{set{
        if (int.Parse(value)> 12 || int.Parse(value) < 1)
        {
            _month = "1";
        }else
        {
            _month = value;
        }
    }}
    public string Year{set{
        if (int.Parse(value) < 2023)
        {
            _year = "2023";
        }else
        {
            _year = value;
        }
    }}

    public int ReservedSeats{get{return _reservedSeats;}
        set{
            if(value < 0){
                _reservedSeats = 0;
            }else
            {
                _reservedSeats = value;
            }
        }
    }

    public double PricePerPerson{
        get{return _pricePerPerson;}
        set{
            double price = value;
            if (price < 0)
            {
                _pricePerPerson = 0;
            }else
            {
                _pricePerPerson = price;
            }
        }
    }

    public double TripMoney{
        get{
            _tripMoney = _pricePerPerson * _reservedSeats;

            return _tripMoney;}
    }

    public double ActivityCost{
        get{ return _activityCost;}
        set{
            double price = value;
            if (price < 0)
            {
                _activityCost = 0;
            }else
            {
                _activityCost = price;
            }
        }
    }

        public double TransportCost{
        get{ return _transportCost;}
        set{
            double price = value;
            if (price < 0)
            {
                _transportCost = 0;
            }else
            {
                _transportCost = price;
            }
        }
    }
    // This is going to help me calculate total cost and earnings. Also is going to help me keep track of all the trips
    
    public static int IndexTrip(Trip newTrip){
        _tripList.Add(newTrip);
        return _tripList.Count;
    }

    private static void GetPropertyValues(string property, out double doubleResult, string property2="null"){
        doubleResult = 0;
        // int i = 0;
        if (property2 == "null"){
            
            foreach (var trip in _tripList)
            {
                // if (i==0){
                //     continue;
                // }
                doubleResult += (double)trip.GetType().GetProperty(property)!.GetValue(trip, null)!;
                // i++;
            }
        }else{
            foreach (var trip in _tripList)
            {
                //   if (i==0){
                //     continue;
                // }
                doubleResult += (double)trip.GetType().GetProperty(property)!.GetValue(trip, null)! + (double)trip.GetType().GetProperty(property)!.GetValue(trip, null)!;
                // i++;
            }
        }
        // return doubleResult;

    }

    public static double TotalCost{
        get{
            GetPropertyValues("ActivityCost", out double totalCost, "TransportCost");
            return totalCost;
        }
    }

    public static double TotalTransportCost{
        get{
            GetPropertyValues("TransportCost", out double transportCost);
            return transportCost;
        }
    }
    public static double TotalActivityCost{
        get{
            GetPropertyValues("ActivityCost", out double activityCost);
            return activityCost;
        }
    }

    public static double TotalCreditMoney{
        get{
            GetPropertyValues("TripMoney", out double creditMoney);
            return creditMoney;
        }
    }

    public static void ExportList(out List<Trip> tripList){
        tripList = _tripList;
    } 

    public static string GenerateList(){
        string stringList = "";
        foreach (var singleTrip in _tripList)
        {
            stringList += $"{singleTrip.Id}. {singleTrip.Destination} \n";
        }

        return stringList;
    }
}

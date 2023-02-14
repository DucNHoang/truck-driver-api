using MongoDB.Driver;
using truck_driver_api;

// I didn't have time to research and implement a MongoDB mock during runtime. So the production code is unfortunately commented out.
// Instead, I'm implementing a hack that has static data to serve our demo.
// But the production code in the comments would be how I'd approach the problem.
public class TruckDriverService
{
  // private readonly IMongoCollection<TruckDriver> _truckDrivers;
  private readonly List<TruckDriver> _truckDrivers;

  public TruckDriverService()
  {
    // var client = new MongoClient("TruckDriverDbConnectionString");
    // var database = client.GetDatabase("TruckDriverDb");
    // _truckDrivers = database.GetCollection<TruckDriver>("TruckDrivers");
    _truckDrivers = new List<TruckDriver>
    {
      new TruckDriver { FirstName = "John", LastName = "Doe", Location = "Berlin" },
      new TruckDriver { FirstName = "Duc", LastName = "Hoang", Location = "Mannheim" },
      new TruckDriver { FirstName = "Dennis", LastName = "Jantos", Location = "Stuttgart" },
      new TruckDriver { FirstName = "Norah", LastName = "Jones", Location = "Hamburg" }
    };
  }

  public List<TruckDriver> GetTruckDriversByLocation(string? location)
  {
    if (location == null) return _truckDrivers;
    // var driversAtLocation = _truckDrivers.Find(driver => driver.Location == location).ToList();
    var driversAtLocation = _truckDrivers.FindAll(driver => driver.Location == location);
    return driversAtLocation;
  }
}

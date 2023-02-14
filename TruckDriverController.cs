using Microsoft.AspNetCore.Mvc;

namespace truck_driver_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TruckDriverController : ControllerBase
{
  private readonly ILogger _logger;
  private readonly TruckDriverService _truckDriverService;

  public TruckDriverController(ILogger<TruckDriverController> logger, TruckDriverService truckDriverService)
  {
    _logger = logger;
    _truckDriverService = truckDriverService;
  }

  [HttpGet]
  public ActionResult<List<TruckDriver>> GetTruckDriversByLocation([FromQuery] string? location)
  {
    _logger.LogInformation("Getting all truck drivers for location {location}", location);
    var drivers = _truckDriverService.GetTruckDriversByLocation(location);
    if (drivers == null || drivers.Count == 0)
    {
      return NotFound();
    }
    return Ok(drivers);
  }
}

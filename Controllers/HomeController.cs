using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Booking.Models;
using Booking.Services;

namespace Booking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEventService _eventService;

    public HomeController(ILogger<HomeController> logger, IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    public IActionResult Index()
    {
        var events = _eventService.GetAllEventsAsync().Result;
        return View(events);
    }
}

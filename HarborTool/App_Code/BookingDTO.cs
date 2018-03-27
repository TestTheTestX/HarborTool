using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookingDTO
/// </summary>
public class BookingDTO
{
    public int Id { get; set; }
    public int BoatId { get; set; }
    public int DockId { get; set; }
    public String Arrival { get; set; }
    public String Departure { get; set; }
}
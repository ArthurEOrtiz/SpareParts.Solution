using System.Collections.Generic;

namespace SpareParts.Models
{
  public class Vehicle
  {
    public Vehicle()
    {
      this.Parts = new HashSet<Part>();
    }
    public int VehicleId { get; set; }
    public string Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public virtual ICollection<Part> Parts { get; set; }
  }
}

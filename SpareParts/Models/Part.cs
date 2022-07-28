namespace SpareParts.Models
{
  public class Part
  {
    public int PartId { get; set; }
    public int VehicleId { get; set; }
    public string Description { get; set; }
    public string PartNumber { get; set; }
    public string Manufacture { get; set; }
    public virtual Vehicle Vehicle { get; set; }
  }
}
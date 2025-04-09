using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AddressModel {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int NeighborHoodId { get; set; }
    public string StreetId { get; set; }
    public int Number { get; set; }

    public AddressModel() { }

    public AddressModel(int neighborhoodId, string streetId, int number) {
        NeighborHoodId = neighborhoodId;
        StreetId = streetId;
        Number = number;
    }

}
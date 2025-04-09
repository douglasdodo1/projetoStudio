using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NeighborhoodModel {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
    public string Name { get; set; }

    public NeighborhoodModel() { }
    public NeighborhoodModel(string name) {
        Name = name;
    }
}
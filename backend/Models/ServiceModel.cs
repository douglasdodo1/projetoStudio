using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ServiceModel {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public ServiceModel(){}
    public ServiceModel (string name, string value) {
        Name = name;
        Value = value;
    }

}
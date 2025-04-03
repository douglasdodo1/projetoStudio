using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    public static implicit operator ServiceModel(EntityEntry<ServiceModel> v)
    {
        throw new NotImplementedException();
    }
}
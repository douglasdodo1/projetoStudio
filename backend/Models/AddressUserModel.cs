using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class AddressUserModel {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public int AdressId { get; set; }

    public AddressUserModel() { }

    public AddressUserModel(string name, string cpf, int adressId) {
        Name = name;
        Cpf = cpf;
        AdressId = adressId;
    }

    public static implicit operator AddressUserModel(EntityEntry<AddressUserModel> v) {
        throw new NotImplementedException();
    }
}
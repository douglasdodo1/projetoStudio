using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AdressUserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public int AdressId { get; set; }

    public AdressUserModel() { }

    public AdressUserModel(string name, string cpf, int adressId)
    {
        Name = name;
        Cpf = cpf;
        AdressId = adressId;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserModel
{
    [Key]
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public bool Employee { get; set; }
    public string telephone { get; set; }

    public UserModel(){}

    public UserModel(string name, string cpf, string password, bool employee, string telephone)
    {
        Cpf = cpf;
        Name = name;
        Password = password;
        Employee = employee;
        this.telephone = telephone;
    }

}
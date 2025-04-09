using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class SessionModel {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Cpf { get; set; }
    public bool State { get; set; }
    public double Value { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }

    public SessionModel() { }
    public SessionModel(string cpf, bool status, double valor, string tipo, string data, string hora) {
        Cpf = cpf;
        State = status;
        Value = valor;
        Date = data;
        Time = hora;
    }

    public static implicit operator SessionModel(EntityEntry<SessionModel> v) {
        throw new NotImplementedException();
    }
}
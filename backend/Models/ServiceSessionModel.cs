using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class ServiceSessionModel{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdConsulta { get; set; }
    public int IdServico { get; set; }

    public ServiceSessionModel(){}
    public ServiceSessionModel(int idConsulta, int idServico) {
        IdConsulta = idConsulta;
        IdServico = idServico;
    }

    public static implicit operator ServiceSessionModel(EntityEntry<ServiceSessionModel> v)
    {
        throw new NotImplementedException();
    }
}
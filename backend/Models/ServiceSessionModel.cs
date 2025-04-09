using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class ServiceSessionModel {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdSession { get; set; }
    public int IdService { get; set; }

    public ServiceSessionModel() { }
    public ServiceSessionModel(int idConsulta, int idServico) {
        IdSession = idConsulta;
        IdService = idServico;
    }

    public static implicit operator ServiceSessionModel(EntityEntry<ServiceSessionModel> v) {
        throw new NotImplementedException();
    }
}
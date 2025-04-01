using Microsoft.EntityFrameworkCore;

public class Db : DbContext
{
    public DbSet<UserModel> User { get; set; }
    public DbSet<AddressModel> Address { get; set; }
    public DbSet<StreetModel> Street { get; set; }
    public DbSet<AddressUserModel> AdressUser { get; set; }
    public DbSet<NeighborhoodModel> Neighborhood { get; set; }
    public DbSet<SessionModel> Session { get; set; }
    public DbSet<ServiceModel> Service {get; set; }
    public DbSet<ServiceSessionModel> SessionService {get; set; }


    public Db(DbContextOptions<Db> options) : base(options) { }
}

using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository{
    private readonly Db _db;

    public UserRepository(Db db)
    {
        _db = db;
    }

    public async Task<UserModel> AddUser(UserModel user) {
        try
        {
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }
        catch (Exception exception)
        {
            throw new Exception("Erro ao adicionar usuário: " + exception.Message);
        }
    }

    public async Task<UserModel> FindUserByCpf(string cpf){
        try{
            return await _db.User.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }
        catch (Exception exception){
            throw new Exception(exception.Message);
        }
    }

    public async Task<UserModel> UpdatedUser(UserModel userToUpdate, UserModel findedUser)
    {
        findedUser.Name = userToUpdate.Name;
        findedUser.Password = userToUpdate.Password;
        findedUser.telephone = userToUpdate.telephone;
        findedUser.Employee = userToUpdate.Employee;

        await _db.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task<UserModel> DeleteUser(UserModel userToDelete){
        _db.User.Remove(userToDelete) ;
        await _db.SaveChangesAsync();
        return userToDelete;
    }

}
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository{
    private readonly Db _db;

    public UserRepository(Db db)
    {
        _db = db;
    }

    public async Task<UserModel> Add(UserModel user) {
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

    public async Task<UserModel> FindByCpf(string cpf){
        try{
            return await _db.User.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }
        catch (Exception exception){
            throw new Exception(exception.Message);
        }
    }

    public async Task<List<UserModel>> FindAll(){
        List<UserModel> userList = await _db.User.ToListAsync();
        return userList;
    }

    public async Task<UserModel> Update(UserModel userToUpdate, UserModel findedUser)
    {
        findedUser.Name = userToUpdate.Name;
        findedUser.Password = userToUpdate.Password;
        findedUser.telephone = userToUpdate.telephone;
        findedUser.Employee = userToUpdate.Employee;

        await _db.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task<UserModel> Delete(UserModel userToDelete){
        _db.User.Remove(userToDelete) ;
        await _db.SaveChangesAsync();
        return userToDelete;
    }

}
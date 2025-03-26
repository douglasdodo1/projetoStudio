public interface IUserRepository{
    Task<UserModel> AddUser(UserModel user);
    Task<UserModel> FindUserByCpf(string cpf);
    Task<UserModel> UpdatedUser(UserModel userToUpdate, UserModel findedUser);
    Task<UserModel> DeleteUser(UserModel userToDelete);
}
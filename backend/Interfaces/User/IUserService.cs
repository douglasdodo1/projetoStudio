public interface IUserService {
    Task<UserModel> addUser(UserModel user);
    Task<UserModel> findUserByCpf(string cpf);
    Task<UserModel> updateUser(string cpf, UserModel userToUpdate);
    Task<UserModel> deleteUser(string cpf);
}
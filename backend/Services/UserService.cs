public class UserService : IUserService{

    private readonly IUserRepository _userRepository;

    public UserService(UserRepository userRepository){
        _userRepository = userRepository;
    }
    public async Task<UserModel> addUser(UserModel user){
        UserModel FindedUser = await _userRepository.FindUserByCpf(user.Cpf);
        if(FindedUser != null){
            throw new Exception("Usuário já cadastrado.");
        }

        UserModel result = await _userRepository.AddUser(user);
        return result;
    }

    public async Task<UserModel> findUserByCpf(string cpf){
        UserModel user = await _userRepository.FindUserByCpf(cpf);
        if(user == null){
            throw new Exception("Usuário não encontrado.");
        }
        return user;
    }

    public async Task<UserModel> updateUser(string cpf, UserModel userToUpdate){
        UserModel findedUser = await _userRepository.FindUserByCpf(cpf);
        if(findedUser == null){
            throw new Exception("Usuário não encontrado.");
        }

        UserModel updatedUser = await _userRepository.UpdatedUser(userToUpdate,findedUser);
        return updatedUser;
    }

    public async Task<UserModel> deleteUser(string cpf){
        UserModel userToDelete = await _userRepository.FindUserByCpf(cpf);
        if (userToDelete == null)
        {
            throw new Exception("usuário não encontrado");
        }

        UserModel deletedUser = await _userRepository.DeleteUser(userToDelete);
        return deletedUser;
    }
}
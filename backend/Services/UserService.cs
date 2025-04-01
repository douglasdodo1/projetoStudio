
public class UserService : IUserService{

    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository){
        _userRepository = userRepository;
    }
    public async Task<UserModel> Add(UserModel user){
        UserModel FindedUser = await _userRepository.FindByCpf(user.Cpf);
        if(FindedUser != null){
            throw new Exception("Usuário já cadastrado.");
        }

        UserModel result = await _userRepository.Add(user);
        return result;
    }

    public async Task<UserModel> FindByCpf(string cpf){
        UserModel user = await _userRepository.FindByCpf(cpf);
        if(user == null){
            throw new Exception("Usuário não encontrado.");
        }
        return user;
    }

    public async Task<List<UserModel>> FindAll()
    {
        List<UserModel> userList = await _userRepository.FindAll();
        return userList;
    }

    public async Task<UserModel> Update(string cpf, UserModel userToUpdate){
        UserModel findedUser = await _userRepository.FindByCpf(cpf);
        if(findedUser == null){
            throw new Exception("Usuário não encontrado.");
        }

        UserModel updatedUser = await _userRepository.Update(userToUpdate,findedUser);
        return updatedUser;
    }

    public async Task<UserModel> Delete(string cpf){
        UserModel userToDelete = await _userRepository.FindByCpf(cpf);
        if (userToDelete == null)
        {
            throw new Exception("usuário não encontrado");
        }

        UserModel deletedUser = await _userRepository.Delete(userToDelete);
        return deletedUser;
    }

    
}
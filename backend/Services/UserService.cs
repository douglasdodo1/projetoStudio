using FluentValidation;

public class UserService : IUserService{

    private readonly UserRepository _userRepository;
    private readonly IValidator<UserModel> _validator;

    public UserService(IValidator<UserModel> validador, UserRepository userRepository){
        _userRepository = userRepository ;
        _validator = validador;
    }
    public async Task<UserModel> Add(UserModel user){
        var validationResult = _validator.Validate(user);
        var erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

        if(!validationResult.IsValid){
            throw new ArgumentException(erros);
        }

        UserModel FindedUser = await _userRepository.FindByCpf(user.Cpf);
        if(FindedUser != null){
            throw new InvalidOperationException("Usuário já cadastrado.");
        }

        UserModel result = await _userRepository.Add(user);
        return result;
    }

    public async Task<UserModel> FindByCpf(string cpf){
        UserModel user = await _userRepository.FindByCpf(cpf);
        if(user == null){
            throw new KeyNotFoundException("Usuário não encontrado.");
        }
        return user;
    }

    public async Task<List<UserModel>> FindAll()
    {
        List<UserModel> userList = await _userRepository.FindAll();
        return userList;
    }

    public async Task<UserModel> Update(string cpf, UserModel userToUpdate){
        var resultadoValidacao = _validator.Validate(userToUpdate);
        if (!resultadoValidacao.IsValid){
            throw new ArgumentException($"{resultadoValidacao.Errors} argumentos inválidos");
        }

        UserModel findedUser = await _userRepository.FindByCpf(cpf);
        if(findedUser == null){
            throw new KeyNotFoundException("Usuário não encontrado.");
        }

        UserModel updatedUser = await _userRepository.Update(userToUpdate,findedUser);
        if(updatedUser == null){
            throw new InvalidOperationException("erro ao atualizar usuario");
        }
        return updatedUser;
    }

    public async Task<UserModel> Delete(string cpf){
        UserModel userToDelete = await _userRepository.FindByCpf(cpf);
        if (userToDelete == null)
        {
            throw new KeyNotFoundException("usuário não encontrado");
        }

        UserModel deletedUser = await _userRepository.Delete(userToDelete);
        return deletedUser;
    }
}
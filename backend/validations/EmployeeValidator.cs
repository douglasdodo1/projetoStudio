using System.Security.Claims;

public class EmployeeValidator {
    private readonly HttpContextAccessor _httpContextAccessor;
    private readonly UserService _userService;

    public EmployeeValidator(HttpContextAccessor httpContextAccessor, UserService userService) {
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public async Task ValidateEmployee() {
        var cpf = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value ?? throw new InvalidOperationException("Usuário não autenticado");
        UserModel user = await _userService.FindByCpf(cpf);
        if (user.Employee == false) {
            throw new InvalidOperationException("Usuário não é um funcionário");
        }
    }
}
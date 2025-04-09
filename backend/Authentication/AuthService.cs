using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthService {
    private readonly IConfiguration _configuration;
    private readonly UserService _userService;
    private PasswordHasher _passwordHasher;

    public AuthService(IConfiguration configuration, UserService userService, PasswordHasher passwordHasher) {
        _passwordHasher = passwordHasher;
        _configuration = configuration;
        _userService = userService;
    }

    public async Task<string> Login(string cpf, string password) {

        if (string.IsNullOrEmpty(cpf)) {
            throw new ArgumentException("cpf não fornecido");
        }
        else if (cpf.Length != 11) {
            throw new ArgumentException("cpf não possui 11 digitos");
        }

        if (string.IsNullOrEmpty(password)) {
            throw new ArgumentException("senha não fornecida");
        }

        UserModel findedUser = await _userService.FindByCpf(cpf);
        if (findedUser == null) {
            throw new KeyNotFoundException("Usuário não encontrado");
        }

        bool hashedPassoword = _passwordHasher.verifyPassword(password, findedUser.Password);
        if (!hashedPassoword) {
            throw new UnauthorizedAccessException("Senha inválida");
        }

        var claims = new[]{
            new Claim(ClaimTypes.Name, cpf)
        };

        var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
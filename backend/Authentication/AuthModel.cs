public class AuthModel {
    public string Cpf { get; set; }
    public string Password { get; set; }

    public AuthModel(string cpf, string password) {
        Cpf = cpf;
        Password = password;
    }
}
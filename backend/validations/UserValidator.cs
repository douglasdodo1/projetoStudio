using FluentValidation;

public class UserValidator : AbstractValidator<UserModel>{
    public UserValidator(){
        RuleFor(x => x.Cpf).Length(11).WithMessage("O cpf deve ter exatamente 11 digitos");
        RuleFor(x=>x.Name).MinimumLength(2).WithMessage("O nome deve ter no minimo 2 digitos");
        RuleFor(x=>x.Password).MinimumLength(6).WithMessage("A senha deve ter no minimo 6 digitos");
        RuleFor(x=>x.Employee).NotNull().WithMessage("cargo não fornecido");
        RuleFor(x=>x.telephone).Length(11).WithMessage("O telefone deve ter exatamente 11 digitos");
    }
}
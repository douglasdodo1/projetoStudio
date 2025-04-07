using FluentValidation;

public class SessionValidator: AbstractValidator<SessionModel>{
    public SessionValidator(){
        RuleFor(x => x.Cpf).Length(11).WithMessage("Cpf deve conter 11 digitos");
        RuleFor(x => x.State).NotNull().WithMessage("Deve conter estado da sessão");
        RuleFor(x => x.Value).GreaterThan(0).WithMessage("Valor da sessão deve ser maior que zero");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Data da sessão não pode ser vazia");
        RuleFor(x => x.Time).NotEmpty().WithMessage("Hora da sessão não pode ser vazia");
    }
}
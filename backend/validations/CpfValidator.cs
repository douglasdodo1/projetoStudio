public class CpfValidator {


    public bool IsValid(string cpf) {
        int burden = 10;
        int sum = 0;
        int firstCheckDigit = -1;
        int secondCheckDigit = -1;

        if (cpf.Distinct().Count() == 1) {
            return false;
        }

        for (int i = 0; i < 9; i++) {
            sum += int.Parse(cpf[i].ToString()) * burden;
            burden--;
        }

        if ((sum % 11) < 2) {
            firstCheckDigit = 0;
        }
        else {
            firstCheckDigit = 11 - (sum % 11);
        }

        sum = 0;
        burden = 11;

        for (int i = 0; i < 10; i++) {
            sum += int.Parse(cpf[i].ToString()) * burden;
            burden--;
        }

        if ((sum % 11) < 2) {
            secondCheckDigit = 0;
        }
        else {
            secondCheckDigit = 11 - (sum % 11);
        }



        if (firstCheckDigit == int.Parse(cpf[9].ToString()) && secondCheckDigit == int.Parse(cpf[10].ToString())) {
            return true;
        }

        return false;
    }
}
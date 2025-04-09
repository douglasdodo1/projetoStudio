using System.Net.Mail;

public class EmailValidator {
    public static bool IsValidEmail(string email) {
        var mail = new MailAddress(email);
        if (mail != null) {
            return true;
        }

        return false;
    }
}
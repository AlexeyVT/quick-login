using QuickLogin.Helpers;

namespace QuickLogin.LoginFlow;

public class LoginQrCode
{
    public IQuickLoginIdentity? Identity { get; private set; }
    public string Code { get; init; }
    public string? VerificationCode { get; private set; }
    public string ReturnUrl { get; init; }
    public DateTime Expired { get; init; }
    public Action<string, string> LoginSuccessCallback { get; init; }

    public bool IsActual => Expired > DateTime.Now;

    public LoginQrCode(byte codeLength, string returnUrl, DateTime expired, Action<string, string> loginSuccessCallback)
    {
        Code = RandomGenerator.CreateString(codeLength);
        ReturnUrl = returnUrl;
        Expired = expired;
        LoginSuccessCallback = loginSuccessCallback;
    }


    public bool Authenticate(string verificationCode) => VerificationCode == verificationCode && Identity?.IsActual == true;

    public bool Authorize(IQuickLoginIdentity identity)
    {
        if (!IsActual || !identity.IsActual) //повторная проверка
        {
            return false;
        }

        Identity = identity;
        VerificationCode = RandomGenerator.CreateString(24);

        try
        {
            LoginSuccessCallback(Code, VerificationCode);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
namespace QuickLogin.LoginFlow;

public interface ILoginFlowService
{
    string Create(string returnUrl, Action<string, string> loginSuccessCallback);

    LoginQrCode? Get(string code);
}
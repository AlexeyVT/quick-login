namespace QuickLogin.SetupFlow;

public interface ISetupFlowService
{
    string Create(IQuickLoginIdentity identity, Action setupSuccessCallback);

    SetupQrCode? Get(string code);
}
using BSMVCprj.Models;

namespace BSMVCprj.Interfaces
{
    public interface IBanktransferrequest
    {
        int Deposit(MoneyTransferM transfer);
        int Withdraw(MoneyTransferM transfer);
    }
}

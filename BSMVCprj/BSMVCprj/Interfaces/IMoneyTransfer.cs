using BSMVCprj.Models;

namespace BSMVCprj.Interfaces
{
    public interface IMoneyTransfer
    {
        int MoneyTransfer(MoneyTransferM transfer, int userid);
        int Deposit(BankingModel transfer);
        int Withdraw(MoneyTransferM transfer, int Userid);
    }
}

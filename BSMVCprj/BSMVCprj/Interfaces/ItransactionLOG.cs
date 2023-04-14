using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Interfaces
{
    public interface ItransactionLOG
    {
        Task transaction(MoneyTransferM transactionlogmodel, int userid, string transtype);
        void UpdateTransaction(MoneyTransferM updatemodel,string procedurename);
        Task TransactionId(MoneyTransferM model,int Userid);
    }
}

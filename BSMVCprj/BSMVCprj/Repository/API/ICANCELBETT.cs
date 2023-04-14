using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface ICANCELBETT
    {
        void CancelBett(string PrivateToken,int TransactionId,int BetTransactionId,decimal Amount,out TokenModel Model);
    }
}

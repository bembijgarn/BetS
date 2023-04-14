using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Interfaces
{
    public interface IBankRequest
    {
        Task MoneyRequest(MoneyTransferM model, int Userid);
        Task WithdrawRequest(MoneyTransferM model,int Userid);
    }
}

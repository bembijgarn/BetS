using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface IWINN
    {
        void Winnzor(string PrivateToken, int TransactionId, string TransType, decimal Amount,out TokenModel model);
    }
}

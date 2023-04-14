using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface IBETT
    {
        Task Bettzor(string PrivateToken,int TransactionId,string TransType,decimal Amount, TokenModel model);
    }
}

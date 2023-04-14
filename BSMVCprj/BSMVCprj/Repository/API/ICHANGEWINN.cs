using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface ICHANGEWINN
    {
        void ChangeWinn(string PrivateToken,int TransactionId,int PreviousTranId,decimal Amount,decimal PreviousAmount,out TokenModel Model);
    }
}

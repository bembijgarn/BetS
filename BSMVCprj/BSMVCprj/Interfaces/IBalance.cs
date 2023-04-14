using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository
{
    public interface IBalance
    {
        Task GetBalance(Balancemodel balance,int Userid);
    }
}

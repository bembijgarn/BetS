using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface IAPIBALANCE
    {
        void Balance(string Token,string Status,out TokenModel Balance);
    }
}

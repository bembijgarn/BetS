using BSMVCprj.Models;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface IAUTH
    {
        void Authentification(out TokenModel Privatetoken,string Token,string Status);
    }
}

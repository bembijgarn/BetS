using BSMVCprj.APIModels;
using BSMVCprj.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.API
{
    public interface IAPIUSER
    {
        List<UserAccountM>ApiUser(string Token,string Status,out TokenModel token);
    }
}

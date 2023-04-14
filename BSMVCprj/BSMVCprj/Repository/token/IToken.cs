using BSMVCprj.Models;
using System;
using System.Threading.Tasks;

namespace BSMVCprj.Repository.token
{
    public interface IToken
    {
        Task Createtoken(int Userid,string Status);
        Task GetToken(int Userid, string Status,TokenModel token);
        Task DeleteToken(TokenModel model);
    }
}

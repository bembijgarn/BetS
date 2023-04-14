using BSMVCprj.Models;
using System.Collections.Generic;

namespace BSMVCprj.Interfaces
{
    public interface IDetails
    {
        IEnumerable<UserAccountM> Getuserinfo(int Id);
    }
}

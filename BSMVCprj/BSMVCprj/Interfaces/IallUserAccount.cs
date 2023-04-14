using BSMVCprj.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSMVCprj.Interfaces
{
    public interface IallUserAccount
    {
        IEnumerable<UserAccountM> GetAll();
        Task Delete(int Id);
    }
}

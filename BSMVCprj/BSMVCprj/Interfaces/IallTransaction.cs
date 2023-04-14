using BSMVCprj.Models;
using System.Collections.Generic;

namespace BSMVCprj.Interfaces
{
    public interface IallTransaction
    {
        IEnumerable<TransactionstoryM> Getalltran(DatetimeModel datetime,int Userid);
    }
}

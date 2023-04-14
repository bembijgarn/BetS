using BSMVCprj.Models;
using System.Collections.Generic;

namespace BSMVCprj.Interfaces
{
    public interface ILoginRegistrationStatus
    {
        IEnumerable<dynamic> Login(LoginM user);
        void Registration(RegistrationM user);
    }
}

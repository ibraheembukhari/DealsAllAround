using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealsAllAround.DataAccess
{
    public interface IUserInfoProvider
    {
        bool IsValid(string email, string password);
        void Registeration(User user);
    }
}

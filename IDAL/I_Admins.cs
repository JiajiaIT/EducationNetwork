using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface I_Admins:I_Base<Admins>
    {
        int Login(string username,string password);
        void EditPassword(string username, string password);
        string ViewPassword(string username);
    }
}

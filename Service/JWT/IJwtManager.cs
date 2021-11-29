using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.JWT
{
    public interface IJwtManager
    {
        string Authentication(string id, string username, string password, string[] roles);
        
    }
}

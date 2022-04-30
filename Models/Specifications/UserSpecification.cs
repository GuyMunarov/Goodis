using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class UserSpecification : BaseSpecification<AppUser>
    {
        public UserSpecification(string userName, string password) : base(x => x.UserName == userName && x.Password == password)
        {

        }

        public UserSpecification(string userName) : base(x => x.UserName == userName)
        {

        }
    }
}

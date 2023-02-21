using DataAccess.Management;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Member GetMember(string email, string password)
        {
            return MemberManagement.Instance.GetMember(email, password);
        }
    }
}

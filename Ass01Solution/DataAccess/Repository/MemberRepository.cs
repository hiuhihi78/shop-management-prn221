using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public ObservableCollection<MemberDTO> GetListMember(string parmeter)
        {
            return MemberManagement.Instance.GetListMember(parmeter);
        }

        public Member GetMember(string email, string password)
        {
            return MemberManagement.Instance.GetMember(email, password);
        }

        public Member GetMemberByEmail(string email)
        {
            return MemberManagement.Instance.GetMemberByEmail(email);
        }
    }
}

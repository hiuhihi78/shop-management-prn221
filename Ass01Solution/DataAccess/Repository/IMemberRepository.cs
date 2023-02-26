using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        Member GetMember(string email, string password);
        Member GetMemberByEmail(string email);
        ObservableCollection<MemberDTO> GetListMember(string parmeter);
        bool DeleteMember(int memberId);
        void CreateMember(Member member);   
        void UpdateMember(Member member);
    }
}

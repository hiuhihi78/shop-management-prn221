using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Management
{
    public class MemberManagement
    {
        //Using Singleton Pattern
        private static MemberManagement instance = null;
        private static readonly object instanceLock = new object();

        public static MemberManagement Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberManagement();  
                    }
                }
                return instance;
            }
        }

        private MemberManagement() { }

        public Member GetMember(string email, string password) 
        {
            Member? member;
            try
            {
                Assgiment1PrnContext context = new Assgiment1PrnContext();  
                member = context.Members.FirstOrDefault(x => x.Email == email && x.Password == password);   
            }catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public Member GetMemberByEmail(string email)
        {
            Member? member;
            try
            {
                Assgiment1PrnContext context = new Assgiment1PrnContext();
                member = context.Members.FirstOrDefault(x => x.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }


        public ObservableCollection<MemberDTO> GetListMember(string parmeter) 
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            ObservableCollection<MemberDTO> result = new ObservableCollection<MemberDTO>(); 
            var memebers = context.Members.Where(x => x.Email.Contains(parmeter)).ToList();
            foreach(var memeber in memebers) 
            {
                result.Add(MemberDTO.FromMember(memeber));
            }
            return result;
        }

        public bool DeleteMember(int memberId)
        {
            try
            {
                Assgiment1PrnContext context = new Assgiment1PrnContext();
                var member = context.Members.FirstOrDefault(x =>x.MemberId == memberId);
                if(member != null) 
                {
                    context.Members.Remove(member);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch(Exception ex) 
            {
                return false;   
            }
        }

        public void CreateMember(Member memberCreate)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            context.Members.Add(memberCreate);
            context.SaveChanges();
        }

        public void UpdateMember(Member memberUpdate)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            var member = context.Members.FirstOrDefault(x => x.MemberId == memberUpdate.MemberId);
            member.Email = memberUpdate.Email;
            member.CompanyName = memberUpdate.CompanyName;  
            member.City = memberUpdate.City;    
            member.Country = memberUpdate.Country;
            member.Password= memberUpdate.Password; 
            context.SaveChanges();
        }


    }
}

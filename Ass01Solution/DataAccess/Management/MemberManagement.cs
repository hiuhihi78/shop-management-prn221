using DataAccess.Models;
using System;
using System.Collections.Generic;
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

        
    }
}

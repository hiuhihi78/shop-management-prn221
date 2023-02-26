using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace SalesWPFApp.Common
{
    public static class DataContext
    {
        public static IMemberRepository memberRepository { get; set; }
    }
}

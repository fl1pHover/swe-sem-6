using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swe_seminar6
{
    internal class user_parameter
    {
        static int Uid;
        public static int uid
        {
            get
            {
                return Uid;
            }
            set
            {
                Uid = value;
            }
        }
    }
}

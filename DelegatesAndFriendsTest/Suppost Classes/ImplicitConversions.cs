using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndFriendsTest.Suppost_Classes
{

    public class UserDefinedType
    {
        //LD property and constructor
        public int aNumber { get; set; }
        public UserDefinedType(int ANumber)
        {
            aNumber = ANumber;
        }

        //user defined conversion from "UserDefinedType" to double
        public static implicit operator double(UserDefinedType x)
        {
            return x.aNumber*10;
        }

        //user defined conversion from int to "UserDefinedType"
        public static implicit operator UserDefinedType(int x)
        {
            return new UserDefinedType(x);
        }
    }


}

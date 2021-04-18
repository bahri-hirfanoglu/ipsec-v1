using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpSec
{
    public class ipsec
    {
        public static bool Create(string type)
        {
            try
            {
                type = string.IsNullOrEmpty(type) ? "BLOCK" : (!(type.ToUpper() != "BLOCK") || !(type.ToUpper() != "PERMIT") ? type.ToUpper() : "BLOCK");
                string empty = string.Empty;
                string result = string.Empty;

                result = command.PolicyAdd("IpSec Policy", "IpSec Policy Description", "yes");
                if (result.Length > 0)
                    throw new Exception(result);


                result = command.AddFilter("IpSec Permit Filter List", "IpSec Permit Filter List Description");
                if (result.Length > 0)
                    throw new Exception(result);

                result = command.AddFilter("IpSec Block Filter List", "IpSec Block Filter List Description");
                if (result.Length > 0)
                    throw new Exception(result);

                if (!check("1.1.1.1", "IpSec Block Filter List"))
                    throw new Exception("Error : Adding a default Filter to Block Filter List");

                if (!check("1.1.1.1", "IpSec Permit Filter List"))
                    throw new Exception("Error : Adding a default Filter to Permit Filter List");

                result = command.AddFilterAction("Permit", "IpSec Permit Filter Action","permit");
                if (result.Length > 0)
                    throw new Exception(result);

                result = command.AddFilterAction("Block", "IpSec Block Filter Action","block");
                if (result.Length > 0)
                    throw new Exception(result);

                result = command.AddRule("IpSec Block Rule", "IpSec Policy", "IpSec Block Filter List", "Block", type == "BLOCK" ? "yes" : "yes");
                if (result.Length > 0)
                    throw new Exception(result);

                result = command.AddRule("IpSec Permit Rule", "IpSec Policy", "IpSec Permit Filter List", "Permit", type == "PERMIT" ? "yes" : "yes");
                if (result.Length > 0)
                    throw new Exception(result);

                addFilterList("1.1.1.1", "IpSec Permit Filter List");
                addFilterList("1.1.1.1", "IpSec Block Filter List");
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool on_or_off(bool A_0)
        {
            string text = command.UpdatePolicy("IpSec Policy", A_0 ? "yes" : "no");
            return text.Length == 0;
        }
        public static bool addFilterList(string a, string b)
        {
            return command.DeleteFilterList(b, a).Length == 0;
        }
        public static bool check(string a, string b)
        {
            return command.AddFilterList(b, a).Length == 0;
        }


       

    }
}

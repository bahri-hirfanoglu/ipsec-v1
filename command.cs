using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpSec
{
    class command
    {
        public static string AllDelete()
        {
            return netSh.command(string.Format("ipsec static delete all"));
        }
        public static string FilterListDelete(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static delete filter filterlist=\"{0}\" srcaddr=any dstaddr=me protocol=tcp dstport=\"{1}\"", (object)A_0, (object)A_1));
        }
        public static string FilterListAdd(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static add filter filterlist=\"{0}\" srcaddr=any dstaddr=me protocol=tcp dstport=\"{1}\"", (object)A_0, (object)A_1));
        }
        public static string PolicyAdd(string A_0, string A_1, string A_2)
        {
            return netSh.command(string.Format("ipsec static add policy name=\"{0}\" description=\"{1}\" assign={2}", (object)A_0, (object)A_1, (object)A_2));
        }
        public static string ListPolicy(string A_0)
        {
            return netSh.command(string.Format("ipsec static show policy name=\"{0}\"", (object)A_0));
        }

        public static string DeletePolicy(string A_0)
        {
            return netSh.command(string.Format("ipsec static delete policy name=\"{0}\"", (object)A_0));
        }

        public static string UpdatePolicy(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static set policy name=\"{0}\" assign=\"{1}\"", (object)A_0, (object)A_1));
        }

        public static string AddFilter(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static add filterlist name=\"{0}\" description=\"{1}\"", (object)A_0, (object)A_1));
        }

        public static string AddFilterList(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static add filter filterlist=\"{0}\" srcaddr={1} dstaddr=me protocol=any", (object)A_0, (object)A_1));
        }
        public static string DeleteFilterList(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static delete filter filterlist=\"{0}\" srcaddr={1} dstaddr=me protocol=any", (object)A_0, (object)A_1));
        }
        public static string ShowFilter(string A_0)
        {
            return netSh.command(string.Format("ipsec static show filterlist name=\"{0}\"", (object)A_0));
        }

        public static string DeleteFilter(string A_0)
        {
            return netSh.command(string.Format("ipsec static delete filterlist name=\"{0}\"", (object)A_0));
        }

        public static string AddFilterAction(string A_0, string A_1, string type)
        {
            return netSh.command(string.Format("ipsec static add filteraction name=\"{0}\" description=\"{1}\" action=\"{2}\"", (object)A_0, (object)A_1,(object)type));
        }
        public static string ShowFilterAction(string A_0)
        {
            return netSh.command(string.Format("ipsec static show filteraction name=\"{0}\"", (object)A_0));
        }

        public static string DeleteFilterAction(string A_0)
        {
            return netSh.command(string.Format("ipsec static delete filteraction name=\"{0}\"", (object)A_0));
        }

        public static string ShowFilterList(string A_0)
        {
            return netSh.command(string.Format("ipsec static show filterlist name=\"{0}\" level=verbose format=table", (object)A_0));
        }
        public static string AddRule(string A_0, string A_1, string A_2, string A_3, string A_4)
        {
            return netSh.command(string.Format("ipsec static add rule name=\"{0}\" policy=\"{1}\" filterlist=\"{2}\" filteraction=\"{3}\" activate={4}", (object)A_0, (object)A_1, (object)A_2, (object)A_3, (object)A_4));
        }

        public static string ShowRule(string A_0, string A_1)
        {
            return netSh.command(string.Format("ipsec static show rule name=\"{0}\" policy=\"{1}\"", (object)A_0, (object)A_1));
        }
 
        public static string UpdateRule(string A_0, string A_1, string A_2)
        {
            return netSh.command(string.Format("ipsec static set rule name=\"{0}\" policy=\"{1}\" activate={2}", (object)A_0, (object)A_1, (object)A_2));
        }

    }
}

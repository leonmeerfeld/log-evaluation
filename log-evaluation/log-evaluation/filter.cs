using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_evaluation
{
    class Filter
    {
        public List<string[]> filter_list(List<string[]> unfiltered_list, string date, string time, string name, string alias, string ipadress, string sessionid)
        {
            List<string[]> filtered_list = new List<string[]>();

            foreach(var item in unfiltered_list)
            {
                bool date_bool = (String.IsNullOrEmpty(date)) ? false : true;
                if(date_bool)
                {

                }

                if ((date.Length > 0) ? (item[0].Contains(date)) : true &&
                    (time.Length > 0) ? (item[1].Contains(time)) : true &&
                    (name.Length > 0) ? (item[4].Contains(name)) : true && 
                    (alias.Length > 0) ? (item[5].Contains(alias)) : true &&
                    (ipadress.Length > 0) ? (item[6].Contains(ipadress)) : true && 
                    (sessionid.Length > 0) ? (item[7].Contains(sessionid)) : true)
                {
                    filtered_list.Add(item);
                }
            }
                return filtered_list;
        }
    }
}

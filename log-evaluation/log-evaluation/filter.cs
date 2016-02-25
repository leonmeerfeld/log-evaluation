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
                //f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text)
                if (item[0].Contains(date) && item[1].Contains(time) && item[4].Contains(name) && item[5].Contains(alias) && item[6].Contains(ipadress) && item[7].Contains(sessionid))
                {
                    filtered_list.Add(item);
                }
            }
            return filtered_list;
        }
    }
}

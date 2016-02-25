using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_evaluation
{
    class sort
    {
        /* Log file:
         * [0]: 0, 11: Date
         * [1]: 12, 8: Time
         * [2]: 21, 4: INFO or WARN
         * [3]: 27, 12: Exec
         * [4]: Who
         * [5]: Alias
         * [6]: IP
         * [7]: SessionID
         */
        public List<string[]> sort_log(string text)
        {
            List<string[]> sorted_log_list = new List<string[]>();

            string[] log_rows = text.Split('\n');

            foreach(var item in log_rows)
            {
                if( ! String.IsNullOrEmpty(item))
                {
                    string[] log_row = new string[8];
                    int word_length = 0;

                    log_row[0] = item.Substring(0, 11);
                    log_row[1] = item.Substring(12, 8);
                    log_row[2] = item.Substring(21, 4);
                    log_row[3] = item.Substring(27, 12);

                    if(log_row[2] != "WARN")
                    {
                        log_row[4] = item.Substring(54, (item.IndexOf("als", 54) - 55));

                        word_length = ((item.IndexOf(" von ", 54) - 1) - (item.IndexOf(" als ", 54) + 4));
                        log_row[5] = item.Substring((item.IndexOf("als", 54) + 4), word_length);

                        word_length = ((item.IndexOf(" mit ", 54) - 1) - (item.IndexOf(" von ", 54) + 4));
                        log_row[6] = item.Substring((item.IndexOf("von", 54) + 4), word_length);

                        log_row[7] = item.Substring((item.IndexOf("sessionid", 54) + 10));
                    }

                    sorted_log_list.Add(log_row);
                }
            }

            return sorted_log_list;
        }
    }
}

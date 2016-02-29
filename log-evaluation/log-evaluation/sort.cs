using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_evaluation
{
    class Sort
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

        //int lt1 = 0;
        //int lt2 = 0;
        //int lt3 = 0;
        //int lt4 = 0;
        //int lt5 = 0;
        //int lt6 = 0;
        //int lt7 = 0;
        //int lt8 = 0;

        public List<string[]> sort_log_into_list(string text)
        {
            List<string[]> sorted_log_list = new List<string[]>();

            string[] log_rows = text.Split('\n');
            List<string> log_row = new List<string>();

            foreach(var item in log_rows)
            {
                if( ! String.IsNullOrEmpty(item))
                {
                    int word_length = 0;

                    log_row.Add(item.Substring(0, 11));
                    log_row.Add(item.Substring(12, 8));
                    log_row.Add(item.Substring(21, 4));
                    log_row.Add(item.Substring(27, 12));

                    if(log_row[2] != "WARN")
                    {
                        log_row.Add(item.Substring(54, (item.IndexOf("als", 54) - 55)));

                        word_length = ((item.IndexOf(" von ", 54) - 1) - (item.IndexOf(" als ", 54) + 4));
                        log_row.Add(item.Substring((item.IndexOf("als", 54) + 4), word_length));

                        word_length = ((item.IndexOf(" mit ", 54) - 1) - (item.IndexOf(" von ", 54) + 4));
                        log_row.Add(item.Substring((item.IndexOf("von", 54) + 4), word_length));

                        log_row.Add(item.Substring((item.IndexOf("sessionid", 54) + 10)));
                    }else
                    {
                        log_row.Add(item.Substring(54, (item.IndexOf("von", 54) - 55)));

                        log_row.Add("");

                        word_length = ((item.IndexOf("fehlgeschlagen", 54) - 1) - (item.IndexOf(" von ", 54) + 4));
                        log_row.Add(item.Substring((item.IndexOf("von", 54) + 4), word_length));

                        log_row.Add("");
                    }
                    string[] log_array = new string[8];

                    int i = 0;
                    foreach(var row_item in log_row)
                    {
                        log_array[i++] = row_item;
                    }

                    sorted_log_list.Add(log_array);
                    log_row.Clear();
                }
            }

            return sorted_log_list;
        }
    }
}

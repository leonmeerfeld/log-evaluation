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
            string[] log_row = new string[8];

            foreach(var item in log_rows)
            {
                if( ! String.IsNullOrEmpty(item))
                {
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
                    }else
                    {
                        log_row[4] = "";
                        log_row[5] = "";
                        log_row[6] = "";
                        log_row[7] = "";
                    }

                    //lt1 = (log_row[0].Length > lt1) ? log_row[0].Length : lt1;
                    //lt2 = (log_row[1].Length > lt2) ? log_row[1].Length : lt2;
                    //lt3 = (log_row[2].Length > lt3) ? log_row[2].Length : lt3;
                    //lt4 = (log_row[3].Length > lt4) ? log_row[3].Length : lt4;
                    //lt5 = (log_row[4].Length > lt5) ? log_row[4].Length : lt5;
                    //lt6 = (log_row[5].Length > lt6) ? log_row[5].Length : lt6;
                    //lt7 = (log_row[6].Length > lt7) ? log_row[6].Length : lt7;
                    //lt8 = (log_row[7].Length > lt8) ? log_row[7].Length : lt8;

                    sorted_log_list.Add(log_row);
                }
            }

            return sorted_log_list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_evaluation
{
    /// <summary>
    /// Holds method for filtering data
    /// </summary>
    class Filter
    {
        /// <summary>
        /// Filters a sorted multidimensional array by parameters.
        /// </summary>
        /// <param name="sorted_logs"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="name"></param>
        /// <param name="alias"></param>
        /// <param name="ipadress"></param>
        /// <param name="sessionid"></param>
        /// <returns></returns>
        public string[,,] filter_list(string[,,] sorted_logs, string date, string time, string name, string alias, string ipadress, string sessionid)
        {
            string[,,] filtered_list = new string[sorted_logs.GetLength(0), sorted_logs.GetLength(1), 8];

            for(int i = 0; i < sorted_logs.GetLength(0); i++)
            {
                for (int j = 0; j < sorted_logs.GetLength(1); j++ )
                {
                    if (
                        (!String.IsNullOrEmpty(date) ? (!String.IsNullOrWhiteSpace(sorted_logs[i, j, 0]) ? sorted_logs[i, j, 0].Contains(date) : false) : true) &&
                        (!String.IsNullOrEmpty(time) ? (!String.IsNullOrWhiteSpace(sorted_logs[i, j, 1]) ? sorted_logs[i, j, 1].Contains(time) : false) : true) &&
                        (!String.IsNullOrEmpty(name) ? (!String.IsNullOrWhiteSpace(sorted_logs[i, j, 4]) ? sorted_logs[i, j, 4].Contains(name) : false) : true) &&
                        (!String.IsNullOrEmpty(alias) ? (!String.IsNullOrWhiteSpace(sorted_logs[i, j, 5]) ? sorted_logs[i, j, 5].Contains(alias) : false) : true) &&
                        (!String.IsNullOrEmpty(ipadress) ? (!String.IsNullOrWhiteSpace(sorted_logs[i, j, 6]) ? sorted_logs[i, j, 6].Contains(ipadress) : false) : true) &&
                        (!String.IsNullOrEmpty(sessionid) ? (!String.IsNullOrWhiteSpace(sorted_logs[i, j, 7]) ? sorted_logs[i, j, 7].Contains(sessionid) : false) : true)
                       )
                    {
                        filtered_list[i, j, 0] = sorted_logs[i, j, 0];
                        filtered_list[i, j, 1] = sorted_logs[i, j, 1];
                        filtered_list[i, j, 2] = sorted_logs[i, j, 2];
                        filtered_list[i, j, 3] = sorted_logs[i, j, 3];
                        filtered_list[i, j, 4] = sorted_logs[i, j, 4];
                        filtered_list[i, j, 5] = sorted_logs[i, j, 5];
                        filtered_list[i, j, 6] = sorted_logs[i, j, 6];
                        filtered_list[i, j, 7] = sorted_logs[i, j, 7];
                    }
                }
            }

            return filtered_list;
        }
    }
}

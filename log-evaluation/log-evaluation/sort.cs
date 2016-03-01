using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace log_evaluation
{
    class Sort
    {
        public int highest_row_count(string[] fileDirectories)
        {
            //Determine what the highest count of rows in all files is
            int most_rows = 0;
            int file_number = 0;

            foreach(var files in fileDirectories)
            {
                string[] row_ar = File.ReadAllLines(fileDirectories[file_number]);
                most_rows = (most_rows > row_ar.Count() ? most_rows : row_ar.Count());

                file_number++;
            }

            return most_rows;
        }

        public string[,,] sort_log_into_list(string[] fileDirectories)
        {
            string[,,] sorted_list = new string[fileDirectories.Count(), highest_row_count(fileDirectories), 8];

            int file_number = 0;

            foreach(var directory in fileDirectories)
            {
                string[] rows_in_text = File.ReadAllLines(fileDirectories[file_number]);

                int row_number = 0;
                int word_length = 0;

                foreach(var row in rows_in_text)
                {
                    if(!String.IsNullOrEmpty(row))
                    {
                        //Date
                        sorted_list[file_number, row_number, 0] = row.Substring(0, 11);

                        //Time
                        sorted_list[file_number, row_number, 1] = row.Substring(12, 8);

                        //INFO or WARN
                        sorted_list[file_number, row_number, 2] = row.Substring(21, 4);

                        //Exec
                        sorted_list[file_number, row_number, 3] = row.Substring(27, 12);

                        //Determines if there was an error
                        if (sorted_list[file_number, row_number, 2] != "WARN")
                        {
                            //Name
                            sorted_list[file_number, row_number, 4] = row.Substring(54, (row.IndexOf("als", 54) - 55));

                            //Alias
                            word_length = ((row.IndexOf(" von ", 54) - 1) - (row.IndexOf(" als ", 54) + 4));
                            sorted_list[file_number, row_number, 5] = row.Substring((row.IndexOf("als", 54) + 4), word_length);
                            
                            //IP
                            word_length = ((row.IndexOf(" mit ", 54) - 1) - (row.IndexOf(" von ", 54) + 4));
                            sorted_list[file_number, row_number, 6] = row.Substring((row.IndexOf("von", 54) + 4), word_length);

                            //SessionID
                            sorted_list[file_number, row_number, 7] = row.Substring((row.IndexOf("sessionid", 54) + 10));
                        }
                        else
                        {
                            sorted_list[file_number, row_number, 4] = row.Substring(54, (row.IndexOf("von", 54) - 55));

                            sorted_list[file_number, row_number, 5] = "";

                            word_length = ((row.IndexOf("fehlgeschlagen", 54) - 1) - (row.IndexOf(" von ", 54) + 4));
                            sorted_list[file_number, row_number, 6] = row.Substring((row.IndexOf("von", 54) + 4), word_length);

                            sorted_list[file_number, row_number, 7] = "";
                        }
                        row_number++;
                    }
                }
                file_number++;
            }
            return sorted_list;
        }
    }
}

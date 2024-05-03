using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class SaveInfo
    {
        //how info is stored: depth, games played, AI wins, player wins, ties
        public void updateFile(int update, int d)
        {
            //if update is 0, increase the number of ties
            //if it's 1, increase the number of player wins
            //if it's 2, increase the number of AI wins
            List<int[]> statList = new List<int[]>();
            int[] stats;
            stats = new int[5];
            statList = readFile();
            if(statList.Count == 0)
            {
                stats[0] = d;
                stats[1] = 1;
                if(update == 0)
                {
                    stats[4] = 1;
                }
                else if(update == 1)
                {
                    stats[3] = 1;
                }
                else if (update == 2)
                {
                    stats[2] = 1;
                }
                statList.Add(stats);
                writeToFile(statList);
            }
            else
            {
                bool notInList = true;
                foreach (int[] stat in statList)
                {
                    if (stat[0] == d)
                    {
                        notInList = false;
                        stat[1]++;
                        if (update == 0)
                        {
                            stat[4]++;
                        }
                        else if (update == 1)
                        {
                            stat[3]++;
                        }
                        else if (update == 2)
                        {
                            stat[2]++;
                        }
                    }
                }
                if(notInList)
                {
                    stats = new int[5];
                    stats[0] = d;
                    stats[1] = 1;
                    if (update == 0)
                    {
                        stats[4] = 1;
                    }
                    else if (update == 1)
                    {
                        stats[3] = 1;
                    }
                    else if (update == 2)
                    {
                        stats[2] = 1;
                    }
                    statList.Add(stats);
                }
                writeToFile(statList);
            }

        }

        public List<int[]> readFile()
        {
            List<int[]> statList = new List<int[]>();
            int[] stats;
            string line;
            int commaPos;
            char delim = ',';
            StreamReader file = new StreamReader("..//..//..//Stats.txt");
            if (file != null)
            {
                while ((line = file.ReadLine()) != null)
                {
                    stats = new int[5];
                    commaPos = line.IndexOf(delim);
                    stats[0] = Int32.Parse(line.Substring(0, commaPos));
                    line = line.Substring(commaPos + 1);
                    commaPos = line.IndexOf(delim);
                    stats[1] = Int32.Parse(line.Substring(0, commaPos));
                    line = line.Substring(commaPos + 1);
                    commaPos = line.IndexOf(delim);
                    stats[2] = Int32.Parse(line.Substring(0, commaPos));
                    line = line.Substring(commaPos + 1);
                    commaPos = line.IndexOf(delim);
                    stats[3] = Int32.Parse(line.Substring(0, commaPos));
                    line = line.Substring(commaPos + 1);
                    commaPos = line.IndexOf(delim);
                    stats[4] = Int32.Parse(line);
                    statList.Add(stats);
                }
                file.Close();
                return statList;
            }
            else
            {
                stats = new int[5];
                Debug.WriteLine("Error reading file");
                stats[0] = -1;
                statList.Add(stats);
                return statList;
            }
        }

        private void writeToFile(List<int[]> statList)
        {
            FileInfo finfo = new FileInfo("..//..//..//Stats.txt");
            //if there's data in the text file open in append
            using (StreamWriter writer = new StreamWriter("..//..//..//Stats.txt"))
            {
                foreach (int[] stat in statList)
                {
                    writer.Write(stat[0]);
                    writer.Write(",");
                    writer.Write(stat[1]);
                    writer.Write(",");
                    writer.Write(stat[2]);
                    writer.Write(",");
                    writer.Write(stat[3]);
                    writer.Write(",");
                    writer.Write(stat[4]);
                    writer.Write("\n");

                }
                writer.Close();
            }
        }
    }
}

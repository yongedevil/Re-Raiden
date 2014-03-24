using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

namespace Raiden
{
    public class FileIO
    {

        static public List<DataNode> LoadFile(string path)
        {
            List<DataNode> nodes = new List<DataNode>();

            try
            {
                StreamReader reader = new StreamReader(path);
                string line, line_prev;

                line = reader.ReadLine();

                while (null != line)
                {             
       
                    line_prev = line;
                    line = reader.ReadLine();
                }
            }
            catch
            {
                //file could not be read
            }

            return nodes;
        }


        static private bool ProccessLine(string line, out string key, out string value)
        {
            string[] line_subs;
            int index_comment;

            //check if there is a comment in the line, if there is drop everything passed the comment
            if((index_comment = line.IndexOf("//")) > -1)
            {
                line = line.Substring(0, index_comment);
            }


            line_subs = line.Split('=');
            if (2 == line_subs.Length && 0 < line_subs[0].Length && 0 < line_subs[1].Length)
            {
                key = line_subs[0];
                value = line_subs[1];
            }
            else
            {
                key = "";
                value = "";
                return false;
            }
        }
    }
}

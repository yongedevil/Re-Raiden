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
            string nodeName;
            DataNode node;

            try
            {
                StreamReader reader = new StreamReader(path);
                string line, line_prev;

                line = ReadNext(ref reader);
                line_prev = string.Empty;

                while (null != line)
                {
                    if (string.Empty != line_prev && NodeStart(line, line_prev, out nodeName))
                    {
                        node = new DataNode(nodeName);
                        ProcessNode(ref reader, ref node);
                        nodes.Add(node);
                    }

                    line_prev = line;
                    line = ReadNext(ref reader);
                }
            }
            catch
            {
                //file could not be read
                Debug.Log("ERROR FileIO: Could not open file " + path);
            }

            return nodes;
        }


        //Reads in from reader untill reaching the end of the node
        static private void ProcessNode(ref StreamReader reader, ref DataNode node)
        {
            string line, line_prev;
            string key, val;
            string subnodeName;
            DataNode subNode;

            line = ReadNext(ref reader);
            line_prev = string.Empty;

            while (null != line && !NodeEnd(line))
            {
                if (null != node && ProccessValues(line, out key, out val))
                {
                    node.AddValue(key, val);
                }

                if (string.Empty != line_prev && NodeStart(line, line_prev, out subnodeName))
                {
                    subNode = new DataNode(subnodeName);
                    ProcessNode(ref reader, ref subNode);
                    node.AddNode(subNode);
                }

                line_prev = line;
                line = ReadNext(ref reader);
            }
        }


        //Retruns true if line is the start of a DataNode and sets nodeName to the name
        static private bool NodeStart(string line, string line_prev, out string nodeName)
        {
            string[] line_subs;

            if(line.Contains("{"))
            {

                line_subs = line.Split('{');
                
                if(string.Empty == line_subs[0])
                {
                    nodeName = line_prev;
                }
                else
                {
                    nodeName = line_subs[0];
                }
                return true;
            }
            
            nodeName = "";
            return false;

        }

        //Returns true if line is the end of a DataNode
        static private bool NodeEnd(string line)
        {
            if (line.Contains("}"))
                return true;

            return false;
        }


        //Retrusn true if line is a valid property and sets key and value
        static private bool ProccessValues(string line, out string key, out string value)
        {
            string[] line_subs;

            //split line by =
            line_subs = line.Split('=');
            if (2 == line_subs.Length && 0 < line_subs[0].Length && 0 < line_subs[1].Length)
            {
                key = line_subs[0];
                value = line_subs[1];
                return true;
            }
            else
            {
                key = "";
                value = "";
                return false;
            }
        }


        static private string ReadNext(ref StreamReader reader)
        {
            string line = reader.ReadLine();
            RemoveComments(ref line);
            return line;
        }

        //Removes comments, denoted by "//" from the line
        static private void RemoveComments(ref string line)
        {
            int index_comment;

            //check if there is a comment in the line, if there is drop everything passed the comment
            if((index_comment = line.IndexOf("//")) > -1)
                line = line.Substring(0, index_comment);

            //trim off whitespace at begining on end
            line = line.Trim();
        }


    }
}

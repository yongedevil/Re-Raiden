using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    public interface iDataNode
    {
        void LoadData(DataNode node);
        //public void SaveData(ref DataNode node);
    }

    public class DataNode
    {
        private string m_name;
        public string name { get { return m_name; } }

        private Dictionary<string, string> m_variables;
        private List<DataNode> m_subNodes;

        //used in ToString()
        private static int indentLevel = 0;

        public DataNode(string name)
        {
            m_name = name;
            m_variables = new Dictionary<string, string>();
            m_subNodes = new List<DataNode>();
        }


        public void AddValue(string key, string val)
        {
            m_variables.Add(key, val);
        }

        public void AddNode(DataNode node)
        {
            m_subNodes.Add(node);
        }

        public bool HasValue(string key)
        {
            return m_variables.ContainsKey(key);
        }

        public string GetValue(string key)
        {
            string val;
            m_variables.TryGetValue(key, out val);

            return val;
        }

        public List<DataNode> GetNodes()
        {
            List<DataNode> subNodes = new List<DataNode>(m_subNodes);
            return subNodes;
        }

        public override string ToString()
        {
            string rtnString;

            rtnString = AddIndent() + name + "\n";
            rtnString += AddIndent() + "{\n";

            ++indentLevel;

            foreach (KeyValuePair<string, string> variable in m_variables)
            {
                rtnString += AddIndent() + variable.Key + " = " + variable.Value + "\n";
                Debug.Log("variable.Key " + variable.Key + " | variable.Value " + variable.Value);
            }

            foreach (DataNode node in m_subNodes)
            {
                rtnString += node.ToString();
            }

            --indentLevel;

            rtnString +=  AddIndent() + "}\n";

            return rtnString;
        }

        private string AddIndent()
        {
            string spaces = "";
            for (int i = 0; i < indentLevel; ++i)
            {
                spaces += "  ";
            }

            return spaces;
        }
    }
}

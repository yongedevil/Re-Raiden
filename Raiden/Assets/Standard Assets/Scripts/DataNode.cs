using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    public class DataNode
    {
        private string m_name;
        public string name { get { return m_name; } }

        private Dictionary<string, string> m_variables;
        private List<DataNode> m_subNodes;

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
    }
}

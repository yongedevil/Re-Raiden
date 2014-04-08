using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Raiden
{
    class Test : MonoBehaviour
    {
        public string path;

        public void Start()
        {
            List<DataNode> nodes = FileIO.LoadFile(path);

            foreach (DataNode node in nodes)
                Debug.Log(node.ToString());
        }
    }
}

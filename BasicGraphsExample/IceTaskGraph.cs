using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraphsExample
{
    public class IceTaskGraph
    {
        private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
        public void AddEdge(int u, int v)
        {
            if (!adjacencyList.ContainsKey(u))
                adjacencyList[u] = new List<int>();
            if (!adjacencyList.ContainsKey(v))
                adjacencyList[v] = new List<int>();

            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u); // Assuming the graph is undirected
        }

        public List<int> ShortestPathBFS(int source, int destination)
        {
            Dictionary<int, int> parent = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == destination)
                {
                    List<int> path = new List<int>();
                    int node = destination;
                    while (node != source)
                    {
                        path.Add(node);
                        node = parent[node];
                    }
                    path.Add(source);
                    path.Reverse();
                    return path;
                }

                foreach (int neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                        parent[neighbor] = current;
                    }
                }
            }

            return null;
        }

    }

}
/* private Dictionary<int, CNode<int>> nodeLookup = new Dictionary<int, CNode<int>>();

        public void addNode(int id, int data)
        {
            nodeLookup.Add(id, new CNode<int>(data, id));
        }
        public CNode<int> getNode(int id)
        {
            return nodeLookup[id];
        }

        public void addEdges(int source, int destination)
        {
            CNode<int> s = getNode(source);
            CNode<int> d = getNode(destination);

            s.children.AddFirst(d);
        }

        public List<int> ShortestPath(int source, int child)
        {
            return ShortestPath(getNode(source), getNode(child));
        }

        public List<int> ShortestPath(CNode<int> source, CNode<int> child)
        {
            Dictionary<int, int> parent = new Dictionary<int, int>();   
            Queue<CNode<int>> nexttovisit = new Queue<CNode<int>>();
            HashSet<int> visited = new HashSet<int>();

            nexttovisit.Enqueue(source);

            while (nexttovisit.Count > 0)
            {
                CNode<int> Node = nexttovisit.Dequeue();

                if (Node == child)
                {
                    List<int> path = new List<int>();
                    int node = child.id;
                    while (node != child.id)
                    {
                        path.Add(node);
                        node = parent[node];
                    }
                    path.Add(child.id);
                    path.Reverse();
                    return path;
                }

                if (visited.Contains(Node.id))
                {
                    continue;
                }

                visited.Add(Node.id);
                foreach (CNode<int> c in Node.children)
                {

                    if (!visited.Contains(c.id))
                    {
                        nexttovisit.Enqueue(c);
                        visited.Add(c.id);
                        parent[c.id] = Node.id;
                    }


                }
            }
            return null ;
        }
    */


namespace BasicGraphsExample
{
    internal class Program
    {
        static readonly string textFile = @"C:\Users\lab_services_student\OneDrive\2023 PROG\chat\BasicGraphsExample\graph.txt";
        static void Main(string[] args)
        {
            CGraph graph = new CGraph();
            IceTaskGraph iceGraph = new IceTaskGraph();
            using (StreamReader file = new StreamReader(textFile))
            {
                
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                    string[] parts = ln.Split(' ');
                    int u = int.Parse(parts[0]);
                    int v = int.Parse(parts[1]);
                    iceGraph.AddEdge(u, v);
                   
                }
                file.Close();
             
            }

            while (true)
            {
                Console.Write("\nEnter the source vertex: ");
                int source = int.Parse(Console.ReadLine());

                Console.Write("Enter the destination vertex: ");
                int destination = int.Parse(Console.ReadLine());

                List<int> shortestPath = iceGraph.ShortestPathBFS(source, destination);

                if (shortestPath != null)
                {
                    Console.WriteLine($"Shortest path from {source} to {destination}: {string.Join(" -> ", shortestPath)}");
                    Console.WriteLine($"Length of the path: {shortestPath.Count - 1}");
                }
                else
                {
                    Console.WriteLine("No path found between the source and destination vertices.");
                }
            }
           
        }
    }
}
/*graph.addNode(1, "Nicole");
            graph.addNode(2, "Luke");
            graph.addNode(3, "Stefan");

            for (int i = 4; i <= 24; i++)
            {
                graph.addNode(i, "Person " + i);
            }

            graph.addEdges(1, 2);
            graph.addEdges(2, 3);
            graph.addEdges(5, 11);
            graph.addEdges(1, 24);

            bool yes = graph.hasPathDFS(1, 24);
            if (yes)
            {
                Console.WriteLine("Nicole is related to Person 24 they can be cousins");
            } else
            {
                Console.WriteLine("NOOOOOOO :)");
            }

            bool BFSYes = graph.hasPathBFS(1, 24);

            if (BFSYes)
            {
                Console.WriteLine("BFS PATH FOUND between Nicole and Person 24");
            } else
            {
                Console.WriteLine("NOO");
            }

            bool DSF = graph.hasPathDFS(5, 11);

            if (DSF)
            {
                Console.WriteLine("DFS PATH FOUND between Person 5 and Person 11");
            }
            else
            {
                Console.WriteLine("NOO");
            }*/
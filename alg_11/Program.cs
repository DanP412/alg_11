using System;

namespace alg_11
{
    interface IGraph
    {
        bool AdEdge(int s, int e, int w);
        bool AddDirectedEdge(int s, int e, int w);
        bool RemoveEdge(int s, int e, int w);
        bool RemoveDirectedEdge(int s, int e);
    }
    class AdGraph
    {
        int[,] _matrix;

        public AdGraph(int n)
        {
            _matrix = new int[n,n];
        }

        public bool AddEdge(int start, int end, int weight = 1)
        {
            if ( start == _matrix[start, end]   )
            {
                return true;
            }

            _matrix[start, end] = weight;
            _matrix[end, start] = weight;
            return true;
        }

        public bool AddirecetedEdge(int start, int end, int weight = 1)
        {
            //dodać spoza zakresu
            _matrix[start, end] = weight;
            return true;

        }
        public bool RemoveEdge(int start, int end)
        {
            return AddEdge(start, end, 0);
        }
        public bool RemoveDirectedEdge(int start, int end)
        {
            return AddirecetedEdge(start, end, 0);
        }

        public override string ToString()
        {
            string r = "";
            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                for (int col = 0; col < _matrix.GetLength(1); col++)
                {
                    if (_matrix[row, col] !=0)
                    {
                        r += $"edge ({row}, {col})\n";
                    }
                }
            }
            return r;
        }
    }

    public class InGrapgh:IGraph
    {
        int[,] _matrix;
        int edge = 0;
         public InGrapgh(int vertex, int edges)
        {
            _matrix = new int[vertex, edges];
        }

        public bool AddDirectedEdge(int s, int e, int w)
        {
            if (edge >= _matrix.GetLength(1))
            {
                return false;
            }
            _matrix[s, edge] = 1;
            _matrix[e, edge] = -1;
            edge++;
            return true;
            // testowanie poprawności s i e, false dla niepoprawnych
        }

        public bool AdEdge(int s, int e, int w)
        {
            if (edge >= _matrix.GetLength(1))
            {
                return false;
            }
            _matrix[s, edge] = 1;
            _matrix[e, edge] = 1;
            edge++;
            return true;
        }

        public bool RemoveEdge(int s, int e, int w)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDirectedEdge(int s, int e)
        {
            for (int col = 0; col < _matrix.GetLength(1); col++)
            {
                if (_matrix[s, col] == 1 && _matrix[e,col] == -1)
                {
                    _matrix[s, col] = 0;
                    _matrix[e, col] = 0;
                    return true;

                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AdGraph graph = new AdGraph(5);
            graph.AddEdge(1, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(2, 4);
            Console.WriteLine(graph);
            //Utwóz graf z opsiem automatu uchylonych drzwi 
        }
    }
}

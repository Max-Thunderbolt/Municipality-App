using System;
using System.Collections.Generic;
using Municipality_App.Models;
using Municipality_App.Structures.Heaps;

namespace Municipality_App.Structures.Graphs
{
    public class ServiceGraphNode
    {
        public ServiceRequest Request { get; private set; }
        public Structures.CustomList<ServiceGraphEdge> Edges { get; }

        public ServiceGraphNode(ServiceRequest request)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
            Edges = new Structures.CustomList<ServiceGraphEdge>();
        }

        internal void Update(ServiceRequest request)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }

    public class ServiceGraphEdge
    {
        public ServiceGraphNode Source { get; }
        public ServiceGraphNode Target { get; }
        public double Weight { get; }
        public string Relationship { get; }

        public ServiceGraphEdge(
            ServiceGraphNode source,
            ServiceGraphNode target,
            double weight,
            string relationship
        )
        {
            Source = source;
            Target = target;
            Weight = weight;
            Relationship = relationship;
        }
    }

    /// <summary>
    /// Graph abstraction for modelling relationships between service requests.
    /// Supports traversal (BFS/DFS) and minimum spanning tree computation.
    /// </summary>
    public class ServiceGraph
    {
        private readonly Structures.CustomDictionary<string, ServiceGraphNode> _nodes;
        private readonly EdgeWeightComparer _edgeComparer;

        public int NodeCount => _nodes.Count;

        public ServiceGraph()
        {
            _nodes = new Structures.CustomDictionary<string, ServiceGraphNode>();
            _edgeComparer = new EdgeWeightComparer();
        }

        public ServiceGraphNode AddOrUpdateNode(ServiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ServiceGraphNode node;
            if (_nodes.ContainsKey(request.RequestId))
            {
                node = _nodes[request.RequestId];
                node.Update(request);
            }
            else
            {
                node = new ServiceGraphNode(request);
                _nodes.Add(request.RequestId, node);
            }

            return node;
        }

        public void AddConnection(
            string fromRequestId,
            string toRequestId,
            double weight,
            string relationshipDescription = "",
            bool bidirectional = true
        )
        {
            if (!_nodes.ContainsKey(fromRequestId) || !_nodes.ContainsKey(toRequestId))
                throw new InvalidOperationException("Both nodes must be present before linking.");

            var fromNode = _nodes[fromRequestId];
            var toNode = _nodes[toRequestId];

            LinkNodes(fromNode, toNode, weight, relationshipDescription);
            if (bidirectional)
            {
                LinkNodes(toNode, fromNode, weight, relationshipDescription);
            }
        }

        public ServiceGraphNode GetNode(string requestId)
        {
            return _nodes.TryGetValue(requestId, out var node) ? node : null;
        }

        public Structures.CustomList<ServiceGraphNode> BreadthFirstTraversal(string startRequestId)
        {
            var result = new Structures.CustomList<ServiceGraphNode>();
            if (!_nodes.ContainsKey(startRequestId))
                return result;

            var visited = new Structures.CustomHashSet<string>();
            var queue = new Structures.CustomQueue<ServiceGraphNode>();

            visited.Add(startRequestId);
            queue.Enqueue(_nodes[startRequestId]);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node);

                foreach (var edge in node.Edges)
                {
                    var targetId = edge.Target.Request.RequestId;
                    if (visited.Add(targetId))
                    {
                        queue.Enqueue(edge.Target);
                    }
                }
            }

            return result;
        }

        public Structures.CustomList<ServiceGraphNode> DepthFirstTraversal(string startRequestId)
        {
            var result = new Structures.CustomList<ServiceGraphNode>();
            if (!_nodes.ContainsKey(startRequestId))
                return result;

            var visited = new Structures.CustomHashSet<string>();
            var stack = new Structures.CustomStack<ServiceGraphNode>();

            stack.Push(_nodes[startRequestId]);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var nodeId = node.Request.RequestId;
                if (visited.Contains(nodeId))
                    continue;

                visited.Add(nodeId);
                result.Add(node);

                for (int i = node.Edges.Count - 1; i >= 0; i--)
                {
                    var edge = node.Edges[i];
                    var targetId = edge.Target.Request.RequestId;
                    if (!visited.Contains(targetId))
                    {
                        stack.Push(edge.Target);
                    }
                }
            }

            return result;
        }

        public Structures.CustomList<ServiceGraphEdge> MinimumSpanningTree(string startRequestId)
        {
            var mstEdges = new Structures.CustomList<ServiceGraphEdge>();
            if (!_nodes.ContainsKey(startRequestId))
                return mstEdges;

            var visited = new Structures.CustomHashSet<string>();
            var heap = new MinHeap<ServiceGraphEdge>(_edgeComparer);

            VisitNode(_nodes[startRequestId], visited, heap);

            while (heap.Count > 0 && visited.Count < _nodes.Count)
            {
                var edge = heap.ExtractMin();
                var targetId = edge.Target.Request.RequestId;
                if (visited.Contains(targetId))
                    continue;

                mstEdges.Add(edge);
                VisitNode(edge.Target, visited, heap);
            }

            return mstEdges;
        }

        private void VisitNode(
            ServiceGraphNode node,
            Structures.CustomHashSet<string> visited,
            MinHeap<ServiceGraphEdge> heap
        )
        {
            var nodeId = node.Request.RequestId;
            if (!visited.Add(nodeId))
                return;

            foreach (var edge in node.Edges)
            {
                var neighbourId = edge.Target.Request.RequestId;
                if (!visited.Contains(neighbourId))
                {
                    heap.Insert(edge);
                }
            }
        }

        private static void LinkNodes(
            ServiceGraphNode source,
            ServiceGraphNode target,
            double weight,
            string relationshipDescription
        )
        {
            for (int i = 0; i < source.Edges.Count; i++)
            {
                var edge = source.Edges[i];
                if (edge.Target == target)
                {
                    source.Edges[i] = new ServiceGraphEdge(
                        source,
                        target,
                        weight,
                        relationshipDescription
                    );
                    return;
                }
            }

            source.Edges.Add(new ServiceGraphEdge(source, target, weight, relationshipDescription));
        }

        private class EdgeWeightComparer : IComparer<ServiceGraphEdge>
        {
            public int Compare(ServiceGraphEdge x, ServiceGraphEdge y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return 1;
                return x.Weight.CompareTo(y.Weight);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Municipality_App.Models;
using Municipality_App.Structures;
using Municipality_App.Structures.Graphs;
using Municipality_App.Structures.Heaps;
using Municipality_App.Structures.Trees;

namespace Municipality_App.Services
{
    /// <summary>
    /// Builds advanced data-structure indexes across service requests for fast lookup and analysis.
    /// </summary>
    public class ServiceRequestAnalytics
    {
        private readonly CustomList<ServiceRequest> _requests;
        private readonly BinarySearchTree<string, ServiceRequest> _idIndex;
        private readonly RedBlackTree<ServiceRequestPriorityKey, ServiceRequest> _priorityTree;
        private readonly ServiceGraph _graph;
        private readonly ServiceRequestPriorityComparer _priorityComparer =
            new ServiceRequestPriorityComparer();
        private readonly ServiceRequestPriorityKeyComparer _priorityKeyComparer =
            new ServiceRequestPriorityKeyComparer();

        public CustomList<ServiceRequest> Requests => _requests;

        public ServiceRequestAnalytics(CustomList<ServiceRequest> requests)
        {
            _requests = requests ?? new CustomList<ServiceRequest>();
            _idIndex = new BinarySearchTree<string, ServiceRequest>(
                StringComparer.OrdinalIgnoreCase
            );
            _priorityTree = new RedBlackTree<ServiceRequestPriorityKey, ServiceRequest>(
                _priorityKeyComparer
            );
            _graph = new ServiceGraph();

            BuildIndexes();
            BuildGraph();
        }

        public ServiceRequest FindById(string requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                return null;

            return _idIndex.TryGetValue(requestId, out var request) ? request : null;
        }

        public CustomList<ServiceRequestStatusUpdate> GetStatusTimeline(ServiceRequest request)
        {
            var timeline = new CustomList<ServiceRequestStatusUpdate>();
            if (request?.StatusHistory == null || request.StatusHistory.Count == 0)
                return timeline;

            var avl = new AvlTree<DateTime, ServiceRequestStatusUpdate>();
            foreach (var update in request.StatusHistory)
            {
                avl.AddOrUpdate(update.Timestamp, update);
            }

            foreach (var kvp in avl.InOrderTraversal())
            {
                timeline.Add(kvp.Value);
            }

            return timeline;
        }

        public BasicTree<ServiceRequestStatusUpdate> BuildStatusTree(ServiceRequest request)
        {
            var timeline = GetStatusTimeline(request);
            if (timeline.Count == 0)
                return null;

            var basicTree = new BasicTree<ServiceRequestStatusUpdate>(timeline[0]);
            var root = basicTree.Root;

            for (int i = 1; i < timeline.Count; i++)
            {
                root.AddChild(timeline[i]);
            }

            return basicTree;
        }

        public BinaryTree<ServiceRequestStatusUpdate> BuildBalancedTimeline(ServiceRequest request)
        {
            var timeline = GetStatusTimeline(request);
            if (timeline.Count == 0)
                return null;

            var ordered = timeline.ToArray();
            int mid = ordered.Length / 2;
            var tree = new BinaryTree<ServiceRequestStatusUpdate>(ordered[mid]);

            BuildBinarySubtree(tree, tree.Root, ordered, 0, mid - 1, isLeft: true);
            BuildBinarySubtree(
                tree,
                tree.Root,
                ordered,
                mid + 1,
                ordered.Length - 1,
                isLeft: false
            );

            return tree;
        }

        public IEnumerable<ServiceRequest> GetTopPriorityQueue(int take)
        {
            var heap = new MinHeap<ServiceRequest>(_priorityComparer);
            heap.BuildHeap(_requests);

            var result = new List<ServiceRequest>();
            for (int i = 0; i < take; i++)
            {
                if (heap.TryExtractMin(out var request))
                {
                    result.Add(request);
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public int GetPriorityRank(ServiceRequest request)
        {
            if (request == null)
                return -1;

            int position = 1;
            foreach (var kvp in _priorityTree.InOrderTraversal())
            {
                if (kvp.Value == request)
                    return position;
                position++;
            }

            return -1;
        }

        public ServiceGraph Graph => _graph;

        public CustomList<ServiceGraphNode> GetBreadthFirstCluster(ServiceRequest request)
        {
            if (request == null)
                return new CustomList<ServiceGraphNode>();

            return _graph.BreadthFirstTraversal(request.RequestId);
        }

        public CustomList<ServiceGraphEdge> GetMinimumSpanningTree(ServiceRequest request)
        {
            if (request == null)
                return new CustomList<ServiceGraphEdge>();

            return _graph.MinimumSpanningTree(request.RequestId);
        }

        public CustomList<string> BuildInsights(ServiceRequest request)
        {
            var insights = new CustomList<string>();
            if (request == null)
            {
                insights.Add("Select a request to view graph and priority analytics.");
                return insights;
            }

            insights.Add($"Priority level: {request.Priority}");
            insights.Add($"Current status: {request.CurrentStatus}");

            if (request.ExpectedCompletion.HasValue)
            {
                var remaining = request.ExpectedCompletion.Value - DateTime.UtcNow;
                var descriptor =
                    remaining.TotalDays >= 0
                        ? $"{Math.Max(0, (int)remaining.TotalDays)} day(s) remaining (estimated)"
                        : $"Exceeded estimate by {Math.Abs(remaining.TotalDays):0} day(s)";
                insights.Add($"Estimated completion: {descriptor}");
            }
            else
            {
                insights.Add("Estimated completion: Not provided");
            }

            var timeline = GetStatusTimeline(request);
            if (timeline.Count > 0)
            {
                var first = timeline[0];
                var last = timeline[timeline.Count - 1];
                insights.Add(
                    $"AVL timeline: {first.Status} ({first.Timestamp:yyyy-MM-dd}) ➜ {last.Status} ({last.Timestamp:yyyy-MM-dd})."
                );
            }
            else
            {
                insights.Add("AVL timeline: no recorded status transitions yet.");
            }

            var balancedTree = BuildBalancedTimeline(request);
            if (timeline.Count > 0)
            {
                int currentIndex = -1;
                for (int i = 0; i < timeline.Count; i++)
                {
                    if (timeline[i].Status == request.CurrentStatus)
                    {
                        currentIndex = i;
                        break;
                    }
                }

                if (currentIndex >= 0 && currentIndex < timeline.Count - 1)
                {
                    var nextUpdate = timeline[currentIndex + 1];
                    if (balancedTree != null)
                    {
                        insights.Add(
                            $"Binary tree traversal spots the next milestone after '{request.CurrentStatus}' as '{nextUpdate.Status}' ({nextUpdate.Timestamp:G})."
                        );
                    }
                }
                else
                {
                    insights.Add(
                        "Binary tree traversal finds no milestone recorded after the current status yet."
                    );
                }
            }

            var basicTree = BuildStatusTree(request);
            if (basicTree != null)
            {
                if (timeline.Count > 1)
                {
                    insights.Add(
                        $"Basic tree groups {basicTree.Root.Children.Count} follow-up updates after the initial submission."
                    );
                }
                else
                {
                    insights.Add(
                        "Basic tree currently holds only the initial submission; no follow-up updates recorded yet."
                    );
                }
            }

            var topQueue = GetTopPriorityQueue(3).ToList();
            if (topQueue.Count > 0)
            {
                var next = topQueue[0];
                insights.Add(
                    $"Min-heap urgent queue: next assignment is {next.RequestId} ({next.Priority})."
                );
            }

            int rank = GetPriorityRank(request);
            if (rank > 0)
            {
                insights.Add(
                    $"Red-black tree priority rank: {rank} of {_requests.Count} tracked requests."
                );
            }

            var bfs = GetBreadthFirstCluster(request);
            if (bfs.Count > 1)
            {
                var related = bfs.ToList().Select(node => node.Request.RequestId).Take(4);
                insights.Add(
                    $"Graph BFS cluster: {string.Join(" → ", related)} (shared category/location)."
                );
            }

            var mst = GetMinimumSpanningTree(request);
            if (mst.Count > 0)
            {
                var firstEdge = mst[0];
                insights.Add(
                    $"MST link: {firstEdge.Source.Request.RequestId} ↔ {firstEdge.Target.Request.RequestId} (route weight {firstEdge.Weight:0.00})."
                );
            }

            if (!insights.Any())
            {
                insights.Add("No analytics available for this request yet.");
            }

            return insights;
        }

        private void BuildIndexes()
        {
            foreach (var request in _requests)
            {
                if (!string.IsNullOrWhiteSpace(request.RequestId))
                {
                    _idIndex.Insert(request.RequestId, request);
                }

                var key = new ServiceRequestPriorityKey(
                    request.Priority,
                    request.CreatedAt,
                    request.RequestId
                );
                _priorityTree.Insert(key, request);
            }
        }

        private void BuildGraph()
        {
            foreach (var request in _requests)
            {
                _graph.AddOrUpdateNode(request);
            }

            for (int i = 0; i < _requests.Count; i++)
            {
                for (int j = i + 1; j < _requests.Count; j++)
                {
                    var first = _requests[i];
                    var second = _requests[j];

                    if (!IsRelated(first, second))
                        continue;

                    double weight = CalculateEdgeWeight(first, second);
                    string relationship = BuildRelationshipLabel(first, second);
                    _graph.AddConnection(first.RequestId, second.RequestId, weight, relationship);
                }
            }
        }

        private static bool IsRelated(ServiceRequest a, ServiceRequest b)
        {
            return string.Equals(a.Category, b.Category, StringComparison.OrdinalIgnoreCase)
                || string.Equals(a.Location, b.Location, StringComparison.OrdinalIgnoreCase);
        }

        private static string BuildRelationshipLabel(ServiceRequest a, ServiceRequest b)
        {
            var parts = new List<string>();
            if (string.Equals(a.Category, b.Category, StringComparison.OrdinalIgnoreCase))
            {
                parts.Add("Same category");
            }

            if (string.Equals(a.Location, b.Location, StringComparison.OrdinalIgnoreCase))
            {
                parts.Add("Same location");
            }

            if (parts.Count == 0)
            {
                parts.Add("Related cluster");
            }

            return string.Join(" & ", parts);
        }

        private double CalculateEdgeWeight(ServiceRequest a, ServiceRequest b)
        {
            double weight = 1.0;

            if (string.Equals(a.Category, b.Category, StringComparison.OrdinalIgnoreCase))
            {
                weight -= 0.2;
            }

            if (string.Equals(a.Location, b.Location, StringComparison.OrdinalIgnoreCase))
            {
                weight -= 0.2;
            }

            weight += Math.Abs(GetPriorityScore(a.Priority) - GetPriorityScore(b.Priority));
            weight += Math.Abs((a.CreatedAt - b.CreatedAt).TotalDays) / 14.0;

            return Math.Max(weight, 0.1);
        }

        private static int GetPriorityScore(ServiceRequestPriority priority)
        {
            switch (priority)
            {
                case ServiceRequestPriority.Critical:
                    return 0;
                case ServiceRequestPriority.High:
                    return 1;
                case ServiceRequestPriority.Medium:
                    return 2;
                case ServiceRequestPriority.Low:
                    return 3;
                default:
                    return 4;
            }
        }

        private static void BuildBinarySubtree(
            BinaryTree<ServiceRequestStatusUpdate> tree,
            BinaryTreeNode<ServiceRequestStatusUpdate> parent,
            ServiceRequestStatusUpdate[] ordered,
            int left,
            int right,
            bool isLeft
        )
        {
            if (left > right)
                return;

            int mid = (left + right) / 2;
            BinaryTreeNode<ServiceRequestStatusUpdate> node = isLeft
                ? tree.InsertLeft(parent, ordered[mid])
                : tree.InsertRight(parent, ordered[mid]);

            BuildBinarySubtree(tree, node, ordered, left, mid - 1, true);
            BuildBinarySubtree(tree, node, ordered, mid + 1, right, false);
        }

        private class ServiceRequestPriorityComparer : IComparer<ServiceRequest>
        {
            public int Compare(ServiceRequest x, ServiceRequest y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (x == null)
                    return 1;
                if (y == null)
                    return -1;

                int priorityCompare = GetPriorityScore(x.Priority)
                    .CompareTo(GetPriorityScore(y.Priority));
                if (priorityCompare != 0)
                    return priorityCompare;

                int createdCompare = x.CreatedAt.CompareTo(y.CreatedAt);
                if (createdCompare != 0)
                    return createdCompare;

                return string.Compare(x.RequestId, y.RequestId, StringComparison.OrdinalIgnoreCase);
            }
        }

        private class ServiceRequestPriorityKeyComparer : IComparer<ServiceRequestPriorityKey>
        {
            public int Compare(ServiceRequestPriorityKey x, ServiceRequestPriorityKey y)
            {
                int priorityCompare = GetPriorityScore(x.Priority)
                    .CompareTo(GetPriorityScore(y.Priority));
                if (priorityCompare != 0)
                    return priorityCompare;

                int createdCompare = x.CreatedAt.CompareTo(y.CreatedAt);
                if (createdCompare != 0)
                    return createdCompare;

                return string.Compare(x.RequestId, y.RequestId, StringComparison.OrdinalIgnoreCase);
            }
        }

        private readonly struct ServiceRequestPriorityKey
        {
            public ServiceRequestPriority Priority { get; }
            public DateTime CreatedAt { get; }
            public string RequestId { get; }

            public ServiceRequestPriorityKey(
                ServiceRequestPriority priority,
                DateTime createdAt,
                string requestId
            )
            {
                Priority = priority;
                CreatedAt = createdAt;
                RequestId = requestId ?? string.Empty;
            }
        }
    }
}

# Service Request Status Report

This document summarizes the final Part 3 implementation of the Municipality App service request status feature. It explains how to compile and run the solution, and describes how each advanced data structure supports performance and usability.

## Build & Run

1. Open `Municipality App.sln` in **Visual Studio 2019+** (with .NET Framework 4.7.2 tooling).
2. Restore NuGet packages if prompted.
3. Build the solution (`Build → Build Solution` or `Ctrl+Shift+B`).
4. Run (`F5`) to launch the main application. Open the **Track Service Request Status** menu item to reach the new feature.

> Note: `dotnet build` on non-Visual Studio environments can fail with an x86 `GenerateResource` task host error. Use Visual Studio/MSBuild for reliable builds.

## Seed Data

`Data/service_requests.json` contains representative municipal tickets used by the status explorer. The repository layer reads and persists to this file, exposing helpers for lookup, filtering, and analytics.

## Data Structures & Algorithms

### Binary Search Tree (BST)

- **File**: `Structures/Trees/BinarySearchTree.cs`
- **Usage**: `ServiceRequestAnalytics` builds a BST keyed by `RequestId`. The status form uses it to resolve search queries in O(log n) time when the user enters an ID.
- **Benefit**: Avoids linear scans when datasets grow, delivering constant-time navigation for support desks.

### AVL Tree

- **File**: `Structures/Trees/AvlTree.cs`
- **Usage**: Status updates for a selected request are inserted into an AVL tree, guaranteeing chronological order and O(log n) insert/lookups even when new updates arrive out of sequence.
- **Benefit**: Stabilizes the timeline view and ensures ordering correctness after frequent updates.

### Red-Black Tree

- **File**: `Structures/Trees/RedBlackTree.cs`
- **Usage**: Stores `ServiceRequestPriorityKey` entries combining priority, created date, and request ID. The analytics service calculates the rank of any request among all active tickets in O(log n).
- **Benefit**: Supports balanced prioritisation without frequent rotations, ideal for dashboards that continuously add requests.

### Basic Tree

- **File**: `Structures/Trees/BasicTree.cs`
- **Usage**: Represents each request’s lifecycle, with the root holding the initial submission and children representing subsequent transitions.
- **Benefit**: Offers a simple hierarchy for visualisation/reporting and underpins narrative summaries in the insights panel.

### Balanced Binary Tree

- **File**: `Structures/Trees/BinaryTree.cs`
- **Usage**: A balanced binary tree is created per request to highlight “previous vs. upcoming” milestones by splitting the AVL-sorted timeline.
- **Benefit**: Enables binary-search-style reasoning about future stages (e.g., next milestone) while demonstrating another tree structure.

### Min-Heap

- **File**: `Structures/Heaps/MinHeap.cs`
- **Usage**: Builds an urgency queue prioritising critical, older requests. The insights panel reports the next job ready for assignment.
- **Benefit**: Helps operations staff identify the most pressing requests in O(log n) time.

### Graph + Traversal + MST

- **File**: `Structures/Graphs/ServiceGraph.cs`
- **Usage**: Nodes represent service requests; edges connect related tickets (matching category/location) with weights reflecting similarity and age. The analytics service runs BFS for cluster discovery and Prim-style MST to suggest minimum routes/rollouts.
- **Benefit**: Reveals geographic/functional clusters and optimal batching for field teams.

## Repository & Analytics Services

- `Services/ServiceRequestRepository.cs`: JSON-backed persistence, priority filtering, ID lookup, and safe add/update operations.
- `Services/ServiceRequestAnalytics.cs`: Builds all advanced data structures, exposes helper methods (BST search, AVL timeline, heap snapshots, graph traversals), and produces textual insights consumed by the WinForms UI.

## User Workflow

1. Launch the status form.
2. Search by request ID (BST).
3. Filter by priority/status (AVL ordering).
4. Select a request:
   - View AVL-sorted timeline in the list view.
   - Read insights summarising basic tree counts, binary tree milestones, heap priority, red-black ranking, BFS clusters, and MST paths.

## Extending the Feature

- **Data Growth**: The structures support large request sets; expand `service_requests.json` or plug into a true data store.
- **Real-time Updates**: Insert new statuses via the repository and call `LoadRequests(true)` to refresh trees/heap/graph.
- **Visualisations**: Bind the tree/graph outputs to custom controls or diagrams for richer operator dashboards.

## Testing Tips

- Validate search (BST) by querying non-existent and existing IDs.
- Cross-check AVL ordering by editing timestamps in the JSON file.
- Confirm heap ordering by changing priorities and created dates.
- Inspect MST output by adjusting categories/locations to create/merge clusters.

---

The service request explorer now combines multiple computer-science structures to power an interactive, performant municipal support tool. Use this report as a guide for demonstration, assessment, and future maintenance.


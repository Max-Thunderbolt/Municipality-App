# Municipality App

A comprehensive Windows Forms application designed to enhance civic engagement through advanced gamification, intelligent recommendations, and seamless municipal service integration. Citizens can report issues, participate in community events, earn points, unlock achievements, and engage with personalized content recommendations.

## Key Features

### Municipal Services

- **Issue Reporting**: Comprehensive issue submission with file attachments
- **Event Management**: Community event discovery and registration
- **Announcement System**: Municipal announcement delivery and tracking
- **Service Request Tracking**: Advanced status explorer with ID search, timeline analytics, graph traversal, and priority insights

### Advanced Gamification System

- **Points & Levels**: Dynamic point calculation with level progression
- **Achievement System**: 11 badges across multiple categories
- **Community Challenges**: Active challenges with participation tracking
- **Social Features**: Content sharing with points rewards
- **Progress Tracking**: Real-time engagement feedback

### Intelligent Recommendations

- **Smart Suggestions**: Personalized content based on user behavior and preferences
- **Advanced Algorithms**: Multi-factor scoring with rule-based ranking algorithms
- **Performance Optimization**: O(log n) complexity with caching
- **Analytics Integration**: Comprehensive user behavior tracking

### Clean Architecture

- **Clean Architecture**: Proper separation of concerns
- **Advanced Data Structures**: Priority queues, hash tables, stacks, dictionaries
- **Performance Optimization**: Caching, indexing, and efficient algorithms
- **Material Design**: Modern, responsive user interface

## Project Architecture

```
Municipality App/
├── Data/                           # Seed data sets
│   └── service_requests.json       # Sample service request catalogue
├── Docs/                           # Supporting documentation
│   └── ServiceStatusReport.md      # Detailed write-up for Task 3 feature
├── Forms/                          # UI Layer
│   ├── Main/                       # Main menu and navigation
│   ├── Issues/                     # Issue reporting workflow
│   ├── Engagement/                 # Local events and announcements
│   ├── Gamification/               # Progress, achievements, challenges
│   └── ServiceStatus/              # Service request status explorer (Task 3)
├── Models/                         # Data models
│   ├── ServiceRequest.cs           # Service request + history
│   ├── IssueReport.cs              # Issue reporting model
│   ├── UserProfile.cs              # Gamification state
│   ├── Event.cs / EventRegistration.cs
│   ├── Announcement.cs
│   └── UserSearch.cs
├── Services/                       # Business logic + orchestration
│   ├── ServiceRequestRepository.cs # JSON persistence for requests
│   ├── ServiceRequestAnalytics.cs  # Advanced data-structure analytics
│   ├── GamificationService.cs
│   ├── IssueRepository.cs
│   ├── EventService.cs
│   ├── AnnouncementService.cs
│   ├── RecommendationService.cs
│   ├── SearchService.cs
│   └── ThemeService.cs
├── Structures/                     # Custom collection implementations
│   ├── Custom*.cs                  # List, Dictionary, Queue, etc.
│   ├── Trees/                      # BasicTree, BST, AVL, Red-Black helpers
│   ├── Heaps/                      # MinHeap for urgency queue
│   └── Graphs/                     # ServiceGraph with traversal + MST
├── Properties/                     # Application configuration
├── Program.cs                      # Application entry point
└── Municipality App.csproj         # Project configuration
```

## Getting Started

### Prerequisites

- **Visual Studio 2019 or later** (recommended)
- **.NET Framework 4.7.2** or later
- **Windows 10/11** operating system
- **4GB RAM** minimum (8GB recommended for optimal performance)

### Installation

1. **Clone or download** the project to your local machine
2. **Open** `Municipality App.sln` in Visual Studio
3. **Restore NuGet packages** (Visual Studio will do this automatically)
4. **Build** the solution (Ctrl+Shift+B)

### Compilation

#### Using Visual Studio (Recommended)

1. Open `Municipality App.sln` in Visual Studio
2. Select **Build** → **Build Solution** (or press Ctrl+Shift+B)
3. The compiled executable will be in `bin\Debug\` or `bin\Release\`

#### Using Command Line

```bash
# Navigate to project directory
cd "Municipality App"

# Build using MSBuild (if available)
msbuild "Municipality App.sln" /p:Configuration=Release

# Or using dotnet CLI (may have resource generation issues)
dotnet build "Municipality App.sln" --configuration Release

> ⚠️ The .NET CLI on non-Visual Studio machines can fail with `GenerateResource` x86 host errors. Use Visual Studio/MSBuild on Windows for reliable builds.
```

### Running the Application

1. **From Visual Studio**: Press F5 or click the "Start" button
2. **From File Explorer**: Navigate to `bin\Debug\` and double-click `Municipality App.exe`
3. **From Command Line**:
   ```bash
   cd "bin\Debug"
   "Municipality App.exe"
   ```

## How to Use the Application

### Main Menu

The main interface provides access to all application features:

- **Report Issues**: Submit municipal problems and concerns
- **Events & Announcements**: Engage with community events and announcements
- **Track Request Status**: Analyse and monitor service requests with graphs, trees, and priority queues
- **View Activity → Your Progress**: Access detailed progress and achievements

### Reporting Issues

1. Click **"Report Issues"** from the main menu
2. Fill out the comprehensive issue form:
   - **Location**: Where the issue is located
   - **Category**: Type of issue (Sanitation, Roads, Utilities, Parks, Other)
   - **Description**: Detailed description of the problem (minimum 20 characters)
   - **Attachments**: Upload photos or documents (optional)
3. Watch the **real-time progress bar** fill as you complete each field
4. Click **"Submit"** to report the issue and earn points

**Points System:**

- Base submission: 10 points
- Location provided: +5 points
- Category selected: +5 points
- Detailed description (50+ chars): +10 points
- Attachments: +5 points each (max +20)
- **Total possible**: 50 points per submission

### Gamification System

#### Points and Levels

- **Points**: Earned through various activities and engagement
- **Levels**: Calculated as (Points ÷ 100) + 1
- **Current Badge**: Based on total points earned
- **Achievement Tracking**: Comprehensive achievement system

#### Badge System

**Point-Based Badges:**

- **First Steps** (10+ points)
- **Active Participant** (100+ points)
- **Engaged Citizen** (250+ points)
- **Community Leader** (500+ points)

**Issue-Based Badges:**

- **Issue Reporter** (1+ issues submitted)
- **Dedicated Reporter** (5+ issues submitted)
- **Community Champion** (10+ issues submitted)

**Event-Based Badges:**

- **Event Attendee** (1+ events attended)
- **Regular Attendee** (3+ events attended)

**Announcement-Based Badges:**

- **Informed Citizen** (5+ announcements read)
- **Well Informed** (10+ announcements read)

**Achievement System:**

- **Form Master** (10+ forms completed)
- **Form Expert** (25+ forms completed)
- **Social Butterfly** (5+ social shares)
- **Community Influencer** (20+ social shares)
- **Challenge Seeker** (3+ challenges participated)
- **Challenge Champion** (10+ challenges participated)
- **Point Collector** (1000+ points earned)
- **Point Master** (5000+ points earned)

#### Community Challenges

**Active Challenges:**

- **Weekly Engagement Champion**: Complete 5 different activities this week (50 points)
- **Community Helper**: Submit 3 issue reports this month (75 points)
- **Social Media Advocate**: Share 5 pieces of content this month (40 points)

### Service Request Status

1. Click **"Track Request Status"** from the main menu.
2. Use the **ID search** bar to jump directly to a specific request (`SR-1001`, etc.). The search is backed by a custom **binary search tree** for O(log n) lookups.
3. Filter by **status** or **priority** to rebuild the list using AVL ordering.
4. Select a request to view:
   - **AVL-sorted timeline** of status updates.
   - **Balanced binary tree** view highlighting past and upcoming milestones.
   - **Basic tree** grouping of lifecycle transitions.
   - **Min-heap** insights showing the next urgent jobs in the queue.
   - **Red-black tree** priority ranking across all requests.
   - **Graph traversal summaries** (BFS cluster and MST routing) revealing relationships between related tickets.
5. The insights list is regenerated on every selection, demonstrating the interplay between trees, heaps, and graph algorithms.

### Events & Announcements

1. Click **"Events & Announcements"** from the main menu
2. **Browse Events**: View upcoming community events with detailed information
3. **Register for Events**:
   - Click on an event to view details
   - Provide name and email for registration
   - Earn 25 points for successful registration
4. **Read Announcements**:
   - Browse municipal announcements
   - Click to read full announcement details
   - Earn 5 points for reading announcements
5. **Smart Recommendations**: Get personalized suggestions based on your interests

**Features:**

- **Search Functionality**: Find events and announcements by keywords
- **Category Filtering**: Filter by event/announcement categories
- **Location Filtering**: Filter by specific locations
- **Smart Recommendations**: Personalized suggestions based on user interests

### Progress Tracking

1. Click **"View Activity"** → **"Your Progress"** from the main menu
2. View comprehensive statistics:
   - **Total points and current level**
   - **Current badge and unlocked achievements**
   - **Recent activities with timestamps**
   - **Summary of submitted issues**
   - **Form completion statistics**
   - **Social sharing activity**
   - **Challenge participation**
3. Use the **"Refresh"** button to update data

## Custom Data Structures

This application implements custom data structures from scratch, replacing all built-in .NET collections. All custom structures are located in the `Structures/` folder and provide the same functionality as their .NET counterparts while demonstrating fundamental computer science principles.

### **CustomList<T>**

- **Purpose**: Dynamic array-based list implementation
- **Location**: `Structures/CustomList.cs`
- **Implementation**: Dynamic array with automatic resizing
- **Operations**: Add (O(1) amortized), Remove (O(n)), Contains (O(n)), IndexOf (O(n)), Insert (O(n))
- **Features**: Automatic capacity management, indexed access, enumeration support
- **Usage**: Used throughout the application for all list operations

### **CustomDictionary<TKey, TValue>**

- **Purpose**: Hash table implementation with chaining collision resolution
- **Location**: `Structures/CustomDictionary.cs`
- **Implementation**: Hash table with separate chaining for collision handling
- **Operations**: Add (O(1) average), Remove (O(1) average), ContainsKey (O(1) average), TryGetValue (O(1) average)
- **Features**:
  - Default capacity: 16, load factor: 0.75
  - Automatic resizing when load factor exceeded
  - Chaining for collision resolution
  - Keys and Values collections
- **Usage**: Event lookup, announcement lookup, search frequency tracking, analytics

### **CustomHashSet<T>**

- **Purpose**: Set implementation for unique element storage
- **Location**: `Structures/CustomHashSet.cs`
- **Implementation**: Uses CustomDictionary internally for O(1) operations
- **Operations**: Add (O(1) average), Remove (O(1) average), Contains (O(1) average)
- **Features**: Automatic uniqueness enforcement, efficient set operations
- **Usage**: User preferences, user interests, announcement categories, popular search terms

### **CustomStack<T>**

- **Purpose**: LIFO (Last In, First Out) stack implementation
- **Location**: `Structures/CustomStack.cs`
- **Implementation**: Array-based stack with automatic resizing
- **Operations**: Push (O(1) amortized), Pop (O(1)), Peek (O(1))
- **Features**: Array-based storage, automatic capacity management
- **Usage**: Event registration history tracking

### **CustomQueue<T>**

- **Purpose**: FIFO (First In, First Out) queue implementation
- **Location**: `Structures/CustomQueue.cs`
- **Implementation**: Circular array-based queue
- **Operations**: Enqueue (O(1) amortized), Dequeue (O(1)), Peek (O(1))
- **Features**: Circular array to optimize memory usage, automatic resizing
- **Usage**: Event notifications, announcement delivery queue

### **CustomSortedDictionary<TKey, TValue>**

- **Purpose**: Sorted dictionary maintaining keys in sorted order
- **Location**: `Structures/CustomSortedDictionary.cs`
- **Implementation**: AVL (Adelson-Velsky and Landis) self-balancing binary search tree
- **Operations**: Add (O(log n)), Remove (O(log n)), ContainsKey (O(log n)), TryGetValue (O(log n))
- **Features**:
  - Self-balancing AVL tree ensures O(log n) operations
  - Maintains keys in sorted order
  - In-order traversal for sorted iteration
  - Automatic tree rebalancing after insertions/deletions
- **Usage**: Event priority queue (sorted by date), search history (sorted by timestamp), announcement date sorting

### **CustomSortedSet<T>**

- **Purpose**: Sorted set maintaining elements in sorted order
- **Location**: `Structures/CustomSortedSet.cs`
- **Implementation**: AVL self-balancing binary search tree (reuses tree structure from SortedDictionary)
- **Operations**: Add (O(log n)), Remove (O(log n)), Contains (O(log n))
- **Features**:
  - Self-balancing AVL tree
  - Maintains elements in sorted order
  - Automatic uniqueness enforcement
- **Usage**: Priority queue for recommendation ranking

### **CustomConcurrentDictionary<TKey, TValue>**

- **Purpose**: Thread-safe dictionary for concurrent access
- **Location**: `Structures/CustomConcurrentDictionary.cs`
- **Implementation**: Thread-safe wrapper around CustomDictionary using lock statements
- **Operations**: AddOrUpdate (thread-safe), TryGetValue (thread-safe), ContainsKey (thread-safe)
- **Features**:
  - Fine-grained locking for thread safety
  - Snapshot-based enumeration to avoid issues during iteration
  - Thread-safe operations for multi-threaded scenarios
- **Usage**: Recommendation cache for thread-safe caching

## Advanced Data Structures & Algorithms

The application implements advanced data structures and algorithms for optimal performance using custom implementations:

### **Priority Queue (EventService)**

- **Purpose**: Events sorted by date and priority
- **Implementation**: `CustomSortedDictionary<DateTime, CustomList<Event>>`
- **Benefits**: O(log n) insertion, O(1) access to highest priority items
- **Usage**: Event scheduling and management

### **Hash Table (AnnouncementService)**

- **Purpose**: Fast announcement lookup by category
- **Implementation**: `CustomDictionary<string, CustomList<Announcement>>`
- **Benefits**: O(1) average case lookup time with chaining collision resolution
- **Usage**: Categorized announcement storage and retrieval

### **Stack (Event Registration History)**

- **Purpose**: LIFO (Last In, First Out) event registration tracking
- **Implementation**: `CustomStack<EventRegistration>`
- **Benefits**: O(1) push/pop operations
- **Usage**: Registration history and undo functionality

### **Sorted Dictionary (Search Analytics)**

- **Purpose**: Search patterns sorted by timestamp
- **Implementation**: `CustomSortedDictionary<DateTime, UserSearch>`
- **Benefits**: Chronological ordering with efficient range queries using AVL tree
- **Usage**: Search history and analytics

### **Set (User Interests)**

- **Purpose**: Unique user interest tracking
- **Implementation**: `CustomHashSet<string>`
- **Benefits**: O(1) add/remove operations, automatic uniqueness
- **Usage**: User preference management

### **Queue (Notifications)**

- **Purpose**: FIFO (First In, First Out) notification delivery
- **Implementation**: `CustomQueue<string>`
- **Benefits**: O(1) enqueue/dequeue operations with circular array
- **Usage**: Event and announcement notifications

### **Advanced Recommendation Algorithm**

- **Purpose**: Personalized content suggestions
- **Implementation**: Multi-factor scoring system with priority queues
- **Data Structures**: `CustomSortedSet<RankedRecommendation>`, `CustomConcurrentDictionary` for caching
- **Factors**: User interests, search history, activity level, recency
- **Benefits**: Improved user engagement and content discovery
- **Performance**: O(log n) complexity with intelligent caching
- **Algorithm Type**: Rule-based multi-factor scoring (not AI/ML)

## Data Structures in Service Request Status

The Task 3 Service Request Status feature brings together all of our custom data structures so the Windows Form can expose rich, efficient analytics. Each structure contributes a specific capability:

### **CustomList<T>**

- **Role in feature:** All repositories and analytics return `CustomList<T>` instances instead of .NET `List<T>`. The status form binds directly to these lists when populating the request grid, status history, and insight panel.
- **Efficiency impact:** `CustomList<T>` delivers O(1) amortised append. When the repository hydrates the sample dataset, the list grows without repeated reallocations, ensuring the UI can reload data quickly.
- **Example:** `ServiceRequestRepository.GetAll()` returns a `CustomList<ServiceRequest>` which the form iterates to render each row of the “Open and Historical Service Tickets” list.

### **CustomDictionary<TKey,TValue> / CustomHashSet<T>**

- **Role in feature:** The analytics layer uses dictionaries and hash sets when deduplicating categories, building adjacency lists, and tracking visited nodes during traversals.
- **Efficiency impact:** Chaining-based dictionaries provide O(1) expected lookup/insert, keeping graph construction and category filter population fast even for large datasets.
- **Example:** When users reload data, `PopulateCategoryFilter` walks the `CustomList` of requests, inserts category strings into a `CustomHashSet<string>`, and then repopulates the combo box without duplicates.

### **CustomQueue<T> / CustomStack<T>**

- **Role in feature:** `CustomQueue` appears inside BFS traversal, and `CustomStack` supports in-order tree enumerations without recursion.
- **Efficiency impact:** Both structures guarantee O(1) enqueue/dequeue/pop operations, ensuring graph traversal remains linear in the number of nodes/edges.
- **Example:** `ServiceGraph.BreadthFirstTraversal` enqueues neighbouring requests, such as the two Ward 7 waste tickets (`SR-1004`, `SR-1006`), and emits a relationship trail used in the insight “Graph BFS cluster: SR-1004 → SR-1006 (shared category/location).”

### **BasicTree<ServiceRequestStatusUpdate>**

- **Role in feature:** Represents each request’s lifecycle with the initial submission as root and every subsequent status as a child.
- **Efficiency impact:** The n-ary tree provides O(n) traversal with minimal overhead, allowing the insights panel to summarise follow-up counts without converting to other structures.
- **Example:** For `SR-1006`, the basic tree records “Submitted → Acknowledged → InProgress → QualityCheck,” yielding the message “Basic tree groups 3 follow-up updates after the initial submission.”

### **BinaryTree<ServiceRequestStatusUpdate>**

- **Role in feature:** `BuildBalancedTimeline` converts the AVL-sorted timeline into a height-balanced binary tree centred on the median update.
- **Efficiency impact:** With a balanced structure, locating neighbours (previous/next milestones) is O(log n). We leverage this alongside the raw timeline to present predictive insights.
- **Example:** When `SR-1006` is currently `InProgress`, the balanced tree highlights the next scheduled milestone, driving the message “Binary tree traversal spots the next milestone after 'InProgress' as 'QualityCheck' (2025-09-18 09:30).”

### **BinarySearchTree<string, ServiceRequest>**

- **Role in feature:** Stores each request keyed by `RequestId`, enabling logarithmic search when the user uses the “Find Request” button.
- **Efficiency impact:** Searching by ID avoids scanning the entire list every time, keeping user interactions responsive even with large datasets.
- **Example:** Typing `SR-1004` jumps straight to the Riverside waste ticket via `_idIndex.FindById`, selecting the row and revealing its insights.

### **AvlTree<DateTime, ServiceRequestStatusUpdate>**

- **Role in feature:** Maintains chronological status history per request. Insertions occur as analytics hydrates each `ServiceRequest`.
- **Efficiency impact:** AVL balancing guarantees O(log n) insert and lookup, so we can add new status updates (even out of order) without degrading performance.
- **Example:** The “Status Timeline (BST/AVL)” grid enumerates the AVL tree in-order, ensuring the `SR-1009` smart-light update history appears in the correct temporal order.

### **RedBlackTree<ServiceRequestPriorityKey, ServiceRequest>**

- **Role in feature:** Tracks prioritised ordering across all requests, allowing us to calculate each ticket’s rank.
- **Efficiency impact:** Red-black trees reduce rotation overhead compared to AVL, making them ideal for frequent insertions while retaining O(log n) rank queries.
- **Example:** The insight “Red-black tree priority rank: 2 of 9 tracked requests.” for `SR-1004` is derived from an in-order traversal of the red-black tree.

### **MinHeap<ServiceRequest>**

- **Role in feature:** Manages the urgency queue surfaced as “Min-heap urgent queue: next assignment is …”.
- **Efficiency impact:** Each heapify operation is O(log n); building the heap from the request list is O(n). This provides a quick way to surface the next critical job (e.g., `SR-1002` Critical water leak).
- **Example:** The heap compares priority, created date, and ID to ensure ties are deterministic, helping supervisors know which ticket needs immediate attention.

### **ServiceGraph**

- **Role in feature:** Models relationships between requests, connecting nodes that share category or location. Supplies BFS clusters and MST edges.
- **Efficiency impact:** Graph traversals are O(V+E). Our implementation uses adjacency lists with `CustomDictionary` and `CustomList`, minimising memory and traversal overhead.
- **Example:** For Ward 7 waste management, BFS reveals a chain `SR-1004 → SR-1006`, while the MST insight reports an edge weight combining priority difference and temporal distance—useful when planning combined site visits.

### **Supporting Helpers**

- **ServiceRequestAnalytics** orchestrates all the above structures. Its `BuildInsights` method converts raw data-structure outputs into the strings rendered in the UI.
- **ServiceRequestRepository** ensures the analytics layer always receives `CustomList<ServiceRequest>` instances, maintaining compatibility with the custom collections.

Together these data structures transform a static grid into an interactive, data-driven dashboard where each insight is backed by a purposeful algorithm with predictable performance characteristics.

## Data Storage

### User Profile Storage

- **Location**: `%LocalAppData%\MunicipalityApp\user_profile.json`
- **Format**: JSON with complete user data
- **Includes**: Points, submitted issues, unlocked badges, activity history, achievements, social shares, challenge participation
- **Migration**: Automatically converts from old text format

### Issue Storage

- **Repository**: In-memory storage during session
- **User Profile**: All submitted issues saved to user profile
- **Persistence**: Issues persist across application sessions

## Technical Details

### Dependencies

- **.NET Framework 4.7.2**
- **Newtonsoft.Json 13.0.3** (for JSON serialization)
- **MaterialSkin 0.2.1** (for modern UI components)
- **Windows Forms** (UI framework)

### Key Features

- **JSON Persistence**: User data stored in structured JSON format
- **Gamification Engine**: Comprehensive points and badge system
- **Progress Tracking**: Real-time progress indicators
- **File Attachments**: Support for images and documents
- **Clean Architecture**: Proper separation of concerns
- **Custom Data Structures**: Fully custom implementations of lists, dictionaries, hash sets, stacks, queues, sorted dictionaries, sorted sets, and concurrent dictionaries
- **Recommendation System**: Smart suggestions based on user behavior and preferences
- **Search Analytics**: Comprehensive search tracking and analysis
- **Event Management**: Full event lifecycle management with registration
- **Announcement System**: Categorized announcement delivery and tracking
- **Social Integration**: Social sharing capabilities with points rewards
- **Community Challenges**: Active challenges with participation tracking
- **Achievement System**: Comprehensive achievement tracking with categories

### Namespace Structure

```csharp
Municipality_App                    // Root namespace
├── Municipality_App.Models         // Data models
├── Municipality_App.Services       // Business logic
└── Municipality_App.Forms          // UI components
    ├── Municipality_App.Forms.Main
    ├── Municipality_App.Forms.Issues
    ├── Municipality_App.Forms.Engagement
    └── Municipality_App.Forms.Gamification
```

## Troubleshooting

### Build Issues

- **MSBuild Host Error**: Use Visual Studio instead of command line
- **Resource Generation**: Ensure all .resx files are properly linked
- **Missing References**: Restore NuGet packages
- **Designer Errors**: If form designer shows errors, rebuild the solution
- **Assembly Loading**: Ensure all referenced assemblies are in the correct location

### Runtime Issues

- **File Access**: Ensure write permissions to `%LocalAppData%`
- **JSON Parsing**: Delete `user_profile.json` to reset user data
- **Form Display**: Check that all form files are in correct directories
- **Memory Issues**: Close and reopen the application if memory usage is high
- **Threading Issues**: All UI operations are performed on the main thread

### Data Issues

- **Reset Progress**: Delete `%LocalAppData%\MunicipalityApp\user_profile.json`
- **Migration**: Old text files are automatically converted to JSON
- **Corruption**: JSON files are validated on load
- **Data Loss**: Regular backups are recommended for user profiles
- **Search Issues**: Clear search history if search functionality stops working

### Advanced Data Structure Issues

- **Priority Queue**: Events are automatically sorted by date
- **Hash Table**: Announcements are indexed by category for fast lookup
- **Stack Operations**: Event registration history uses LIFO (Last In, First Out)
- **Dictionary Performance**: Large datasets may require optimization
- **Memory Management**: Advanced data structures are automatically garbage collected

### Performance Issues

- **Slow Loading**: Large user profiles may take time to load
- **Search Performance**: Complex searches may be slow with large datasets
- **Memory Usage**: Monitor memory usage with large numbers of events/announcements
- **UI Responsiveness**: All operations run on the main thread (synchronous)

### Common Error Messages

- **"File not found"**: Check file paths and permissions
- **"Invalid JSON"**: Delete corrupted JSON files to reset
- **"Access denied"**: Run as administrator or check file permissions
- **"Out of memory"**: Close other applications or restart the system
- **"Form not found"**: Ensure all form files are properly compiled

### Debugging Tips

- **Enable Debug Mode**: Set configuration to Debug for detailed error messages
- **Check Event Logs**: Windows Event Viewer may contain additional error details
- **Verify Dependencies**: Ensure all required .NET Framework components are installed
- **Test Data**: Use sample data to test functionality before using real data
- **Backup Data**: Always backup user profiles before making changes

## Change Log

Part 1 - 2 changes:

1. Refined user engagement so that the chosen user engagement strategy is seamlessly integrated, positively influencing user participation.
2. Updated README so that it is excellent, providing all relevant information for compiling, running, and using the software.
3. Updated UI to ensure that the interface maintains a consistent color scheme and layout, enhancing user familiarity. Labels, buttons, and instructions are clear and easily understood. Feedback mechanisms are implemented effectively, keeping users informed. The interface is responsive, accommodating various screen sizes.
4. Implemented event handlers for button clicks and user interactions, ensuring flawless functionality. Appropriate data structures (e.g., CustomList) are used efficiently to manage and organise user-reported issues.

Part 2 - 3 changes:

1. Incorporated custom data structures throughout the solution, including:
   - `CustomList`, `CustomDictionary`, `CustomQueue`, `CustomStack`, `CustomSortedSet`, and `CustomSortedDictionary` for bespoke collection handling.
   - Tree suite (`BasicTree`, `BinaryTree`, `BinarySearchTree`, `AvlTree`, `RedBlackTree`) to model timelines, rankings, and lookups.
   - `MinHeap` for urgency queues and `ServiceGraph` for traversal + MST analytics.
2. Enhanced the Local Events & Announcements experience, aligning the engagement form with the new data structures and recommendation services to deliver personalised, high-performance content.
3. Strengthened the documentation and sample data footprint so that events, announcements, and engagement workflows can be demonstrated end-to-end during evaluation.

## License

This project is developed for educational purposes as part of the PROG7312 Portfolio of Evidence.

---

**Municipality App** - Enhancing Civic Engagement Through Technology

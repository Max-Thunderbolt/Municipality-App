# Municipality App

A comprehensive Windows Forms application designed to enhance civic engagement through advanced gamification, intelligent recommendations, and seamless municipal service integration. Citizens can report issues, participate in community events, earn points, unlock achievements, and engage with personalized content recommendations.

## Key Features

### Municipal Services

- **Issue Reporting**: Comprehensive issue submission with file attachments
- **Event Management**: Community event discovery and registration
- **Announcement System**: Municipal announcement delivery and tracking
- **Service Request Tracking**: Monitor submitted requests and their status (Part 3 - Not implemented)

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
├── Forms/                          # UI Layer
│   ├── Main/                       # Main menu and navigation
│   ├── Issues/                     # Issue reporting functionality
│   ├── Engagement/                 # Events and announcements
│   └── Gamification/              # Progress and achievements display
├── Models/                         # Data Models
│   ├── IssueReport.cs             # Issue data structure
│   ├── UserProfile.cs             # User progress and achievements
│   ├── Event.cs                    # Event data structure
│   ├── Announcement.cs             # Announcement data structure
│   └── UserSearch.cs               # Search analytics model
├── Services/                       # Business Logic
│   ├── GamificationService.cs     # Points, badges, and progress tracking
│   ├── IssueRepository.cs         # Issue data management
│   ├── EventService.cs            # Event management with priority queues
│   ├── AnnouncementService.cs     # Announcement delivery system
│   ├── RecommendationService.cs   # Rule-based recommendation engine
│   ├── SearchService.cs           # Search analytics and tracking
│   └── ThemeService.cs            # UI theming and responsive design
├── Properties/                     # Application configuration
├── Program.cs                      # Application entry point
└── Municipality App.csproj        # Project configuration
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
- **Track Request Status**: Monitor submitted service requests (Part 3 - Not implemented)
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

## Advanced Data Structures & Algorithms

The application implements advanced data structures and algorithms for optimal performance:

### **Priority Queue (EventService)**

- **Purpose**: Events sorted by date and priority
- **Implementation**: `SortedDictionary<DateTime, List<Event>>`
- **Benefits**: O(log n) insertion, O(1) access to highest priority items
- **Usage**: Event scheduling and management

### **Hash Table (AnnouncementService)**

- **Purpose**: Fast announcement lookup by category
- **Implementation**: `Dictionary<string, List<Announcement>>`
- **Benefits**: O(1) average case lookup time
- **Usage**: Categorized announcement storage and retrieval

### **Stack (Event Registration History)**

- **Purpose**: LIFO (Last In, First Out) event registration tracking
- **Implementation**: `Stack<EventRegistration>`
- **Benefits**: O(1) push/pop operations
- **Usage**: Registration history and undo functionality

### **Sorted Dictionary (Search Analytics)**

- **Purpose**: Search patterns sorted by timestamp
- **Implementation**: `SortedDictionary<DateTime, UserSearch>`
- **Benefits**: Chronological ordering with efficient range queries
- **Usage**: Search history and analytics

### **Set (User Interests)**

- **Purpose**: Unique user interest tracking
- **Implementation**: `HashSet<string>`
- **Benefits**: O(1) add/remove operations, automatic uniqueness
- **Usage**: User preference management

### **Queue (Notifications)**

- **Purpose**: FIFO (First In, First Out) notification delivery
- **Implementation**: `Queue<string>`
- **Benefits**: O(1) enqueue/dequeue operations
- **Usage**: Event and announcement notifications

### **Advanced Recommendation Algorithm**

- **Purpose**: Personalized content suggestions
- **Implementation**: Multi-factor scoring system with priority queues
- **Data Structures**: `SortedSet<RankedRecommendation>`, `ConcurrentDictionary` for caching
- **Factors**: User interests, search history, activity level, recency
- **Benefits**: Improved user engagement and content discovery
- **Performance**: O(log n) complexity with intelligent caching
- **Algorithm Type**: Rule-based multi-factor scoring (not AI/ML)

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
- **Advanced Data Structures**: Priority queues, hash tables, stacks, and dictionaries
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

### Network Issues

- **Offline Mode**: Application works completely offline
- **Data Synchronization**: No network connectivity required
- **File Sharing**: User profiles can be shared between installations

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

## License

This project is developed for educational purposes as part of the PROG7312 Portfolio of Evidence.

---

**Municipality App** - Enhancing Civic Engagement Through Technology

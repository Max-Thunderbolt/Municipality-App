# Municipality App

A Windows Forms application designed to enhance civic engagement through gamification. Citizens can report municipal issues, track their progress, earn points, and unlock achievements while contributing to their community.

## Project Architecture

The application follows proper .NET architecture patterns with clear separation of concerns:

```
Municipality App/
├── Forms/                          # UI Layer
│   ├── Main/                       # Main menu and navigation
│   ├── Issues/                     # Issue reporting functionality
│   ├── Engagement/                 # Events and announcements
│   └── Gamification/              # Progress and achievements display
├── Models/                         # Data Models
│   ├── IssueReport.cs             # Issue data structure
│   └── UserProfile.cs             # User progress and achievements
├── Services/                       # Business Logic
│   ├── GamificationService.cs     # Points, badges, and progress tracking
│   └── IssueRepository.cs         # Issue data management
├── Properties/                     # Application configuration
├── Program.cs                      # Application entry point
└── Municipality App.csproj        # Project configuration
```

## Getting Started

### Prerequisites

- **Visual Studio 2019 or later** (recommended)
- **.NET Framework 4.7.2** or later
- **Windows 10/11** operating system

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
- **Events & Announcements**: Engage with community events (coming soon)
- **View Activity → Your Progress**: Access detailed progress and achievements

### Reporting Issues

1. Click **"Report Issues"** from the main menu
2. Fill out the issue form:
   - **Location**: Where the issue is located
   - **Category**: Type of issue (Sanitation, Roads, Utilities, Parks, Other)
   - **Description**: Detailed description of the problem
   - **Attachments**: Upload photos or documents (optional)
3. Watch the progress bar fill as you complete each field
4. Click **"Submit"** to report the issue

**Points Awarded:**

- Base submission: 10 points
- Location provided: +5 points
- Category selected: +5 points
- Detailed description (50+ chars): +10 points
- Attachments: +5 points each (max +20)

### Gamification System

#### Points and Levels

- **Points**: Earned through various activities
- **Levels**: Calculated as (Points ÷ 100) + 1
- **Current Badge**: Based on total points earned

#### Badge System

The application features 11 different badges:

**Point-Based Badges:**

- 🥉 **First Steps** (10+ points)
- 🥈 **Active Participant** (100+ points)
- 🥇 **Engaged Citizen** (250+ points)
- 👑 **Community Leader** (500+ points)

**Issue-Based Badges:**

- 📝 **Issue Reporter** (1+ issues submitted)
- 📋 **Dedicated Reporter** (5+ issues submitted)
- 🏆 **Community Champion** (10+ issues submitted)

**Event-Based Badges:**

- 🎪 **Event Attendee** (1+ events attended)
- 🎭 **Regular Attendee** (3+ events attended)

**Announcement-Based Badges:**

- 📰 **Informed Citizen** (5+ announcements read)
- 📚 **Well Informed** (10+ announcements read)

#### Viewing Your Progress

1. Click **"View Activity"** → **"Your Progress"** from the main menu
2. View comprehensive statistics:
   - Total points and current level
   - Current badge and unlocked achievements
   - Recent activities with timestamps
   - Summary of submitted issues
3. Use the **"Refresh"** button to update data

### Events & Announcements

1. Click **"Events & Announcements"** from the main menu
2. Simulate community engagement:
   - **Mark attendance for a local event** (+25 points)
   - **Read a municipal announcement** (+5 points)

## Data Storage

### User Profile Storage

- **Location**: `%LocalAppData%\MunicipalityApp\user_profile.json`
- **Format**: JSON with complete user data
- **Includes**: Points, submitted issues, unlocked badges, activity history
- **Migration**: Automatically converts from old text format

### Issue Storage

- **Repository**: In-memory storage during session
- **User Profile**: All submitted issues saved to user profile
- **Persistence**: Issues persist across application sessions

## Technical Details

### Dependencies

- **.NET Framework 4.7.2**
- **Newtonsoft.Json 13.0.3** (for JSON serialization)
- **Windows Forms** (UI framework)

### Key Features

- **JSON Persistence**: User data stored in structured JSON format
- **Gamification Engine**: Comprehensive points and badge system
- **Progress Tracking**: Real-time progress indicators
- **File Attachments**: Support for images and documents
- **Clean Architecture**: Proper separation of concerns

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

### Runtime Issues

- **File Access**: Ensure write permissions to `%LocalAppData%`
- **JSON Parsing**: Delete `user_profile.json` to reset user data
- **Form Display**: Check that all form files are in correct directories

### Data Issues

- **Reset Progress**: Delete `%LocalAppData%\MunicipalityApp\user_profile.json`
- **Migration**: Old text files are automatically converted to JSON
- **Corruption**: JSON files are validated on load

## Future Enhancements

- **Real Event Integration**: Connect to municipal event systems
- **Real Announcement Integreation**: Connect to municipal announcement systems
- **Issue Status Tracking**: Track resolution of reported issues

## License

This project is developed for educational purposes as part of the PROG7312 Portfolio of Evidence.

## Contributing

This is an academic project. For questions or suggestions, please contact the development team.

---

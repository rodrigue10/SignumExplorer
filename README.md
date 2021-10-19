# SignumExplorer
This project was started as a way for me to learn ASP/.NET Blazor and .NET EF Core.  Expect there to be lots of room for improvement in this project.

The goals of this project are as follows
  - Cross-platform Explorer for the Signum Blockchain built using .NET Core technologies.
  - Allows easy navigation of blockchain entities along with linked entities
  - Provide localization options across the site.

Ultimately this has been a vehicle to help me learn and solidify my development skills.


# Environment Setup and Release Config/Installation

## Pre-Requisites
  - The explorer needs a Signum Node that uses a MariaDB backend (NO H2 file DB support)
  - Addition of Indexes and Views to the DB (Currently managed by the application and these should be added upon startup so long as your connection strings are setup correctly.)
  - Access to your MariaDB Signum DB as needed based on how your deploying the application.  (Firewall, and DB GRANT permissions setup.)
  - For Windows,  IIS is the preferred way to deploy, however the application can be run on it's own as long as you are able to configure your webserver/proxy redirect to point to the appropriate port.
  - For Linux, I have not been able to try this yet.  Will know more once i try to deploy there.
  - This is meant to run as a Blazor SERVER application.  Because of this it uses a "Signal-R" connection, which is essentially an abstraction over WebSockets.  Make sure you're setup for this when trying to access the site from outside your local network via any reverse proxy/web server you have setup.

### MariaDB Views and Indexes
This should be automated now.  Scripts included for reference purposes.
~~Your DB will need some additional Views and Indexes added.  This is a manual process at this 
time so using your DB access tool of choice you will find a series of `.sql` scripts for Views and Indexes located here:
 [DB Scripts](https://github.com/rodrigue10/SignumExplorer/tree/master/SignumExplorer/DB%20scripts) .  These scripts will add necessary views to allow the explorer to function properly.~~
 
 ### Configuration.
 There are a couple files that will help configure the connection strings that are needed to connect to your MariaDB.
 `appsettings.json` and `appsettings.production.json` . 
 
 The main areas of concern in these files are as follows and stick the the format in the files to replace the information needed to match your environment.:
  - `SRSConnection` - Signum Node Connection String
  -  `ExplorerConnection` - Explorer DB Connection String (You won't have a DB setup for this.  The app will create it for you as long as the connection string is setup
  -  `MariaDBSettings` - Define the MariaDB version that you are using (Recommend using version 10.6 as this is what i've built it with, however >10.3 is likely to work without any issues).  
 
 ```json
   "ConnectionStrings": {
    "SQLiteConnection": "Data Source=SignumExplorerDB.db",
    "SRSConnection": "server=srs-node-pool;user=signum;password=signumpassword;database=signum",
    "ExplorerConnection": "server=srs-node-pool;user=signum;password=signumpassword;database=explorer"
  },
  "MariaDBSettings": {
    "Version": "10.6.4-mariadb"
  },
  "AllowedHosts": "*",
  "Urls": "http://localhost:4100;http://localhost:4101",
 ```
  
## Development

The project is in active development so bugs/issues are to be expected.  I'm open to others playing with and helping increase/update the functionality.  If you feel like donating to help my developer journey please do so at this Signum Address: 
#### S-TGS2-BU2Q-DBFR-DNATE

### Pre-Requisites for development
  - Current development is being done with Pre-Release versions of .NET Core, EF Core, and [Pomelo.EnittyFramework](https://github.com/PomeloFoundation). 
  - The most recent Visual Studio 2022 is recommended and may be required to help with ease of development.
  - (DO NOT TRY TO GO BEYOND .NET `6.0.0-rc1*`).  The Pomelo.EntityFramework packages are not able to support recent .NET RC2 release.
  




# SignumExplorer
This project was started as a way for me to learn ASP/.NET so expect there to be lots of room for improvement along the way.

The goals of this project are as follows
  - Cross-platform Explorer for the Signum Blockchain built using .NET Core technologies.
  - Allows easy navigation of blockchain entities along with linked entities
  - Provide localization options across the site.
  


## Production and development

The project is in active development so bugs/issues are to be expected.

### Pre-Requisites
  - Current development is being done with Pre-Release .NET core packages.  As such the most recent Visual Studio 2022 is recommended, but shouldn't be required
  - The explorer needs a Signum Node that uses a MariaDB backend (NO H2 file DB support)
  

## Environment Setup

### MariaDB Views and Indexes
The DB will need some additional Views and Indexes added.  This is a manual process at this 
time so using your DB access tool of choice you will find a series of `.sql` scripts located here:
 [DB Scripts](https://github.com/rodrigue10/SignumExplorer/tree/master/SignumExplorer/DB%20scripts)
  




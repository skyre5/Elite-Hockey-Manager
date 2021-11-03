# Elite-Hockey-Manager
A hockey management simulator built in c#. Simulates all facets of an entire league ranging from 6 to 32 teams through multiple years. Each year features a new regular season, playoffs, draft, and free agency. Custom or randomly created players make up the league and progress in their skill ratings through the years based on skill level and age.

![Game Image](Elite%20Hockey%20Manager/Elite%20Hockey%20Manager/Screenshots/gameScreenshot.png)
## Features
- Create a league from 6 to 32 teams, either randomly generated or user created
- Each player has unique ratings and a hidden skill level to determine how their ratings change as they age
- Game system that factors in player ratings vs opponents player ratings
- Fully functional playoff, offseason, draft systems
- **Import teams and players from any season in NHL history using the NHL public api**
- Cumulative stat tracking of teams and players across the entire length of the league

## To do
- Loading from a saved state
- Redo user created player system
- Allow roster sharing, possibly host online in database
- Add trading logic and salary cap logic



## Requirements
Visual Studio or any Development enviroment with 

	- .NET Framework 4.5 or higher
	- C# 7.0 or higher


## Instructions
1. Download or clone project
2. Open project in Visual Studio
3. Right click on Elite Hockey Manager project name and select Manage NuGet Packages
4. Download missing packages (Newtonsoft.Json and NUnit packages)
5. You are good to go!


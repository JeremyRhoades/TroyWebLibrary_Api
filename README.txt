****************************
**  Troy Web Consulting ****
**  Technical Assessment ***
****************************

Developer: Jeremy Rhoades
Date: 3/1/2025



**********************
** Complete Features**
** (as of 3/2/3025) **
**********************

- API
	- Basic CRUD functions for Books, Reviews, and Users
	- Swagger Page
	- Models, Controllers
	- Fake data populated via Bogus

- Angular/Bootstrap
	- Simple MVP design
	- Navbar MVP
	- Various MVP pages with basic functionality
		- Connects to API:
			- Sign Up
			- View Books
			- Manage Books
			- User List (used for debugging)
	- Compartmentalized components in Angular

- Reviews
	- Missing Page/details for reviews
	- Database model is complete



**********************
** Missing Features **
** (as of 3/2/3025) **
**********************
- Logins
	- Page blocking via assigned roles
	- ASP.NET Identity for User/Role management

- Website Functionality
	- Search/Add/Delete/Checkout books
	- General form validation
	- Additional UI improvements

- Reviews
	- Missing Page/details for reviews
	- Database model is complete

- Backend
	- SQL Server Code First Database

- General code organization



*********************
** Technology used **
**    (Overview)   **
*********************

** Front-end **
- ran locally via http://localhost:4200/
- Angular 19
- Visual Studio Code 1.96.4
- Bootstrap 5.3.3

** Back-end **
- ran locally via https://localhost:7282/
- C#.NET
- .NET Framework 8.0
- Visual Studio 2022

** Nuget packages **
    <PackageReference Include="Bogus" Version="35.6.2" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.13" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />

** Database **
- EntityFrameworkCore.InMemory 9.0.2 (Code first DB implementation still in progress)








*********************
** Anguler 19.2.0  **
**    (Detailed)   **
*********************

Angular CLI: 19.2.0
Node: 22.14.0
Package Manager: npm 11.1.0
OS: win32 x64

Angular: 19.2.0
... cli, common, compiler, compiler-cli, core, forms     
... platform-browser, platform-browser-dynamic, router   

Package                         Version
---------------------------------------------------------
@angular-devkit/architect       0.1902.0
@angular-devkit/build-angular   19.2.0
@angular-devkit/core            19.2.0
@angular-devkit/schematics      19.2.0
@schematics/angular             19.2.0
rxjs                            7.8.2
typescript                      5.7.3
zone.js                         0.15.0


****************************
**** Visual Studio Code ****
****     (Detailed)     ****
****************************

Version: 1.96.4 (user setup)
Commit: cd4ee3b1c348a13bafd8f9ad8060705f6d4b9cba
Date: 2025-01-16T00:16:19.038Z
Electron: 32.2.6
ElectronBuildId: 10629634
Chromium: 128.0.6613.186
Node.js: 20.18.1
V8: 12.8.374.38-electron.0
OS: Windows_NT x64 10.0.19045


****************************
**** Visual Studio 2022 ****
****     (Detailed)     ****
****************************
.NET Framework Version 8.0
Bootstrap  v5.3.3
SQL Server
SQL Server Management Studio
VS Code
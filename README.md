# PizzeriaApp
- There are three APIs in this application and the main Api is Pizzerias (CWRETAIL.Api.Pizzerias) the other two are supporting Microservices. 
- The client application is CWRETAIL.WebApp
- Open the solution on Visual studio 2022. 
- Build the solution
- Initially build the client
	1) Navigate to the CWRETAIL.WebApp folder.

		There should be a package.json file in this folder. This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 13.3.10.
		
	2) In a command window (or the Command prompt in VS Code), type `npm install`.

		This creates a node_modules folder and installs all packages from the package.json file into that folder. You may see a few warnings during this process, but you should not see any errors.
		
   
- Please make sure, multiple startup projects are set for all Apis and CWRETAIL.WebApp

- Please make sure the correct endpoints are configured on the Pizzerias appsettings.
- The default endpoints are:
  - Menus: https://localhost:7189
  - Orders: https://localhost:7027
  - Pizzerias: https://localhost:7099
  - WebApp: http://localhost:4200

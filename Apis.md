# ASP.NET Core 6 APIs
1. Data Services
2. Http Action Methods
	- These methods will be executed when the HTTP Call to made to it
		- Http GET, POST, PUT, and DELETE
		- GET: Retrieve data from Server
		- POST: CReate a new Enrty by posting / passing data to server
		- PUT: Updating existing record on the server
		- DELETE: Deleting eisting record from the server
	- Each action method returns JSON Data by default
3. Microsoft.AspNetCore.App
	- ASP.NET Core Eco-System
		- HTTP Pipeline for Request Processing
			- Host Application inside Hosting Environment
				- IIS
				- Kestral (Default)
				- Apache / Nginx
				- Docker
			- A Container to Register all Dependencies with their Instances and Lifetime
			- Load all Objects those are used during Processing request
				- Exceptions
				- HTTP
				- Encryption
				- ROuting
				- File Providers Access
				- Mapping Request to Resource
					- Razor Page
					- MVC COnrtoller
					- API Controller
		- Support for Identity
		- RAzor Views
		- MVC, with Controllers
		- API, with ApiController
		- Filters
		- Middlewares

4. ASP.NET Core 6 Object Model
	- WebApplication
		- The class that is acting as a bridge netween ASP.NET Core and Hosting Env.
		- CreateBuilder()
			- USed to Create a Builder Object which is a collection of necessary (or default) objects used to run ASP.NET COre App on the Host  
			- The 'Services' property
				- Of the Type 'IServiceCollection'
				- Povides a 'Dependency Container' to register instances of all necessary objects required by the current application
						- Database
						- Security
						- Session
						- Caching
						- Custom Objets (Logic Objects) Required by the Application
						- External Service Objects e.g. BAckground Service
						- ... and many more
			- The 'Build()' method
				- Of the Type WebApplicationBuilder
					- Register 'Middlewares' into the HTTP Request Pipeline
					- They are the objects those are added into pipeline to provde addtional fetures to HTTP Request Processing
						- Handle Exceptions when any of the API is crashed
					- Middlewares are replacement for HttpHandler and HttpModule
	- appsettings.json
		- APplication level Configuration file
		- USed to define consfigurations as follows
			- Connection Strings
			- Logging Level
			- Host COnfguration
			- Token
			- Custom COnfiguration that is required for the whole application
		- IConfiguration Interface
			- USed to REad the appsettings.json file loaded on application Server, using 'WebApplicationBuilder.Configuration' property
			- WebApplicationBuilder.Configuration, is of the type 'ConfigurationManager'
5. Parameter Binders aka Model Binders
	- Attributes applied to Action Method Parameter of API Controller to Map Values received from HTTP Request to CLR Object
		- FromBody: Data will be POsted in HTTP Request MEssage Body
		- FromQuery: The Data will be poasted i QUeryString(?)
			- QueryString is a portion of URL after Question MArk
				- e.g.
					- https://MyServer/MyAPI/MyController?Name1=Value1&Name2=Vaue2.....
		- FromRoute: Posted Data in URL as Route Values
			- e.g.
				- https://MyServer/MyAPI/MyController/Val1/Va2/Val3.....
			
		- FromForm
			- USes the HTML FOrm Tag to Post data to Server as FormModel aka FormField
		- FromHeader
			- Data is Posted from Http Header
- Validations
	- Data Annatations
		- APply attributes on Propertie of Entity CLass to set its behavior e.g. Required
		- System.ComponentMOdel.DataAnntations
	- Domain Specific Validations
		- A Custom Data Annotation Validator
	- Explicit Logic to Validate a Property of Entity / Model class
		- e.g.
			- Check if the Email is already registered 
			- The Price of Product is MOre than the BasePrice for the cataegory under which the Product will be registered
				- THis may be either INvlid Value OR you may throw an exception
	- The 'ValidationAttribute' is a Base class for All Standard Validattors under  System.ComponentMOdel.DataAnntations
		- THis is an Abstratc class that contains 'IsValid()' metho that returns false if the data in invalid
		
- Rules for CReating custom middleware
	- We must create a class which is injected using 'RequestDelegate' delegate
		- This delegate accepts an input parameter as 'HttpContext'
		- THis becomes a part of teh Request Processing throguh the HttpContext
	- THis class MUST have a method named 'InvokeAsync(HttpContext)' that accepts the HttpContext as Input parameter and this method contains logic for the middleware
		- THis method returns a Task Object for Async Execution 
	- There MUST present a class that register the class with Requestelegate injected as a Custom Middleware for the Application
		- This class will contains an extension method for IApplicationBuilder interface
			- THis interface provide UseMiddleware<T>() methdo to register the Class as Custome middlwere
				- T is the class that is injected with RequestDelegate
			


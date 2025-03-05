# exam_app_net_angular
This test exam application was created by .NET Core Web API and Angular. 

Migration command:
  -  When you run the migration command, you must set ExamCore.Database class library as the Startup Project. 

Example command:
  -  dotnet ef migrations add InitDatabase --project ExamCore.Database -s ExamCore.Api -c DatabaseContext --verbose
  -  dotnet ef database update InitDatabase --project ExamCore.Database -s ExamCore.Api -c DatabaseContext --verbose
  -  dotnet ef migrations remove --project ExamCore.Database -s ExamCore.Api -c DatabaseContext --verbose

Task description:
You create an API like City or Employee. Whatever you choose, must need to add a relation in Country. When your API is complete then you create an Angular component like Create, Update, and List. Must set routing, from validation. 

Backend step:
  -  Create a domain model on the domain class library.
  -  Add domain model on the database class library.
  -  Create IRepository interface, and Repository class for this domain model on the repository class library.
  -  Create IManager interface, and Manager class for this domain model on the manager class library.
  -  Create application login using CQRS and Mediator pattern for this domain model application logic class library.
  -  Create API controller and call IManager class library.

Frontend step:
  -  Create models.
  -  Create service.
  -  Create Create, Update, List component.
  -  Add routing.

I already do similar tasks like Country. You just follow the Country for Backend and Frontend. 

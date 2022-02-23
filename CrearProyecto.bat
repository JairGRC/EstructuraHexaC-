 
 dotnet new sln --name EP_Simulador			 
 
 dotnet new classlib -lang C# -o EP_SimuladorMicroservice.Infraestructure  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj -s "01. Layer Infraestructure"
 
 dotnet new classlib -lang C# -o EP_SimuladorMicroservice.Repository  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Repository\EP_SimuladorMicroservice.Repository.csproj -s "01. Layer Infraestructure"
 
 dotnet new classlib -lang C# -o EP_SimuladorMicroservice.Domain  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj -s "02. Layer Domain"
 
 dotnet new classlib -lang C# -o EP_SimuladorMicroservice.Entities  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Entities\EP_SimuladorMicroservice.Entities.csproj -s "02. Layer Domain"	
 
 mkdir "EP_SimuladorMicroservice.Entities/Enums"
 mkdir "EP_SimuladorMicroservice.Entities/Filter"
 mkdir "EP_SimuladorMicroservice.Entities/Model"
 mkdir "EP_SimuladorMicroservice.Entities/Request"
 mkdir "EP_SimuladorMicroservice.Entities/Response"
 
 dotnet new classlib -lang C# -o EP_SimuladorMicroservice.Exceptions  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Exceptions\EP_SimuladorMicroservice.Exceptions.csproj -s "02. Layer Domain"
  
 dotnet new classlib -lang C# -o EP_SimuladorMicroservice.Service  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Service\EP_SimuladorMicroservice.Service.csproj -s "03. Layer Api"	
 
 dotnet new classlib -lang C# -o Util  -f net5.0
 dotnet sln .\EP_Simulador.sln add .\Util\Util.csproj -s "04. Util"
 
 dotnet new webapi --name EP_SimuladorMicroservice.Api
 dotnet sln .\EP_Simulador.sln add .\EP_SimuladorMicroservice.Api	-s "03. Layer Api"
 


 dotnet add .\Util\Util.csproj package System.Composition -v 1.4.0
 dotnet add .\Util\Util.csproj package Microsoft.Extensions.Configuration -v 3.1.3

 dotnet add .\EP_SimuladorMicroservice.Repository\EP_SimuladorMicroservice.Repository.csproj reference .\EP_SimuladorMicroservice.Entities\EP_SimuladorMicroservice.Entities.csproj


 dotnet add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj package Dapper -v 2.0.35
 dotnet add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj package System.Composition -v 1.4.0
 dotnet add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj package Microsoft.Extensions.Configuration -v 3.1.3
  
 dotnet add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj reference .\EP_SimuladorMicroservice.Entities\EP_SimuladorMicroservice.Entities.csproj
 dotnet add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj reference .\EP_SimuladorMicroservice.Repository\EP_SimuladorMicroservice.Repository.csproj
 dotnet add .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj reference .\Util\Util.csproj
 
 
 dotnet add .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj package System.Composition -v 1.4.0

 dotnet add .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj reference .\EP_SimuladorMicroservice.Entities\EP_SimuladorMicroservice.Entities.csproj
 dotnet add .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj reference .\EP_SimuladorMicroservice.Exceptions\EP_SimuladorMicroservice.Exceptions.csproj
 dotnet add .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj reference .\EP_SimuladorMicroservice.Repository\EP_SimuladorMicroservice.Repository.csproj
 dotnet add .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj reference .\Util\Util.csproj
 
 
 dotnet add .\EP_SimuladorMicroservice.Service\EP_SimuladorMicroservice.Service.csproj reference .\EP_SimuladorMicroservice.Domain\EP_SimuladorMicroservice.Domain.csproj
 dotnet add .\EP_SimuladorMicroservice.Service\EP_SimuladorMicroservice.Service.csproj reference .\EP_SimuladorMicroservice.Entities\EP_SimuladorMicroservice.Entities.csproj
 dotnet add .\EP_SimuladorMicroservice.Service\EP_SimuladorMicroservice.Service.csproj reference .\EP_SimuladorMicroservice.Exceptions\EP_SimuladorMicroservice.Exceptions.csproj
 

 dotnet add .\EP_SimuladorMicroservice.Api\EP_SimuladorMicroservice.Api.csproj reference .\EP_SimuladorMicroservice.Entities\EP_SimuladorMicroservice.Entities.csproj
 dotnet add .\EP_SimuladorMicroservice.Api\EP_SimuladorMicroservice.Api.csproj reference .\EP_SimuladorMicroservice.Infraestructure\EP_SimuladorMicroservice.Infraestructure.csproj	
 dotnet add .\EP_SimuladorMicroservice.Api\EP_SimuladorMicroservice.Api.csproj reference .\EP_SimuladorMicroservice.Service\EP_SimuladorMicroservice.Service.csproj	
 dotnet add .\EP_SimuladorMicroservice.Api\EP_SimuladorMicroservice.Api.csproj reference .\Util\Util.csproj	
 
 
 dotnet add .\EP_SimuladorMicroservice.Api\EP_SimuladorMicroservice.Api.csproj package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 3.1.2
 dotnet add .\EP_SimuladorMicroservice.Api\EP_SimuladorMicroservice.Api.csproj package Swashbuckle.AspNetCore -v 5.4.1
 
 
 
 
 
 
 
 
 
 

 
 
 
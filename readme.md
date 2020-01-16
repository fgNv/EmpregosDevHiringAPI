# Empregos Dev Hiring API

Para executar esse projeto, o dotnet versão 2.1.5 ou superior deve estar instalado, e o dotnet cli deve estar configurado no PATH.

Os seguintes comandos devem ser executados, na pasta raiz do projeto, para iniciar localmente a aplicação:

* dotnet dev-certs https
* dotnet run --project EmpregosDevHiringAPI\EmpregosDevHiringAPI.csproj 

Para validar a consulta de repositórios, pode-se fazer uma chamada http GET pelo navegador, para a seguinte url:

* http://localhost:5000/api/repository
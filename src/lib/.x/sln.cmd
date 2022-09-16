set Area=src
set ProjectId=lib
call %~dp0..\config.cmd

cd %ProjectRoot%

dotnet sln add ../literals/z0.literals.csproj
dotnet sln add ../sys/z0.sys.csproj
dotnet sln add ../bit/z0.bit.csproj
dotnet sln add ../text/z0.text.csproj
dotnet sln add ../math/z0.math.csproj
dotnet sln add ../api.specs/z0.api.specs.csproj
dotnet sln add ../clr.query/z0.clr.query.csproj
dotnet sln add ../hex/z0.hex.csproj
dotnet sln add ../cells/z0.cells.csproj
dotnet sln add ../cmd.specs/z0.cmd.specs.csproj
dotnet sln add ../imagine/z0.imagine.csproj
dotnet sln add ../lang/z0.lang.csproj





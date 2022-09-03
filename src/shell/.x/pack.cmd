call %~dp0config.cmd

dotnet pack %SlnPath% %BuildProps% -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
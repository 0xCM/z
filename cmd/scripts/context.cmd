procdump64 -ma -mk 42640
robocopy %Views%\zcmd d:\views\db\capture\2022-07-14.19.28.22.987\context /e
: zcmd.exe_220714_194148.Kernel
dotnet symbol --symbols --modules --debugging --diagnostics zcmd.exe_220714_194148.dmp
dotnet symbol zcmd\*.dll --modules --symbols --debugging --diagnostics -o zcmd.deps
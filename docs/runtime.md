# Encoding Notes

## Clr Event Tracing

The source of clr event definition truth is defined by <file:///d:/views/repos/dotnet/runtime/src/coreclr/vm/clretwall.man>


<https://docs.microsoft.com/en-us/dotnet/standard/frameworks>

.NET 6	6	net6.0	N/A
.NET 5	5	net5.0	N/A
.NET Standard	2.1	netstandard2.1	N/A
.NET Core	3.1	netcoreapp3.1	2.1
.NET Framework	4.8	net48	2.0

.NET 5+ (and .NET Core)	netcoreapp1.0
netcoreapp1.1
netcoreapp2.0
netcoreapp2.1
netcoreapp2.2
netcoreapp3.0
netcoreapp3.1
net5.0*
net6.0*

.NET Standard	netstandard1.0
netstandard1.1
netstandard1.2
netstandard1.3
netstandard1.4
netstandard1.5
netstandard1.6
netstandard2.0
netstandard2.1

NET Framework	net11
net20
net35
net40
net403
net45
net451
net452
net46
net461
net462
net47
net471
net472
net48

Universal Windows Platform	uap [uap10.0]
uap10.0 [win10] [netcore50]

et5.0	net1..4 (with NU1701 warning)
netcoreapp1..3.1 (warning when WinForms or WPF is referenced)
netstandard1..2.1
net5.0-windows	netcoreapp1..3.1 (plus everything else inherited from net5.0)
net6.0	(subsequent version of net5.0)
net6.0-android	xamarin.android (+everything else inherited from net6.0)
net6.0-ios	xamarin.ios (+everything else inherited from net6.0)
net6.0-macos	xamarin.mac (+everything else inherited from net6.0)
net6.0-maccatalyst	xamarin.ios (+everything else inherited from net6.0)
net6.0-tvos	xamarin.tvos (+everything else inherited from net6.0)
net6.0-windows	(subsequent version of net5.0-windows)
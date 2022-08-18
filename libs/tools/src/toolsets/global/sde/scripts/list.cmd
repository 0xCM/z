@echo off

set tools=b:/tools
set sde=%tools%/sde/sde.exe
set app=cmd.exe
set chips=%tools%/sde/misc/cpuid

set adl=%tools%/sde/misc/cpuid/adl/cpuid.def
set bdw=%tools%/sde/misc/cpuid/bdw/cpuid.def
set clx=%tools%/sde/misc/cpuid/clx/cpuid.def
set cnl=%tools%/sde/misc/cpuid/cnl/cpuid.def
set cpx=%tools%/sde/misc/cpuid/cpx/cpuid.def
set future=%tools%/sde/misc/cpuid/future/cpuid.def
set glm=%tools%/sde/misc/cpuid/glm/cpuid.def
set glp=%tools%/sde/misc/cpuid/glp/cpuid.def
set hsw=%tools%/sde/misc/cpuid/hsw/cpuid.def
set icl-server=%tools%/sde/misc/cpuid/icl-server/cpuid.def
set icl=%tools%/sde/misc/cpuid/icl/cpuid.def
set ivb=%tools%/sde/misc/cpuid/ivb/cpuid.def
set knl=%tools%/sde/misc/cpuid/knl/cpuid.def
set knm=%tools%/sde/misc/cpuid/knm/cpuid.def
set mrm=%tools%/sde/misc/cpuid/mrm/cpuid.def
set nhm=%tools%/sde/misc/cpuid/nhm/cpuid.def
set pentium3=%tools%/sde/misc/cpuid/pentium3/cpuid.def
set pentium4=%tools%/sde/misc/cpuid/pentium4/cpuid.def
set pentium4p=%tools%/sde/misc/cpuid/pentium4p/cpuid.def
set pnr=%tools%/sde/misc/cpuid/pnr/cpuid.def
set quark=%tools%/sde/misc/cpuid/quark/cpuid.def
set skl=%tools%/sde/misc/cpuid/skl/cpuid.def
set skx=%tools%/sde/misc/cpuid/skx/cpuid.def
set slm=%tools%/sde/misc/cpuid/slm/cpuid.def
set slt=%tools%/sde/misc/cpuid/slt/cpuid.def
set snb=%tools%/sde/misc/cpuid/snb/cpuid.def
set snr=%tools%/sde/misc/cpuid/snr/cpuid.def
set spr=%tools%/sde/misc/cpuid/spr/cpuid.def
set tgl=%tools%/sde/misc/cpuid/tgl/cpuid.def
set tnt=%tools%/sde/misc/cpuid/tnt/cpuid.def
set wsm=%tools%/sde/misc/cpuid/wsm/cpuid.def

set chip=%adl%
set sde-adl=%sde% -cpuid-in %chip% -- %app%
echo [adl]
echo %sde-adl%

set chip=%bdw%
set sde-bdw=%sde% -cpuid-in %chip% -- %app%
echo [bdw]
echo %sde-bdw%

set chip=%future%
set sde-future=%sde% -cpuid-in %chip% -- %app%
echo [future]
echo %sde-future%

set chip=%pentium3%
set sde-pentium3=%sde% -cpuid-in %chip% -- %app%
echo [pentium3]
echo %sde-pentium3%

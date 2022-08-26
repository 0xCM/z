@echo off
call %~dp0..\config.cmd

dotnet sln add B:/dev/z0/libs/z/z0.z.csproj
dotnet sln add B:/dev/z0/libs/literals/z0.literals.csproj
dotnet sln add B:/dev/z0/libs/sys/z0.sys.csproj
@REM dotnet sln add B:/dev/z0/libs/text/z0.text.csproj
@REM dotnet sln add B:/dev/z0/libs/clr.msil/z0.clr.msil.csproj
@REM dotnet sln add B:/dev/z0/libs/clr.query/z0.clr.query.csproj
@REM dotnet sln add B:/dev/z0/libs/clr.models/z0.clr.models.csproj
@REM dotnet sln add B:/dev/z0/libs/imagine/z0.imagine.csproj
@REM dotnet sln add B:/dev/z0/libs/events/z0.events.csproj
@REM dotnet sln add B:/dev/z0/libs/lib/z0.lib.csproj
@REM dotnet sln add B:/dev/z0/libs/containers/z0.containers.csproj
@REM dotnet sln add B:/dev/z0/libs/symbolics/z0.symbolics.csproj
@REM dotnet sln add B:/dev/z0/libs/bit/z0.bit.csproj
@REM dotnet sln add B:/dev/z0/libs/cmd.specs/z0.cmd.specs.csproj
@REM dotnet sln add B:/dev/z0/libs/digital/z0.digital.csproj
@REM dotnet sln add B:/dev/z0/libs/wf/z0.wf.csproj
@REM dotnet sln add B:/dev/z0/libs/api.code/z0.api.code.csproj
@REM dotnet sln add B:/dev/z0/libs/alloc/z0.alloc.csproj
@REM dotnet sln add B:/dev/z0/libs/asm/z0.asm.csproj
@REM dotnet sln add B:/dev/z0/libs/asm.core/z0.asm.core.csproj
@REM dotnet sln add B:/dev/z0/libs/asm.models/z0.asm.models.csproj
@REM dotnet sln add B:/dev/z0/libs/bits/z0.bits.csproj
@REM dotnet sln add B:/dev/z0/libs/builds/z0.builds.csproj
@REM dotnet sln add B:/dev/z0/libs/diagnostics/z0.diagnostics.csproj
@REM dotnet sln add B:/dev/z0/libs/emath/z0.emath.csproj
@REM dotnet sln add B:/dev/z0/libs/files/z0.files.csproj
@REM dotnet sln add B:/dev/z0/libs/machines/z0.machines.csproj
@REM dotnet sln add B:/dev/z0/libs/memory/z0.memory.csproj
@REM dotnet sln add B:/dev/z0/libs/native/z0.native.csproj
@REM dotnet sln add B:/dev/z0/libs/numbers/z0.numbers.csproj
@REM dotnet sln add B:/dev/z0/libs/polyrand/z0.polyrand.csproj
@REM dotnet sln add B:/dev/z0/libs/rules/z0.rules.csproj
@REM dotnet sln add B:/dev/z0/libs/tools/z0.tools.csproj
@REM dotnet sln add B:/dev/z0/libs/sos.cmd/z0.sos.cmd.csproj
@REM dotnet sln add B:/dev/z0/libs/validity/z0.validity.csproj
@REM dotnet sln add B:/dev/z0/libs/tuples/z0.tuples.csproj
@REM dotnet sln add B:/dev/z0/libs/asm.svc/z0.asm.svc.csproj
@REM dotnet sln add B:/dev/z0/libs/archives/z0.archives.csproj
@REM dotnet sln add B:/dev/z0/libs/cli/z0.cli.csproj
@REM dotnet sln add B:/dev/z0/libs/clr.cil/z0.clr.cil.csproj
@REM dotnet sln add B:/dev/z0/libs/calcs/z0.calcs.csproj
@REM dotnet sln add B:/dev/z0/libs/api.md/z0.api.md.csproj
@REM dotnet sln add B:/dev/z0/libs/circuits/z0.circuits.csproj
@REM dotnet sln add B:/dev/z0/libs/coff/z0.coff.csproj
@REM dotnet sln add B:/dev/z0/libs/fsm/z0.fsm.csproj
@REM dotnet sln add B:/dev/z0/libs/llvm.svc/z0.llvm.svc.csproj
@REM dotnet sln add B:/dev/z0/libs/lang/z0.lang.csproj
@REM dotnet sln add B:/dev/z0/libs/linq/z0.linq.csproj
@REM dotnet sln add B:/dev/z0/libs/dynamic/z0.dynamic.csproj
@REM dotnet sln add B:/dev/z0/libs/heaps/z0.heaps.csproj
@REM dotnet sln add B:/dev/z0/libs/intel.svc/z0.intel.svc.csproj
@REM dotnet sln add B:/dev/z0/libs/memory.svc/z0.memory.svc.csproj
@REM dotnet sln add B:/dev/z0/libs/queues/z0.queues.csproj
@REM dotnet sln add B:/dev/z0/libs/render/z0.render.csproj
@REM dotnet sln add B:/dev/z0/libs/assets/z0.assets.csproj
@REM dotnet sln add B:/dev/z0/libs/agents/z0.agents.csproj
@REM dotnet sln add B:/dev/z0/libs/asm.prototypes/z0.asm.prototypes.csproj
@REM dotnet sln add B:/dev/z0/libs/db/z0.db.csproj
@REM dotnet sln add B:/dev/z0/cg/cg.common/z0.cg.common.csproj
@REM dotnet sln add B:/dev/z0/cg/cg.llvm/z0.cg.llvm.csproj
@REM dotnet sln add B:/dev/z0/cg/cg.intel/z0.cg.intel.csproj
@REM dotnet sln add B:/dev/z0/cg/cg.libs/z0.cg.libs.csproj
@REM dotnet sln add B:/dev/z0/test/test.checks/z0.test.checks.csproj
@REM dotnet sln add B:/dev/z0/test/test.units/z0.test.units.csproj

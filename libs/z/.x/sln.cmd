@echo off
call %~dp0..\config.cmd

dotnet sln add B:/dev/z0/libs/literals/z0.literals.csproj
dotnet sln add B:/dev/z0/libs/sys/z0.sys.csproj
dotnet sln add B:/dev/z0/libs/text/z0.text.csproj
dotnet sln add B:/dev/z0/libs/clr.msil/z0.clr.msil.csproj
dotnet sln add B:/dev/z0/libs/clr.query/z0.clr.query.csproj
dotnet sln add B:/dev/z0/libs/clr.models/z0.clr.models.csproj
dotnet sln add B:/dev/z0/libs/imagine/z0.imagine.csproj
dotnet sln add B:/dev/z0/libs/events/z0.events.csproj
dotnet sln add B:/dev/z0/libs/lib/z0.lib.csproj
dotnet sln add B:/dev/z0/libs/containers/z0.containers.csproj
dotnet sln add B:/dev/z0/libs/symbolics/z0.symbolics.csproj
dotnet sln add B:/dev/z0/libs/bit/z0.bit.csproj
dotnet sln add B:/dev/z0/libs/cmd.specs/z0.cmd.specs.csproj
dotnet sln add B:/dev/z0/libs/digital/z0.digital.csproj
dotnet sln add B:/dev/z0/libs/wf/z0.wf.csproj
dotnet sln add B:/dev/z0/libs/api.code/z0.api.code.csproj
dotnet sln add B:/dev/z0/libs/alloc/z0.alloc.csproj
dotnet sln add B:/dev/z0/libs/asm/z0.asm.csproj
dotnet sln add B:/dev/z0/libs/asm.core/z0.asm.core.csproj
dotnet sln add B:/dev/z0/libs/asm.models/z0.asm.models.csproj
dotnet sln add B:/dev/z0/libs/bits/z0.bits.csproj
dotnet sln add B:/dev/z0/libs/builds/z0.builds.csproj
dotnet sln add B:/dev/z0/libs/diagnostics/z0.diagnostics.csproj
dotnet sln add B:/dev/z0/libs/emath/z0.emath.csproj
dotnet sln add B:/dev/z0/libs/files/z0.files.csproj
dotnet sln add B:/dev/z0/libs/machines/z0.machines.csproj
dotnet sln add B:/dev/z0/libs/memory/z0.memory.csproj
dotnet sln add B:/dev/z0/libs/native/z0.native.csproj
dotnet sln add B:/dev/z0/libs/numbers/z0.numbers.csproj
dotnet sln add B:/dev/z0/libs/polyrand/z0.polyrand.csproj
dotnet sln add B:/dev/z0/libs/rules/z0.rules.csproj
dotnet sln add B:/dev/z0/libs/tools/z0.tools.csproj
dotnet sln add B:/dev/z0/libs/sos.cmd/z0.sos.cmd.csproj
dotnet sln add B:/dev/z0/libs/validity/z0.validity.csproj
dotnet sln add B:/dev/z0/libs/tuples/z0.tuples.csproj
dotnet sln add B:/dev/z0/libs/asm.svc/z0.asm.svc.csproj
dotnet sln add B:/dev/z0/libs/archives/z0.archives.csproj
dotnet sln add B:/dev/z0/libs/cli/z0.cli.csproj
dotnet sln add B:/dev/z0/libs/clr.cil/z0.clr.cil.csproj
dotnet sln add B:/dev/z0/libs/calcs/z0.calcs.csproj
dotnet sln add B:/dev/z0/libs/api.md/z0.api.md.csproj
dotnet sln add B:/dev/z0/libs/circuits/z0.circuits.csproj
dotnet sln add B:/dev/z0/libs/coff/z0.coff.csproj
dotnet sln add B:/dev/z0/libs/fsm/z0.fsm.csproj
dotnet sln add B:/dev/z0/libs/llvm.svc/z0.llvm.svc.csproj
dotnet sln add B:/dev/z0/libs/lang/z0.lang.csproj
dotnet sln add B:/dev/z0/libs/linq/z0.linq.csproj
dotnet sln add B:/dev/z0/libs/dynamic/z0.dynamic.csproj
dotnet sln add B:/dev/z0/libs/heaps/z0.heaps.csproj
dotnet sln add B:/dev/z0/libs/intel.svc/z0.intel.svc.csproj
dotnet sln add B:/dev/z0/libs/llvm.tools/z0.llvm.tools.csproj
dotnet sln add B:/dev/z0/libs/memory.svc/z0.memory.svc.csproj
dotnet sln add B:/dev/z0/libs/queues/z0.queues.csproj
dotnet sln add B:/dev/z0/libs/render/z0.render.csproj
dotnet sln add B:/dev/z0/libs/assets/z0.assets.csproj
dotnet sln add B:/dev/z0/libs/agents/z0.agents.csproj
dotnet sln add B:/dev/z0/libs/asm.prototypes/z0.asm.prototypes.csproj
dotnet sln add B:/dev/z0/libs/db/z0.db.csproj
dotnet sln add B:/dev/z0/cg/cg.common/z0.cg.common.csproj
dotnet sln add B:/dev/z0/cg/cg.llvm/z0.cg.llvm.csproj
dotnet sln add B:/dev/z0/cg/cg.intel/z0.cg.intel.csproj
dotnet sln add B:/dev/z0/cg/cg.libs/z0.cg.libs.csproj
dotnet sln add B:/dev/z0/test/test.checks/z0.test.checks.csproj
dotnet sln add B:/dev/z0/test/test.units/z0.test.units.csproj

: dotnet sln add B:/dev/z0/libs/wf.shell/z0.wf.shell.csproj
@REM dotnet sln add B:/dev/z0/libs/api.checks/z0.api.checks.csproj
@REM dotnet sln add B:/dev/z0/libs/cmd.checks/z0.cmd.checks.csproj
@REM dotnet sln add B:/dev/z0/libs/memory.checks/z0.memory.checks.csproj
@REM dotnet sln add B:/dev/z0/libs/shell.cmd/z0.shell.cmd.csproj
@REM dotnet sln add B:/dev/z0/libs/workers/z0.workers.csproj
@REM dotnet sln add B:/dev/z0/test/test.shell/z0.test.shell.csproj
@REM dotnet sln add B:/dev/z0/cg/cg.shell/z0.cg.shell.csproj
@REM dotnet sln add B:/dev/z0/cg/cg.test/z0.cg.test.csproj



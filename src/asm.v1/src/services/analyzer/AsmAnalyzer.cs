// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using Asm;

//     public sealed class AsmAnalyzer : AppService<AsmAnalyzer>
//     {
//         AsmRowBuilder AsmRows => Wf.AsmRowBuilder();

//         AsmCallPipe Calls => Wf.AsmCallPipe();

//         AsmJmpPipe Jumps => Wf.AsmJmpPipe();

//         ProcessAsmSvc ProcessAsm => Wf.ProcessAsmSvc();

//         HostAsmEmitter HostAsm => Wf.HostAsmEmitter();

//         AsmAnalyzerSettings Settings;

//         public AsmAnalyzer()
//         {
//             AsmAnalyzerSettings.@default(out Settings);
//         }

//         public void Analyze(ReadOnlySpan<AsmRoutine> src, IApiPackArchive dst)
//         {
//             var blocks = default(Index<ApiCodeBlock>);
//             var process = default(ReadOnlySpan<ProcessAsmRecord>);
//             var jumps = default(Index<AsmJmpRow>);
//             var calls = default(Index<AsmCallRow>);
//             var hostasm = default(Index<HostAsmRecord>);
//             var details = default(Index<AsmDetailRow>);
//             if(Settings.EmitCalls)
//                 calls = EmitCalls(src, dst);

//             if(Settings.EmitJumps)
//                 jumps = EmitJumps(src, dst);

//             if(Settings.EmitStatements)
//                 hostasm = HostAsm.EmitHostAsm(src, dst);

//             if(Settings.EmitProcessAsm)
//                 process = ProcessAsm.EmitProcessAsm(src, dst.ProcessAsmPath());

//             if(Settings.EmitAsmDetails)
//             {
//                 blocks = CollectBlocks(src);
//                 details = EmitDetails(blocks, dst);
//             }
//         }

//         Index<AsmDetailRow> EmitDetails(ReadOnlySpan<ApiCodeBlock> src, IApiPackArchive dst)
//         {
//             var target = dst.DetailTables();
//             target.Clear();
//             return AsmRows.Emit(src, target.Root);
//         }

//         public Index<ApiCodeBlock> CollectBlocks(ReadOnlySpan<AsmRoutine> src)
//             => AsmRoutines.blocks(src);

//         Index<AsmCallRow> EmitCalls(ReadOnlySpan<AsmRoutine> src, IApiPackArchive dst)
//             => Calls.EmitRows(src, dst.AsmCallsPath());

//         Index<AsmJmpRow> EmitJumps(ReadOnlySpan<AsmRoutine> src, IApiPackArchive dst)
//             => Jumps.EmitRows(src, dst.JmpTarget());
//     }
// }
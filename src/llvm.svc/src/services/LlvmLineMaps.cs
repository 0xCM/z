//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmLineMaps : WfSvc<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths => Wf.LlvmPaths();

        LlvmDataCalcs DataCalcs => Wf.LlvmDataCalcs();

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        public void EmitLineMaps()
        {


        }

        public LineMap<string> CalcDefMap(string project, string name)
        {
            var src = DataProvider.RecordLines(project,name);
            return DbArchives.map(src, DataCalcs.CalcDefRelations(src));
        }

        public void EmitMap(string project, string name, LineMap<string> src)
        {
            var dst = LlvmPaths.LineMap(project,name);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.IntervalCount; i++)
                writer.WriteLine(src[i].Format());
            EmittedFile(emitting, src.IntervalCount);
        }

        public LineMap<string> EmitLineMap<T>(Index<T> src, Index<TextLine> records, string name)
            where T : struct, ILineRelations<T>
        {
            var map = DbArchives.map(records, src);
            var dst = LlvmPaths.LineMap(name);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<map.IntervalCount; i++)
                writer.WriteLine(map[i].Format());
            EmittedFile(emitting, map.IntervalCount);
            return map;
        }
    }
}
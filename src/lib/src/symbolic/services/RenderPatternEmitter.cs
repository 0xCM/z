//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class RenderPatternEmitter : AppService<RenderPatternEmitter>
    {
        public void Emit(Type src, FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var patterns = Sources(src);
            var view = patterns.View;

            var count = view.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(view,i).Format());

            EmittedFile(flow, count);
        }

        [Op]
        public RenderPatternSources Sources(Type src)
        {
            var values = src.LiteralFieldValues<string>(out var fields);
            var count = values.Length;
            var buffer = alloc<RenderPatternSource>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new RenderPatternSource(skip(fields,i), skip(values,i));
            return buffer;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class RenderPatternEmitter : Channeled<RenderPatternEmitter>
    {        
        public void Emit(Type src, FilePath dst)
        {
            var flow = Channel.EmittingFile(dst);
            using var writer = dst.Writer();
            var patterns = RenderPatternSources.from(src);
            var view = patterns.View;

            var count = view.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(view,i).Format());

            Channel.EmittedFile(flow, count);
        }
    }
}
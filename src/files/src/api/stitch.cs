//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static string stitch(FileStitch spec)
        {
            var src = spec.Source.ReadText();
            var i = text.index(src, spec.Markers.Left);
            var content = EmptyString;
            if(i >= 0)
            {
                var j = text.index(src, spec.Markers.Right);
                if(j >0)
                {
                    content = text.segment(src,i,j);
                    using var dst = spec.Target.Writer();
                    dst.AppendLine(content);
                }
            }
            return content;
        }
    }    
}
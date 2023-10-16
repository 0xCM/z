//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CsLimitGen
    {
        public void GenLimits(IWfChannel channel, IDbArchive dst)
        {
            const string CommentPattern = "Specifies the maximum value of a {0}-bit number, {1:#,#}";
            const string NamePattern = "Max{0}u";
            var max = 0ul;
            var emitter = CsEmitter.create();
            var offset = 0u;
            emitter.Namespace(offset, "Z0");
            emitter.LiteralProvider(offset);
            emitter.OpenStruct(offset, "Limit");
            offset+=4;
            for(var i=1; i<=64; i++)
            {
                emitter.Comment(offset, string.Format(CommentPattern, i, max));
                max = (ulong)Pow2.m1((byte)i);
                if(i <= 8)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (byte)max);
                else if(i <= 16)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ushort)max);
                else if(i <= 32)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (uint)max);
                else if(i <= 64)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ulong)max);
                emitter.AppendLine();
            }
            offset-=4;
            emitter.CloseStruct(offset);
            offset-=4;

            channel.FileEmit(emitter.Emit(), dst.Path("limit", FileKind.Cs));
        }
    }
}
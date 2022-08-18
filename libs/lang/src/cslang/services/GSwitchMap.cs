//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static CsModels;

    partial class CsLang
    {
        public class GSwitchMap : AppService<GSwitchMap>
        {
            public string Generate<S,T>(SwitchMap<S,T> spec)
                where S : unmanaged
                where T : unmanaged
            {
                var srcType = typeof(S);
                var eSrc = srcType.IsEnum;
                var dstType = typeof(T);
                var eDst = dstType.IsEnum;
                var count = Require.equal(spec.Sources.Count, spec.Targets.Count);
                if(count == 0)
                    return EmptyString;
                var dst = text.buffer();
                var margin = 0u;
                dst.IndentLineFormat(margin, "public static {0} {1}({2} src)", dstType.CodeName(), spec.Name, srcType.CodeName());
                margin+=4;
                dst.IndentLine(margin, "=> src switch {");
                margin+=4;
                for(var i=0; i<count; i++)
                {
                    ref readonly var a = ref spec.Sources[i];
                    ref readonly var b = ref spec.Targets[i];

                    var srcCase = eSrc ? string.Format("{0}.{1}", srcType.Name, a) : a.ToString();
                    var dstCase = eDst ? string.Format("{0}.{1}", dstType.Name, b) : b.ToString();

                    dst.IndentLineFormat(margin, "{0} => {1},", srcCase, dstCase);
                }
                dst.IndentLineFormat(margin, "_ => {0}", default(T));

                margin-=4;
                dst.IndentLine(margin, "};");

                return dst.Emit();
            }
        }
    }
}

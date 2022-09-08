//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class TypeParser : AppService<TypeParser>
    {
        public static bool parametric(TypeSpec src)
            => text.contains(src.Text, Chars.Lt);

        public static Index<TypeParam> parameters(TypeSpec src)
        {
            var buffer = sys.empty<TypeParam>();
            if(parametric(src))
            {
                var content = Fenced.unfence(src.Text, Fenced.Angled);
                if(nonempty(content))
                {
                    var parts = text.split(content,Chars.Comma);
                    var count = parts.Length;
                    if(count != 0)
                    {
                        buffer = alloc<TypeParam>(count);
                        for(var i=0; i<count; i++)
                        {
                            ref readonly var part = ref skip(parts,i);
                            ref var dst = ref seek(buffer,i);
                            if(nonempty(part))
                            {
                                var j = text.index(part, Chars.Colon);
                                if(j >= 0)
                                    dst = (text.left(part,i),text.right(part,i));
                                else
                                    dst = (EmptyString, part);
                            }
                            else
                                dst = TypeParam.Empty;
                        }
                    }
                }
            }

            return buffer;
        }

        public bool IsParametric(TypeSpec src)
            => parametric(src);

        public Index<TypeParam> Parameters(TypeSpec src)
            =>  parameters(src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class TypeList : Seq<TypeList,TypeListEntry>
    {
        public static TypeList materialize(FileUri src)
        {
            var lines = src.ReadLines(skipBlank:true);
            var count = lines.Count;
            var dst = sys.alloc<TypeListEntry>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var type = Type.GetType(line) ?? typeof(void);
                seek(dst,i) = type;
            }
            return new (dst);
        }

        public static void serialize(ReadOnlySpan<Type> src, FileUri dst)
        {
            var emitter = text.emitter();
            for(var i=0; i<src.Length; i++)
                emitter.AppendLine(skip(src,i).AssemblyQualifiedName);        
            using var writer = dst.Utf8Writer();
            writer.Write(emitter.Emit());            
        }

        public TypeList()
        {

        }

        public TypeList(TypeListEntry[] src)
            : base(src)
        {

        }
    }
}
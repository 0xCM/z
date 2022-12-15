//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsPatterns;

    public class GLiteralProvider : AppService<GLiteralProvider>
    {
        public void Emit<T>(Identifier ns, LiteralSeq<T> literals, FilePath dst)
            where T : IComparable<T>, IEquatable<T>
        {
            var buffer = text.buffer();
            var margin = 0u;
            var typename = typeof(T).Name.ToLower();
            var count = literals.Count;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            margin += 4;
            buffer.IndentLine(margin, "[LiteralProvider]");
            buffer.IndentLine(margin, PublicReadonlyStruct(literals.Name));
            buffer.IndentLine(margin, Open());
            margin +=4;
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref literals[i];
                var itemName = literal.Name;
                var itemValue = literal.Value.Format();
                if(CsData.test(itemName))
                    itemName = CsData.identifier(itemName);

                buffer.IndentLineFormat(margin, "public const {0} {1} = {2};", typename, itemName, itemValue);
            }
            margin -=4;
            buffer.IndentLine(margin, Close());
            margin -=4;
            buffer.IndentLine(margin, Close());

            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.Writer();
            writer.Write(buffer.Emit());

            Channel.EmittedFile(emitting, count);
        }
    }
}
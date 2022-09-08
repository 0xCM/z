//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = Chars;

    partial class CsLang
    {
        public class GAsciLookup : AppService<GAsciLookup>
        {
            public static ByteSpanSpec specify(Identifier name, string content)
            {
                var src = span(content);
                var count = src.Length;
                var dst = alloc<byte>(count);
                for(var i=0; i<count; i++)
                    seek(dst, i) = (byte)skip(src,i);
                return new ByteSpanSpec(name, dst, true);
            }

            public ByteSpanSpec Specify(Identifier name, string content)
                => specify(name, content);

            public ByteSpanSpec Emit(uint indent, Identifier name, string data, ITextBuffer dst)
                => GSpanRes.ascirender(indent, name, data, dst);

            public static void Emit(FolderPath root)
            {
                var dst = root + FS.file("asci", FS.Txt);
                using var writer = dst.Writer();
                writer.Write(BuildAsciData(false));
                writer.Write(BuildAsciData(true));
                writer.Write(BuildAsciByteSpan(256));
            }

            const char BS = '\\';

            const char SQ = '\'';

            const char QU = '\"';

            static string BuildAsciData(bool span)
            {
                var sb = text.build();
                var count = 128;
                var name = span ? "AsciData" : "AsciDataString";
                var access = "public";
                var spanPropDecl = $"{access} static ReadOnlySpan<char> {name} => new " + $"char[{count}]" +"{";
                var constPropDecl = $"{access} const string {name} = \"";
                var propDecl = span ? spanPropDecl : constPropDecl;
                var charFence = span ? "'" : "";
                var spanPropClose = "};";
                var constPropClose = "\";";
                var propClose = span ? spanPropClose : constPropClose;

                sb.Append(propDecl);
                if(span)
                    sb.AppendLine();

                for(var i=0; i<count; i++)
                {
                    var c = (char)i;
                    sb.Append(charFence);

                    if(c == 0)
                        sb.Append(C.D0);
                    else if(c == 10 || c == 13)
                        sb.Append(C.D0);
                    else if(c == QU)
                        sb.Append($"\\{c}");
                    else if(Char.IsControl(c) || c == BS || c == SQ)
                        sb.Append($"0");
                    else
                        sb.Append(c);
                    sb.Append(charFence);

                    if(span)
                    {
                        sb.Append(", ");
                        if(i % 8 == 0 && i != 0)
                            sb.AppendLine();
                    }
                }

                sb.AppendLine(propClose);

                return sb.ToString();
            }

            static string BuildAsciByteSpan(uint size, string name = "AsciBytes")
            {
                var sb = text.build();

                var propDecl = $"publid static ReadOnlySpan<byte> {name} => new " + $"byte[{size}]" +"{";
                var propClose = "};";

                sb.Append(propDecl);
                sb.AppendLine();

                var j =0;
                for(int i=0; i<size; i++)
                {
                    if(i % 2 == 0)
                        sb.Append($"{j++},");
                    else
                        sb.Append("0,".PadRight(6));

                    if((i + 1) % 16 == 0 && i != 0)
                        sb.AppendLine();
                }

                sb.AppendLine(propClose);

                return sb.ToString();
            }
        }
    }
}
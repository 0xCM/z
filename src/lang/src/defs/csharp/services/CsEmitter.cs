//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CsEmitter
    {
        List<string> Dst;

        public CsEmitter()
        {
            Dst = new();
        }

        public void Clear()
        {
            Dst.Clear();
        }

        public ReadOnlySpan<string> Emit()
            => Dst.ViewDeposited();

        public void AppendLine()
            => Dst.Add(EmptyString);

        public void AppendLine(string content)
            => Dst.Add(content);

        const string HeaderLine1 = "//-----------------------------------------------------------------------------";
        const string HeaderLine2 = "// Copyright   :  (c) Chris Moore, 2023";
        const string HeaderLine3 = "// License     :  MIT";
        const string HeaderLine4 = "//-----------------------------------------------------------------------------";

        public void FileHeader()
        {
            IndentLine(0,HeaderLine1);
            IndentLine(0,HeaderLine2);
            IndentLine(0,HeaderLine3);
            IndentLine(0,HeaderLine4);
        }

        public void PublicField(uint offset, string type, string name)
            => IndentLineFormat(offset, "public {0} {1};", type, name);

        public void PublicField(string type, string name)
            => PublicField(0, type, name);

        public void IndentLine<T>(uint offset, T src)
            => Dst.Add(indent(offset,src));

        public void IndentLineFormat(uint offset, string pattern, params object[] args)
            => Dst.Add(IndentFormat(offset, pattern, args));

        public void Namespace(uint offset, string name)
            => IndentLineFormat(offset,"namespace {0};", name);

        public void Namespace(string name)
            => Namespace(0, name);

        public void UsingNamespace(uint offset, string name)
            => IndentLineFormat(offset,"uisng {0};", name);

        public void UsingNamespace(string name)
            => UsingNamespace(0, name);

        public void CommentLines(uint indent, params object[] lines)
        {
            IndentLine(indent,"/// <summary>");
            for(var i=0; i<lines.Length; i++)
                IndentLineFormat(indent, "/// {0}", skip(lines,i));
            IndentLine(indent,"/// </summary>");
        }
 
        public void Comment(uint indent, string content)
        {
            IndentLine(indent,"/// <summary>");
            IndentLineFormat(indent,"/// {0}", text.ifempty(content, "Undocumented"));
            IndentLine(indent,"/// </summary>");
        }

        public void Symbols(uint offset, SymbolSet src, bool attributions = true)
        {
            var counter = 0ul;
            var names = src.Names.View;
            var count = names.Length;
            var values = src.Values.IsNonEmpty;
            if(values)
                Require.equal(count, src.Values.Length);

            var symbols = src.Symbols.IsNonEmpty;
            if(symbols)
                Require.equal(count, src.Symbols.Length);

            var descriptions = src.Descriptions.IsNonEmpty;
            if(descriptions)
                Require.equal(count, src.Descriptions.Length);

            Span<string> attribs = new string[12];
            var k=0u;
            if(src.Flags)
                seek(attribs,k++) = "Flags";
            if(attributions)
            {
                if(text.nonempty(src.Group))
                    seek(attribs,k++) = string.Format("SymSource(\"{0}\")", src.Group);
                else
                    seek(attribs,k++) = "SymSource";
                if(src.Size.Packed != src.Size.Native)
                    seek(attribs,k++) = $"DataWidth({src.Size.Packed})";
            }

            if(k != 0)
                IndentLine(offset, text.bracket(text.join(", ", slice(attribs,0,k).ToArray())));

            IndentLineFormat(offset, "public enum {0} : {1}", src.Name, NumericKinds.kind(src.DataType).Keyword());
            IndentLine(offset,"{");

            offset += 4;
            for(var i=0; i<count; i++)
            {
                var name = CsData.identifier(skip(names,i));
                var description = EmptyString;
                var value = (ulong)i;
                var symbol = SymExpr.Empty;
                if(values)
                    value = src.Values[i];
                if(symbols)
                    symbol = src.Symbols[i];
                if(descriptions)
                    description = text.ifempty(src.Descriptions[i],EmptyString);

                if(nonempty(description))
                    Comment(offset,description);

                if(symbol.IsNonEmpty && attributions)
                {
                    if(nonempty(description))
                        IndentLineFormat(offset, "[Symbol(\"{0}\",\"{1}\")]", symbol, description);
                    else
                        IndentLineFormat(offset, "[Symbol(\"{0}\")]", symbol);
                }

                IndentLineFormat(offset, "{0} = {1},", name, value);
                if(i != count -1)
                    AppendLine();
            }
            offset -= 4;

            IndentLine(offset,"}");
        }

        public void OpenClass(uint offset, string name, bool partial = false)
        {
            const string P0 = "public class {0}";
            const string P1 = "public partial class {0}";
            var pattern = partial ? P1 : P0;
            IndentLineFormat(offset, pattern, name);
            IndentLine(offset, "{");
        }

        public void OpenClass(string name, bool partial = false)
            => OpenClass(0, name, partial);

        public void OpenStruct(uint offset, string name, bool @readonly = true, bool partial = false)
        {
            const string P0 = "public readonly struct {0}";
            const string P1 = "public struct {0}";
            const string P2 = "public readonly partial struct {0}";
            const string P3 = "public partial struct {0}";

            //var options = Numbers.pack(@readonly, partial);
            var options = (byte)(u8(@readonly) | (u8(partial) << 1));
            var pattern = EmptyString;
            switch(options)
            {
                case 0:
                    pattern = P1;
                break;
                case 1:
                    pattern = P0;
                break;
                case 2:
                    pattern = P2;
                break;
                case 3:
                    pattern = P3;
                break;
            }
            IndentLineFormat(offset, pattern, name);
            IndentLine(offset, "{");
        }

        public void Close(uint offset)
            => IndentLine(offset, "}");

        public void OpenPublicStaticProp<T>(uint offset, string name, T def)
        {
            IndentLineFormat(offset, "public static {0} {1}", name, def);
            IndentLine(offset, "{");
        }

        public void PropBody<T>(uint offset, T content, bool inline = true)
        {
            if(inline)
                IndentLine(offset,"[MethodImpl(Inline)]");
            IndentLineFormat(offset, "get => {0};", content);
        }

        public void CloseProp(uint offset)
            => IndentLine(offset, "}");

        public void AppMain(uint offset, string body)
        {
            IndentLine(offset, "static void Main(string[] args)");
            IndentLine(offset, "{");
            IndentLine(offset + 4, body);
            IndentLine(offset, "}");
        }

        public void Attribute(uint offset, string name)
            => IndentLine(offset, $"[{name}]");

        public void Attribute<T>(uint offset, string name, T args)
            => IndentLine(offset, $"[{name}({args})]");

        public void LiteralProvider(uint offset)
            => Attribute(offset, nameof(LiteralProvider));

        public void DataWidth(uint offset, uint packed)
            => Attribute(offset, nameof(DataWidth), packed);

        public void NumericLit<T>(uint offset, string name, T value)
            => IndentLineFormat(offset,"public const {0} {1} = {2};", typeof(T).DisplayName(), name, value);

        public void CloseStruct(uint offset)
            => Close(offset);

        public void CloseNamespace(uint offset)
            => Close(offset);

        public void LineComment<T>(uint offset, T src)
            => IndentLineFormat(offset, "// {0}", src);

        public void Constant(uint offset, string name, byte src)
            => IndentLine(offset, string.Format("public const byte {0} = {1};", name, src));

        public void Constant(uint offset, string name, sbyte src)
            => IndentLine(offset, string.Format("public const sbyte {0} = {1};", name, src));

        public void Constant(uint offset, string name, short src)
            => IndentLine(offset, string.Format("public const short {0} = {1};", name, src));

        public void Constant(uint offset, string name, ushort src)
            => IndentLine(offset, string.Format("public const ushort {0} = {1};", name, src));

        public void Constant(uint offset, string name, int src)
            => IndentLine(offset, string.Format("public const int {0} = {1};", name, src));

        public void Constant(uint offset, string name, uint src)
            => IndentLine(offset, string.Format("public const uint {0} = {1};", name, src));

        public void Constant(uint offset, string name, long src)
            => IndentLine(offset, string.Format("public const long {0} = {1};", name, src));

        public void Constant(uint offset, string name, ulong src)
            => IndentLine(offset, string.Format("public const ulong {0} = {1};", name, src));

        public void Constant(uint offset, string name, string src)
            => IndentLine(offset, string.Format("public const string {0} = \"{1}\";", name, src));

        public void Constant(uint offset, string name, char src)
            => IndentLine(offset, string.Format("public const char {0} = '{1}';", name, src));

        public void Constant(uint offset, string name, Enum src)
            => IndentLine(offset, string.Format("public const {0} {1} = {0}.{2};", src.GetType().Name, name, src));

        static string pad(uint width)
            => new string(Chars.Space, (int)width);

        public static string indent<T>(uint offset, T src)
            => string.Format("{0}{1}", pad(offset), src);

        static string IndentFormat(uint offset, string pattern, params object[] args)
            => indent(offset, string.Format(pattern, args));
    }
}
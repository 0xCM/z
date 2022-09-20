//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CsLang
    {
        public class CsEmitter
        {
            static string pad(uint width)
                => new string(Chars.Space, (int)width);

            public static string indent<T>(uint offset, T src)
                => string.Format("{0}{1}", pad(offset), src);

            static string IndentFormat(uint offset, string pattern, params object[] args)
                => indent(offset, string.Format(pattern, args));

            const string summary = nameof(summary);

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

            public void IndentLine<T>(uint offset, T src)
                => Dst.Add(indent(offset,src));

            public void IndentLineFormat(uint offset, string pattern, params object[] args)
                => Dst.Add(IndentFormat(offset, pattern, args));

            public void OpenNamespace(uint offset, string name)
            {
                IndentLineFormat(offset,"namespace {0}", name);
                IndentLine(offset, "{");
            }

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

            public void SummaryComment(uint offset, params object[] lines)
            {
                IndentLineFormat(offset, "/// <{0}>", summary);
                for(var i=0; i<lines.Length; i++)
                    IndentLineFormat(offset, "/// {0}", skip(lines,i));
                IndentLineFormat(offset, "/// </{0}>", summary);
            }
        }
    }
}
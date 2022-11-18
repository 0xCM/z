//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using D = DecimalDigitFacets;

    partial class XTend
    {
        [Op]
        public static AsciLineReader AsciLineReader(this FilePath src)
            => new AsciLineReader(src.AsciReader());

    }

    [Free,ApiHost]
    public class AsciLines
    {
        [MethodImpl(Inline), Op]
        static BinaryCode tobytes(string src)
            => Encoding.ASCII.GetBytes(src);

        public static T lookup<T>(FilePath src)
            where T : ISettings, new()
                => lookup<T>(lookup(src, Chars.Eq));

        public static T lookup<T>(SettingLookup src)
            where T : new()
        {
            var dst = new T();
            var members = Settings.members<T>();
            for(var i=0; i<members.Count; i++)
            {
                ref readonly var member = ref members[i];
                if(src.Find(member.Name, out var setting))
                {
                    member.SetValue(dst, setting.Value);
                }
            }

            return dst;
        }

        public static SettingLookup<T> lookup<T>(T src)
            where T : new()
                => new (typeof(T).PublicInstanceFields().Select(f => new Setting(f.Name, f.GetValue(src))));
 
        public static SettingLookup lookup(FilePath src, char sep)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            var quoted = new Fence<AsciCode>(AsciCode.SQuote, AsciCode.SQuote);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var value = Asci.format(SQ.right(content,i));
                        dst.Add(new Setting(name, value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        } 

        public static AsciProcessor<T> processor<T>(IWfChannel channel, uint buffer, Func<MemoryAddress,uint,T> f)
            => new AsciProcessor<T>(channel, buffer,f);

        public static uint settings(ref AsciLineReader src, Type type, char sep, out object dst)
        {
            dst = Activator.CreateInstance(type);
            var counter = 0u;
            var line = AsciLineCover.Empty;
            var members = Settings.members(type);
            while(src.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var data = SQ.right(content,i);
                        if(members.Member(name, out var field))
                        {
                            if(Settings.parse(Asci.format(data), field.FieldType, out var value))
                            {
                                field.SetValue(dst,value);
                                counter++;
                            }
                        }
                    }
                }
            }

            return counter;
        }

        public static uint settings<T>(ref AsciLineReader src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var counter = 0u;
            var line = AsciLineCover.Empty;
            var members = Settings.members<T>();
            while(src.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var data = SQ.right(content,i);
                        if(members.Member(name, out var field))
                        {
                            if(Settings.parse(Asci.format(data), field.FieldType, out var value))
                            {
                                field.SetValue(dst,value);
                                counter++;
                            }
                        }
                    }
                }
            }

            return counter;
        }

        [Op]
        public static bool next(ref LineReaderState state, out AsciLineCover<byte> dst)
        {
            dst = AsciLineCover<byte>.Empty;
            var line = state.Source.ReadLine();
            if(line == null)
                return false;
            var data = tobytes(line).Storage;
            state.LineCount++;

            if(AsciLines.number(data, out var length, out var num))
                dst = new AsciLineCover<byte>(data);
            else
                dst = new AsciLineCover<byte>(data);

            state.Offset+=length;

            return true;
        }

        static bool number(ReadOnlySpan<char> src, out uint j, out LineNumber dst)
        {
            j = 0;
            dst = default;
            var i = text.index(src,Chars.Colon);
            if(i == NotFound)
                return false;

            if(uint.TryParse(slice(src,0, i), out var n))
            {
                j = (uint)(i + 1);
                dst = n;
                return true;
            }

            return false;
        }

        [Op]
        public static bool next(ref LineReaderState state, out AsciLineCover<char> dst)
        {
            dst = AsciLineCover<char>.Empty;
            var line = state.Source.ReadLine();
            if(line == null)
                return false;

            var data = line.ToCharArray();
            state.LineCount++;

            if(number(data, out var length, out var num))
                dst = new AsciLineCover<char>(data);
            else
                dst = new AsciLineCover<char>(data);

            state.Offset+=length;

            return true;
        }

        public static bool next<T>(ref LineReaderState State, Span<byte> buffer, out AsciLineCover<T> dst)
            where T : unmanaged
        {
            dst = AsciLineCover<T>.Empty;
            var _line = State.Source.ReadLine();
            if(_line == null)
                return false;

            var count = Asci.encode(_line, buffer);
            var data = slice(buffer,0,count);

            State.LineCount++;

            if(AsciLines.number(data, out var length, out var num))
                dst = new AsciLineCover<T>(recover<byte,T>(slice(data, (int)length)));
            else
                dst = new AsciLineCover<T>(recover<byte,T>(data));

            State.Offset+=length;

            return true;
        }

        [Op]
        public static LineCount count(FilePath src)
            => (src, count(src.ReadBytes()));

        public static void emit(ReadOnlySpan<LineStats> src, FilePath dst)
        {
            using var writer = dst.AsciWriter();
            writer.WriteLine(LineStats.Header);
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(skip(src,i).Format());
        }

        public static ReadOnlySpan<LineStats> stats(ReadOnlySpan<byte> data, uint buffer = 0)
        {
            var dst = span<LineStats>(buffer);
            var last = 0u;
            var counter = 0u;
            var j=0u;
            for(var i=0u; i<data.Length && i < buffer; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    seek(dst,j++) = new LineStats(counter++, offset, length);
                    last = offset;
                }
            }

            return slice(dst,0,j);
        }

        [Op]
        public static Index<LineCount> count(ReadOnlySpan<FilePath> src)
        {
            var dst = bag<LineCount>();
            iter(src, path => dst.Add(count(path)), true);
            return dst.ToArray().Sort();
        }

        public static Index<LineStats> stats(MemoryFile src, uint buffer = 0)
        {
            var dst = list<LineStats>(buffer);
            var data = src.View();
            var last = 0u;
            var counter = 0u;
            for(var i=0u; i<data.Length; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    dst.Add(new LineStats(counter++, offset, length));
                    last = offset;
                }
            }

            return dst.Array();
        }

        [MethodImpl(Inline)]
        public static AsciLineCover<T> asci<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => new AsciLineCover<T>(src);

        [MethodImpl(Inline), Op]
        public static AsciLineCover asci(ReadOnlySpan<byte> src)
            => new AsciLineCover(src);

        [MethodImpl(Inline), Op]
        public static uint asci(ReadOnlySpan<AsciCode> src, ref uint number, ref uint i, out AsciLineCover dst)
            => asci(core.recover<AsciCode,byte>(src), ref number, ref i, out dst);

        [MethodImpl(Inline), Op]
        public static AsciLineCover asci(ReadOnlySpan<byte> src, uint offset, uint length)
            => new AsciLineCover(slice(src,offset,length));

        [MethodImpl(Inline), Op]
        public static uint asci(ReadOnlySpan<byte> src, ref uint number, ref uint i, out AsciLineCover dst)
        {
            var i0 = i;
            dst = default;
            var max = src.Length;
            var length = 0u;
            while(i++ < max - 1)
            {
                if(SQ.eol(skip(src, i), skip(src, i + 1)))
                {
                    length = i - i0;
                    dst = new AsciLineCover(slice(src, i0, length));
                    ++number;
                    i+=2;
                    break;
                }
            }

            return length;
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<char> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<AsciCode> src, uint offset)
            => empty(recover<AsciCode,byte>(src), offset);

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<byte> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
        }

        /// <summary>
        /// Reads a <see cref='AsciLineCover{bytee}'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="number">The current line count</param>
        /// <param name="i">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint asci(string src, ref uint number, ref uint i, out AsciLineCover<byte> dst)
        {
            var i0 = i;
            dst = AsciLineCover<byte>.Empty;
            var max = src.Length;
            var length = 0u;
            var data = span(src);
            if(empty(src,i))
            {
                i+=2;
            }
            else
            {
                while(i++ < max - 1)
                {
                    if(SQ.eol(skip(data, i), skip(data, i + 1)))
                    {
                        length = i - i0;
                        dst = asci<byte>(tobytes(text.slice(src, i0, length)).View);
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }

        public static void load(FilePath src)
        {
            using var map = MemoryFiles.map(src);
            var data = map.View<AsciSymbol>();
            var count = AsciLines.count(data);
        }

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<AsciSymbol> src)
            => count(recover<AsciSymbol,byte>(src));

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<AsciCode> src)
            => count(recover<AsciCode,byte>(src));

        /// <summary>
        /// Counts the number of asci-encoded lines represented in the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        static uint count(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var counter = 0u;
            for(var pos=0u; pos<size- 1; pos++)
            {
                ref readonly var a0 = ref skip(src, pos);
                ref readonly var a1 = ref skip(src, pos + 1);
                if(SQ.eol(a0,a1))
                    counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        static bool test(Base10 @base, byte c)
            => (DecimalDigitValue)c >= D.MinDigit && (DecimalDigitValue)c <= D.MaxDigit;

        [Op]
        public static bool number(ReadOnlySpan<byte> src, out uint j, out LineNumber dst)
        {
            j=0;
            dst = 0;
            const char Delimiter = Chars.Colon;
            const byte LastIndex = 8;
            const byte ContentLength = 9;

            var result = false;
            var storage = CharBlock8.Null;
            var buffer = storage.Data;

            while(j++ <= LastIndex)
            {
                ref readonly var c = ref skip(src, j);
                if(test(base10, c))
                    seek(buffer, j) = (char)c;
                else if(c == Delimiter && j==LastIndex)
                {
                    result = uint.TryParse(buffer, out var n);
                    if(result)
                        dst = n;
                    break;
                }
                else
                    break;
            }
            return result;
        }
    }
}
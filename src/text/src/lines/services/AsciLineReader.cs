//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct AsciLineReader : IDisposable
    {
        readonly StreamReader Source;

        uint LineCount;

        uint Offset;

        Seq<byte> _Buffer;

        public AsciLineReader(StreamReader src)
        {
            Source = src;
            LineCount = 0;
            Offset = 0;
            _Buffer = sys.alloc<byte>(1024*4);
        }

        [MethodImpl(Inline)]
        Span<byte> Buffer()
        {
            _Buffer.Storage.Clear();
            return _Buffer.Edit;
        }


        public void Dispose()
        {
            Source?.Dispose();
        }

        public bool Next(out AsciLineCover dst)
        {
            dst = AsciLineCover.Empty;
            var _line = Source.ReadLine();
            if(_line == null)
                return false;
            var buffer = Buffer();
            var count = AsciSymbols.encode(_line, buffer);
            var data = slice(buffer,0,count);

            LineCount++;

            if(AsciLines.number(data, out var length, out var n))
                dst = new AsciLineCover(slice(data, (int)length));
            else
                dst = new AsciLineCover(data);

            Offset+=length;

            return true;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class CharStream : CharSource, ITokenSource<char>
    {
        readonly StreamReader Reader;

        readonly Seq<char> Buffer;

        uint Index;

        uint Length;

        readonly uint MaxLength;

        bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Index >= Length;
        }

        bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Index < Length;
        }

        bool IsDepleted
        {
            [MethodImpl(Inline)]
            get => Reader.EndOfStream;
        }

        internal CharStream(StreamReader reader)
        {
            Reader = reader;
            MaxLength = 1024;
            Buffer = sys.alloc<char>(MaxLength);
        }

        public override bool Next(out char dst)
        {
            var result = false;
            dst = AsciNull.Literal;
            if(IsNonEmpty)
            {
                dst = Buffer[Index++];
                result = true;
            }
            else
            {
                if(!IsDepleted)
                {
                    Length = (uint)Reader.Read(Buffer,0,(int)MaxLength);
                    Index = 0;
                    dst = Buffer[Index++];
                    result = true;
                }
            }
            return result;
        }

        public override void Dispose()
        {
            Reader.Dispose();
        }
    }

}
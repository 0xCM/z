//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct ArgValue
    {
        readonly dynamic Data;

        internal ArgValue(dynamic data)
        {
            Data = data;
        }

        public string Format()
        {
            var dst = EmptyString;
            var kind = Kind();
            if(kind != 0)
                dst = Data.ToString();
            return dst;
        }

        public override string ToString()
            => Format();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == null || (Data is string s && text.empty(s));
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ArgValueKind Kind()
        {
            var kind = ArgValueKind.None;
            if(Data is string)
            {
                kind = ArgValueKind.String;
            }
            else if(Data is FilePath || Data is FileUri)
            {
                kind = ArgValueKind.File;
            }
            else if(Data is FolderPath)
            {
                kind = ArgValueKind.Folder;
            }
            else if(Data is bit)
            {
                kind = ArgValueKind.Bit;
            }
            else if(Data is bool)
            {
                kind = ArgValueKind.Bool;
            }
            else if(Data is int || Data is uint)
            {
                kind = ArgValueKind.Integer;
            }
            return kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(string s)
            => new ArgValue(s);

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(FilePath s)
            => new ArgValue(s);

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(FolderPath s)
            => new ArgValue(s);

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(bool s)
            => new ArgValue(s);

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(bit s)
            => new ArgValue(s);

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(int s)
            => new ArgValue(s);

        [MethodImpl(Inline)]
        public static implicit operator ArgValue(uint s)
            => new ArgValue(s);

        public static ArgValue Empty => new ArgValue(EmptyString);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Drive : IFsEntry<Drive>
    {
        public static Outcome drive(string src, out Drive dst)
        {
            var i = text.index(src, Chars.Colon);
            var result = Outcome.Failure;
            dst = default;
            if(i>=0)
            {
                var spec = text.left(src,i);
                if(spec.Length == 1)
                {
                    var c = spec[0].ToUpper();
                    if(c >= (char)DriveLetter.A && c<= (char)DriveLetter.B)
                    {
                        dst = (DriveLetter)c;
                        result = true;
                    }
                }
            }
            return result;
        }

        public readonly DriveLetter Name;

        PathPart IFsEntry.Name
            => new PathPart(Name.ToString());

        [MethodImpl(Inline)]
        public Drive(DriveLetter name)
            => Name = name;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Char.ToLower((char)Name);
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(Drive src)
            => sys.cmp(Name.ToString(), src.Name.ToString(), uncased());

        [MethodImpl(Inline)]
        public bool Equals(Drive src)
            =>  string.Equals(Name.ToString(), src.Name.ToString(), NoCase);

        [MethodImpl(Inline)]
        public string Format()
            => Name.ToString();

        [MethodImpl(Inline)]
        public static implicit operator Drive(DriveLetter src)
            => new Drive(src);

        public static Drive Empty => default;
    }

}
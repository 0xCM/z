//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures the content of a command-line
    /// </summary>
    public record class CmdLine
    {
        readonly CmdArgs Data;

        [MethodImpl(Inline)]
        public CmdLine(params string[] parts)
        {
            Data = sys.map(parts, x => new CmdArg(x));
        }

        public CmdLine(params CmdArg[] args)
        {
            Data = args;
        }

        public CmdLine(CmdArgs args)
        {
            Data = args;
        }

        public FilePath ExePath 
            => FS.path(Data[0]);

        public CmdArgs Args
            => Data.Skip(1);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public CmdArg this[uint i]
        {
            [MethodImpl(Inline)]
            get => Data[i];
        }

        public CmdArg this[int i]
        {
            [MethodImpl(Inline)]
            get => Data[i];
        }

        public uint PartCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(CmdArg[] src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdLine src)
            => src.Format();

        public static CmdLine Empty
        {
            [MethodImpl(Inline)]
            get => new CmdLine(sys.empty<string>());
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class FileFormat
    {
        public string Name {get;}

        protected FileFormat(string name)
        {
            Name = name;
        }
    }

    public abstract class FileFormat<F> : FileFormat
        where F : FileFormat<F>, new()
    {
        protected FileFormat(string name)
            : base(name)
        {
        }

    }

    public abstract class BinaryFormat<F> : FileFormat<F>
        where F : BinaryFormat<F>, new()
    {
        protected BinaryFormat(string name)
            : base(name)
        {
        }

    }

    public class PeFileFormat : BinaryFormat<PeFileFormat>
    {
        public static bool test(FilePath src)
        {
            const byte Min = Signature.Offset + Signature.Size;
            if(src.Size < Min)
                return false;

            using var reader = src.BinaryReader();
            Span<byte> buffer = stackalloc byte[256];
            var length = reader.Read(buffer);
            var result = false;
            var value = @as<Signature>(slice(buffer,Signature.Offset, Signature.Size));
            result = value == Signature.Value;            
            return result;

        }
        [StructLayout(LayoutKind.Sequential, Size =4)]
        public readonly record struct Signature
        {
            public const byte Offset = 0x3C;

            public const byte Size = 4;

            public static ref readonly Signature Value => ref @as<Signature>(MatchData);

            static ReadOnlySpan<byte> MatchData => new byte[Size]{(byte)AsciCode.P, (byte)AsciCode.E, (byte)AsciCode.Null, (byte)AsciCode.Null};

        }

        public PeFileFormat()
            : base("pe")
        {

        }
    }
}
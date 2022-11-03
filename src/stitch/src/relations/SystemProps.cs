//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SystemProps
    {
        public static Version version(string name, uint a, uint b = 0, uint c = 0, uint d = 0)
            => new Version(name, a, b, c, d);

        public static File file(string name, string value)
            => new File(name, value);

        public static Folder folder(string name, string value)
            => new Folder(name, value);

        public sealed record class Version : SystemProp<Version,(uint,uint,uint,uint)>
        {
            byte PartCount;

            public Version()
            {

            }

            public Version(string name, uint a, uint b, uint c, uint d)
                : base(name, (a,b,c,d))
            {
                PartCount = 4;
            }

            public Version(string name, uint a, uint b, uint c)
                : base(name, (0,a,b,c))
            {
                PartCount = 3;
            }

            uint A => Value.Item1;

            uint B => Value.Item2;

            uint C => Value.Item3;

            uint D => Value.Item4;

            public override bool Parse(string name, string src, out Version dst)
            {
                dst = Default;
                var parts = src.Trim().Split('.');
                var count = parts.Length;
                var result = true;
                switch(count)
                {
                    case 1:
                    break;
                    case 2:
                    break;
                    case 3:
                    break;
                    case 4:
                    break;
                    default:
                        result=false;
                        break;
                }
                return result;
            }

            public override int Hash
                => HashCode.Combine(A,B,C,D);

            public override int GetHashCode()
                => Hash;

            public override string Format()
            {
                var dst = EmptyString;
                if(PartCount == 3)
                    dst = $"{Name}={B}.{C}.{D}";
                else
                    dst = $"{Name}={A}.{B}.{C}.{D}";
                return dst;
            }

            public override bool Equals(Version src)
                => Value == src.Value;

            public override Version Default => default;
        }

        public sealed record class Drive : SystemProp<Drive,DriveLetter>
        {
            public Drive()
            {

            }

            public Drive(string name, DriveLetter letter)
                : base(name,letter)
            {

            }

            public override int Hash
                => (int)Value;

            public override int GetHashCode()
                => Hash;

            public override bool Equals(Drive other)
                => Value == other.Value;

            public override bool Parse(string name, string src, out Drive dst)
            {
                dst = Default;
                var result = false;
                var input = src.Trim();
                if(input.Length == 1)
                {
                    dst = new Drive(name,(DriveLetter)input[0]);
                    result = true;
                }
                return result;
            }

            public override Drive Default
                => new Drive(EmptyString, DriveLetter.a);

            public static implicit operator Drive(SystemProp<DriveLetter> src)
                => new Drive(src.Name, src.Value);
        }

        public sealed record class Folder : SystemProp<Folder,string>
        {
            public Folder()
            {

            }

            public Folder(string name, string value)
                : base(name,value)
            {

            }

            public override bool Parse(string name, string src, out Folder dst)
            {
                dst = new Folder(name.Trim(), src.Trim());
                return true;
            }

            public override int Hash
                => Value.GetHashCode();

            public override int GetHashCode()
                => Hash;

            public override bool Equals(Folder src)
                => Value.ToLower().Equals(src.Value.ToLower());

            public override Folder Default
                => new Folder(EmptyString,EmptyString);

            public static implicit operator Folder(SystemProp<string> src)
                => new Folder(src.Name, src.Value);
        }

        public sealed record class File : SystemProp<File,string>
        {
            public File()
            {

            }

            public File(string name, string value)
                : base(name,value)
            {

            }

            public override bool Parse(string name, string src, out File dst)
            {
                dst = new File(name.Trim(), src.Trim());
                return true;
            }

            public override bool Equals(File src)
                => Value.ToLower().Equals(src.Value.ToLower());

            public override int Hash
                => Value.GetHashCode();

            public override int GetHashCode()
                => Hash;

            public override File Default
                => new File(EmptyString,EmptyString);

            public static implicit operator File(SystemProp<string> src)
                => new File(src.Name, src.Value);
        }
    }
}
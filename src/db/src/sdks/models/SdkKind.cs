//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct SdkKind : ISdkKind<SdkKind>
    {
        public readonly asci16 Name;

        [MethodImpl(Inline)]
        public SdkKind(string name)
        {
            Name = name;
        }

        asci16 ISdkKind.Name 
            => Name;

        public string Format()
            => Name;

        public override string ToString()
            => Name;

        [MethodImpl(Inline)]
        public static implicit operator SdkKind(string name)
            => new SdkKind(name);

    }
}

//K:\dist\dotnet\coreclr\windows.x64.Release
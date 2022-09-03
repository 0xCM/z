//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    /// <summary>
    /// Taken from https://github.com/dotnet/runtime/src/libraries/System.Linq.Expressions/tests/ILReader/DynamicMethodILProvider.cs
    /// </summary>
    public struct DynamicIlProvider
    {
        public DynamicMethod Source {get;}

        public BinaryCode Code {get;}

        public BinaryCode LocalSig {get;}

        public int MaxStackSize {get;}

        public static Outcome create(DynamicMethod src, out DynamicIlProvider dst)
        {
            try
            {
                dst = new DynamicIlProvider(src);
                return true;
            }

            catch(Exception e)
            {
                dst = default;
                return e;
            }
        }

        public DynamicIlProvider(DynamicMethod src)
            : this()
        {
            Source = src;
            Code = GetByteArray(src);
            MaxStackSize = GetMaxStack(src);
            LocalSig = GetLocalSignature(src);
        }

        static byte[] GetByteArray(DynamicMethod src)
        {
            var ilgen = src.GetILGenerator();
            var dst = Array.Empty<byte>();
            try
            {
                var baked = (byte[])s_miBakeByteArray.Invoke(ilgen, null);
                if (baked != null)
                    dst = baked;
            }
            catch (TargetInvocationException)
            {
                var length = (int)s_fiLen.GetValue(ilgen);
                dst = new byte[length];
                Array.Copy((byte[])s_fiStream.GetValue(ilgen), dst, length);
            }

            return dst;
        }

        static byte[] GetLocalSignature(DynamicMethod src)
        {
            ILGenerator ilgen = src.GetILGenerator();
            var sig = (SignatureHelper)s_fiLocalSignature.GetValue(ilgen);
            return sig.GetSignature();
        }

        static int GetMaxStack(DynamicMethod src)
        {
            ILGenerator ilgen = src.GetILGenerator();
            return (int)s_miMaxStackSize.Invoke(ilgen, null);
        }

        static readonly Type IlGeneratorType = typeof(ILGenerator);

        static readonly FieldInfo s_fiLen = Clr.field(IlGeneratorType, "m_length");

        static readonly FieldInfo s_fiStream = Clr.field(IlGeneratorType, "m_ILStream");

        static readonly FieldInfo s_fiExceptions = Clr.field(IlGeneratorType, "m_exceptions");

        static readonly FieldInfo s_fiExceptionCount = Clr.field(IlGeneratorType, "m_exceptionCount");

        static readonly FieldInfo s_fiLocalSignature = Clr.field(IlGeneratorType, "m_localSignature");

        static readonly MethodInfo s_miBakeByteArray = Clr.method(IlGeneratorType, "BakeByteArray");

        static readonly MethodInfo s_miMaxStackSize = Clr.method(IlGeneratorType,"GetMaxStackSize");
    }
}
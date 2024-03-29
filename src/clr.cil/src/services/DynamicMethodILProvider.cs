// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class DynamicMethodILProvider : IILProvider
    {
        static readonly FieldInfo s_fiLen = typeof(ILGenerator).RequireField("m_length");

        static readonly FieldInfo s_fiStream = typeof(ILGenerator).RequireField("m_ILStream");

        static readonly FieldInfo s_fiExceptions = typeof(ILGenerator).RequireField("m_exceptions");

        static readonly FieldInfo s_fiExceptionCount = typeof(ILGenerator).RequireField("m_exceptionCount");

        static readonly FieldInfo s_fiLocalSignature = typeof(ILGenerator).RequireField("m_localSignature");

        static readonly MethodInfo s_miBakeByteArray = typeof(ILGenerator).RequireMethod("BakeByteArray");

        static readonly MethodInfo s_miMaxStackSize = typeof(ILGenerator).RequireMethod("GetMaxStackSize");

        readonly DynamicMethod _method;

        byte[] _byteArray;

        ExceptionInfo[] _exceptionInfo;

        byte[] _localSignature;

        int? _maxStackSize;

        public DynamicMethodILProvider(DynamicMethod method)
        {
            _method = method;
        }

        public byte[] GetByteArray()
        {
            if (_byteArray == null)
            {
                var ilgen = _method.GetILGenerator();
                try
                {
                    _byteArray = (byte[])s_miBakeByteArray.Invoke(ilgen, null);
                    if (_byteArray == null)
                    {
                        _byteArray = Array.Empty<byte>();
                    }
                }
                catch (TargetInvocationException)
                {
                    int length = (int)s_fiLen.GetValue(ilgen);
                    _byteArray = new byte[length];
                    Array.Copy((byte[])s_fiStream.GetValue(ilgen), _byteArray, length);
                }
            }

            return _byteArray;
        }

        public ExceptionInfo[] GetExceptionInfos()
        {
            if (_exceptionInfo == null)
            {
                ILGenerator ilgen = _method.GetILGenerator();

                var n = (int)s_fiExceptionCount.GetValue(ilgen);
                if (n > 0)
                {
                    var exceptions = (Array)s_fiExceptions.GetValue(ilgen);

                    _exceptionInfo = new ExceptionInfo[n];
                    for (var i = 0; i < n; i++)
                        _exceptionInfo[i] = new ExceptionInfo(exceptions.GetValue(i));
                }
                else
                    _exceptionInfo = Array.Empty<ExceptionInfo>();
            }

            return _exceptionInfo;
        }

        public byte[] GetLocalSignature()
        {
            if (_localSignature == null)
            {
                ILGenerator ilgen = _method.GetILGenerator();

                var sig = (SignatureHelper)s_fiLocalSignature.GetValue(ilgen);

                _localSignature = sig.GetSignature();
            }

            return _localSignature;
        }

        public int MaxStackSize
        {
            get
            {
                if (_maxStackSize == null)
                {
                    ILGenerator ilgen = _method.GetILGenerator();
                    _maxStackSize = (int)s_miMaxStackSize.Invoke(ilgen, null);
                }

                return _maxStackSize.Value;
            }
        }
    }
}
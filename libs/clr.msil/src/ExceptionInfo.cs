// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System;
    using System.Reflection;

    public sealed class ExceptionInfo
    {
        static readonly Type s_tyExceptionInfo = Type.GetType("System.Reflection.Emit.__ExceptionInfo", throwOnError: true);
        
        static readonly MethodInfo s_miGetStartAddress = GetMethodInfo(nameof(GetStartAddress));
        
        static readonly MethodInfo s_miGetEndAddress = GetMethodInfo(nameof(GetEndAddress));
        
        static readonly MethodInfo s_miGetNumberOfCatches = GetMethodInfo(nameof(GetNumberOfCatches));
        
        static readonly MethodInfo s_miGetCatchAddresses = GetMethodInfo(nameof(GetCatchAddresses));
        
        static readonly MethodInfo s_miGetCatchEndAddresses = GetMethodInfo(nameof(GetCatchEndAddresses));
        
        static readonly MethodInfo s_miGetCatchClass = GetMethodInfo(nameof(GetCatchClass));
        
        static readonly MethodInfo s_miGetExceptionTypes = GetMethodInfo(nameof(GetExceptionTypes));

        public int StartAddress {get;}
        
        public int EndAddress {get;}
        
        public ExceptionHandlerInfo[] Handlers {get;}

        public int GetStartAddress() 
            => Invoke<int>(s_miGetStartAddress);
        
        public int GetEndAddress() 
            => Invoke<int>(s_miGetEndAddress);
        
        public int GetNumberOfCatches() 
            => Invoke<int>(s_miGetNumberOfCatches);
        
        public int[] GetCatchAddresses() 
            => Invoke<int[]>(s_miGetCatchAddresses);
        
        public int[] GetCatchEndAddresses() 
            => Invoke<int[]>(s_miGetCatchEndAddresses);
        
        public Type[] GetCatchClass() 
            => Invoke<Type[]>(s_miGetCatchClass);
        
        public int[] GetExceptionTypes() 
            => Invoke<int[]>(s_miGetExceptionTypes);

        readonly object _exceptionInfo;

        public ExceptionInfo(object exceptionInfo)
        {
            _exceptionInfo = exceptionInfo;
            StartAddress = GetStartAddress();
            EndAddress = GetEndAddress();

            int n = GetNumberOfCatches();
            if (n > 0)
            {
                int[] handlerStart = GetCatchAddresses();
                int[] handlerEnd = GetCatchEndAddresses();
                Type[] catchType = GetCatchClass();
                int[] types = GetExceptionTypes();

                Handlers = new ExceptionHandlerInfo[n];

                for (var i = 0; i < n; i++)
                {
                    Handlers[i] = new ExceptionHandlerInfo(handlerStart[i], handlerEnd[i], catchType[i], types[i]);
                }
            }
            else
                Handlers = Array.Empty<ExceptionHandlerInfo>();
        }

        static MethodInfo GetMethodInfo(string name) 
            => s_tyExceptionInfo.GetMethodAssert(name);
        
        T Invoke<T>(MethodInfo method, params object[] args) 
            => (T)method.Invoke(_exceptionInfo, args);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfEmissions : IExpr, IDisposable
    {
        void Close();

        ref readonly TableFlow<T> LogEmission<T>(in TableFlow<T> flow);

        ref readonly FileEmission LogEmission(in FileEmission flow);
    }
}
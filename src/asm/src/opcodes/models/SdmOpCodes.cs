//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class SdmOpCodes : AppService<SdmOpCodes>
    {
        const NumericKind Closure = UnsignedInts;

        static readonly AsmOcDatasets _Datasets;

        public static ref readonly AsmOcDatasets Datasets
        {
            [MethodImpl(Inline)]
            get => ref _Datasets;
        }

        static SdmOpCodes()
        {
            _Datasets = AsmOcDatasets.load();
        }

        public SdmOpCodes()
        {

        }

        public static string expression(AsmOcToken src)
        {
            if(src.IsEmpty)
                return EmptyString;

            if(_Datasets.Expressions.Find(src.Id, out var x))
                return x;

            return RP.Error;
        }
   }
}
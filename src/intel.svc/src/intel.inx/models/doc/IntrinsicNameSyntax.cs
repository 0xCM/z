//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntrinsicsDoc
{
    /// <summary>
    /// https://software.intel.com/content/www/us/en/develop/documentation/cpp-compiler-developer-guide-and-reference/top/compiler-reference/intrinsics/intrinsics-for-intel-advanced-vector-extensions-512-intel-avx-512-instructions/overview-intrinsics-for-intel-advanced-vector-extensions-512-intel-avx-512-instructions.html
    /// </summary>
    public struct IntrinsicNameSyntax
    {
        // _mm512[_<maskprefix>]_<intrin_op>_<suffix>

        /// <summary>
        /// When present, indicates write-masked (_mask) or zero-masked (_maskz) predication.
        /// </summary>
        public struct MaskPrefix
        {


        }

        /// <summary>
        /// Indicates the basic operation of the intrinsic
        /// </summary>
        public struct Operation
        {


        }

        public struct Suffix
        {


        }
    }
}

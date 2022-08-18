//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = CreditModel.Chapter;
    using A = CreditModel.Appendix;

    partial class CreditModel
    {
        /// <summary>
        /// Defines division reference component values
        /// </summary>
        public enum Division : byte
        {
            None = 0,

            /// <summary>
            /// Chapter 1
            /// </summary>
            Chapter1 = C.Chapter1,

            /// <summary>
            /// Chapter 2
            /// </summary>
            Chapter2 = C.Chapter2,

            /// <summary>
            /// Chapter 3
            /// </summary>
            Chapter3 = C.Chapter3,

            /// <summary>
            /// Chapter 4
            /// </summary>
            Chapter4 = C.Chapter4,

            /// <summary>
            /// Chapter 5
            /// </summary>
            Chapter5 = C.Chapter5,

            /// <summary>
            /// Chapter 6
            /// </summary>
            Chapter6 = C.Chapter6,

            /// <summary>
            /// Chapter 7
            /// </summary>
            Chapter7 = C.Chapter7,

            /// <summary>
            /// Chapter 8
            /// </summary>
            Chapter8 = C.Chapter8,

            /// <summary>
            /// Chapter 9
            /// </summary>
            Chapter9 = C.Chapter9,

            /// <summary>
            /// Chapter 10
            /// </summary>
            Chapter10 = C.Chapter10,

            /// <summary>
            /// Chapter 11
            /// </summary>
            Chapter11 = C.Chapter11,

            /// <summary>
            /// Chapter 12
            /// </summary>
            Chapter12 = C.Chapter12,

            /// <summary>
            /// Chapter 13
            /// </summary>
            Chapter13 = C.Chapter13,

            /// <summary>
            /// Chapter 14
            /// </summary>
            Chapter14 = C.Chapter14,

            /// <summary>
            /// Chapter 15
            /// </summary>
            Chapter15 = C.Chapter15,

            /// <summary>
            /// Appendix A
            /// </summary>
            AppendixA = A.AppendixA,

            /// <summary>
            /// Appendix B
            /// </summary>
            AppendixB = A.AppendixB,

            /// <summary>
            /// Appendix C
            /// </summary>
            AppendixC = A.AppendixC,

            /// <summary>
            /// Appendix D
            /// </summary>
            AppendixD = A.AppendixD,

            /// <summary>
            /// Appendix E
            /// </summary>
            AppendixE = A.AppendixE,

            /// <summary>
            /// Appendix F
            /// </summary>
            AppendixF = A.AppendixF
        }
    }
}
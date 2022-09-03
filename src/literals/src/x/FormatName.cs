//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static string FormatName(this NativeTypeWidth w, bool lowercase = false)
            => w != 0 ? (lowercase ?  w.ToString().ToLowerInvariant() : w.ToString()) : EmptyString;

        public static string FormatName(this DataWidth w, bool lowercase = false)
            => w != 0 ? (lowercase ?  w.ToString().ToLowerInvariant() : w.ToString()) : EmptyString;

        public static string FormatName(this NumericWidth w, bool lowercase = false)
            => w != 0 ? (lowercase ?  w.ToString().ToLowerInvariant() : w.ToString()) : EmptyString;

        public static string FormatName(this CpuCellWidth w, bool lowercase = false)
            => w != 0 ? (lowercase ?  w.ToString().ToLowerInvariant() : w.ToString()) : EmptyString;

        public static string FormatName(this NativeVectorWidth w, bool lowercase = false)
            => w != 0 ? (lowercase ?  w.ToString().ToLowerInvariant() : w.ToString()) : EmptyString;
    }
}
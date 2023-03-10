//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public interface IBinaryFormat
    {
        ReadOnlySeq<StreamFormat> Streams {get;}

        ReadOnlySeq<SegmentFormat> Segments {get;}
    }   

    public readonly struct SegmentFormat
    {

    }

    public readonly struct StreamFormat
    {

    }   
}
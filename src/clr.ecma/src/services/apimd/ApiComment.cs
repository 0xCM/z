//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Record(TableId)]
public struct ApiComment : IComparable<ApiComment>
{
    const string TableId = "api.comments";

    [Render(12)]
    public readonly ApiCommentTarget Target;

    [Render(140)]
    public readonly @string TargetName;

    [Render(1)]
    public readonly @string Summary;

    [MethodImpl(Inline)]
    public ApiComment(ApiCommentTarget target, string name, string summary)
    {
        Target = target;
        TargetName = XmlCommentData.TypeDisplayName(name);
        Summary = summary;
    }

    public int CompareTo(ApiComment src)
    {
        var result = TargetName.CompareTo(src.TargetName);
        if(result == 0)
            result = ((byte)Target).CompareTo((byte)src.Target);
        return result;
    }

    public static ApiComment Empty => new ApiComment(0, EmptyString, EmptyString);
}

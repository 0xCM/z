//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiComments;

    /// <summary>
    ///
    /// </summary>
    [Record(TableId)]
    public struct ApiComment
    {
        const string TableId = "api.comments";

        [Render(12)]
        public ApiCommentTarget Target;

        [Render(140)]
        public string TargetName;

        [Render(1)]
        public string Summary;

        [MethodImpl(Inline)]
        public ApiComment(ApiCommentTarget target, string name, string summary)
        {
            Target = target;
            TargetName = CommentDataset.TypeDisplayName(name);
            Summary = summary;
        }

        public static ApiComment Empty => new ApiComment(0, EmptyString, EmptyString);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        public static OpUri Uri(this MethodInfo src)
            => ApiIdentity.from(src);
    }

    [ApiHost]
    public readonly partial struct ApiIdentity
    {
        /// <summary>
        /// Extracts an 8-bit immediate value from an identity if it contains an immediate suffix; otherwise, returns none
        /// </summary>
        /// <param name="src">The source identity</param>
        [MethodImpl(Inline), Op]
        public static Option<byte> imm8(OpIdentity src)
        {
            if(src.HasImm && byte.TryParse(src.IdentityText.RightOfLast(IDI.Imm), out var immval))
                return immval;
            else
                return Option.none<byte>();
        }

        [Op]
        public static OpUri from(MethodInfo src)
            => define(ApiUriScheme.Located, ApiIdentity.host(src.DeclaringType), src.Name, ApiIdentity.identify(src));

        [Op]
        public static OpUri define(ApiUriScheme scheme, ApiHostUri host, string group, OpIdentity opid)
            => new OpUri(host, opid, BuildUriText(scheme, host, group, opid));

        [Op]
        public static OpUri hex(ApiHostUri host, string group, OpIdentity opid)
            => new OpUri(host, opid, BuildUriText(ApiUriScheme.Hex, host, group, opid));

        // [MethodImpl(Inline), Op]
        // public static OpUri located(ApiHostUri host, string group, OpIdentity opid)
        //     => new OpUri(host, opid, BuildUriText(ApiUriScheme.Located, host, group, opid));

        [Op]
        public static string QueryText(ApiUriScheme scheme, PartName part, string host, string group)
            => $"{scheme.Format()}{IDI.EndOfScheme}{part.Format()}{IDI.UriPathSep}{host}{IDI.UriQuery}{group}";

        [Op]
        public static string FullUriText(ApiUriScheme scheme, PartName part, string host, string group, OpIdentity opid)
            => $"{scheme.Format()}{IDI.EndOfScheme}{part.Format()}{IDI.UriPathSep}{host}{IDI.UriQuery}{group}{IDI.UriFragment}{opid.IdentityText}";

        public static ApiUriScheme scheme(string src)
            => Enum.TryParse(typeof(ApiUriScheme), src, true, out var result) ? (ApiUriScheme)result : ApiUriScheme.None;

        public static ParseResult<ApiHostUri> host(string src)
        {
            var failure = ParseResult.unparsed<ApiHostUri>(src);
            if(blank(src))
                return failure;

            var parts = src.SplitClean(IDI.UriPathSep);
            var count = parts.Length;
            if(count != 2)
                return failure.WithReason(string.Concat("Component count ", count," != ", 2));

            if(!ApiParsers.part(skip(parts,0), out PartName owner))
                return failure.WithReason("Invalid part");

            var host = skip(parts,1);
            if(blank(host))
                return failure.WithReason("Host unspecified");

            return ParseResult.parsed(src, new ApiHostUri(owner, host));
        }

        // public static Outcome host(string src, out ApiHostUri dst)
        // {
        //     var result = Outcome.Success;
        //     dst = ApiHostUri.Empty;
        //     if(blank(src))
        //         return (false, "Empty input");

        //     var parts = src.SplitClean(IDI.UriPathSep);
        //     var count = parts.Length;
        //     if(count != 2)
        //         return (false,string.Concat("Component count ", count," != ", 2));

        //     Enum.TryParse(skip(parts,0), true, out PartId part);
        //     if(part == 0)
        //         return (false, string.Format("Invalid part '{0}'", skip(parts,0)));

        //     var host = skip(parts,1);
        //     if(blank(host))
        //         return (false, "Host unspecified");

        //     dst = new ApiHostUri(part,host);

        //     return result;
        // }

        // public static Outcome host2(string uri, out ApiHostUri dst)
        // {
        //     const string UriMarker = "://";
        //     var result = Outcome.Failure;
        //     dst = ApiHostUri.Empty;
        //     var i = text.index(uri,UriMarker);
        //     if(i > 0)
        //     {
        //         var j = text.index(uri, Chars.Question);
        //         if(j > i)
        //         {
        //             var x = text.inside(uri,i + UriMarker.Length - 1, j);
        //             var components = text.split(x,Chars.FSlash);
        //             if(components.Length == 2)
        //             {
        //                 var part = ApiParsers.part(skip(components,0));
        //                 dst = ApiIdentity.host(part, skip(components,1));
        //                 result = true;
        //             }
        //         }
        //     }
        //     return result;
        // }

        // public static OpIdentity opid_define(string src)
        //     => new OpIdentity(OpIdentity.safe(src));

        [Op]
        public static OpIdentity opid(string src)
        {
            try
            {
                if(empty(src))
                    return OpIdentity.Empty;

                var name = OpIdentity.safe(text.trim(src.TakeBefore(IDI.PartSep)));
                var suffixed = src.Contains(IDI.SuffixSep);
                var suffix = text.trim(suffixed ? src.TakeAfter(IDI.SuffixSep) : EmptyString);
                var _generic = src.TakeAfter(IDI.PartSep);
                var generic =  nonempty(_generic) ? _generic[0] == IDI.Generic : false;
                var imm = suffix.Contains(IDI.Imm);
                var components = core.map(src.SplitClean(IDI.PartSep), OpIdentity.safe);
                var data = OpIdentity.safe(text.trim(src));
                return new OpIdentity(data, name, suffix, generic, imm, components);
            }
            catch(Exception)
            {
                throw new Exception(string.Format("Unable to created identity for {0}", src));
            }
        }

        public static ParseResult<OpUri> parse(string src)
        {
            var parts = src.SplitClean(IDI.EndOfScheme);
            var msg = string.Empty;
            if(parts.Length != 2)
                return ParseResult.unparsed<OpUri>(src, $"Splitting on {IDI.EndOfScheme} produced {parts.Length} pieces");

            var uriScheme = scheme(parts[0]);
            var rest = parts[1];
            var pathText = rest.TakeBefore(IDI.UriQuery);
            var path = host(pathText);
            if(path.Failed)
                return ParseResult.unparsed<OpUri>(src, $"{path.Message}");

            var id = opid(rest.TakeAfter(IDI.UriFragment));
            var group = rest.Between(IDI.UriQuery,IDI.UriFragment);
            var uri = define(uriScheme, path.Value, group, id);
            return ParseResult.parsed(src, uri);
        }

        [Parser]
        public static Outcome parse(string src, out OpUri dst)
        {
            var result = parse(src);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = OpUri.Empty;
                return false;
            }
        }

        /// <summary>
        /// Defines an 8-bit immediate suffix predicated on an immediate value
        /// </summary>
        /// <param name="imm8">The source immediate</param>
        public static string Imm8Suffix(byte imm8)
            => $"{IDI.SuffixSep}{IDI.Imm}{imm8}";

        // [Op]
        // public static string PathText(string scheme, PartId catalog, string host)
        //     => $"{scheme}{IDI.EndOfScheme}{catalog.Format()}{IDI.UriPathSep}{host}";

        // [Op]
        // public static string GroupUriText(ApiUriScheme scheme, ApiHostUri host, string group)
        //     => QueryText(scheme, host.Part, host.HostName, group);

        // [Op]
        // public static string HostUri(Type host)
        //     => $"{PartNames.name(host)}{IDI.UriPathSep}{host.Name}";

        /// <summary>
        /// Builds the *canonical* operation uri
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="host"></param>
        /// <param name="group"></param>
        /// <param name="opid"></param>
        [Op]
        static string BuildUriText(ApiUriScheme scheme, ApiHostUri host, string group, OpIdentity opid)
            => (opid.IsEmpty
                ? QueryText(scheme, host.Part, host.HostName, group)
                : FullUriText(scheme, host.Part, host.HostName, group, opid)).Trim();
        /// <summary>
        /// Assigns identity to each value parameter (not to be confused with type parametricity) declared by a method
        /// </summary>
        /// <param name="src">The source method</param>
        static IEnumerable<string> ValueParamIdentities(MethodInfo src)
        {
            var args = src.GetParameters();
            var argtypes = src.ParameterTypes(true);
            for(var i=0; i<argtypes.Length; i++)
            {
                var argtext = parameter(args[i]);
                if(argtext.IsNotBlank())
                    yield return argtext;
            }
        }

        /// <summary>
        /// Assigns identity to each type argument supplied to close a generic method
        /// </summary>
        /// <param name="src">The constructed generic method</param>
        static IEnumerable<string> TypeArgIdentities(MethodInfo src)
            => src.GenericArguments().Select(arg => ApiIdentity.identify(arg).IdentityText);

        /// <summary>
        /// Assigns aggregate identity to the type argument sequence that closes a generic method
        /// </summary>
        /// <param name="src">The constructed generic method</param>
        static string TypeArgIdentity(MethodInfo src)
            => sequential(IDI.TypeArgsOpen, IDI.TypeArgsClose, IDI.ArgSep, TypeArgIdentities(src));

        /// <summary>
        /// Assigns aggregate identity to a method's value parameter sequence
        /// </summary>
        /// <param name="src">The source method</param>
        static string ValueParamIdentity(MethodInfo src)
            => sequential(IDI.ArgsOpen, IDI.ArgsClose, IDI.ArgSep, ValueParamIdentities(src));
    }
}
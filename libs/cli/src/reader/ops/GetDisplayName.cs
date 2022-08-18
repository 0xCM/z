//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  Apache 2.0
// Origin      : https://github.com/dotnet/symreader-converter/src/Microsoft.DiaSymReader.Converter/Utilities/AssemblyDisplayNameBuilder.cs
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial class CliReader
    {
        public string GetDisplayName(AssemblyReference src)
        {
            var nameStr = MD.GetString(src.Name);
            var cultureName = src.Culture.IsNil ? EmptyString : MD.GetString(src.Culture);
            var publicKeyOrToken = MD.GetBlobContent(src.PublicKeyOrToken);
            bool hasPublicKey = (src.Flags & AssemblyFlags.PublicKey) != 0;
            return BuildDisplayName(
                name: nameStr,
                version: src.Version,
                cultureName: cultureName,
                publicKeyOrToken: publicKeyOrToken,
                hasPublicKey: hasPublicKey,
                isRetargetable: (src.Flags & AssemblyFlags.Retargetable) != 0,
                contentType: (AssemblyContentType)((int)(src.Flags & AssemblyFlags.ContentTypeMask) >> 9));
        }

        static string BuildDisplayName(string name, Version version, string cultureName, ImmutableArray<byte> publicKeyOrToken,
            bool hasPublicKey, bool isRetargetable, AssemblyContentType contentType)
        {
            const string InvariantCultureDisplay = "neutral";

            var sb = new StringBuilder();
            EscapeName(sb, name);

            sb.Append(", Version=");
            sb.Append(version.Major);
            sb.Append(".");
            sb.Append(version.Minor);
            sb.Append(".");
            sb.Append(version.Build);
            sb.Append(".");
            sb.Append(version.Revision);

            sb.Append(", Culture=");
            if (cultureName.Length == 0)
                sb.Append(InvariantCultureDisplay);
            else
                EscapeName(sb, cultureName);

            if (hasPublicKey)
            {
                sb.Append(", PublicKey=");
                AppendKey(sb, publicKeyOrToken);
            }
            else
            {
                sb.Append(", PublicKeyToken=");
                if (publicKeyOrToken.Length > 0)
                    AppendKey(sb, publicKeyOrToken);
                else
                    sb.Append("null");
            }

            if (isRetargetable)
                sb.Append(", Retargetable=Yes");

            switch (contentType)
            {
                case AssemblyContentType.Default:
                    break;

                case AssemblyContentType.WindowsRuntime:
                    sb.Append(", ContentType=WindowsRuntime");
                    break;

                default:
                    Errors.Throw(string.Format("The content type {0} was not anticipated",contentType));
                    break;
            }

            return sb.ToString();
        }

        static void AppendKey(StringBuilder sb, ImmutableArray<byte> key)
        {
            foreach (byte b in key)
                sb.Append(b.ToString("x2"));
        }

        static void EscapeName(StringBuilder result, string name)
        {
            bool quoted = false;
            if (IsWhiteSpace(name[0]) || IsWhiteSpace(name[name.Length - 1]))
            {
                result.Append('"');
                quoted = true;
            }

            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                switch (c)
                {
                    case ',':
                    case '=':
                    case '\\':
                    case '"':
                    case '\'':
                        result.Append('\\');
                        result.Append(c);
                        break;

                    case '\t':
                        result.Append("\\t");
                        break;

                    case '\r':
                        result.Append("\\r");
                        break;

                    case '\n':
                        result.Append("\\n");
                        break;

                    default:
                        result.Append(c);
                        break;
                }
            }

            if (quoted)
            {
                result.Append('"');
            }
        }

        static bool IsWhiteSpace(char c)
            => c == ' ' || c == '\t' || c == '\r' || c == '\n';
    }
}
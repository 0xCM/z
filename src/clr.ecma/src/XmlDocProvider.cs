//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/source-indexer
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;
    using System.Threading;
    using System.Xml.Linq;

    public class XmlDocProvider : DocumentationProvider
    {
        public static XmlDocProvider create(FilePath src)
            => new XmlDocProvider(src.Name);

        readonly Dictionary<string, string> members = new Dictionary<string, string>();

        public XmlDocProvider(string filePath)
        {
            var xmlDocFile = XDocument.Load(filePath);
            foreach (var member in xmlDocFile.Descendants("member"))
            {
                var id = member.Attribute("name").Value;
                var value = member.ToString();

                // there might be multiple entries with same id, just pick one at random
                members[id] = value;
            }
        }

        protected override string GetDocumentationForSymbol(string documentationMemberID, CultureInfo preferredCulture, CancellationToken cancellationToken = default(CancellationToken))
        {
            members.TryGetValue(documentationMemberID, out string result);
            return result;
        }

        public override int GetHashCode()
        {
            return members.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }
    }
}
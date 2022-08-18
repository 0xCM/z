//-----------------------------------------------------------------------------
// Copyright   :  Microsoft
// License     :  MIT
// Source      : Adapted from the tools CLI repo;
//             : see https://github.com/dotnet/core-setup/blob/master/src/corehost/cli/fxr/fx_ver.cpp
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly record struct BuildVersions
    {
        public static string GetId(string ids, int idStart)
        {
            int next = ids.IndexOf('.', idStart);
            return next == -1 ? ids.Substring(idStart) : ids.Substring(idStart, next - idStart);
        }

        [MethodImpl(Inline), Op]
        public static bool ValidIdentifierCharSet(string id)
        {
            // ids must be of the set [0-9a-zA-Z-]

            // ASCII and Unicode ordering
            for (int i = 0; i < id.Length; ++i)
            {
                if (id[i] >= 'A')
                {
                    if ((id[i] > 'Z' && id[i] < 'a') || id[i] > 'z')
                    {
                        return false;
                    }
                }
                else
                {
                    if ((id[i] < '0' && id[i] != '-') || id[i] > '9')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool ValidIdentifier(string id, bool buildMeta)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Identifier must not be empty
                return false;
            }

            if (!ValidIdentifierCharSet(id))
            {
                // ids must be of the set [0-9a-zA-Z-]
                return false;
            }

            int ignored;
            if (!buildMeta && id[0] == '0' && id.Length > 1 && int.TryParse(id, out ignored))
            {
                // numeric identifiers must not be padded with 0s
                return false;
            }
            return true;
        }

        public static bool ValidIdentifiers(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return true;
            }

            bool prerelease = ids[0] == '-';
            bool buildMeta = ids[0] == '+';

            if (!(prerelease || buildMeta))
            {
                // ids must start with '-' or '+' for prerelease & build respectively
                return false;
            }

            int idStart = 1;
            int nextId;
            while ((nextId = ids.IndexOf('.', idStart)) != -1)
            {
                if (!ValidIdentifier(ids.Substring(idStart, nextId - idStart), buildMeta))
                    return false;
                idStart = nextId + 1;
            }

            if (!ValidIdentifier(ids.Substring(idStart), buildMeta))
                return false;

            return true;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfNonNumeric(string s, int startIndex)
        {
            for (int i = startIndex; i < s.Length; ++i)
            {
                if ((s[i] < '0') || (s[i] > '9'))
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool parse(string fxVersionString, out BuildVersion dst)
        {
            dst = default;
            if (string.IsNullOrEmpty(fxVersionString))
            {
                return false;
            }

            int majorSeparator = fxVersionString.IndexOf(".");
            if (majorSeparator == -1)
            {
                return false;
            }

            int major = 0;
            if (!int.TryParse(fxVersionString.Substring(0, majorSeparator), out major))
            {
                return false;
            }
            if (majorSeparator > 1 && fxVersionString[0] == '0')
            {
                // if leading character is 0, and strlen > 1
                // then the numeric substring has leading zeroes which is prohibited by the specification.
                return false;
            }

            int minorStart = majorSeparator + 1;
            int minorSeparator = fxVersionString.IndexOf(".", minorStart);
            if (minorSeparator == -1)
            {
                return false;
            }

            int minor = 0;
            if (!int.TryParse(fxVersionString.Substring(minorStart, minorSeparator - minorStart), out minor))
            {
                return false;
            }
            if (minorSeparator - minorStart > 1 && fxVersionString[minorStart] == '0')
            {
                // if leading character is 0, and strlen > 1
                // then the numeric substring has leading zeroes which is prohibited by the specification.
                return false;
            }

            int patch = 0;
            int patchStart = minorSeparator + 1;
            int patchSeparator = IndexOfNonNumeric(fxVersionString, patchStart);
            if (patchSeparator == -1)
            {
                if (!int.TryParse(fxVersionString.Substring(patchStart), out patch))
                {
                    return false;
                }
                if (patchStart + 1 < fxVersionString.Length && fxVersionString[patchStart] == '0')
                {
                    // if leading character is 0, and strlen != 1
                    // then the numeric substring has leading zeroes which is prohibited by the specification.
                    return false;
                }

                dst = new BuildVersion(major, minor, patch);
                return true;
            }

            if (!int.TryParse(fxVersionString.Substring(patchStart, patchSeparator - patchStart), out patch))
                return false;
            if (patchSeparator - patchStart > 1 && fxVersionString[patchStart] == '0')
                return false;

            int preStart = patchSeparator;
            int preSeparator = fxVersionString.IndexOf("+", preStart);

            string pre = (preSeparator == -1) ? fxVersionString.Substring(preStart) : fxVersionString.Substring(preStart, preSeparator - preStart);

            if (!ValidIdentifiers(pre))
            {
                return false;
            }

            string build = "";
            if (preSeparator != -1)
            {
                build = fxVersionString.Substring(preSeparator);
                if (!ValidIdentifiers(build))
                {
                    return false;
                }
            }

            dst = new BuildVersion(major, minor, patch);

            return true;
        }
    }
}
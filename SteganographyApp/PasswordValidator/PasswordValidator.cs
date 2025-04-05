using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteganographyApp.PasswordValidator
{
    internal class PasswordValidator
    {
        internal static List<string> IsValidPasswordSegment(string segment, int size)
        {
            List<string> results = new List<string>();
            results.Add("None");

            bool hasUpper = Regex.IsMatch(segment, "[A-Z]");
            bool hasLower = Regex.IsMatch(segment, "[a-z]");
            bool hasDigit = Regex.IsMatch(segment, @"\d");
            bool hasSpecial = Regex.IsMatch(segment, "[^A-Za-z0-9]");

            if (!hasUpper)
            {
                results.Add("No Upper");
            }
            if (!hasLower)
            {
                results.Add("No Lower");
            }
            if (!hasDigit)
            {
                results.Add("No Digit");
            }
            if (!hasSpecial)
            {
                results.Add("No Special");
            }

            if (results.Count > 1)
            {
                results.Remove("None");
            }

            return results;
        }

        internal static string CreateValidPassword(string segment, List<string> reasons, string section)
        {
            string validPassword = segment;
            int index;
            List<int> indexToReplace = new List<int>();
            string replacementString;

            List<string> passwordSegments = new List<string>
            {
                "Aa1!",
                "Bb2$",
                "Cc3&",
                "Dd4*",
                "Ee5(",
                "Ff6)",
                "Gg7-",
                "Hh8+",
                "Ii9=",
                "Jj0?",
                "Kk1!",
                "Ll2$",
                "Mm3&",
                "Nn4*",
                "Oo5(",
                "Pp6)",
                "Qq7-",
                "Rr8+",
                "Ss9=",
                "Tt0?",
                "Uu1!",
                "Vv2$",
                "Ww3&",
                "Xx4*",
                "Yy5(",
                "Zz6!"
            };

            index = GetIndex(section);
            replacementString = passwordSegments[index];


            for (int i = 0; i < reasons.Count(); ++i)
            {
                indexToReplace.Add(IndexToReplace(segment, indexToReplace));
            }

            if (reasons.Contains("No Upper"))
            {
                validPassword = ReplaceChar(validPassword, replacementString, indexToReplace[0], 0);
                indexToReplace.RemoveAt(0);
            }
            if (reasons.Contains("No Lower"))
            {
                validPassword = ReplaceChar(validPassword, replacementString, indexToReplace[0], 1);
                indexToReplace.RemoveAt(0);
            }
            if (reasons.Contains("No Digit"))
            {
                validPassword = ReplaceChar(validPassword, replacementString, indexToReplace[0], 2);
                indexToReplace.RemoveAt(0);
            }
            if (reasons.Contains("No Special"))
            {
                validPassword = ReplaceChar(validPassword, replacementString, indexToReplace[0], 3);
                indexToReplace.RemoveAt(0);
            }

            return validPassword;
        }

        private static int GetIndex(string section)
        {
            int hash = 0;
            int index;

            hash = section.GetHashCode() & 0x7FFFFFFF;

            index = hash % 26;

            return index;
        }

        private static int IndexToReplace(string segment, List<int> indexAlreadyFound)
        {
            int upperCount = 0, lowerCount = 0, digitCount = 0, specialCount = 0;

            for (int i = 0; i < segment.Length; i++)
            {
                char c = segment[i];
                if (char.IsUpper(c))
                {
                    upperCount++;
                    if (upperCount == 2 && !indexAlreadyFound.Contains(i))
                    {
                        return i;
                    }
                }
                else if (char.IsLower(c))
                {
                    lowerCount++;
                    if (lowerCount == 2 && !indexAlreadyFound.Contains(i))
                    {
                        return i;
                    }
                }
                else if (char.IsDigit(c))
                {
                    digitCount++;
                    if (digitCount == 2 && !indexAlreadyFound.Contains(i))
                    {
                        return i;
                    }
                }
                else
                {
                    specialCount++;
                    if (specialCount == 2 && !indexAlreadyFound.Contains(i))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private static string ReplaceChar(string segment, string replacement, int replacementIndex, int index)
        {
            char[] chars = segment.ToCharArray();
            chars[replacementIndex] = replacement[index];
            return new string(chars);
        }
    }
}

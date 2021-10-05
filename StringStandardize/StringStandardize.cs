using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Toolkit
{
    public class StringStandardize
    {
        public static string[] SplitName(string Name, params char[] SplitBy)
        {
            string[] splitName = Name.Split(SplitBy);
            return splitName;
        }
        public static string NameStandardize(string Name)
        {
            string standardizedName;
            standardizedName = Name.Trim();
            standardizedName = RemoveSpace(standardizedName);
            standardizedName = UpperFirst(standardizedName);
            return standardizedName;
        }
        public static string RemoveSpace(string Text)
        {
            while (Text.Contains("  "))
            {
                Text = Text.Replace("  ", " ");
            }
            return Text;
        }
        public static string UpperFirst(string Name)
        {
            return Regex.Replace(Name, @"\s\S|^\S", (Match match) =>
            {
                string v = match.ToString();
                return v.Length == 2 ? v.Substring(0, 1) + char.ToUpper(v[1]) : char.ToUpper(v[0]).ToString();
            });
        }
        public static string Join(string[] Array, string JoinWith)
        {
            string Result = "";
            for (int i = 0; i < Array.Length - 1; i++)
            {
                Result += Array[i] + JoinWith;
            }
            Result += Array[Array.Length - 1];
            return Result;
        }
        public static string AddressStandardize(string Address, Dictionary<string, string[]> pattern, params char[] SplitBy)
        {
            string Value;
            foreach (var item in pattern)
            {
                Value = "";
                for (int j = 0; j < item.Value.Length; j++)
                {
                    Value = item.Value[j];
                    Address = Regex.Replace(Address, $"{Value}", (match) =>
                        {
                            return item.Key;
                        });
                }
            }
            string[] temp = Address.Split(SplitBy);
            Address = Join(temp, ", ");
            Address = Regex.Replace(Address, @"\.+", (match) =>
            {
                return ".";
            });
            return Address;
        }
        public string Change_AV(string ip_str_change)
        {
            Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = ip_str_change.Normalize(NormalizationForm.FormD);
            return v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}

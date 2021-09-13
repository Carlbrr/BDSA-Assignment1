using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            Regex rx = new Regex(@"\w+", RegexOptions.IgnorePatternWhitespace);

            foreach (var i in lines)
            {
                foreach (Match m in rx.Matches(i))
                {
                    yield return m.Value;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            IEnumerable<string> splitStrings = SplitLine(resolutions);

            Regex rx = new Regex(@"([0-9].*)x([0-9].*)", RegexOptions.IgnorePatternWhitespace);
            foreach (var i in splitStrings){
                foreach (Match match in rx.Matches(i)){
                    yield return (Int32.Parse(match.Groups[1].Value), Int32.Parse(match.Groups[2].Value));
                }
            }

        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            Regex rx = new Regex(@"<" + tag + "[^>]*>(.*?)</" + tag + ">");
            foreach (Match match in rx.Matches(html))
            {
                yield return match.Groups[1].Value;
            }
        }
    }
}

/*          
            bool inTag = false;
            List<string> hk = new List<string>();

            Regex rx = new Regex(@"<" + tag + "[^>]*>(.*?)</" + tag + ">");
            foreach (Match match in rx.Matches(html))
            {
                hk.Add(match.Groups[1].Value);
            }

            foreach (var match in hk)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var c in match.Split(""))
                {
                    if(c == "<") inTag = true;
                    if(c == ">") inTag = false;

                    if(false){
                        sb.Append(c);
                    }
                }
                yield return sb.ToString;
            }
*/

// regex som finder tags og defter kan man sortere efter de forskellige tag


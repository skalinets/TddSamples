using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground.Legacy
{
    public class HugeAndScarryLegacyCode
    {
        public static string TheUgliesMethodYouMightEverSeen(string s, int i, char c)
        {
            if (s.Length > 5)
            {
                s += "_some_suffix";
            }

            var r = new StringBuilder();

            foreach (var k in s)
            {
                if ((int)k % i == 0)
                {
                    r.Append(c);
                }
                else
                {
                    if (k == c)
                    {
                        if (r.Length <= 2)
                        {
                            //r.Append('a');
                        }
                        else
                        {
                            r.Append('b');
                        }
                    }
                    if (k == '^')
                    {
                        //r.Replace('a', 'b');
                    }
                    else
                    {
                        r.Replace('b', 'a');
                    }
                }
            }

            return r.ToString();
        }
    }
}

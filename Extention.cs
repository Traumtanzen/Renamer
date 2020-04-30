using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace Renamer
{
    public static class ListExt
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        static extern int StrCmpLogicalW(string lhs, string rhs);

        public static void SortNatural<T>(this List<T> self, Func<T, string> stringSelector)
        {
            self.Sort((lhs, rhs) => StrCmpLogicalW(stringSelector(lhs), stringSelector(rhs)));
        }

        public static void SortNatural(this List<string> self)
        {
            self.Sort(StrCmpLogicalW);
        }
    }
}

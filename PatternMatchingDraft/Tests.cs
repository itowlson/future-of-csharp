using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingDraft
{
    // NOTE: THIS IS NOT PLANNED FOR C# vNext.  IT MAY NEVER HAPPEN
    // AT ALL.  NOTHING HERE INDICATES MICROSOFT'S INTENT TO INCLUDE
    // THESE FEATURES IN ANY FUTURE VERSION OF THE LANGUAGE.  MR
    // GAFTER, HE'S MAYBE JUST FUNNIN' WITH YOU FOLKS, OKAY?
    
    public static class Tests
    {
        public static void RecordMatching()
        {
            Cartesian c = new Cartesian(3.0, 4.0);

            if (c is Cartesian(3.0, *))
            {
                Console.WriteLine("fabric of space time still intact");
            }
        }

        public static void MatchingUsingOperatorIs()
        {
            for (int x = 0; x < 1.0; x += 0.05)
            {
                if (new Cartesian(x, 0.5) is WithinUnitCircle())
                {
                    Console.WriteLine(x + " is in unit circle");
                } 
            }
        }

        public static void ConversionByPatterns()
        {
            Cartesian c = new Cartesian(3.0, 4.0);

            if (c is Polar(var r, *))
            {
                Console.WriteLine("magnitude = " + r);
            }
        }

        public static void TypePattern(object o)
        {
            if (o is int i)
            {
                Console.WriteLine("integer " + i);
            }
            else if (o is string s)
            {
                Console.WriteLine("string length " + s.Length);
            }
        }

        public static void NullableTypeSafeExtraction(int? maybeInt)
        {
            if (maybeInt is int i)
            {
                Console.WriteLine(i);
            }
        }

        public static void SwitchOnPatterns_Type(object o)
        {
            switch (o)
            {
                case int i:
                    Console.WriteLine(i);
                    break;
                case string s:
                    Console.WriteLine(s.Length);
                    break;
            }
        }

        public static double SwitchOnPatterns_Classes(Cartesian pt)
        {
            switch (pt)
            {
                case Cartesian(0.0, 0.0): return 0;
                case Polar(r, *): return r;
                default: throw new Exception("fabric of space time damaged - fetch puncture repair kit");
            }
        }
    }
}

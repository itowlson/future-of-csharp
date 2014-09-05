using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingDraft
{
    // http://roslyn.codeplex.com/discussions/560339

    // NOTE: THIS IS NOT PLANNED FOR C# vNext.  IT MAY NEVER HAPPEN
    // AT ALL.  NOTHING HERE INDICATES MICROSOFT'S INTENT TO INCLUDE
    // THESE FEATURES IN ANY FUTURE VERSION OF THE LANGUAGE.  PLEASE
    // STOP CHEWING MY LEG, MR LAWYER.
    
    // Record class - plain old data + automatically matchable

    public record class Cartesian(double x: X, double y: Y);

    // Static class defining operator is - allows matching and optional conversion

    public static class WithinUnitCircle
    {
        public static bool operator is(Cartesian c)
        {
            return (c.X * c.X + c.Y * c.Y) <= 1.0;
        }
    }

    public static class Polar
    {
        public static bool operator is(Cartesian c, out double R, out double Theta)
        {
            R = Math.Sqrt(c.X * c.X + c.Y * c.Y);
            Theta = Math.Atan2(c.Y, c.X);
            return c.X != 0 || c.Y != 0;
        }
    }
}

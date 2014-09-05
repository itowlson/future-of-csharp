using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingDraft
{
    // NOTE: THIS IS NOT PLANNED FOR C# vNext.  IT MAY NEVER HAPPEN
    // AT ALL.  NOTHING HERE INDICATES MICROSOFT'S INTENT TO INCLUDE
    // THESE FEATURES IN ANY FUTURE VERSION OF THE LANGUAGE.  BUT IT
    // WOULD BE RUDE NOT TO MENTION THAT THESE FEATURES *DO*
    // EXIST IN F# RIGHT NOW.  PATTERN MATCHING AND ACTIVE PATTERNS.
    // YOU CAN LOOK 'EM UP.  THEY'RE PRETTY SWEET.

    abstract class Expr;
    record class X() : Expr;
    record class Const(double Value) : Expr;
    record class Add(Expr Left, Expr Right) : Expr;
    record class Mult(Expr Left, Expr Right) : Expr;
    record class Neg(Expr Value) : Expr; 

    public static class ExprExtensions
    {
        public static Expr Derivative(this Expr e)
        {
            switch (e)
            {
                case X():
                    return Const(1);
                case Const(*):
                    return Const(0);
                case Add(var Left, var Right):
                    return Add(Deriv(Left), Deriv(Right));
                case Mult(var Left, var Right):
                    return Add(Mult(Deriv(Left), Right), Mult(Left, Deriv(Right)));
                case Neg(var Value):
                    return Neg(Deriv(Value));
            }
        }

        public static Expr Simplify(this Expr e)
        {
            switch (e)
            {
                case Mult(Const(0), *): return Const(0);
                case Mult(*, Const(0)): return Const(0);
                case Mult(Const(1), var x): return Simplify(x);
                case Mult(var x, Const(1)): return Simplify(x);
                case Mult(Const(var l), Const(var r)): return Const(l*r);
                case Add(Const(0), var x): return Simplify(x);
                case Add(var x, Const(0)): return Simplify(x);
                case Add(Const(var l), Const(var r)): return Const(l+r);
                case Neg(Const(var k)): return Const(-k);
                default: return e; 
            }
        }

        public static string PrettyPrint(this Expr e)
        {
            switch (e)
            {
                case X():
                    return "x";
                case Const(var v):
                    return v.ToString();
                case Add(var Left, var Right):
                    return $"{Left.PrettyPrint()} + {Right.PrettyPrint()}";
                case Mult(var Left, var Right):
                    return $"{Left.PrettyPrint()} * {Right.PrettyPrint()}";
                case Neg(var Value):
                    return $"-{Value.PrettyPrint()}";
                default:
                    throw new ArgumentException("unknown argument type");
            }
        }
    }
}

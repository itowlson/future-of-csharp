using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    public static class Planned
    {
        // PLANNED: digit separators
        // public const int BlackmailAmount = 1_000_000

        // PLANNED: binary literals
        // public const int BehaviourFlagsMask = 0b0000_0111_1000_0000;

        public static Dictionary<int, double> PrecalculateSines()
        {
            // Before

            return new Dictionary<int, double>
            {
                { 0,  0 },
                { 30, 0.5 },
                { 45, Math.Sqrt(2) / 2 },
                { 60, Math.Sqrt(3) / 2 },
                { 90, 1 },
            };
        }

        //public static Dictionary<int, double> PrecalculateSines()
        //{
        //    // PLANNED - indexer-style initialisation syntax
        //
        //    return new Dictionary<int, double>
        //    {
        //        [0] = 0,
        //        [30] = 0.5,
        //        [45] = Math.Sqrt(2) / 2,
        //        [60] = Math.Sqrt(3) / 2,
        //        [90] = 1,
        //    };
        //}

        public static Customer MakeBellicoseCustomer(Name name)
        {
            var customer = new Customer
            {
                Name = name,
            };
            customer.StroppyEmailAcknowledged += (o, e) => EverybodyHideUnderTheDesk();
            return customer;

            // PLANNED - event initialisers
            // return new Customer
            // {
            //     Name = name,
            //     StroppyEmailAcknowledged += (o, e) => EverybodyHideUnderTheDesk(),
            // };
        }

        // PLANNED - params IEnumerable<...>

        // Allows the method to be called as PrintStrings("alice", "bob", "carol") or:
        // PrintStrings(customers.Select(c => c.Name.First))
        // instead of the latter requiring 
        // PrintStrings(customers.Select(c => c.Name.First).ToArray())

        //public static void PrintStrings(params IEnumerable<string> strings)
        //{
        //    foreach (var str in strings)
        //    {
        //        Console.WriteLine(str);
        //    }
        //}

        // PLANNED - semicolon operator (similar to C comma operator)

        //public static IEnumerable<string> HelloifyLogged(IEnumerable<string> strings)
        //{
        //    return strings.Select(s => Console.WriteLine(s); "Hello " + s);
        //}

        private static void EverybodyHideUnderTheDesk() { }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }

        public string Full
        {
            get
            {
                // Before
                return String.Format("{0} {1}", First, Last);

                // MAYBE ("possibly") - string interpolation
                // return $"{First} {Last}";
            }
        }
    }

    public class InvariantMethodAttribute(string methodName) : Attribute
    {
        public string MethodName { get; } = methodName;
    }

    [InvariantMethod("CheckIntegrity")]  // boo
    //[InvariantMethod(nameof(CheckIntegrity))]  // safer
    public class ClassWithAnInvariant
    {
        public void CheckIntegrity()
        {
            throw new InvalidOperationException("This class has no integrity");
        }
    }
}

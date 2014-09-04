using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    public static class Planned
    {
        //public static Dictionary<int, double> PrecalculateSines()
        //{
        //    return new Dictionary<int, double>
        //    {
        //        [0] = 0,
        //        [30] = 0.5,
        //        [45] = Math.Sqrt(2) / 2,
        //        [60] = Math.Sqrt(3) / 2,
        //        [90] = 1,
        //    };
        //}

        public static bool WillFirstNameFitInDB(Customer customer)
        {
            // Before

            if (customer == null)
            {
                return true;
            }
            if (customer.Name == null)
            {
                return true;
            }
            if (customer.Name.First == null)
            {
                return true;
            }

            return customer.Name.First.Length < 8;  // Probably an Oracle database then

            // PLANNED - null propagation
            // "violating the Law of Demeter faster and more conveniently than ever before"

            // int? firstNameLength = customer?.Name?.First?.Length;
            // return firstNameLength.GetValueOrDefault() < 8;

            // or
            // int? firstNameLength = customer?.Name.First.Length;  // because if customer is null...
            // See design discussion at http://roslyn.codeplex.com/discussions/540883

            // customer?.SendStroppyEmail();
        }

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

    public class Customer
    {
        public Name Name { get; set; }

        public void SendStroppyEmail() { }

        public event EventHandler StroppyEmailAcknowledged;

        protected virtual void OnStroppyEmailAcknowledged()
        {
            var handler = StroppyEmailAcknowledged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            // PLANNED - null propagation
            // StroppyEmailAcknowledged?.Invoke(this, EventArgs.Empty);
        }

        public string FullName
        {
            get
            {
                // Before
                return String.Format("{0} {1}", Name.First, Name.Last);

                // MAYBE ("possibly") - string interpolation
                // return "\{Name.First} \{Name.Last}";
            }
        }
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
                // return "\{First} \{Last}";
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

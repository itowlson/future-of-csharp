using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    public static class CustomerUtils
    {
        public static string GetCustomerNameForPersonalisedLetter_CS5(Customer customer)
        {
            // Before

            if (customer == null || customer.Name == null)
            {
                return "Valued Customer";
            }

            return customer.Name.First;
        }

        public static string GetCustomerNameForPersonalisedLetter_CS6(Customer customer)
        {
            // Null propagation
            // "violating the Law of Demeter faster and more conveniently than ever before"

            return (customer?.Name?.First) ?? "Valued Customer";
        }

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

            // After

            //int? firstNameLength = customer?.Name?.First?.Length;  // nullable
            //return firstNameLength.GetValueOrDefault() < 8;
        }

        public static void SendCustomerStroppyEmailIfTheyExist(Customer customer)
        {
            customer?.SendStroppyEmail();
        }
    }

    public class Customer
    {
        public Name Name { get; set; }

        public void SendStroppyEmail() { }

        public event EventHandler StroppyEmailAcknowledged;

        protected virtual void OnStroppyEmailAcknowledgedCS5()
        {
            var handler = StroppyEmailAcknowledged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnStroppyEmailAcknowledged_CS6()
        {
            StroppyEmailAcknowledged?.Invoke(this, EventArgs.Empty);  // note need for .Invoke
        }

        public string FullName
        {
            get
            {
                // Before
                return String.Format("{0} {1}", Name.First, Name.Last);

                // MAYBE ("possibly") - string interpolation
                // return $"{Name.First} {Name.Last}";
            }
        }
    }
}

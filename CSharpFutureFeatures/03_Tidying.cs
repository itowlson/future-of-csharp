using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    public static class Miscellaneous
    {
        public static async Task<HttpResponseMessage> MakeLoggedRequest(HttpRequestMessage request)
        {
            HttpClient client = new HttpClient();
            try
            {
                await client.PostAsync("logger.verbosecompany.com", new StringContent("Entering MakeLoggedRequest"));

                var response = await client.SendAsync(request);

                await client.PostAsync("logger.verbosecompany.com", new StringContent("MakeLoggedRequest - status code = " + response.StatusCode));

                return response;
            }
            catch
            {
                // Can await in catch block
                await client.PostAsync("raygun.io", new StringContent("...some Raygun JSON..."));
                throw;
            }
            finally
            {
                // Can await in finally block
                await client.PostAsync("logger.verbosecompany.com", new StringContent("Exiting MakeLoggedRequest"));
            }
        }

        public static void InitialiseBadlyDesignedCollection()
        {
            // Before

            var cs5 = new BadlyDesignedCollection<string>();
            cs5.Append("alice");
            cs5.Append("bob");
            cs5.Append("carol");

            // After

            var cs6 = new BadlyDesignedCollection<string>
            {
                "alice",  // invokes extension method
                "bob",
                "carol",
            };
        }

        public static void FileMe()
        {
            try
            {
                File.ReadAllText("hello.txt");
                File.ReadAllText("goodbye.txt");
            }
            catch (FileNotFoundException ex) if (ex.FileName.EndsWith("goodbye.txt"))
            {
                Console.WriteLine("Didn't say goodbye. How rude");
            }
            // if hello.txt not found then no need to rethrow
        }

        public static void TupleMe()
        {
            // Before
            var tuple5 = new Tuple<string, int>("bob", 123);

            // Workaround
            var tuple5b = Tuple.Create("bob", 123);

            // After
            // var tuple6 = new Tuple("bob", 123);
        }
    }

    // Assume this is outside your control
    public class BadlyDesignedCollection<T> : IEnumerable<T>
    {
        private readonly List<T> _impl = new List<T>();

        public void Append(T item)
        {
            _impl.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _impl.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _impl.GetEnumerator();
        }
    }

    // But we can do this:
    public static class BadlyDesignedCollectionExtensions
    {
        public static void Add<T>(this BadlyDesignedCollection<T> collection, T item)
        {
            collection.Append(item);
        }
    }

    ////////////////////////////////////////////////////////////////////
    //
    // private protected has been withdrawn
    //
    ////////////////////////////////////////////////////////////////////

    public class VisibilityDemo
    {
        // Existing - equivalent to FamORAssem
        protected internal void Foo()
        {
        }

        // PLANNED - equivalent to FamANDAssem
        //private protected void Bar()
        //{
        //}
    }
}

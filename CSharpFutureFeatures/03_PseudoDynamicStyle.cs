using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    public static class WildlifeRepository
    {
        public static void StringIndexerShortcut()
        {
            var heights = new Dictionary<string, int>();
            heights.$alice = 175;  // equivalent to heights["alice"]
            heights.$bob = 165;
            heights.$carol = 170;

            Console.WriteLine(heights.$alice);
        }

        public static void StringIndexerShortcut_Initialiser()
        {
            var heights = new Dictionary<string, int>
            {
                $alice = 175,  // equivalent to ["alice"] = 175
                $bob = 165,
                $carol = 170,
            };

            Console.WriteLine(heights.$alice);
        }

        public static IEnumerable<string> GetNamesOfAdeliePenguins()
        {
            using (var textReader = File.OpenText("Sample.json"))
            using (var jsonReader = new JsonTextReader(textReader))
            {
                JObject repo = JObject.Load(jsonReader);

                JArray penguins = (JArray)repo.$penguins;  // equivalent to (JArray)repo["penguins"]

                return penguins.Where(p => (string)p.$species == "Adelie")
                               .Select(p => (string)p.$name);
            }
        }

        public static void OnlyNeedsIndexer()
        {
            var nonDictionary = new NonDictionary();
            nonDictionary.$alice = 1234;  // equivalent to nonDictionary["alice"]
            Console.WriteLine(nonDictionary.$alice);
        }
    }

    public class NonDictionary
    {
        public int this[string key]
        {
            get { return 100; }
            set { }
        }
    }
}

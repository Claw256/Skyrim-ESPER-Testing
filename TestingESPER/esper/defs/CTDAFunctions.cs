using TestingESPER.esper.helpers;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestingESPER.esper.defs {
    public class CTDAFunctions : Def {
        public static readonly string defId = "ctdaFunctions";

        public ReadOnlyCollection<CTDAFunction> ctdaFunctions;

        public CTDAFunctions(DefinitionManager manager, JObject src) 
            : base(manager, src) {
            ctdaFunctions = JsonHelpers.Defs<CTDAFunction>(manager, src, "ctdaFunctions");
        }

        public CTDAFunction FunctionByIndex(UInt16 index) {
            return CollectionHelpers.BinarySearch(ctdaFunctions, fn => {
                return index.CompareTo(fn.index);
            });
        }

        public CTDAFunction FunctionByName(string name) {
            return ctdaFunctions.FirstOrDefault(fn => {
                return fn.name == name;
            });
        }
    }
}

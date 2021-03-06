using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;

namespace TestingESPER.esper.defs.TES5 {
    public class ScriptFragmentsQuestCounter : ElementCounter {
        public new static string defId = "ScriptFragmentsQuestCounter";

        public override string path => "FragmentCount";

        public ScriptFragmentsQuestCounter(
            DefinitionManager manager, JObject src
        ) : base(manager, src) {}
    }
}

using TestingESPER.esper.elements;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace TestingESPER.esper.defs.TES5 {
    public class TimeFormat : FormatDef {
        private static readonly Regex timeExpr = new Regex(
            @"^([0-1][0-9]|2[0-3]):([0-5][0-9])$"
        );

        public static readonly string defId = "ClmtTimeFormat";

        public TimeFormat(DefinitionManager manager, JObject src)
            : base(manager, src) {}

        public override string DataToValue(ValueElement element, dynamic data) {
            Int64 time = data;
            var hours = time / 6;
            var minutes = (time % 6) * 10;
            if (hours > 23) return time.ToString();
            return $"{hours:00}:{minutes:00}";
        }

        public override dynamic ValueToData(ValueElement element, string value) {
            var match = timeExpr.Match(value);
            if (match == null) return 0;
            var hours = int.Parse(match.Groups[1].Value);
            var minutes = int.Parse(match.Groups[2].Value);
            var time = (hours * 6) + (minutes / 10);
            return (byte) time;
        }
    }
}

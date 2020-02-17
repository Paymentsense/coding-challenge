using System.Collections.Generic;

namespace paymentsense.common.Contracts.Geographic
{
    public class RegionalBloc
    {
        public string acronym { get; set; }
        public string name { get; set; }
        public List<object> otherAcronyms { get; set; }
        public List<string> otherNames { get; set; }
    }
}

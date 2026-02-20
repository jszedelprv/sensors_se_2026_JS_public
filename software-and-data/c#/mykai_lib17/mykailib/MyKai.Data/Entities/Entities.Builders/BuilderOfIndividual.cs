using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data.Entities
{
    public class BuilderOfIndividual : KaiDataBuilderBase<Individual>
    {
        public BuilderOfIndividual WithColumnFields(string pIndividualName, string pIndividualSID)
        {
            instance.IndividualName = pIndividualName;
            instance.IndividualSID = pIndividualSID;
            instance.Name = pIndividualName + " | " + pIndividualSID;

            return this;
        }
    }
}

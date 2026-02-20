
namespace MyKai.Data
{
    public class BuilderOfSubstringFilter : KaiDataBuilderBase<KaiDataSubstringFilter>
    {
        public BuilderOfSubstringFilter WithSubstringParameters((int pStartIndex, int pLength) pSubstringParameters)
        {
            instance.SubstringParameters = pSubstringParameters;
            return this;
        }

        public BuilderOfSubstringFilter WithName( string pFilterName )
        {
            instance.FilterName = pFilterName;
            return this;
        }

        public BuilderOfSubstringFilter WithRequiredValue( string pRequiredSubstringValue ) 
        { 
            instance.RequiredValue = pRequiredSubstringValue;
            return this; 
        }
    }
}

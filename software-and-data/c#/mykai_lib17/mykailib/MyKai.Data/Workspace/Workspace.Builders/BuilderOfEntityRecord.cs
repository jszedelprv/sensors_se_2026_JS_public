using MyKai.Data.Attributes;

namespace MyKai.Data
{
    public class BuilderOfEntityRecord : KaiDataBuilderBase<KaiDataWorkspace.EntityRecord>
    {
        public BuilderOfEntityRecord WithRelativePath(string pRelativePath)
        {
            instance.RelativePath = pRelativePath;
            return this;
        }

        public BuilderOfEntityRecord WithSubdirectory(string pSubdirectory)
        {
            instance.Subdirectory = pSubdirectory;
            return this;
        }

        public BuilderOfEntityRecord WithEntity(IKaiDataEntity pEntity)
        {
            instance.Entity = pEntity;
            return this;
        }

        public BuilderOfEntityRecord WithEntityOptions(EntityOptions pEntityOptions)
        {
            instance.EntityOptions = pEntityOptions;
            return this;
        }
    }
}

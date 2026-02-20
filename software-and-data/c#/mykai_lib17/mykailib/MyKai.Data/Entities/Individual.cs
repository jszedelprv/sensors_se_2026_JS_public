using System;
using MyKai.Data.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data.Entities
{
    public class Individual : KaiDataObjectBase
    {
        [KaiDataColumn(Index = 0)]
        public string IndividualName;
        
        [KaiDataColumn(Index = 1)]
        public string IndividualSID;
    }


    [KaiDataFileEntity(EntityName = "Individuals", FileName = "Individuals.csv", RelativePath = "\\individuals")]
    [KaiDataMasterEntity(MasterEntityName = "ImageDatasets")]
    public class IndividualEntity : KaiDataFileStoredEntityBase
    {
        public override KaiDataObjectBase GetNewObject()
        {
            return new BuilderOfIndividual().Build();
        }

        public override Type GetObjectType() => typeof(Individual);

        protected override void Deserialize()
        {
            Objects = GetFileReader().ReadObjects(this);
        }

        public override string RelativePath()
        {
            KaiDataFolderObjectBase masterFolder 
                = (KaiDataFolderObjectBase)KaiDataWorkspace.Find.MasterEntitySelectedObjectByType(this.GetType());

            string resultPath = masterFolder.FolderPath + KaiDataWorkspace.Find.RecordByEntityName("Individuals").RelativePath;

            return resultPath;
        }

        protected override string FileNameAttributeValue()
        {
            KaiDataFileEntityAttribute fileEntityAttribute 
                = (KaiDataFileEntityAttribute)Attribute.GetCustomAttribute(typeof(IndividualEntity), typeof(KaiDataFileEntityAttribute));

            return fileEntityAttribute.FileName;
        }
    }
}

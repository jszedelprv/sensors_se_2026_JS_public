using System;
using System.IO;
using System.Drawing;
using MyKai.Data.Attributes;

namespace MyKai.Data.Entities
{
    public class GesturePattern : KaiDataImageObjectBase
    {
    }

    [KaiDataEntity(EntityName = "GesturePatterns", RelativePath = "\\patterns")]
    [KaiDataMasterEntity(MasterEntityName = "ImageDatasets")]
    public class GesturePatternEntity : KaiDataImageEntityBase
    {
        public override string RelativePath()
        {

            KaiDataFolderObjectBase masterFolder 
                = (KaiDataFolderObjectBase)KaiDataWorkspace.Find.MasterEntitySelectedObjectByType(this.GetType());

            string resultPath = masterFolder.FolderPath + KaiDataWorkspace.Find.RecordByEntityName("GesturePatterns").RelativePath;

            return resultPath;
        }

        public override Type GetObjectType() => typeof(GesturePattern);

        public override KaiDataObjectBase GetNewObject() => new BuilderOfGesturePattern().Build();

        protected override KaiDataImageObjectBase BuildImage(string pName, string pFullName)
            => new BuilderOfGesturePattern().WithName(pName)
                                            .WithClassLabel(pName.Substring(0,4))
                                            .WithFullName(pFullName)
                                            .WithImage()
                                            .Build();
    }
}

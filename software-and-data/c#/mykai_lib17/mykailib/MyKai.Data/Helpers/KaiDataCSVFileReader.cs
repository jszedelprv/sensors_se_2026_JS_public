using System.IO;
using Csv;

namespace MyKai.Data
{
    internal class KaiDataCSVFileReader : IKaiDataFileReader
    {
        public KaiDataObjectCollection ReadObjects(KaiDataFileStoredEntityBase pFileEntity)
        {
            var csv = File.ReadAllText(pFileEntity.RelativePath() + "\\" + pFileEntity.FileName);

            KaiDataObjectCollection resultCollection = new KaiDataObjectCollection(pFileEntity);

            foreach (var line in CsvReader.ReadFromText(csv))
            {
                KaiDataObjectBase newObject = pFileEntity.GetNewObject();
                string newObjectsName = "";

                foreach (var field in pFileEntity.Fields.Items)
                {
                    var fieldValue = line[field.Index];
                    var fieldInfo = field.Info;
                    fieldInfo.SetValue(newObject, fieldValue);

                    if (field.Index == 0)
                        newObjectsName = fieldValue; // First column is assumed to be new object's name
                }

                newObject.Name = newObjectsName;
                resultCollection.Items.Add(newObject);

                // Usage of CSV:
                // Header is handled, each line will contain the actual row data
                // var firstCell = line[0];
                // var byName = line["Column name"];
            }

            return resultCollection;
        }
    }
}

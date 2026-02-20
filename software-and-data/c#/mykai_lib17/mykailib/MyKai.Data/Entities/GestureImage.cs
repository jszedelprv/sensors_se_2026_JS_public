using MoCap.CapturedData;
using MoCap.Gesture;
using MyKai.Data.Attributes;
using MyKai.Data.Helpers.Exceptions;
using MyKai.General;
using MyKai.Gesture;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace MyKai.Data.Entities
{
    public class GestureImage : KaiDataGestureImageBase
    {
        public string SamplesDirectory { get; set; } = string.Empty;

        public Point[] GesturePoints { get; set; }
        private readonly string pointsSubdirectory = "\\points\\";
        private readonly string beziersSubdirectory = "\\beziers\\";

        public string PointsFileName() => Path.Combine(SamplesDirectory + pointsSubdirectory,
                                          Path.GetFileNameWithoutExtension(ImageFileFullName) + "_points.csv");

        public string BeziersImageFileName() => Path.Combine(SamplesDirectory + beziersSubdirectory,
                                                Path.GetFileNameWithoutExtension(ImageFileFullName) + "_beziers.jpg");

        public Image BezierImage { get; set; } = null;

        public UintGesture2D ToUintGesture2D()
        {
            UintGesture2D resultGesture = new UintGesture2D();
            UintFrame2D uintFrame;
            UintPoint2D uintPoint;

            if (GesturePoints != null)
            {
                foreach (Point gesturePoint in GesturePoints)
                {
                    uintFrame = new UintFrame2D();
                    uintPoint = new UintPoint2D();

                    uintPoint.X = (uint)gesturePoint.X;
                    uintPoint.Y = (uint)gesturePoint.Y;
                    
                    uintFrame.Points.Add(uintPoint);

                    resultGesture.Frames.Add(uintFrame);
                }
            }

            return resultGesture;
        }
    }

    [KaiDataEntity(EntityName = "CapturedGestureImages", RelativePath = "\\samples", Subdirectory = "\\as-captured", EntityOptions = EntityOptions.None)]
    [KaiDataMasterEntity(MasterEntityName = "ImageDatasets")]
    public class GestureImageEntity : KaiDataImageEntityBase
    {
        public override string RelativePath()
        {
            KaiDataFolderObjectBase masterFolder = (KaiDataFolderObjectBase)KaiDataWorkspace.Find.MasterEntitySelectedObjectByType(this.GetType());

            string resultPath = masterFolder.FolderPath;
            resultPath += KaiDataWorkspace.Find.RecordByEntityName("CapturedGestureImages").RelativePath;
            resultPath += KaiDataWorkspace.Find.RecordByEntityName("CapturedGestureImages").Subdirectory;

            return resultPath;
        }

        public string SamplesRelativePath()
        {
            KaiDataFolderObjectBase masterFolder = (KaiDataFolderObjectBase)KaiDataWorkspace.Find.MasterEntitySelectedObjectByType(this.GetType());
            
            string resultPath = masterFolder.FolderPath;
            resultPath += KaiDataWorkspace.Find.RecordByEntityName("CapturedGestureImages").RelativePath;
            
            return resultPath;
        }

        public override Type GetObjectType() => typeof(KaiDataGestureImageBase);

        public override KaiDataObjectBase GetNewObject() => new BuilderOfGestureImage().Build();

        protected override KaiDataImageObjectBase BuildImage(string pName, string pFullName)
        {
            KaiDataImageObjectBase newImage = new BuilderOfGestureImage().WithName(pName)
                                                                         .WithFullName(pFullName)
                                                                         .WithImageRead()
                                                                         .WithSamplesDirectoryName(SamplesRelativePath())
                                                                         .Build();
            return newImage;
        }

        public override void DeleteInstances(KaiDataObjectCollection pInstancesToDel)
        {
            foreach (KaiDataObjectBase instanceToDel in pInstancesToDel.Items)
            {
                try
                {
                    if ( instanceToDel.GetType().Name != new GestureImage().GetType().Name )
                         throw new InvalidKaiDataObjectException(instanceToDel, new GestureImage());
                }
                catch (InvalidKaiDataObjectException e) 
                {
                    MessageBox.Show($"{this.GetType().Name} - {e.Message}");
                }

                GestureImage imageToDel = (GestureImage)instanceToDel;

                try 
                {
                    File.Delete(imageToDel.ImageFileFullName);
                }
                catch (Exception e) 
                {
                    MessageBox.Show($"{this.GetType().Name} - {e.Message}");
                }
            }

            Objects.Items.RemoveAll(aCapturedImage => aCapturedImage.IsInCollection(pInstancesToDel) );
        }

        protected override void Deserialize()
        {
            DeserializeTrailImages();
            DeserializeBezierImages();
            DeserializePoints();
        }

        protected override void Serialize()
        {
            SerializeTrailImages();
            SerializeBezierImages();
            SerializePoints();
        }

        private void DeserializeTrailImages()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(RelativePath());

            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                if (IsAnImageFile(fileInfo.Name))
                    Objects.Items.Add(BuildImage(fileInfo.Name, fileInfo.FullName));
            }
        }

        private void DeserializeBezierImages()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(RelativePath());
            GestureImage gestureImage = new GestureImage();

            foreach (var gestureImages in Objects.Items)
            {
                gestureImage = (GestureImage)gestureImages;
                string beziersFileName = gestureImage.BeziersImageFileName();
                if (File.Exists(beziersFileName))
                {
                    var image = Image.FromFile(beziersFileName);
                    
                    if (gestureImage.BezierImage != null)
                        gestureImage.BezierImage.Dispose();
                    
                    gestureImage.BezierImage = new Bitmap(image);
                    
                    image.Dispose();
                }
                else
                {
                    gestureImage.BezierImage = null; // or handle missing file as needed
                }
            }
        }

        private void SerializeTrailImages()
        {
            MyKaiJPGImageSaver saver = new MyKaiJPGImageSaver();
            foreach (GestureImage gestureImage in Objects.Items)
            {
                if (saver.CheckIfImageExists(gestureImage.ImageFileFullName))
                {
                    if (!OverwriteOnSave)
                        continue; // skip saving if file already exists and OverwriteOnSave is false
                    else
                        saver.PrepareSave(gestureImage.ImageFileFullName); // deletes existing file if OverwriteOnSave is true
                }

                // create a copy of the image with white background to avoid transparency issues
                // this is temporary workaround until the "first black image" bug issue is solved
                GestureImage imageCopy = new GestureImage();
                imageCopy.GestureImage = new Bitmap(gestureImage.GestureImage.Width, gestureImage.GestureImage.Height);
                Graphics g = Graphics.FromImage(imageCopy.GestureImage);
                g.Clear(Color.White);
                g.DrawImage(gestureImage.GestureImage, 0, 0);

                saver.SaveImage(imageCopy.GestureImage, gestureImage.ImageFileFullName);
            }
        }

        private bool IsAnImageFile(string pName)
        {
            string extention = Path.GetExtension(pName);
            return extention == ".jpg" || extention == ".bmp"; // TO DO: supply variable extentions if needed
        }

        private void SerializeBezierImages()
        {
            MyKaiJPGImageSaver saver = new MyKaiJPGImageSaver();
            string beziersFileName;
            foreach (GestureImage gestureImage in Objects.Items)
            {
                beziersFileName = gestureImage.BeziersImageFileName();

                if (saver.CheckIfImageExists(beziersFileName))
                {
                    if (!OverwriteOnSave)
                        continue; // skip saving if file already exists and OverwriteOnSave is false
                    else
                        saver.PrepareSave(beziersFileName); // deletes existing file if OverwriteOnSave is true
                }

                // comment same as in the SaveTrailImages method
                GestureImage imageCopy = new GestureImage();
                imageCopy.BezierImage = new Bitmap(gestureImage.BezierImage.Width, gestureImage.BezierImage.Height);
                Graphics g = Graphics.FromImage(imageCopy.BezierImage);
                g.Clear(Color.White);
                g.DrawImage(gestureImage.BezierImage, 0, 0);

                saver.SaveImage(imageCopy.BezierImage, beziersFileName);
            }
        }

        private void DeserializePoints()
        {
            KaiDataImagePointsCSVFileReader reader = new KaiDataImagePointsCSVFileReader();

            foreach (GestureImage gestureImage in Objects.Items)
            {
                string filePath = gestureImage.PointsFileName();

                if (File.Exists(filePath))
                {
                    reader.ReadObject(gestureImage);
                }
            }
        }

        private void SerializePoints()
        {
            KaiDataImagePointsCSVFileWriter writer = new KaiDataImagePointsCSVFileWriter();

            foreach (GestureImage gestureImage in Objects.Items)
            {
                string filePath = gestureImage.PointsFileName();

                if (File.Exists(filePath))
                {
                    if (!OverwriteOnSave)
                        continue; // skip saving if file already exists and OverwriteOnSave is false
                    else
                        writer.PrepareSave(filePath); // deletes existing file if OverwriteOnSave is true
                }

                writer.SaveObject(gestureImage);
            }
        }
    }
}

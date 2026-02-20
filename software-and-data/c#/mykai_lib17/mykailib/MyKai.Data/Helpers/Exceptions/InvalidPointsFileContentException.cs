using MyKai.Data.Entities;
using System;


namespace MyKai.Data.Helpers.Exceptions
{
    internal class InvalidPointsFileContentException : Exception
    {
        string invalidFilePath { get; } = null;
        GestureImage gestureImage { get; } = null;

        public InvalidPointsFileContentException(string pInvalidFilePath, GestureImage pImage) : base()
        {
            invalidFilePath = pInvalidFilePath;
            gestureImage = pImage;
        }

        public override string Message => $"Kai.Data: {this.GetType().Name} while reddnig the file " +
                                          $"{invalidFilePath}. Can not parse the file content for object named {gestureImage.Name}.";
    }
}

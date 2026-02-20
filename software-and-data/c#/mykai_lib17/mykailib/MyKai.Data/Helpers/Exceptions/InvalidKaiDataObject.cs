using MyKai.Data;
using System;

namespace MyKai.Data.Helpers.Exceptions
{
    public class InvalidKaiDataObjectException : Exception
    {
        public KaiDataObjectBase InvalidObject { get; } = null;
        public KaiDataObjectBase CorrectObject { get; } = null;

        public InvalidKaiDataObjectException(KaiDataObjectBase pInvalidObject, KaiDataObjectBase pCorrectObject) : base()
        {
            InvalidObject = pInvalidObject;
            CorrectObject = pCorrectObject;
        }

        public override string Message => "Kai.Data: Invalid KaiDataObjectException. Expected: " +
                                          $"{InvalidObject.GetType().Name}, but got {CorrectObject.GetType().Name}.";
    }
}

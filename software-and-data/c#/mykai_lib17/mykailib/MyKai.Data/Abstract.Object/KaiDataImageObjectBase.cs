using System.Drawing;

namespace MyKai.Data
{
    public abstract class KaiDataImageObjectBase : KaiDataObjectBase
    {
        public string ImageFileFullName { get; set; }
        public string ImageClassLabel { get; set; }
        public Image GestureImage { get; set; } = null;
    }
}

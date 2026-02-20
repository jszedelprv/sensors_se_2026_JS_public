using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyKai.Data.Entities
{
    class BuilderOfGesturePattern : KaiDataBuilderBase<GesturePattern>
    {
        public BuilderOfGesturePattern()
        {
        }

        public BuilderOfGesturePattern WithClassLabel(string pImageClassLabel)
        {
            instance.ImageClassLabel = pImageClassLabel;
            return this;
        }

        public BuilderOfGesturePattern WithName(string pName)
        {
            instance.Name = pName;
            return this;
        }

        public BuilderOfGesturePattern WithFullName(string pFullName)
        {
            instance.ImageFileFullName = pFullName;
            return this;
        }

        public BuilderOfGesturePattern WithImage()
        {
            instance.GestureImage = Image.FromFile(instance.ImageFileFullName);
            return this;
        }
    }
}

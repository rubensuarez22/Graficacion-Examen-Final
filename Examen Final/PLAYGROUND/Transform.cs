using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    public class Transform
    {
        public float RotationX { get; set; }
        public float RotationY { get; set; }
        public float RotationZ { get; set; }

        public float TranslationX { get; set; }  // Asegúrate de que esté "Translation" y no "Traslation"
        public float TranslationY { get; set; }
        public float TranslationZ { get; set; }

        public Transform()
        {
            RotationX = 0f;
            RotationY = 0f;
            RotationZ = 0f;
            TranslationX = 0f;
            TranslationY = 0f;
            TranslationZ = 0f;
        }

        public void Rotate(float x, float y, float z)
        {
            RotationX += x;
            RotationY += y;
            RotationZ += z;
        }

        public void Translate(float x, float y, float z)
        {
            TranslationX += x;
            TranslationY += y;
            TranslationZ += z;
        }
    }

}

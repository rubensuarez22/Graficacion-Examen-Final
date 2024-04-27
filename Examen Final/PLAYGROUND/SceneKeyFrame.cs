using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    public class SceneKeyframe
    {
        public Dictionary<Mesh, Transform> MeshTransforms { get; private set; }
        public float Time { get; set; } // Tiempo en segundos desde el inicio de la animación

        public SceneKeyframe(float time)
        {
            MeshTransforms = new Dictionary<Mesh, Transform>();
            Time = time;
        }

        public void AddMeshTransform(Mesh mesh, Transform transform)
        {
            MeshTransforms[mesh] = transform;
        }
    }

}

using System;
using System.Collections.Generic;

namespace PLAYGROUND
{
    public class Scene
    {
        public List<Mesh> Models { get; set; } = new List<Mesh>();
        public Mesh ActiveModel { get; private set; }

        public List<SceneKeyframe> Keyframes { get; set; } = new List<SceneKeyframe>();
        public Scene()
        {
            Models = new List<Mesh>();
        }

        public void AddModel(Mesh model)
        {
            Models.Add(model);
        }

        public void SetActiveModel(int index)
        {
            if (index >= 0 && index < Models.Count)
            {
                ActiveModel = Models[index];  
            }
        }

        public void AddKeyframe(SceneKeyframe keyframe)
        {
            Keyframes.Add(keyframe);
            Keyframes.Sort((k1, k2) => k1.Time.CompareTo(k2.Time)); // Ensure keyframes are ordered by time
            Console.WriteLine($"Keyframe added at time {keyframe.Time}"); // Agrega un mensaje de depuración
        }


    }


}


using System.Collections.Generic;

namespace PLAYGROUND
{
    public class Scene
    {
        public List<Mesh> Models { get; set; } = new List<Mesh>();
        public Mesh ActiveModel { get; private set; }

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


    }
}

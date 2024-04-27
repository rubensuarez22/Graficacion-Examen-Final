using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PLAYGROUND
{
    public partial class MyForm : Form
    {
        Scene scene;
        Renderer renderer;
        Canvas canvas;
        public int onn = 0;
        private float angle = 0.0f;
        private float deltaAngle = 2.0f;
        Dictionary<int, string> modelNames = new Dictionary<int, string>();


        private Stopwatch animationStopwatch = new Stopwatch();
        private bool isAnimating = false;
        private int currentFrameIndex = 0;
        private float elapsedSinceLastKeyframe = 0.0f;

        public MyForm()
        {
            InitializeComponent();
            Init();
            Width = PCT_CANVAS.ClientSize.Width;
            Height = PCT_CANVAS.ClientSize.Height;
            CHECKBOX_RotacionX.CheckedChanged += RotarFigura;
            CHECKBOX_RotacionY.CheckedChanged += RotarFigura;
            CHECKBOX_RotacionZ.CheckedChanged += RotarFigura;

            TIMER.Tick += RotarFigura;
        }

        private void Init()
        {
            // Ajusta el tamaño y posición inicial del PictureBox o el control que usas para renderizar
            PCT_CANVAS.SetBounds(panel1.Width + 4, PNL_HEADER.Height + 4,
                Width - panel1.Width - panel2.Width - 24,
                Height - PNL_HEADER.Height - PNL_BOTTOM.Height - 72);

            // Solo prepara el canvas y el renderer pero no carga ningún modelo
            if (canvas == null)
            {
                canvas = new Canvas(PCT_CANVAS);
                renderer = new Renderer(canvas);
                scene = new Scene();
            }
        }


        private void MyForm_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void BTN_Rotate_Click(object sender, EventArgs e)
        {
            // Obtén la referencia al Mesh que deseas rotar
            //Mesh modelToRotate = scene.Models[0]; // Asume que solo hay un modelo en la escena

            // Rota el modelo en los ejes X, Y y Z
            //modelToRotate.Transform.Rotate(1, 0, 0); // Ajusta los valores de rotación según sea necesario

            // Fuerza el renderizado actualizado
            //renderer.RenderScene(scene);
            if (TIMER.Enabled)
            {
                TIMER.Stop();
            }
            else
            {
                TIMER.Start();
            }


        }


        

        private void PCT_CANVAS_MouseMove(object sender, MouseEventArgs e)
        {

            LBL_STATUS.Text = e.Location.ToString() + canvas.bmp.Size;
        }

        private void BTN_2_Click(object sender, EventArgs e)
        {

            renderer.UpdateLightDirection(0, -1, 0);
            renderer.RenderScene(scene);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "OBJ files (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar los modelos existentes temporalmente
                List<Mesh> existingModels = new List<Mesh>();
                if (scene != null && scene.Models != null)
                {
                    for (int i = 0; i < scene.Models.Count; i++)
                    {
                        existingModels.Add(scene.Models[i]);
                    }
                }

                // Crear un nuevo Canvas y Renderer
                canvas = new Canvas(PCT_CANVAS);
                renderer = new Renderer(canvas);
                scene = new Scene();

                // Añadir los modelos existentes a la nueva escena
                for (int i = 0; i < existingModels.Count; i++)
                {
                    scene.AddModel(existingModels[i]);
                }

                // Cargar el nuevo modelo
                string filename = openFileDialog.FileName;
                ObjLoader loader = new ObjLoader();
                Mesh newModel = loader.Load(filename); // Cambio de nombre para evitar el error CS0136
                scene.AddModel(newModel);

                // Agregar el nombre del modelo a la interfaz de usuario
                string modelName = Path.GetFileNameWithoutExtension(filename);
                listBoxModels.Items.Add(modelName);
                modelNames[scene.Models.Count - 1] = modelName;

                // Renderizar la escena con todos los modelos
                renderer.RenderScene(scene);
            }

            // Reiniciar o iniciar el TIMER
            TIMER.Start();
        }



        private void RotarFigura(object sender, EventArgs e)
        {
            if (scene.ActiveModel != null)
            {
                // Convertir deltaAngle a radianes una sola vez
                float deltaAngleRadians = deltaAngle * (float)(Math.PI / 180);
                Mesh modelToRotate = scene.ActiveModel; // Asume que solo hay un modelo en la escena

                // Rota el modelo en los ejes X, Y y Z

                // Rotar figura alrededor del eje X 
                if (CHECKBOX_RotacionX.Checked)
                {
                    modelToRotate.Transform.Rotate(0.01f, 0, 0);
                }

                // Rotar figura alrededor del eje Y 
                if (CHECKBOX_RotacionY.Checked)
                {
                    modelToRotate.Transform.Rotate(0, 0.01f, 0);
                }

                // Rotar figura alrededor del eje Z 
                if (CHECKBOX_RotacionZ.Checked)
                {
                    modelToRotate.Transform.Rotate(0, 0, 0.01f);
                }

                // Redibujar la figura después de aplicar las rotaciones
                renderer.RenderScene(scene);
            }
        }

        private void BTN_MOVERARRIBA_Click(object sender, EventArgs e)
        {
            if (scene.ActiveModel != null)
            {
                Mesh modelToTranslate = scene.ActiveModel; // Asume que solo hay un modelo
                modelToTranslate.Transform.Translate(0.0f, -1.0f, 0.0f); // Ajusta según la necesidad
                renderer.RenderScene(scene);
            }
        }

        private void BTN_MOVERABAJO_Click(object sender, EventArgs e)
        {
            if (scene.ActiveModel != null)
            {
                Mesh modelToTranslate = scene.ActiveModel;                  //n modelo
                modelToTranslate.Transform.Translate(0.0f, 1.0f, 0.0f); // Ajusta según la necesidad
                renderer.RenderScene(scene);
            }
        }

        private void BTN_MOVERIZQUIERDA_Click(object sender, EventArgs e)
        {
            if (scene.ActiveModel != null)
            {
                Mesh modelToTranslate = scene.ActiveModel; // Asume que solo hay un modelo
                modelToTranslate.Transform.Translate(-1.0f, 0.0f, 0.0f); // Ajusta según la necesidad
                renderer.RenderScene(scene);
            }
        }

        private void BTN_MOVERDERECHA_Click(object sender, EventArgs e)
        {
            if (scene.ActiveModel != null)
            {
                Mesh modelToTranslate = scene.ActiveModel; // Asume que solo hay un modelo
                modelToTranslate.Transform.Translate(1.0f, 0.0f, 0.0f); // Ajusta según la necesidad
                renderer.RenderScene(scene);
            }
        }

        private void BTN_Scale_Click(object sender, EventArgs e)
        {
            if (scene.Models.Count > 0)
            {
                Mesh modelToScale = scene.ActiveModel;
                if (float.TryParse(txtScaleX.Text, out float scaleX) &&
                    float.TryParse(txtScaleY.Text, out float scaleY) &&
                    float.TryParse(txtScaleZ.Text, out float scaleZ))
                {
                    if (scaleX >= 0.1f && scaleX <= 1.9f &&
                        scaleY >= 0.1f && scaleY <= 1.9f &&
                        scaleZ >= 0.1f && scaleZ <= 1.9f)
                    {
                        modelToScale.Transform.Scale(scaleX, scaleY, scaleZ);
                        renderer.RenderScene(scene);
                    }
                    else
                    {
                        MessageBox.Show("Los valores de escala deben estar entre 0.1 y 1.9.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxModels.SelectedIndex;
            if (selectedIndex != -1)
            {
                scene.SetActiveModel(selectedIndex);  // Esto establece el modelo activo
            }
        }

        private void PlayAnimation()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < scene.Keyframes.Count - 1; i++)
            {
                var startFrame = scene.Keyframes[i];
                var endFrame = scene.Keyframes[i + 1];
                float frameDuration = endFrame.Time - startFrame.Time;

                while (stopwatch.Elapsed.TotalSeconds < endFrame.Time)
                {
                    float t = (float)((stopwatch.Elapsed.TotalSeconds - startFrame.Time) / frameDuration);

                    foreach (var mesh in scene.Models)
                    {
                        if (startFrame.MeshTransforms.ContainsKey(mesh) && endFrame.MeshTransforms.ContainsKey(mesh))
                        {
                            Transform startTransform = startFrame.MeshTransforms[mesh];
                            Transform endTransform = endFrame.MeshTransforms[mesh];
                            Transform interpolatedTransform = Interpolate(startTransform, endTransform, t);
                            mesh.Transform = interpolatedTransform;
                        }
                    }

                    renderer.RenderScene(scene);
                    Application.DoEvents(); // Mantén la UI responsiva
                }
            }
            stopwatch.Stop();
        }



        private void StopAnimation()
        {
            isAnimating = false;
            TIMER.Stop();
            animationStopwatch.Stop();
            Console.WriteLine("Animación detenida y cronómetro detenido");
        }




        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (isAnimating)
            {
                PlayAnimation();
            }
            else
            {
                
            }
        }

        private Transform Interpolate(Transform start, Transform end, float t)
        {
            return new Transform
            {
                TranslationX = start.TranslationX + (end.TranslationX - start.TranslationX) * t,
                TranslationY = start.TranslationY + (end.TranslationY - start.TranslationY) * t,
                TranslationZ = start.TranslationZ + (end.TranslationZ - start.TranslationZ) * t,
                RotationX = start.RotationX + (end.RotationX - start.RotationX) * t,
                RotationY = start.RotationY + (end.RotationY - start.RotationY) * t,
                RotationZ = start.RotationZ + (end.RotationZ - start.RotationZ) * t,
                ScaleX = start.ScaleX + (end.ScaleX - start.ScaleX) * t,
                ScaleY = start.ScaleY + (end.ScaleY - start.ScaleY) * t,
                ScaleZ = start.ScaleZ + (end.ScaleZ - start.ScaleZ) * t
            };
        }

        private void BTN_PLAY_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Botón PLAY presionado. Verificando keyframes...");
            if (scene.Keyframes.Count < 2)
            {
                MessageBox.Show("Necesitas al menos 2 KeyFrames para la animación.");
                return;
            }

            Console.WriteLine("Hay suficientes KeyFrames. ¿Está animando? " + isAnimating);
            if (!isAnimating)
            {
                // Ordenar los KeyFrames por tiempo para asegurarse de que están en el orden correcto
                scene.Keyframes.Sort((a, b) => a.Time.CompareTo(b.Time));

                // Aplicar el primer Keyframe a todos los modelos
                SceneKeyframe firstKeyframe = scene.Keyframes[0];
                foreach (var mesh in scene.Models)
                {
                    if (firstKeyframe.MeshTransforms.ContainsKey(mesh))
                    {
                        Transform initialTransform = firstKeyframe.MeshTransforms[mesh];
                        mesh.Transform = initialTransform;
                        Console.WriteLine($"Aplicando KeyFrame inicial a Mesh: TransX: {initialTransform.TranslationX}, TransY: {initialTransform.TranslationY}, TransZ: {initialTransform.TranslationZ}");
                    }
                }
                renderer.RenderScene(scene);
                Console.WriteLine("Escena renderizada con el primer KeyFrame.");

                // Reiniciar y empezar el cronómetro y la animación
                animationStopwatch.Restart();
                currentFrameIndex = 0;
                isAnimating = true;
                TIMER.Start();
                Console.WriteLine("Animación iniciada inmediatamente.");
            }
            else
            {
                StopAnimation();
                Console.WriteLine("Animación detenida.");
            }
        }









        private void BTN_KEYFRAME_Click(object sender, EventArgs e)
        {
            float currentTime = TRACKBAR_KEYFRAME.Value; // Asegúrate de que TRACKBAR_KEYFRAME está configurado correctamente
            SceneKeyframe keyframe = new SceneKeyframe(currentTime);

            // Capturar transformaciones de todos los Mesh en la escena
            foreach (Mesh mesh in scene.Models)
            {
                Transform currentTransform = new Transform
                {
                    TranslationX = mesh.Transform.TranslationX,
                    TranslationY = mesh.Transform.TranslationY,
                    TranslationZ = mesh.Transform.TranslationZ,
                    RotationX = mesh.Transform.RotationX,
                    RotationY = mesh.Transform.RotationY,
                    RotationZ = mesh.Transform.RotationZ,
                    ScaleX = mesh.Transform.ScaleX,
                    ScaleY = mesh.Transform.ScaleY,
                    ScaleZ = mesh.Transform.ScaleZ
                };

                keyframe.AddMeshTransform(mesh, currentTransform); // Asegúrate de que cada Mesh tiene una entrada en el diccionario
            }

            scene.AddKeyframe(keyframe);
            LBL_KEYFRAMECOUNT.Text = $"KeyFrames: {scene.Keyframes.Count}";
        }

        private void BTN_ClearKeyFrames_Click(object sender, EventArgs e)
        {
            // Detener la animación si está corriendo
            StopAnimation();

            // Limpiar todos los KeyFrames
            scene.Keyframes.Clear();

            // Actualizar la interfaz de usuario si es necesario, por ejemplo, actualizar un label que muestra el número de KeyFrames
            LBL_KEYFRAMECOUNT.Text = "KeyFrames: 0";

            // Redibujar la escena para mostrar el estado inicial de los modelos
            renderer.RenderScene(scene);

            // Mostrar mensaje de confirmación si es necesario
            MessageBox.Show("KeyFrames limpiados y animación reseteada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        /*
private void BTN_RemoveModel_Click(object sender, EventArgs e)
        {
            if (listBoxModels.SelectedIndex != -1)
            {
                int selectedIndex = listBoxModels.SelectedIndex;
                scene.RemoveModel(selectedIndex);
                listBoxModels.Items.RemoveAt(selectedIndex);
                modelNames.Remove(selectedIndex);
                renderer.RenderScene(scene);
            }
        }
        */
    }

}
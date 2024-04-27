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

        private Transform Interpolate(Transform start, Transform end, float t)
        {
            Transform interpolated = new Transform
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
            return interpolated;
        }


   

        private void PlayAnimation()
        {
            if (!isAnimating)
            {
                if (scene.Keyframes.Count < 2)
                {
                    MessageBox.Show("Necesitas al menos 2 KeyFrames para la animación.");
                    return;
                }
                // Ordena los KeyFrames por tiempo para asegurarte de que estén en el orden correcto
                scene.Keyframes.Sort((a, b) => a.Time.CompareTo(b.Time));

                animationStopwatch.Reset();
                animationStopwatch.Start();
                currentFrameIndex = 0;
                isAnimating = true;
                TIMER.Start();
            }
            else
            {
                // Detener la animación
                animationStopwatch.Stop();
                isAnimating = false;
            }
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (isAnimating)
            {
                if (currentFrameIndex < scene.Keyframes.Count - 1)
                {
                    var startFrame = scene.Keyframes[currentFrameIndex];
                    var endFrame = scene.Keyframes[currentFrameIndex + 1];
                    float frameDuration = endFrame.Time - startFrame.Time;
                    float elapsed = (float)animationStopwatch.Elapsed.TotalSeconds;

                    if (elapsed >= endFrame.Time)
                    {
                        currentFrameIndex++;
                        if (currentFrameIndex >= scene.Keyframes.Count - 1)
                        {
                            isAnimating = false;
                            TIMER.Stop();
                            return;
                        }
                    }

                    float t = (elapsed - startFrame.Time) / frameDuration;

                    foreach (Mesh mesh in scene.Models)
                    {
                        Transform startTransform = startFrame.MeshTransforms[mesh];
                        Transform endTransform = endFrame.MeshTransforms[mesh];
                        Transform interpolatedTransform = Interpolate(startTransform, endTransform, t);
                        mesh.Transform = interpolatedTransform;
                    }

                    renderer.RenderScene(scene);
                }
            }
            else
            {
                // Aquí puedes manejar la lógica para otros usos del timer si es necesario
            }
        }

        private void BTN_PLAY_Click(object sender, EventArgs e)
        {
            if (scene.Keyframes.Count < 2)
            {
                MessageBox.Show("Necesitas al menos 2 KeyFrames para la animación.");
                return;
            }

            // Ordena los KeyFrames por tiempo para asegurarte de que estén en el orden correcto
            scene.Keyframes = scene.Keyframes.OrderBy(kf => kf.Time).ToList();

            // Inicia la animación
            PlayAnimation();
        }

        private void BTN_KEYFRAME_Click(object sender, EventArgs e)
        {
            float currentTime = TRACKBAR_KEYFRAME.Value;  // Suponiendo que TRACKBAR_KEYFRAME está configurado correctamente
            SceneKeyframe keyframe = new SceneKeyframe(currentTime);

            foreach (Mesh mesh in scene.Models)
            {
                Transform currentTransform = mesh.GetCurrentTransform();  // Usa el nuevo método
                keyframe.AddMeshTransform(mesh, currentTransform);
            }

            scene.AddKeyframe(keyframe);
            LBL_KEYFRAMECOUNT.Text = $"KeyFrames: {scene.Keyframes.Count}";
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
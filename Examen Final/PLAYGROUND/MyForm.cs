using System;
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

        public MyForm()
        {
            InitializeComponent();
            Init();

            CHECKBOX_RotacionX.CheckedChanged += RotarFigura;
            CHECKBOX_RotacionY.CheckedChanged += RotarFigura;   
            CHECKBOX_RotacionZ.CheckedChanged += RotarFigura;   

            TIMER.Tick += RotarFigura;
        }

        private void Init()
        {
            PCT_CANVAS.SetBounds(panel1.Width + 4, PNL_HEADER.Height + 4,
                Width - panel1.Width - panel2.Width - 24,
                Height - PNL_HEADER.Height - PNL_BOTTOM.Height - 72);
            if (onn == 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "OBJ files (*.obj)|*.obj";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Creamos nuevo canvas
                    canvas = new Canvas(PCT_CANVAS);
                    renderer = new Renderer(canvas);
                    scene = new Scene();
                    //Buscamos nuevo archivo
                    string filename = openFileDialog.FileName;
                    ObjLoader loader = new ObjLoader();
                    Mesh model = loader.Load(filename); // Asegúrate de especificar la ruta correcta del archivo
                    scene.AddModel(model);
                }
                onn = 1;
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


        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (onn == 1)
            {
                /*Mesh modelToRotate = scene.Models[0]; // Asume que solo hay un modelo en la escena

            // Rota el modelo en los ejes X, Y y Z
            modelToRotate.Transform.Rotate(1, 0, 0);
            renderer.RenderScene(scene);*/
                // Obtén la referencia al Mesh que deseas rotar
               // Mesh modelToRotate = scene.Models[0]; // Asume que solo hay un modelo en la escena

                // Rota el modelo en los ejes X, Y y Z
               // modelToRotate.Transform.Rotate(0.01f, 0, 0); // Ajusta los valores de rotación según sea necesario

                // Fuerza el renderizado actualizado
           //     renderer.RenderScene(scene);
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
                //Creamos nuevo canvas
                canvas = new Canvas(PCT_CANVAS);
                renderer = new Renderer(canvas);
                scene = new Scene();
                //Buscamos nuevo archivo
                string filename = openFileDialog.FileName;
                ObjLoader loader = new ObjLoader();
                Mesh model = loader.Load(filename); // Asegúrate de especificar la ruta correcta del archivo
                scene.AddModel(model);
            }

        }

        private void RotarFigura(object sender, EventArgs e)
        {
            if (scene.Models[0] != null)
            {
                // Convertir deltaAngle a radianes una sola vez
                float deltaAngleRadians = deltaAngle * (float)(Math.PI / 180);
                Mesh modelToRotate = scene.Models[0]; // Asume que solo hay un modelo en la escena

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
    }
}
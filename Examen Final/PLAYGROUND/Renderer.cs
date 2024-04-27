
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PLAYGROUND
{
    public class Renderer
    {
        Canvas canvas;
        public Vertex lightDirection = new Vertex { X = 0, Y = 0, Z = -1 }; //Fuente de luz

        public Renderer(Canvas canvas)
        {

            this.canvas = canvas;
        }

        private void Swap(ref Vertex v1, ref Vertex v2)
        {
            Vertex temp = v1;
            v1 = v2;
            v2 = temp;
        }

        public void UpdateLightDirection(float x, float y, float z)
        {
            lightDirection.X = x;
            lightDirection.Y = y;
            lightDirection.Z = z;
        }

        public void SortByY(Triangle triangle)
        {
            List<Vertex> vertices = new List<Vertex> { triangle.A, triangle.B, triangle.C };
            vertices.Sort((v1, v2) => v1.Position.Y.CompareTo(v2.Position.Y));
            triangle.A = vertices[0];
            triangle.B = vertices[1];
            triangle.C = vertices[2];
        }


        private List<float> Interpolate(float start, float end, int steps)
        {
            List<float> values = new List<float>();

            if (steps <= 0)
            {
                values.Add(start);
                return values;
            }

            float stepSize = (end - start) / steps;
            float value = start;

            for (int i = 0; i <= steps; i++)
            {
                values.Add(value);
                value += stepSize;
            }

            return values;
        }

       public void DrawLine(Vertex v0, Vertex v1, Color color)
{
    int steps = Math.Max(Math.Abs((int)(v1.X - v0.X)), Math.Abs((int)(v1.Y - v0.Y)));
    List<float> xValues = Interpolate(v0.X, v1.X, steps);
    List<float> yValues = Interpolate(v0.Y, v1.Y, steps);
    List<float> zValues = Interpolate(v0.Z, v1.Z, steps);

    for (int i = 0; i <= steps; i++)
    {
        canvas.SetPixel((int)Math.Round(xValues[i]), (int)Math.Round(yValues[i]), zValues[i], color);
    }
}


        private Vertex CalculateNormal(Vertex v1, Vertex v2, Vertex v3)
        {
            // Calcular los vectores de los lados del triángulo
            Vertex edge1 = new Vertex
            {
                X = v2.X - v1.X,
                Y = v2.Y - v1.Y,
                Z = v2.Z - v1.Z
            };

            Vertex edge2 = new Vertex
            {
                X = v3.X - v1.X,
                Y = v3.Y - v1.Y,
                Z = v3.Z - v1.Z
            };

            // Calcular el producto vectorial de los vectores de los lados para obtener la normal
            Vertex normal = new Vertex
            {
                X = edge1.Y * edge2.Z - edge1.Z * edge2.Y,
                Y = edge1.Z * edge2.X - edge1.X * edge2.Z,
                Z = edge1.X * edge2.Y - edge1.Y * edge2.X
            };

            // Si la normal es cero (los vectores de los lados son paralelos o se cruzan), devolvemos una normal predeterminada
            if (normal.X == 0 && normal.Y == 0 && normal.Z == 0)
            {
                normal = new Vertex { X = 0, Y = 0, Z = 1 }; // Normal predeterminada apuntando hacia arriba
            }
            else
            {
                // Normalizar el vector normal
                float length = (float)Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y + normal.Z * normal.Z);
                normal.X /= length;
                normal.Y /= length;
                normal.Z /= length;
            }

            return normal;
        }

        public void DrawFilledTriangle(Vertex v0, Vertex v1, Vertex v2, Color color)
        {
            List<Vertex> vertices = new List<Vertex> { v0, v1, v2 };
            vertices.Sort((a, b) => a.Y.CompareTo(b.Y));

            v0 = vertices[0];
            v1 = vertices[1];
            v2 = vertices[2];

            int y0 = (int)v0.Y;
            int y1 = (int)v1.Y;
            int y2 = (int)v2.Y;

            List<float> x01 = Interpolate(v0.X, v1.X, y1 - y0);
            List<float> z01 = Interpolate(v0.Z, v1.Z, y1 - y0);
            List<float> x02 = Interpolate(v0.X, v2.X, y2 - y0);
            List<float> z02 = Interpolate(v0.Z, v2.Z, y2 - y0);
            List<float> x12 = Interpolate(v1.X, v2.X, y2 - y1);
            List<float> z12 = Interpolate(v1.Z, v2.Z, y2 - y1);

            for (int y = y0; y <= y2; y++)
            {
                int xStart = y < y1 ? (int)x01[y - y0] : (int)x12[y - y1];
                float zStart = y < y1 ? z01[y - y0] : z12[y - y1];
                int xEnd = (int)x02[y - y0];
                float zEnd = z02[y - y0];

                if (xStart > xEnd) // Asegúrate de que xStart es siempre menor o igual a xEnd
                {
                    int tempX = xStart;
                    xStart = xEnd;
                    xEnd = tempX;

                    float tempZ = zStart;
                    zStart = zEnd;
                    zEnd = tempZ;
                }

                List<float> zValues = Interpolate(zStart, zEnd, xEnd - xStart);

                for (int x = xStart; x <= xEnd; x++)
                {
                    canvas.SetPixel(x, y, zValues[x - xStart], color);
                }
            }
        }




        public void RenderTriangle(PointF p1, PointF p2, PointF p3)
        {
            Vertex v1 = new Vertex { X = p1.X, Y = p1.Y, Z = 0, Color = Color.White };
            Vertex v2 = new Vertex { X = p2.X, Y = p2.Y, Z = 0, Color = Color.White };
            Vertex v3 = new Vertex { X = p3.X, Y = p3.Y, Z = 0, Color = Color.White };

            Triangle triangle = new Triangle(v1, v2, v3);
            SortByY(triangle);
            DrawLine(triangle.A, triangle.B, Color.White);
            DrawLine(triangle.B, triangle.C, Color.White);
            DrawLine(triangle.C, triangle.A, Color.White);
        }

        public PointF PerspectiveTransform(Vertex vertex, float cameraZ, float focalLength)
        {
            float z = vertex.Z - cameraZ;
            if (z == 0) z = 0.001f; // Prevent division by zero
            return new PointF(
                (vertex.X * focalLength / z) + canvas.Width / 2,
                (vertex.Y * focalLength / z) + canvas.Height / 2
            );
        }

        public void RenderScene(Scene scene)
        {
            canvas.FastClear(); // Clears the canvas

            float cameraZ = -5.0f;
            float focalLength = 200;

            for (int j = 0; j < scene.Models.Count; j++)
            {
                Mesh mesh = scene.Models[j];
                List<Vertex> transformedVertices = new List<Vertex>();

                for (int i = 0; i < mesh.Vertices.Count; i++)
                {
                    Vertex vertex = mesh.Vertices[i];
                    Vertex rotated = Rotaciones.Rot(mesh.Transform.RotationX, vertex, 'X');
                    rotated = Rotaciones.Rot(mesh.Transform.RotationY, rotated, 'Y');
                    rotated = Rotaciones.Rot(mesh.Transform.RotationZ, rotated, 'Z');


                    // Trasladar el vértice
                    Vertex traslated = new Vertex
                    {
                        X = rotated.X + mesh.Transform.TranslationX,
                        Y = rotated.Y + mesh.Transform.TranslationY,
                        Z = rotated.Z + mesh.Transform.TranslationZ,

                    };
                    transformedVertices.Add(traslated);
                }

                for (int i = 0; i < mesh.Indexes.Count; i += 3)
                {
                    Vertex v1 = transformedVertices[mesh.Indexes[i]];
                    Vertex v2 = transformedVertices[mesh.Indexes[i + 1]];
                    Vertex v3 = transformedVertices[mesh.Indexes[i + 2]];

                    // Transform vertices to perspective
                    PointF p1 = PerspectiveTransform(v1, cameraZ, focalLength);
                    PointF p2 = PerspectiveTransform(v2, cameraZ, focalLength);
                    PointF p3 = PerspectiveTransform(v3, cameraZ, focalLength);

                    // Create transformed vertices
                    Vertex v1Transformed = new Vertex { X = p1.X, Y = p1.Y, Z = v1.Z, Color = v1.Color };
                    Vertex v2Transformed = new Vertex { X = p2.X, Y = p2.Y, Z = v2.Z, Color = v2.Color };
                    Vertex v3Transformed = new Vertex { X = p3.X, Y = p3.Y, Z = v3.Z, Color = v3.Color };

                    // Calcular la normal del triángulo
                    Vertex normal = CalculateNormal(v1, v2, v3);
                    

                    // Calcular la intensidad de la luz reflejada utilizando la ley de Lambert
                    float intensity = Math.Max(0, normal.X * lightDirection.X + normal.Y * lightDirection.Y + normal.Z * lightDirection.Z);
                    

                    // Calcular el color final del triángulo teniendo en cuenta la intensidad de la luz
                    Color triangleColor = Color.FromArgb(
                        Clamp((int)(intensity * 255), 0, 255),
                        Clamp((int)(intensity * 255), 0, 255),
                        Clamp((int)(intensity * 255), 0, 255)
                    );

                    DrawFilledTriangle(v1Transformed, v2Transformed, v3Transformed, triangleColor);
                }
            }

            canvas.Refresh(); // Refreshes the PictureBox to display the new content
        }



        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }



    }
}

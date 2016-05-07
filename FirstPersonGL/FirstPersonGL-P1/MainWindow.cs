using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace FirstPersonGL
{
    class MainWindow : GameWindow
    {
        //
        // OnResize
        //  - Game window sizing and 3D projection setup
        //
        protected override void OnResize(EventArgs e)
        {
            int w = Width;
            int h = Height;
            float aspect = 1;

            // Calculate aspect ratio, checking for divide by zero
            if (h > 0)
            {
                aspect = (float)w / (float)h;
            }

            // Initialise the projection view matrix
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Setup a perspective view
            float FOVradians = MathHelper.DegreesToRadians(45);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(FOVradians, aspect, 1, 4000);
            GL.MultMatrix(ref perspective);

            // Set the viewport to the whole window
            GL.Viewport(0, 0, w, h);
        }

        //
        // OnRenderFrame
        //  - Draw a single 3D frame
        //
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // Clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Initialise the model view matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Draw the scene
            DrawScene();

            // Display the new frame
            SwapBuffers();
        }

        //
        // DrawScene
        //  - Draws our game world
        //
        private void DrawScene()
        {
            GL.Color3(Color.Orange);

            GL.Translate(50, 20, -200);

            GL.Begin(BeginMode.Quads);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(20, 0, 0);
            GL.Vertex3(20, 20, 0);
            GL.Vertex3(0, 20, 0);
            GL.End();
        }

    }
}

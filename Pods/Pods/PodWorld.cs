using Model;
using System.Numerics;

namespace Pods
{
    public partial class PodWorld : Form
    {
        // how much faster than real life is our simulation running ?
        const float SIMULATION_ACCELERATION_FACTOR = 100.0f;

        // This example assumes the existence of a form called Form1.
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        Font drawFont = new Font("Arial", 10);
        SolidBrush writingBrush = new SolidBrush(Color.Black);

        public PodWorld()
        {
            InitializeComponent();
            World.Init();
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with Form1, and with
            // dimensions the same size as the drawing surface of Form1.
            myBuffer = currentContext.Allocate(this.CreateGraphics(),
               this.DisplayRectangle);
            numSpeedFactor.Value = (int)SIMULATION_ACCELERATION_FACTOR;
        }

        private void tmrLife_Tick(object sender, EventArgs e)
        {
            UpdateModel();
            Render();
        }

        private void UpdateModel()
        {
            // number of hours elapsed since last update
            float simultime = (float)(tmrLife.Interval / 1000.0 / 60.0 / 60.0);
            // move Pods on roads
            foreach (Road road in World.Roads)
            {
                road.MovePods(simultime * (float)numSpeedFactor.Value);
            }

            // Put a Pod in motion
            if (World.alea.Next(30) == 0)
            {
                Hub source = World.Hubs[World.alea.Next(World.Hubs.Count)];
                Pod pod = source.CheckoutRandomPod();
                if (pod != null)
                {
                    pod.Speed = World.alea.Next(100, 300);
                    source.GetAnExitRoad().AllowEnter(pod);
                    Console.WriteLine($"Pod {pod.Id} leaves {source.Name}");
                }
            }
        }
        private void Render()
        {
            myBuffer.Graphics.Clear(Color.AliceBlue);

            // draw roads
            Pen p = new Pen(new SolidBrush(Color.LightGray), 1);
            Pen p2 = new Pen(new SolidBrush(Color.Red), 3);
            foreach (Road road in World.Roads)
            {
                myBuffer.Graphics.DrawLine(p, road.EntryPoint.X, road.EntryPoint.Y, road.ExitPoint.X, road.ExitPoint.Y);
                foreach (Pod pod in road.Pods)
                    myBuffer.Graphics.DrawEllipse(p2, new Rectangle((int)pod.Position.X - 4, (int)pod.Position.Y - 2, 4, 4));
            }

            p = new Pen(new SolidBrush(Color.Blue), 8);

            // Draw hubs
            foreach (Hub hub in World.Hubs)
            {
                myBuffer.Graphics.DrawEllipse(p, new Rectangle((int)hub.Position.X - Hub.DIAMETER / 2, (int)hub.Position.Y - Hub.DIAMETER / 2, Hub.DIAMETER, Hub.DIAMETER));
                if (chkShowHubStats.Checked)
                    myBuffer.Graphics.DrawString($"{hub.Name}\n{hub.Parking.Count} Pods", drawFont, writingBrush, hub.Position.X + Hub.DIAMETER, hub.Position.Y - Hub.DIAMETER);
            }
            myBuffer.Render();
        }

    }
}
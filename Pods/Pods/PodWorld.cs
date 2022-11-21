using Model;
using System.Numerics;
using System.Windows.Forms;

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
            if (World.alea.Next(15) == 0)
            {
                CrossRoad source;
                do
                {
                    source = World.CrossRoads[World.alea.Next(World.CrossRoads.Count)];
                } while (source.GetType() != typeof(Hub));
                Pod? pod = ((Hub)source).CheckoutRandomPod();
                if (pod != null)
                {
                    pod.Speed = World.alea.Next(100, 300);
                    Road road = source.GetAnExitRoad();
                    road.AllowEnter(pod);
                    Console.WriteLine($"{pod.GetType().ToString()} {pod.Id} gets on {road.Name}");
                }
            }
        }
        private void Render()
        {
            myBuffer.Graphics.Clear(Color.AliceBlue);

            // draw roads
            Pen roadBrush = new Pen(new SolidBrush(Color.LightGray), 1);
            Pen taxiBrush = new Pen(new SolidBrush(Color.Red), 3);
            Pen truckBrush = new Pen(new SolidBrush(Color.DarkGray), 3);
            foreach (Road road in World.Roads)
            {
                myBuffer.Graphics.DrawLine(roadBrush, road.EntryPoint.X, road.EntryPoint.Y, road.ExitPoint.X, road.ExitPoint.Y);
                foreach (Pod pod in road.Pods)
                    myBuffer.Graphics.DrawEllipse((pod.GetType() == typeof(Taxi)) ? taxiBrush : truckBrush, new Rectangle((int)pod.Position.X - 4, (int)pod.Position.Y - 2, 4, 4));
            }

            Pen crossRoadBrush = new Pen(new SolidBrush(Color.Gray), 8);
            Pen hubBrush = new Pen(new SolidBrush(Color.Blue), 8);

            // Draw crossroads and hubs
            foreach (CrossRoad crossRoad in World.CrossRoads)
            {
                int diameter = (crossRoad.GetType() == typeof(Hub)) ? Hub.DIAMETER : CrossRoad.DIAMETER;
                myBuffer.Graphics.DrawEllipse((crossRoad.GetType() == typeof(Hub))? hubBrush : crossRoadBrush, new Rectangle((int)crossRoad.Position.X - diameter / 2, (int)crossRoad.Position.Y - diameter / 2, diameter, diameter));
                if (chkShowHubStats.Checked)
                    if (crossRoad.GetType() == typeof(Hub))
                        myBuffer.Graphics.DrawString($"{crossRoad.Name}\n{((Hub)crossRoad).Parking.Count} Pods", drawFont, writingBrush, crossRoad.Position.X + diameter, crossRoad.Position.Y - diameter);
                    else
                        myBuffer.Graphics.DrawString($"{crossRoad.Name}", drawFont, writingBrush, crossRoad.Position.X + diameter, crossRoad.Position.Y - diameter);
            }
            myBuffer.Render();
        }

    }
}
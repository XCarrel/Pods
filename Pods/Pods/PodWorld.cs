using Model;
using System.Numerics;

namespace Pods
{
    public partial class PodWorld : Form
    {
        // This example assumes the existence of a form called Form1.
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
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
        }

        private void tmrLife_Tick(object sender, EventArgs e)
        {
            UpdateModel();
            Render();
        }

        private void UpdateModel()
        {
            // move Pods on roads
            foreach (Road road in World.Roads)
                foreach (PodTracker tracker in road.Pods)
                {
                    double dt = 10.0 / 3600; // simulated time: 1min simu = 1h real time
                    double distance = tracker.Pod.Speed * dt;
                    tracker.Completion += distance / road.Length();
                    Vector2 newPos = new Vector2(
                        (int)(road.Entry().X + tracker.Completion * (road.Exit().X - road.Entry().X)),
                        (int)(road.Entry().Y + tracker.Completion * (road.Exit().Y - road.Entry().Y))
                    );
                    tracker.Pod.Position = newPos;
                }

            // Manage road exits
            foreach (Road road in World.Roads)
                foreach (PodTracker tracker in road.Pods.ToList())
                    if (tracker.Completion >= 1.0)
                    {
                        road.To.AddPod(tracker.Pod); // park the pod at its destination
                        road.Pods.Remove(tracker);
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
                myBuffer.Graphics.DrawLine(p, road.Entry().X, road.Entry().Y, road.Exit().X, road.Exit().Y);
                foreach (PodTracker pod in road.Pods)
                    myBuffer.Graphics.DrawEllipse(p2, new Rectangle((int)pod.Pod.Position.X - 4, (int)pod.Pod.Position.Y - 2, 4, 4));
            }

            p = new Pen(new SolidBrush(Color.Blue), 8);
            // Draw hubs
            foreach (Hub hub in World.Hubs)
            {
                myBuffer.Graphics.DrawEllipse(p, new Rectangle((int)hub.Position.X - Hub.DIAMETER / 2, (int)hub.Position.Y - Hub.DIAMETER / 2, Hub.DIAMETER, Hub.DIAMETER));
            }
            myBuffer.Render();
        }

    }
}
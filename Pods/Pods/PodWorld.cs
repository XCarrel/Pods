using Model;
using System.Numerics;

namespace Pods
{
    public partial class PodWorld : Form
    {
        World world;
        Graphics graphics;
        public PodWorld()
        {
            InitializeComponent();
            world = new World();
            world.Init();
            graphics = this.CreateGraphics();
        }

        private void tmrLife_Tick(object sender, EventArgs e)
        {
            Update();
            Render();
        }

        private void Update()
        {
            // move Pods on roads
            foreach (Road road in world.Roads)
                foreach (PodTracker tracker in road.Pods)
                {
                    double dt = 10.0 / 3600 ; // simulated time: 1min simu = 1h real time
                    double distance = tracker.Pod.Speed * dt;
                    tracker.Completion += distance / road.Length();
                    Vector2 newPos = new Vector2 (
                        (int)(road.Entry().X + tracker.Completion * (road.Exit().X - road.Entry().X)), 
                        (int)(road.Entry().Y + tracker.Completion * (road.Exit().Y - road.Entry().Y))
                    );
                    tracker.Pod.Position=newPos;
                }
        }
        private void Render()
        {
            graphics.Clear(Color.AliceBlue);
            Pen p = new Pen(new SolidBrush(Color.Blue), 3);
            // Draw hubs
            foreach (Hub hub in world.Hubs)
            {
                graphics.DrawEllipse(p, new Rectangle((int)hub.Position.X - Hub.DIAMETER/2, (int)hub.Position.Y - Hub.DIAMETER/2, Hub.DIAMETER, Hub.DIAMETER));
            }

            // draw roads
            p = new Pen(new SolidBrush(Color.Black), 1);
            Pen p2 = new Pen(new SolidBrush(Color.Red), 3);
            foreach (Road road in world.Roads)
            {
                graphics.DrawLine(p, road.Entry().X, road.Entry().Y, road.Exit().X, road.Exit().Y);
                foreach (PodTracker pod in road.Pods)
                    graphics.DrawEllipse(p2, new Rectangle((int)pod.Pod.Position.X - 4, (int)pod.Pod.Position.Y - 2, 4, 4));
            }
        }

    }
}
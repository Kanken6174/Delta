
using Game.Model.movement;
using Game.Model.Observable;
using Microsoft.Kinect;
using MonoDelta.Game.Model.Entity;
using System.IO;

namespace Kinect
{
    /// <summary>
    /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
    /// </summary>
    public class KinectManager : Observable
    {

        public Position RightHandPos { get; set; }
        private Skeleton[] skeletons;

        /// <summary>
        /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
        /// </summary>
        public KinectManager() {
            RightHandPos = new Position
            {
                Xpos = 100
            };
        }
        public KinectSensor Kinect { get; private set; }

        /// <summary>
        /// @return
        /// </summary>
        public KinectSkeleton ReadSkeleton(){
            // TODO implement here
            return null;
        }

        private void Kinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            SkeletonFrame currentFrame = e.OpenSkeletonFrame();
            if (currentFrame == null)
                return;
            if ((this.skeletons == null) || (this.skeletons.Length != currentFrame.SkeletonArrayLength))
            {
                this.skeletons = new Skeleton[currentFrame.SkeletonArrayLength];
            }
            currentFrame.CopySkeletonDataTo(skeletons);

            Joint hand = skeletons[0].Joints[JointType.HandRight];
            if (hand.TrackingState == JointTrackingState.NotTracked)
                return;
            RightHandPos.Ypos = -((hand.Position.Y)*250*3);
            RightHandPos.Xpos = (hand.Position.X)*250*3;

            EntityManager.GetCrosshair().position.Xpos = RightHandPos.Xpos;
            EntityManager.GetCrosshair().position.Ypos = RightHandPos.Ypos;
        }

        public void SetKinectAngle(int angle)
        {
            if (Kinect == null)
                return;
            try
            {
                Kinect.ElevationAngle = angle;
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        public void Init() {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.Kinect = potentialSensor;
                    SetKinectAngle(0);
                    break;
                }
            }

            if (null != this.Kinect)
            {
                // Turn on the skeleton stream to receive skeleton frames
                //this.kinect.SkeletonStream.Enable();

                // Start the sensor!
                try
                {
                    this.Kinect.Start();
                    Kinect.SkeletonFrameReady += Kinect_SkeletonFrameReady;
                    Kinect.SkeletonStream.Enable();
                }
                catch (IOException)
                {
                    this.Kinect = null;
                }
            }
        }

        public void Stop() {
            Kinect.Stop();
            // TODO implement here
        }

    }
}
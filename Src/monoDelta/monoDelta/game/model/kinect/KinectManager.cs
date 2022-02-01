
using game.model.movement;
using game.model.observable;
using Microsoft.Kinect;
using System.IO;

namespace kinect
{
    /// <summary>
    /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
    /// </summary>
    public class KinectManager : Observable {

        public Position rightHandPos { get; set; }
        private Skeleton[] skeletons;

        /// <summary>
        /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
        /// </summary>
        public KinectManager() {
            rightHandPos = new Position();
            rightHandPos.xpos = 100;
        }
        public KinectSensor kinect { get; private set; }

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
            rightHandPos.ypos = hand.Position.Y*500;
            rightHandPos.xpos = hand.Position.X*500;
        }

        public void setKinectAngle(int angle)
        {
            if (kinect == null)
                return;
            try
            {
                kinect.ElevationAngle = angle;
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
                    this.kinect = potentialSensor;
                    break;
                }
            }

            if (null != this.kinect)
            {
                // Turn on the skeleton stream to receive skeleton frames
                //this.kinect.SkeletonStream.Enable();

                // Start the sensor!
                try
                {
                    this.kinect.Start();
                    kinect.SkeletonFrameReady += Kinect_SkeletonFrameReady;
                    kinect.SkeletonStream.Enable();
                }
                catch (IOException)
                {
                    this.kinect = null;
                }
            }
        }

        public void Stop() {
            kinect.Stop();
            // TODO implement here
        }

    }
}

using Game.Model.Entity;
using Game.Model.movement;
using Microsoft.Kinect;
using MonoDelta.Game.Model.Entity;
using System.Collections.Generic;
using System.IO;

namespace Kinect
{
    /// <summary>
    /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
    /// </summary>
    public class KinectManager
    {
        //Position fo the right hand
        public List<Position> RightHandPos { get; set; } = new List<Position>();
        //The index of the skeleton to be used with the kinect
        public ushort SkeletonIndex { get; set; }
        //An array used to store all the skeletons detected by the kinect (up to 10 with the kinect V1), only one will be used for target tracking
        private Skeleton[] skeletons;

        /// <summary>
        /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
        /// </summary>
        public KinectManager()
        {
            RightHandPos = new List<Position>
            {
                new Position(){ }
            };
            SkeletonIndex = 0;
        }
        public KinectSensor Kinect { get; private set; }

        /// <summary>
        /// @return
        /// </summary>
        public KinectSkeleton ReadSkeleton()
        {
            // TODO implement here
            return null;
        }

        private void Kinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame currentFrame = e.OpenSkeletonFrame())
            {
                RightHandPos.Clear();
                if (currentFrame == null)
                    return;
                if ((this.skeletons == null) || (this.skeletons.Length != currentFrame.SkeletonArrayLength))
                {
                    this.skeletons = new Skeleton[currentFrame.SkeletonArrayLength];
                }
                currentFrame.CopySkeletonDataTo(skeletons);
                for (ushort i = 0; i < skeletons.Length; i++)
                {
                    Joint possibleHand = skeletons[i].Joints[JointType.HandRight];
                    if (possibleHand.TrackingState != JointTrackingState.NotTracked)
                    {
                        Position pos = new Position();
                        pos.Ypos = -((possibleHand.Position.Y) * 250 * 3)+100*2; //We offset the target to be at the center of the screen, and scaled properly
                        pos.Xpos = ((possibleHand.Position.X) * 250 * 3)+400;
                        RightHandPos.Add(pos);
                    }

                }

            EntityManager.SetCrosshairs(RightHandPos);
                
            }
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

        public void Init()
        {
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

        public void Stop() => Kinect.Stop();

        public void reset()
        {
            Kinect.Stop();
            Init();
        }
    }
}
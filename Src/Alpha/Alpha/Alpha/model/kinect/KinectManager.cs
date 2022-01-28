
using game.model.observable;
using Microsoft.Kinect;
using System.IO;

namespace kinect
{
    /// <summary>
    /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
    /// </summary>
    public class KinectManager : Observable {

        /// <summary>
        /// The KinectManager class will take care of all kinect-related operations and notify the subscribed classes whenever skeletal data is ready.
        /// </summary>
        public KinectManager() {
        }
        public KinectSensor kinect { get; private set; }

        /// <summary>
        /// @return
        /// </summary>
        public KinectSkeleton ReadSkeleton() {
            // TODO implement here
            return null;
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
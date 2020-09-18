namespace Kinectronics
{
    using Microsoft.Kinect;
    using System;
    using Kinectronics.GestureDataBases;
    using Kinectronics.Devices.UniversalRobots.Webots.URe;
    using System.Windows.Controls;

    public class GestureDetector
    {

        // Textblocks for displaying data in the GUI
        private TextBlock database_gd;
        private TextBlock gesture_gd;
        private TextBlock device_gd;
        private TextBlock command_gd;

        // Here you can make reference to another gesture db
        private KinectronicsDefaultGestureDataBase gestureDB;

        public string detectedGesture = null;

        // Definition of the device to use, e.g.
        private TCPUR5 ur5;

        // Definition of the connection type (Uncomment for your app)
        private string connectionType = "WiFi";

        public GestureDetector(KinectSensor kinectSensor, TextBlock database, TextBlock gesture, TextBlock device, TextBlock command)
        {
            if (kinectSensor == null)
            {
                throw new ArgumentNullException("kinectSensor");
            }
            gestureDB = new KinectronicsDefaultGestureDataBase();
            database_gd = database;
            gesture_gd = gesture;
            device_gd = device;
            command_gd = command;

            // Show in the UI the db used, so far is a manual task
            this.database_gd.Text = "KinectronicsDefaultGestureDataBase";

            // Write your program's logic from this point:

            // Show the device in the GUI, so far is a manual task
            this.device_gd.Text = "UR5 (Webots)";

            // Inicialization of the UR5 Object
            ur5 = new TCPUR5(connectionType);

            // Try to reach ur5 in Webots through WiFi
            ur5.StablishConnection();
        }

        public string DetectGesture(Body body)
        {
            if (body != null)
            {
                if (body.IsTracked)
                {
                    detectedGesture = gestureDB.GetGesture(body);
                    // Show the tracked gesture in the UI
                    this.gesture_gd.Text = detectedGesture;
                    // Send the detected gesture to the controller method
                    Controller(detectedGesture);
                    SecondaryController(body);
                }
            }
            return "no tracked body";
        }

        // Controller Method, here a task for a device should be linked to a defined gesture
        // With the assignation of a string to command_gd, in the UI is displayed the command
        // This controller works for the DefaultGestureDataBase. For custom ones, the cases
        // have to be modified.
        private void Controller(string detectedGesture)
        {
            switch (detectedGesture)
            {
                case "Arms45UpPosition":
                    // E.G: this.command_gd.Text = "Move Up";
                    this.command_gd.Text = "none";
                    break;
                case "Arms45DownPosition":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsFrontPosition_L":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsFrontPosition_R":
                    this.command_gd.Text = "UR5 front";
                    ur5.moveFront();
                    break;
                case "ArmsHRectanglePosition_L":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsHRectanglePosition_R":
                    this.command_gd.Text = "UR5 half rectangle";
                    ur5.moveHRPosition();
                    break;
                case "ArmsRectanglePosition_L":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsRectanglePosition_R":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsSidePosition_L":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsSidePosition_R":
                    this.command_gd.Text = "UR5 right";
                    ur5.moveRight();
                    break;
                case "ArmsSquarePosition_L":
                    this.command_gd.Text = "none";
                    break;
                case "ArmsSquarePosition_R":
                    this.command_gd.Text = "none";
                    break;
                default:
                    this.command_gd.Text = "UR5 down";
                    ur5.moveDown();
                    break;
            }
        }

        private void SecondaryController(Body body)
        {
            if(body.HandLeftState == HandState.Closed) 
            {
                ur5.DeactivateTool();
            }
            if(body.HandLeftState == HandState.Open)
            {
                ur5.ActivateTool();
            }
        }

        // Dispose Method
        public void Dispose()
        {
            // Here a the StopConnection for a device should be called.
            ur5.StopConnection();
        }

    }
}

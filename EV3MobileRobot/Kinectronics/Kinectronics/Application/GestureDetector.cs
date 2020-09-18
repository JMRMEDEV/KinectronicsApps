namespace Kinectronics
{
    using Microsoft.Kinect;
    using System;
    using Kinectronics.GestureDataBases;
    using System.Windows.Controls;
    using Kinectronics.Devices.LEGO.Mindstorms;

    public class GestureDetector
    {

        // Textblocks for displaying data in the GUI
        private TextBlock database_gd;
        private TextBlock gesture_gd;
        private TextBlock device_gd;
        private TextBlock command_gd;

        // Definition of the used Gesture DB
        private KinectronicsDefaultGestureDataBase gestureDB;

        public string detectedGesture = null;

        // Definition of the Bebop2 drone
        private EV3MobileRobot eV3Mobile = null;

        // Definition of the connection type
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
            this.database_gd.Text = "KinectronicsDefaultGestureDataBase";

            // Write your program's logic from this point:

            // Inicialization of the Bebop2 Object
            eV3Mobile = new EV3MobileRobot(connectionType);
            // Try to reach ev3 through WiFi
            eV3Mobile.StablishConnection();
            // Show the device in the GUI
            this.device_gd.Text = "EV3MobileRobot";
        }

        public string DetectGesture(Body body)
        {
            if (body != null)
            {
                if (body.IsTracked)
                {
                    detectedGesture = gestureDB.GetGesture(body);
                    this.gesture_gd.Text = detectedGesture;
                    // Send the detected gesture to the controller method
                    ControlBebop2(detectedGesture);
                }
            }
            return "no tracked body";
        }

        // Controller Method
        private void ControlBebop2(string detectedGesture)
        {
            switch (detectedGesture)
            {
                case "Arms45UpPosition":
                    this.command_gd.Text = "None";
                    break;
                case "Arms45DownPosition":
                    this.command_gd.Text = "None";
                    break;
                case "ArmsFrontPosition_L":
                    this.command_gd.Text = "Move Forward";
                    eV3Mobile.MoveForward();
                    break;
                case "ArmsFrontPosition_R":
                    this.command_gd.Text = "Move Forward";
                    eV3Mobile.MoveForward();
                    break;
                case "ArmsHRectanglePosition_L":
                    this.command_gd.Text = "None";
                    break;
                case "ArmsHRectanglePosition_R":
                    this.command_gd.Text = "None";
                    break;
                case "ArmsRectanglePosition_L":
                    this.command_gd.Text = "None";
                    break;
                case "ArmsRectanglePosition_R":
                    this.command_gd.Text = "None";
                    break;
                case "ArmsSidePosition_L":
                    this.command_gd.Text = "Turn Left";
                    eV3Mobile.TurnLeft();
                    break;
                case "ArmsSidePosition_R":
                    this.command_gd.Text = "Turn Right";
                    eV3Mobile.TurnRight();
                    break;
                case "ArmsSquarePosition_L":
                    this.command_gd.Text = "Move Backward";
                    eV3Mobile.MoveBackward();
                    break;
                case "ArmsSquarePosition_R":
                    this.command_gd.Text = "Move Backward";
                    eV3Mobile.MoveBackward();
                    break;
                default:
                    this.command_gd.Text = "Stop";
                    eV3Mobile.Stop();
                    break;
            }
        }

        // Dispose Method
        public void Dispose()
        {
            eV3Mobile.StopConnection();
        }
    }
}
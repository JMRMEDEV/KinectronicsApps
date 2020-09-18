namespace Kinectronics
{
    using Microsoft.Kinect;
    using System;
    using Kinectronics.GestureDataBases;
    using System.Windows.Controls;

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
        private Bebop2 bebop2 = null;

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
            bebop2 = new Bebop2(connectionType);
            // Try to reach the WiFi IP by the port 4444 TODO: Implement exception
            bebop2.StablishConnection();
            // Show the device in the GUI
            this.device_gd.Text = "Bebop2";
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
                    this.command_gd.Text = "Takeoff";
                    bebop2.TakeOff();
                    break;
                case "Arms45DownPosition":
                    this.command_gd.Text = "Land";
                    bebop2.Land();
                    break;
                case "ArmsFrontPosition_L":
                    this.command_gd.Text = "Move Forward";
                    bebop2.MoveForward();
                    break;
                case "ArmsFrontPosition_R":
                    this.command_gd.Text = "Move Forward";
                    bebop2.MoveForward();
                    break;
                case "ArmsHRectanglePosition_L":
                    this.command_gd.Text = "Decrease altitude";
                    bebop2.DecreaseAltitude();
                    break;
                case "ArmsHRectanglePosition_R":
                    this.command_gd.Text = "Increase altitude";
                    bebop2.IncreaseAltitude();
                    break;
                case "ArmsRectanglePosition_L":
                    this.command_gd.Text = "Turn Left";
                    bebop2.TurnLeft();
                    break;
                case "ArmsRectanglePosition_R":
                    this.command_gd.Text = "Turn Right";
                    bebop2.TurnRight();
                    break;
                case "ArmsSidePosition_L":
                    this.command_gd.Text = "Move Left";
                    bebop2.MoveLeft();
                    break;
                case "ArmsSidePosition_R":
                    this.command_gd.Text = "Move Right";
                    bebop2.MoveRight();
                    break;
                case "ArmsSquarePosition_L":
                    this.command_gd.Text = "Move Backward";
                    bebop2.MoveBackward();
                    break;
                case "ArmsSquarePosition_R":
                    this.command_gd.Text = "Move Backward";
                    bebop2.MoveBackward();
                    break;
                default:
                    this.command_gd.Text = "Pause";
                    bebop2.Pause();
                    break;
            }
        }
    }
}
# LEGO Mindstorms EV3 Arm Controller

This example uses a modded version of the [official EV3 arm](https://le-www-live-s.legocdn.com/sc/media/lessons/mindstorms-ev3/building-instructions/ev3-model-core-set-robot-arm-h25-56cdb22c1e3a02f1770bda72862ce2bd.pdf) by LEGO. It was modified to take away the unused sensors and make it more compatible with **Virtual Robotics Toolkit**. However, it was designed a way to behave like the official model. If you need the buliding instructions of the modified version, please contact me.

In this example app, the gestures of the database [DefaultGestureDatabase](https://github.com/JMRMEDEV/Kinectronics/wiki/Gesture-Databases#default-gesture-database) are linked to every defined arm command.

The relationship gesture-drone_command is defined in the following list:

1. **Gesture:** Arms45UpPosition. **Command:** MoveUp().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3ArmV1Controller/ev3armup.png">

2. **Gesture:** Arms45DownPosition. **Command:** MoveDown().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3ArmV1Controller/ev3armdown.png">

3. **Gesture:** ArmsFrontPosition_L. **Command** DeactivateTool().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3ArmV1Controller/ev3armopen.png">

4. **Gesture:** ArmsFrontPosition_R. **Command:** ActivateTool().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3ArmV1Controller/ev3armclose.png">

5. **Gesture:** ArmsHRectanglePosition_L. **Command:** None.

6. **Gesture:** ArmsHRectanglePosition_R. **Command:** None.

7. **Gesture:** ArmsRectanglePosition_L. **Command:** None.

8. **Gesture:** ArmsRectanglePosition_R. **Command:** None.

9. **Gesture:** ArmsSidePosition_L. **Command:** MoveLeft().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3ArmV1Controller/ev3armleft.png">

10. **Gesture:** ArmsSidePosition_R. **Command:** MoveRight().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3ArmV1Controller/ev3armright.png">

11. **Gesture:** ArmsSquarePosition_L. **Command:** None.

12. **Gesture:** ArmsSquarePosition_R. **Command:** None.

13. **Gesture:** None. **Command:** Stop().

## Simulation

This app runs a simulation on [Virtual Robotics Toolkit (VRT)](https://www.virtualroboticstoolkit.com/) through WiFi, just like the real robot.

If you want to run this sample, you need the Virtual Robotics Toolkit (VRT) project. You can find it [**here**](https://drive.google.com/file/d/10Gw1xS2v8jqANcN9NUHJOkB6trNm8DRT/view?usp=sharing).

**Note:** take into account that VRT from time to time have some weird bugs. In this case, the first time the simulation is launched, motors B and C will not respond. For overcoming this, just close the **intelligent brick** window, stop the simulation, start it again and re-open the **intelligent brick** window. Also, please, check the [**VRT requirements for custom models**](https://www.virtualroboticstoolkit.com/documentation/sections/21/articles/100#).

## Warning

This implementation has already been tested in a real-life EV3 by the **Kinectronics Legacy App**. The controller works fine in the EV3. However, due to the limitations of such technology, the absolute positions of the motor are hard to achieve. This means that in this controller, there are not restriction in code to the motors' functioning, what implicates that if you **are not cautious** with the controller, you **may damage** your hardware. Example: If you are telling the robot to turn right even with the physical restrictions of the LEGO frame itself and the wires, could lead to a **motor or wire breaking**. As explained in the MIT license, this software comes with no warranty. **Me or the team behind Kinectronics, are not responsable for any damage to your hardware**.

## Media

You can find a video of the working app in [**here**](https://www.youtube.com/watch?v=g5YbiktZY6A&t=3s).

Here is a screenshot of the working app:

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/ev3app.png">




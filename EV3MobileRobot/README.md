# LEGO Mindstorms EV3 Mobile Robot Controller

This example uses a modded version of the [official EV3 mobile robot](https://le-www-live-s.legocdn.com/sc/media/lessons/mindstorms-ev3/building-instructions/ev3-rem-driving-base-79bebfc16bd491186ea9c9069842155e.pdf) by LEGO. It was modified to make it more compatible with **Virtual Robotics Toolkit**, since VRT does not support the metal ball behaving like in real life. However, it was designed a way to behave like the official model. If you need the buliding instructions of the modified version, please contact me.

In this example app, the gestures of the database [DefaultGestureDatabase](https://github.com/JMRMEDEV/Kinectronics/wiki/Gesture-Databases#default-gesture-database) are linked to every defined mobile robot command.

The relationship gesture-drone_command is defined in the following list:

1. **Gesture:** Arms45UpPosition. **Command:** None.

2. **Gesture:** Arms45DownPosition. **Command:** None.

3. **Gesture:** ArmsFrontPosition_L. **Command** MoveForward().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3MobileController/ev3mobilef.png">

4. **Gesture:** ArmsFrontPosition_R. **Command:** MoveForward().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3MobileController/ev3mobilef.png">

5. **Gesture:** ArmsHRectanglePosition_L. **Command:** None.

6. **Gesture:** ArmsHRectanglePosition_R. **Command:** None.

7. **Gesture:** ArmsRectanglePosition_L. **Command:** None.

8. **Gesture:** ArmsRectanglePosition_R. **Command:** None.

9. **Gesture:** ArmsSidePosition_L. **Command:** TurnLeft().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3MobileController/ev3mobilel.png">

10. **Gesture:** ArmsSidePosition_R. **Command:** TurnRight().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3MobileController/ev3mobiler.png">

11. **Gesture:** ArmsSquarePosition_L. **Command:** MoveBackward().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3MobileController/ev3mobileb.png">

12. **Gesture:** ArmsSquarePosition_R. **Command:** MoveBackward().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/EV3MobileController/ev3mobileb.png">

13. **Gesture:** None. **Command:** Stop().

## Simulation

This app runs a simulation on [Virtual Robotics Toolkit (VRT)](https://www.virtualroboticstoolkit.com/) through WiFi, just like the real robot.

If you want to run this sample, you need the Virtual Robotics Toolkit (VRT) project. You can find it [**here**](https://drive.google.com/file/d/1vwW8TtYI4bE3E6TlBjHQ9GiKHESreO--/view?usp=sharing).

If there are unexpected issues when testing, please, check the [**VRT requirements for custom models**](https://www.virtualroboticstoolkit.com/documentation/sections/21/articles/100#).

## Advice

This implementation has already been tested in a real-life EV3 by the **Kinectronics Legacy App**. The controller works fine. Is safe to use it. However, as the MIT license stages, **neither me or any othe Kinectronics' contributors ares responsable for any damage to your hardware**.

## Media

You can find a video of the working app in [**here**](https://www.youtube.com/watch?v=g5YbiktZY6A&t=3s).

Here is a screenshot of the working app:

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/ev3app.png">





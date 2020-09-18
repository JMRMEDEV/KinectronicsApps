# UR5 TCP Webots Controller

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Devices/Arms/ur5.jpg">

This app runs a simulation on [**Webots**](https://www.cyberbotics.com/) through a TCP port implemented on a C++ app that runs independently of Kinectronics.

If you want to run this sample, you need the Webots' UR5 world and C++ TCP server, they are available [**here**](https://drive.google.com/file/d/1LLr1-JanxOJLp5HQCXxGECTyICSbFZyz/view?usp=sharing).

First thing you need yo do, is load the world in Webots (**UR5_test.wbt**) available in the decompressed **UR5_test** folder. Later, you have to open the solution (**UR5TCPController.sln**) available on the **UR5_test/Controllers/UR5TCPControllers** folder, build it and run it. You could either run directly the executable file. Please **notice** that without doing this first, the Kinectronics' UR5 controlller, won't work.

In this example app, the gestures of the database [DefaultGestureDatabase](https://github.com/JMRMEDEV/Kinectronics/wiki/Gesture-Databases#default-gesture-database) are linked to every defined drone command.

The relationship gesture-drone_command is defined in the following list:

1. **Gesture:** Arms45UpPosition. **Command:** None.

2. **Gesture:** Arms45DownPosition. **Command:** None.

3. **Gesture:** ArmsFrontPosition_L. **Command** None.

4. **Gesture:** ArmsFrontPosition_R. **Command:** moveFront().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/UR5TCPController/Front.png">

5. **Gesture:** ArmsHRectanglePosition_L. **Command:** None.

6. **Gesture:** ArmsHRectanglePosition_R. **Command:** moveHRPosition().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/UR5TCPController/HRectangle.png">

7. **Gesture:** ArmsRectanglePosition_L. **Command:** None.

8. **Gesture:** ArmsRectanglePosition_R. **Command:** None.

9. **Gesture:** ArmsSidePosition_L. **Command:** None.

10. **Gesture:** ArmsSidePosition_R. **Command:** moveRight().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/UR5TCPController/Right.png">

11. **Gesture:** ArmsSquarePosition_L. **Command:** None.

12. **Gesture:** ArmsSquarePosition_R. **Command:** None.

13. **Gesture:** None. **Command:** moveDown().

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/Examples/UR5TCPController/Down.png">

There is a **secondary controller** that only tracks **left hand state** for openning and closing the **gripper**. If the left hand is **open** so it's the gripper, same for the closed hand.

## Simulation

The simulation is achieved through [**Webots Robot Simulator**](https://www.cyberbotics.com/), an open-source software. According to their developers, **Webots** was built thinking on using the developed controllers on the real robots ([transfer to your own robot](https://cyberbotics.com/doc/guide/transfer-to-your-own-robot)). I guess that so can be achieved with a [plugin](https://cyberbotics.com/doc/guide/controller-plugin#remote-control-plugin). However, such implementation has not yet being developed for this controller. I hope it will in future realeases.

## Warning

Please note that so far, each command should go back to the **down position**. Currently moves from one to another which is not the default are not supported. E.G. from front to right, from HRectangle to front.

## Media

You can find a video of the working app in [**here**](https://youtu.be/QQmS2eV6YIE).

Here is a screenshot of the working app:

<img src="https://github.com/JMRMEDEV/Kinectronics/blob/master/RepositoryMedia/ur5app.png">



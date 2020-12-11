
# UR5 human-arm motion replication simulationthrough Kinect V2 with Webots and KinectronicsAPI
This **Universal Robots UR5 Controller** is capable of imitating the motion of a human one through the implementation of forward kinematics. Kinectronics runs in **.NET framework** and sends data in real time to the UR5 C++ controllers, which at its time sends data to [Webots](https://www.cyberbotics.com/) and make the simulated arm to move.
The project divides itself into three stages:
- Simulation of UR5 arms.
- API for instructions with Kinect.
- External controller for Webots developed and running in C++.
## Simulation of UR5 arms
First thing you need to do, is load the world in Webots (**UR5_test.wbt**) available in the decompressed **UR5_test folder**. Later, you must open the solution (**UR5TCPController.sln**) available on the **UR5_test/Controllers/UR5TCPControllers** folder and build it.
## API for instructions with Kinect.
In this example app, the gestures of the database [DefaultGestureDatabase](https://github.com/JMRMEDEV/Kinectronics/wiki/Gesture-Databases#default-gesture-database) consider just the joints instead of the gestures. The function *GetJoints()* gets an object which is the skeleton body and returns the position in space of the elbow and wrist joints as well as an integer which indicates if the hand is open or closed. *SendJointInfo()* will send the message that uses the TCP/IP protocol to connect to C++. So, the Kinectronics send these positions in a string that through TCP/IP which will be received by **UR5TCPController**.
## External controller for Webots developed and running in C++.
The program will run while data is received, it first decodes the string and then converts it to floats for each value of the wrists and elbows in the space X, Y, Z. Once they are assigned to global variables, *commandRobot()* will call the UR5 predetermined functions of movement and use these variables as ranges of motion.
With this been said the second step is to run the C++ of the UR5TCPController. You could either directly run the executable file or run it from Visual Studio. This must throw a terminal showing a successful connection between C++ and Webots
The next step is to run **Kinectronics**, please notice that it is **important** to keep both UR5TCPController and Kinectronics running. Verify that in the section of Devices in the Kinectronics apps says **Webots**. And that is it, you can now move your arms and the simulation in Webots will show you the results.
## Functioning
1.	**GestureDataBases** will get the progressive joints of the right elbow, left elbow, right wrist, and left wrist, and return the coordinates of each joint and the value for open/close of the hand.
2. The value returned from the function is assigned to the respective X, Y, and Z positions.
3.	These variables with the values of the joints are converted into strings and are sent to the controller.
4.	*SendInfo()* sends the string through a message which uses **TCP/IP** to connect to C++.
5.	A do while loop in the **UR5TCPController** will do the work of the condition that the program will work only if there is data that is being received. The data string received is going to be decoded to find X, Y and Z positions with some logic used for the code to ignore the first 3 characters which were the identifiers of the joints, and it will add with *substr()* the next 6 characters which corresponds to the numerical value of the coordinates.
6.	This string contains the numerical value, but it is still a string, so it needs to be converted to float and assigned to global variables.
7.	Then *commandRobot()* calls the UR5 functions for the movement of the robotic arm in the simulator and uses the values of the coordinates as ranges for motion.

## Results

![UR5 World](https://github.com/JMRMEDEV/KinectronicsApps/blob/master/UR5TCPDoubleArmController/UR5World.png "UR5 World")

![Results ](https://github.com/JMRMEDEV/KinectronicsApps/blob/master/UR5TCPDoubleArmController/UR5test.png "Results ")

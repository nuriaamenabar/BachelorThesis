<p align="center"><img src="images/warehouse.gif"/></p>

# LINK TO THE FINAL REPORT

http://hdl.handle.net/2117/378166

# INSTRUCTIONS TO RUN THE SIMULATION
## EMS
Once the board is connected to the computer, open the Arduino IDLE. Then, go to FIle>Examples>Uduino>Uduino. Verify and run the script, and the board will be connected to Unity. The EMS is controlled by the FeedbackController during gameplay, but in case you want to set a pin high or low manually, for callibration for example, you can do it from the Uduino Gameobject, clicking "Discover Ports".


## ROS 
To initiate ROS, turn on the VMWare. Run this on the terminal:
```
    cd Unity-Robotics-Hub/tutorials/pick_and_place/ROS/
    echo "ROS_IP: $(hostname -I)" > src/ur5_moveit/config/params.yaml
    source devel/setup.bash
    hostname -I
    chmod +x src/ur5_moveit/scripts/mover.py
    roslaunch ur5_moveit part_nuria.launch
```
Copy the IP that appears on "Starting ROS on:..." and paste it in Unity>Robotics>ROS Settings>IP. When you start Play mode, ROS should connect to Unity.

## Unity
To run the simulation, first change the participant number in the script `PlayerStats`.Then, activate the corresponding feedback or surveilance mode in the Feedback Controller GameObject. Then, click play and the simulation will finish automatically once three minutes have passed. 

### no robot
It contains all the objects in the environment that are not the robot. The robot needs to be at (0,0,0) so in need to move it, move the no robot game object and you will move the whole environment instead
#### Targets and placements
All the cubes (grabbables) and placements that the robot will pick up. Grabbables are divided in 4 sets, each one activated once the previous one is sorted by the robot, so that cubes don't run out (controlled by `grab_2`, script attached to the first Grabbables). Each grabbable has the `WhereisCube` script that, using triggers and bools, keeps track of where each cube is 

It also contains all the boxes, with the respective colliders in the bottom, that have as a component the `CubesInBox` to check how many cubes are in the box at every moment, as well as the classified and missclassified ones.
#### Environment
All the tables, the directional light and XR interaction Toolkit, ground and the Start Button which has the `clock` script attached, which keeps track of the start time and finishes the GamePlay once 3 minutes have passed.

#### Task 2
First of all, it contains the ChangePannels script which activates and desactivates the pannels when buttons are pushed, and keeps track of the score. As an argument it has an array with all the pannels. 
Also, all the buttons (with the onPressed() finction calling the ChangePannels Script), tagged each one with their respective number.  The maths pannels, with their mathematical opperation as a material (created in paint) and tagged with the solution of the calculation.

#### Planes
The robot task and button task planes, which, in interaction with the lookray, help track where the participant is looking.


### Robot things
The robot and scripts that control it.
Under robert you can find the robot itseld. The publisher has the Trajectory Planner as a component (in that script you can modify the speed of the robot). The Automatic Publisher's script (`prova`) is the responsible to publish the joints conecutively as long as the boxes are not full. From there you can also modify how many cubes in a box it takes for the robot to stop. You can find more information in the `prova` script.




### Feedback controller
From this GameObject you can controll the feedback and surveilance vieww, from the Unity interface without needing to modify the `FeedbackController` script. It also has the Audio Source for the Audio feedback as a component.
From in you can turn the Audio, Visual and EMS Feedback, as well as the Surveilance Camera, on and off. You can also choose a pulsated feedback (Normally off). It has the notifications green and pink, and de surveilance object as arguments (they are all children of the Feedback Controller GameObject), Uduino, The AudioSource previously mentioned, The Automatic Publisher and Lookray (from centerEyeAnchor) scripts and a variable logging the last time the feedback was activated.

As a children of it you can find all the UI elements under VisualFeedback. The pink and green visual feedback, the score UI and both modalities of surveilance (drag the preferred one to the FeedbackController script's
Component.)

#### Visual feedback 

### Uduino
Connects to the Arduino. You can manually set pins to high or low by clicking Discover Ports. It doesn't actually control the EMS while on playmode, that is done with the Feedback Controller.


### Player Stats
Script that saves the stats for every player. Controlled by the `PlayerStats` script. 

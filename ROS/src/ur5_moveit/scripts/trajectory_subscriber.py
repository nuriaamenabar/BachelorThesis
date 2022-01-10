#!/usr/bin/env python
"""
    Subscribes to SourceDestination topic.
    Uses MoveIt to compute a trajectory from the target to the destination.
    Trajectory is then published to PickAndPlaceTrajectory topic.
"""
import rospy

from ur5_moveit.msg import Ur5MoveitJoints, Ur5Trajectory #TODO changed to ur5_moveit.msg and Ur5MoveitJoints and Ur5Trajectory
from moveit_msgs.msg import RobotTrajectory


def callback(data):
    rospy.loginfo(rospy.get_caller_id() + "I heard:\n%s", data)

def listener():
    rospy.init_node('Trajectory_Subscriber', anonymous=True)
    rospy.Subscriber("/ur5_joints", Ur5MoveitJoints, callback) #TODO changed to ur5_joints and Ur5MoveitJoints

    # spin() simply keeps python from exiting until this node is stopped
    rospy.spin()


if __name__ == '__main__':
    listener()

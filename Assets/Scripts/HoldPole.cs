using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class HoldPole : MonoBehaviour
{
    public FullBodyBipedIK ik;
    public Transform leftHandTarget, rightHandTarget, leftFootTarget, rightFootTarget;

    void LateUpdate()
    {
        ik.solver.leftHandEffector.position = leftHandTarget.position;
        ik.solver.leftHandEffector.rotation = leftHandTarget.rotation;
        ik.solver.leftHandEffector.positionWeight = 1f;
        ik.solver.leftHandEffector.rotationWeight = 1f;

        ik.solver.rightHandEffector.position = rightHandTarget.position;
        ik.solver.rightHandEffector.rotation = rightHandTarget.rotation;
        ik.solver.rightHandEffector.positionWeight = 1f;
        ik.solver.rightHandEffector.rotationWeight = 1f;

        ik.solver.leftFootEffector.position = leftFootTarget.position;
        ik.solver.leftFootEffector.rotation = leftFootTarget.rotation;
        ik.solver.leftFootEffector.positionWeight = 1f;
        ik.solver.leftFootEffector.rotationWeight = 1f;

        ik.solver.rightFootEffector.position = rightFootTarget.position;
        ik.solver.rightFootEffector.rotation = rightFootTarget.rotation;
        ik.solver.rightFootEffector.positionWeight = 1f;
        ik.solver.rightFootEffector.rotationWeight = 1f;
    }
}

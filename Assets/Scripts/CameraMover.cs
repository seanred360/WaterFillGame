using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    // iTween ease in-out
    public iTween.EaseType easeType = iTween.EaseType.easeInOutExpo;

    // starting distance from center in local z
    public float startDistance = 0.25f;

    // ending distance from center in local z
    public float endDistance = 19f;

    // iTween animation time
    public float moveTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startDistance = transform.position.y;
    }

    public void MoveCamera()
    {
        // animate the arrow in a cycle from startDistance to endDistance in local z
        iTween.MoveBy(gameObject, iTween.Hash(
            "y", endDistance - startDistance,
            //"looptype", iTween.LoopType.loop,
            "time", moveTime,
            "easetype", easeType
        ));
    }

    public void MoveCameraBack()
    {
        // animate the arrow in a cycle from startDistance to endDistance in local z
        iTween.MoveBy(gameObject, iTween.Hash(
            "y", startDistance - endDistance,
            //"looptype", iTween.LoopType.loop,
            "time", moveTime,
            "easetype", easeType
        ));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    // iTween ease in-out
    public iTween.EaseType easeType = iTween.EaseType.easeInOutExpo;

    // starting distance from center in local z
    public float startDistance = 0.25f;

    // ending distance from center in local z
    public float endDistance = 0.5f;

    // iTween animation time
    public float moveTime = 1f;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        MoveArrow(this.gameObject);
        button = GetComponent<Button>();
    }

    void MoveArrow(GameObject arrowInstance)
    {
        // animate the arrow in a cycle from startDistance to endDistance in local z
        iTween.MoveBy(arrowInstance, iTween.Hash(
            "y", endDistance - startDistance,
            "looptype", iTween.LoopType.loop,
            "time", moveTime,
            "easetype", easeType
        ));
    }

    public void DelayButton()
    {
        button.interactable = false;
        StartCoroutine(DelayButtonRoutine());
    }

    IEnumerator DelayButtonRoutine()
    {
        yield return new WaitForSeconds(2f);
        button.interactable = true;
    }
}

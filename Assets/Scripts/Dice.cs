using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Sprite[] diceSides;
    private Image rend;
    private bool coroutineAllowed = true;

    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<Image>();
        rend.sprite = diceSides[1];
    }

    public void StartRoll()
    {
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        StartCoroutine(EnableDicePress());
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            GetComponent<AudioSource>().Play();
            randomDiceSide = Random.Range(0, diceSides.Length);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GetComponent<AudioSource>().Stop();
        coroutineAllowed = true;// rolling dice is allowed again 
    }

    IEnumerator EnableDicePress()
    {
        this.gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<Button>().interactable = true;
    }
}

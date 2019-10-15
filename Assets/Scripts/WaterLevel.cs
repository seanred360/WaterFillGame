using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterLevel : MonoBehaviour
{
    public ZippyWater2D water;
    public bool waterIsFull = false;
    float waterFillLevel;
    float originalHeightLevel;
    Vector3 originalPosition;
    AudioManager audioManager;

    public SpawnPoint spawnPoint;
    public GameObject dancingPlayerPrefab;
    CameraMover cameraMover;

    public int points;
    float rolledNumber = 1.5f;
    int badLuck;
  
    // Start is called before the first frame update
    void Start()
    {
        cameraMover = GameObject.FindObjectOfType<CameraMover>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        water = this.GetComponent<ZippyWater2D>().GetComponent<ZippyWater2D>();
        waterFillLevel = water.transform.position.y;
        originalHeightLevel = water.height;
        originalPosition = water.transform.position;
    }

    public void StartWaterFill()
    {
        //if ((Random.value < 0.5f) && (badLuck <3))
        //{
        //    rolledNumber = 0;
        //    audioManager.PlaySFX(5);
        //    badLuck += 1;
        //}
        //else
        //{
        //    rolledNumber = 3;
        //    badLuck = 0; 
        //}
        waterIsFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waterIsFull == false)
        {
            water.height += rolledNumber * Time.deltaTime;
            water.transform.position += new Vector3(0, rolledNumber, 0f) * Time.deltaTime;
            if (water.transform.position.y >= waterFillLevel)
            {
                waterFillLevel += rolledNumber ;
                waterIsFull = true;
            }
        }
        if(waterFillLevel >= 14)
        {
            audioManager.PlaySFX(4);
            audioManager.PlaySFX(6);
            points +=1;
            waterFillLevel = 0;
            waterIsFull = true;
            spawnPoint.SpawnDancingPikmin();
            water.height = originalHeightLevel;
            water.transform.position = originalPosition;
            cameraMover.MoveCamera();
            Invoke("MoveBackCamera",3f);
            //GameObject.Find("GameManager").GetComponent<GameManager>().isWinner = true;
            //dancingPlayer.gameObject.SetActive(true);
        }
        if(points >= 3)
        {
            Debug.Log("Game is over");
            GameObject.Find("GameManager").GetComponent<GameManager>().isWinner = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeWinnerText(this.gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioManager.PlayVoice(Random.Range(0, 6));
        }
    }

    void MoveBackCamera()
    {
        cameraMover.MoveCameraBack();
    }
}

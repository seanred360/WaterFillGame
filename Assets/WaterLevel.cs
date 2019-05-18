﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterLevel : MonoBehaviour
{
    public ZippyWater2D water;
    public bool waterIsFull = false;
    float waterFillLevel;

    public GameObject dancingPlayer;
    GameObject soundSource;

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GameObject.FindGameObjectWithTag("Sound");
        water = this.GetComponent<ZippyWater2D>();
        waterFillLevel = water.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (waterIsFull == false)
        {
            water.GetComponent<ZippyWater2D>().height += 2 * Time.deltaTime;
            water.transform.position += new Vector3(0, 2f, 0f) * Time.deltaTime;
            if (water.transform.position.y >= waterFillLevel)
            {
                waterFillLevel += 3;
                waterIsFull = true;
            }
        }
        if(waterFillLevel >= 15)
        {
            Debug.Log("Game over");
            //GameObject.Find("GameManager").GetComponent<GameManager>().HasLevelFinished = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().isWinner = true;
            dancingPlayer.gameObject.SetActive(true);
        }
    }

    public void StartWaterFill()
    {
        soundSource.GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("burrowpull"));
        waterIsFull = false;
    }
}

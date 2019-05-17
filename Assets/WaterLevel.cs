using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterLevel : MonoBehaviour
{
    public ZippyWater2D water;
    public bool waterIsFull = false;
    float waterFillLevel;

    // Start is called before the first frame update
    void Start()
    {
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
                waterFillLevel += 1;
                waterIsFull = true;
            }
        }
    }

    public void StartWaterFill()
    {
        waterIsFull = false;
    }

}

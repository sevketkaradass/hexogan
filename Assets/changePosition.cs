using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePosition : MonoBehaviour
{
    Vector3 worldPos;
    public float distance1 , distance2;
    float tileXOffset = 0.43f;
    float tileYOffset = 0.7f;
    public float x, y;
    bool fall = true;
    void start()
    {

    }
    public void new_location(int t,int k)
    {
        
                if (k % 2 == 0)
                {
                    x = t*tileXOffset*2+tileXOffset*2;
                        y = k*tileYOffset;
                }
                else
                {
                    x = t * tileXOffset*2 + tileXOffset;
                        y = tileYOffset*k;
                }
           
               
            }

    void Update()
    {
      
        if (fall)
        {
            if (transform.position.y - y < 0.05f)
            {
                fall = false;
                transform.position = new Vector3(x, y, 0);
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, 0), Time.deltaTime * 3f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            distance1 = Vector3.Distance(new Vector3(x,y, 0), worldPos);
            distance2 = Vector3.Distance(new Vector3(x, y, 0), worldPos);

        }
    }
   


}
   
  

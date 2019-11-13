using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatGrid : MonoBehaviour
{
   
    public GameObject[] ColorsGameObject;
    int index;
    float tileXOffset = 0.437f;
    float tileYOffset = 0.756f;
    public changePosition [,] hexs;
    int weight = 8;
    int height = 9;
    float tut;
    public float min1, min2, min3;
    public changePosition choose,choose1,choose2;

    // Start is called before the first frame update
    void Start()
    {
        hexs = new changePosition[weight, height];
        for (int x = 0; x < weight; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Hexcreat(x, y);
            }
        }

    }
    
 void Update()
    {
       

        transformObje();
        
    }
    // Update is called once per frame
    public void Hexcreat(int i, int k)
    {
       
        index = Random.Range(0, ColorsGameObject.Length);
        GameObject new_hexs = GameObject.Instantiate(ColorsGameObject[index], new Vector2(i, k + 10), Quaternion.identity);
        changePosition hex = new_hexs.GetComponent<changePosition>();
        hex.new_location(i, k);
        hexs[i, k] = hex;


    }
   
  public float findMin(int t) { 
      for (int k = 0; k< 8; k++)
        {
            for (int l = 0; l< 9; l++)
            {
                for (int i = 0; i< 8; i++)
                {
                    for (int j = 0; j< 9; j++)
                    {
                        if (hexs[k, l].distance1 < hexs[i, j].distance1)
                        {
                            tut = hexs[k, l].distance1;
                            hexs[k, l].distance1 =hexs[i, j].distance1;
                            hexs[i, j].distance1 = tut;

                        }
                    }
                }
            }
        }
        return hexs[0,t].distance1;
    }

    public void transformObje()
    {
        
            min1 = findMin(0);
            min2 = findMin(1);
            min3 = findMin(2);
            Debug.Log(min1 + "   " + min2 + "    " + min3);
            for (int k = 0; k < 8; k++)
            {
                for (int l = 0; l < 9; l++)
                {
                    if (min1 == hexs[k, l].distance2)
                    {
                        choose = hexs[k, l];
                        print(min1 + "Bulundu" + hexs[k, l].distance2);
                    }
                    if (min2 == hexs[k, l].distance2)
                    {
                        choose1 = hexs[k, l];
                    }
                    if (min3 == hexs[k, l].distance2)
                    {
                        choose2 = hexs[k, l];
                    }

                }
            }
            choose.transform.position = Vector3.Lerp(transform.position, new Vector3(choose1.x, choose1.y, 0), Time.deltaTime * 3f);
            choose1.transform.position = Vector3.Lerp(transform.position, new Vector3(choose2.x, choose2.y, 0), Time.deltaTime * 3f);
            choose2.transform.position = Vector3.Lerp(transform.position, new Vector3(choose.x, choose.y, 0), Time.deltaTime * 3f);
        }
    

}



   




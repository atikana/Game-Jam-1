using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public Transform count;




    public GameObject object1;  // 10%
    public GameObject object2;   // 20%
    public GameObject object3;   // 30%
    public GameObject object4;  // 40%


    public Transform spawnPoint1;

    public Transform spawnPoint2;

    public Transform spawnPoint3;

    public Transform spawnPoint4;

    float maxTime = 10;
    float minTime = 5;
    float time;
    float spawnTime;
 
   
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if ( time >= spawnTime && countAll() < 4)
        {
            spawn();

            SetRandomTime();
            time = 0;
        }

   

    }

    void spawn()
    {

        GameObject toSpawn;
        float chance = Random.Range(0, 100);

        int where = Random.Range(0, 4);

        Vector3 pos = spawnPoint1.position;

       switch (where)
        {
            case 0:
                pos = spawnPoint2.position;
                break;
            case 1:
                pos = spawnPoint3.position;
                break;
            case 2:
                pos = spawnPoint4.position;
                break;
            default:
                break;

        }


        // maybe add

        int which = 0;

        if (chance > 75)
        {
            toSpawn = object1;
        }
        else if (chance > 50)
        {
            toSpawn = object2;
            which = 1;
        }
        else if (chance > 25)
        {
            toSpawn = object3;
            which = 2;
        }
        else
        {
            toSpawn = object4;
            which = 3;
        }

        GameObject spawning = Instantiate(toSpawn,  pos + new Vector3(1,1,1), Quaternion.identity) as GameObject;
        spawning.transform.SetParent(count.GetChild(which));
        spawning.SetActive(true);

    }

    int countAll()
    {

        // count if the total of the items
        int total = 0;
        for (int i = 0; i < 4; i++)
        {
            total += count.GetChild(i).childCount;
        }

        return total;
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }


}

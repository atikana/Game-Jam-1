using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{


    public Transform player;


   


    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // if (Vector3.Distance(player.position, transform.position) < 25)
        // {
        /* Vector3 dirToPlayer = transform.position - player.position;
         Vector3 newPos = transform.position + dirToPlayer;
         transform.position = Vector3.MoveTowards(dirToPlayer, newPos, 1f); */

        // Vector3 dir = transform.position - player.position;

        // transform.Translate(dir * 2f * Time.deltaTime);
        //} 
    }



}

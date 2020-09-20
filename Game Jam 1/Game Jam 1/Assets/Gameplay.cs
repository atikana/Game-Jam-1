using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    bool carrying;
    
    // Start is called before the first frame update

    Transform carried;

   public Transform guide;

    
  
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        pickUp();
    }

    void pickUp()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!carrying)
            {

               
                RaycastHit hit;

      
   

                if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
                {
                  
                    if (hit.collider.tag == "object")
                    {



                        carried = hit.collider.transform;

                        carried.SetParent(guide.transform);
                   
                        carried.GetComponent<Rigidbody>().useGravity = false;
                        carried.GetComponent<Rigidbody>().detectCollisions = true;
                        carried.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        carried.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                      
                        carrying = true;
                    }
                }
            }

            else
            {

   
                
                carried.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

                carried.GetComponent<Rigidbody>().useGravity = true;
                carried.transform.SetParent(null);

                carrying = false;
               // Destroy(carried.gameObject);
                    
            }
        }
     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    float distance;
    public Transform guide;

    AudioSource audioSource;


    Quaternion original;

    bool carrying;

    // Start is called before the first frame update
    void Start()
    {
        original = transform.rotation;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = Mathf.Abs(transform.position.x - guide.transform.position.x);


  

        if (Input.GetKeyDown(KeyCode.E))
        {
    
            if (!carrying && distance <= 2f && guide.childCount == 0)
            {

                //fixing position when pick up;

                if (transform.rotation != original)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, original, Time.time * 1f);
                }

                Debug.Log("picking up");

                transform.SetParent(guide.transform);

                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().detectCollisions = true;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                audioSource.PlayOneShot(audioSource.clip);
                carrying = true;
            }



            else if (carrying)
            {

                Debug.Log("throwing\n");
          
                gameObject.GetComponent<Rigidbody>().AddForce(guide.forward * 1000);
        
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                transform.SetParent(null);

                carrying = false;
            }
        }
    }
}

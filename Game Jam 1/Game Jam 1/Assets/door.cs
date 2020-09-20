using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class door : MonoBehaviour
{
    // Start is called before the first frame update



    public Text text;
    public Text score;
    public float timeRemaining;

    public string type;

    public LevelManagement levelManagement;

    float time;
    void Start()
    {
        time = timeRemaining;
        

    }
    // Update is called once per frame
    void Update()
    {


       // Debug.Log(timeRemaining + "\n");
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            text.text = timeRemaining.ToString() + " s";
      
            // check if we can see the screen
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if (onScreen)
            {
                text.gameObject.SetActive(true);
                text.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0, -5));
            }
            else
            {
                text.gameObject.SetActive(false);
            }

          
        }
        else
        {

            Debug.Log("GameOver");
            levelManagement.setGameOver();


        }

  
    
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(type))
        {

            Debug.Log("Hit " + type + "YAY\n");
            timeRemaining = time;
            int temp = int.Parse(score.text) + 100;
            score.text = temp.ToString();

            Debug.Log("destory gameobject\n");
            Destroy(collision.gameObject);
        }
    }

 
}

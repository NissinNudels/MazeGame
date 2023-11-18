using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int keycount = 0;
    float speed = 2.5f;

    public Text keyCollect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Movements/Controls Arrow Keys
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, 0);
        }

    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //if player comes into contact with the key, the key destroys / means it was pick up
        if (collision.gameObject.tag == "Keys")
        {
            keycount++; //counts the collected keys
            keyCollect.text = "Key's Collected : " + keycount;
            Destroy(collision.gameObject);
        }
        // pag nakumpeto na yung 3 keys tapos nag collide sya sa door means level complete na
        if (collision.gameObject.tag == "ExitDoor" && keycount == 3)
        {
            Debug.Log("Level Complete!");
        }

        //when player comes into contact with the enemies the game restarts
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //When player hits the wall it bounce off walls
        if (collision.gameObject.tag == "Wall")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0, 0);
            }
        }
    }
}

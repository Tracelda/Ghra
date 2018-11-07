using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{

    public GameObject Restart;

    public float flash;
    public float flashSpeed;

    // Use this for initialization
    void Start()
    {
        flash = 0;
        StaticGame.Lives = 4;
        StaticGame.level = 1;
        StaticGame.seconds = 6;
        StaticGame.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("UseableObject"));
        flash += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Hit.collider != null)
            {
                if (Hit.collider.gameObject.tag.Equals("Restart"))
                    SceneManager.LoadScene("Level 1");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Hit.collider != null)
            {
                if (Hit.collider.gameObject.tag.Equals("MainMenu"))
                    SceneManager.LoadScene("MainMenu");
            }
        }
        if (flash >= flashSpeed)
        {
            if (Restart.GetComponent<SpriteRenderer>().enabled == false)
            {
                Restart.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                Restart.GetComponent<SpriteRenderer>().enabled = false;
            }
            flash = 0;
           
        }

    }
}


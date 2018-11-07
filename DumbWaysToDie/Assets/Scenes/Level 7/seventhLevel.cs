using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class seventhLevel : MonoBehaviour {

    public GameObject bar;
    public GameObject Gun;
    public GameObject Target;
    private Quaternion GunRotation;
    private Vector2 TargetLocation;
    private bool active;
    private float Timer;
    private float time;
    private float wintime;
    public float winwait;

    // Use this for initialization
    void Start () {
        time = 1;
        GunRotation = Quaternion.Euler(0, 0, -30);
        TargetLocation = new Vector2(-1.67f, 1.63f);
        active = true;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("UseableObject"));

        if (Hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Hit.collider.gameObject.tag.Equals("Button")) 
                {
                    active = false;
                    Gun.transform.rotation = GunRotation;
                    Target.transform.position = TargetLocation;
                }
            }
        }
        
        Timer = Time.deltaTime / StaticGame.seconds;
        time -= Timer;
        bar.gameObject.GetComponent<Slider>().value = time;
        
        if ((time <= 0) && (active == true))
        {
            lose();
        }
        if (active == false)
        {
            wintime += Time.deltaTime;
            if (wintime >= winwait)
            {
                win();
            }
        }

    }
    void win()
    {
        StaticGame.score += 10;
        end();
    }
    void lose()
    {
        StaticGame.Lives -= 1;
        end();
    }
    void end()
    {
        StaticGame.level += 1;
        SceneManager.LoadScene("Loading");
    }
}

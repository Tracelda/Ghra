using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FithLevel : MonoBehaviour {
    public GameObject Battery;
    public GameObject BatteryEnd;
    public GameObject bar;
    public GameObject PowerBar;
    private GameObject _Battery;

    private float Power;
    private bool GamePlay;
    private bool MouseDown;
    private float Timer;
    private float time;
    private float wintime;
    public float winwait;
    private bool active;
    // Use this for initialization
    void Start () {
        GamePlay = true;
        MouseDown = false;
        time = 1;
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
        ObjectDrag();
        Timer = Time.deltaTime / StaticGame.seconds;
        time -= Timer;
        bar.gameObject.GetComponent<Slider>().value = time;
        if (active == true)
        {
            if (time <= 0)
            {
                lose();
            }
        }
        if (active == false)
        {
            Power += Time.deltaTime;
            if (Power >= 1)
            { Power = 1; }
            PowerBar.gameObject.GetComponent<Slider>().value = Power;
            
            wintime += Time.deltaTime;
            if (wintime >= winwait)
            {
                win();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D Target)
    {
       if (Target.gameObject.tag.Equals("BatteryEnd"))
        {
            GamePlay = false;
            MouseDown = false;
            Battery.transform.position = new Vector2(BatteryEnd.transform.position.x, BatteryEnd.transform.position.y);
            active = false;
        }
       
    }
    void ObjectDrag()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("UseableObject")); if (Hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Hit.collider.gameObject.tag.Equals("Battery"))
                {
                    MouseDown = true;
                    _Battery = Hit.collider.gameObject;
                }

            }
        }
        if (MouseDown == true)
        {
            _Battery.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9f));
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            MouseDown = false;
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

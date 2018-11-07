using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdLevel : MonoBehaviour {


    private Vector3 FirstTouchPos;
    private Vector3 LastTouchPos;
    public int ScreenPercentageForSwipe;
    private float dragDistance;


    public GameObject Missle;
    public GameObject bullet;
    public GameObject Tank;
    
    private Vector2 NewMissle;
    private Vector2 NewBullet;
   

    private float Travel;
    private float Timer;
    private float time;
    private bool fired;
    private bool active;
    private float _firerate;
    private float EndTime;
    public float BulletSpeed;
    

	// Use this for initialization
	void Start () {

        dragDistance = Screen.height * ScreenPercentageForSwipe / 100;


        time = 1;
        
        NewMissle = Missle.transform.position;
        Travel = Missle.transform.position.y;
        NewBullet = Tank.transform.position;
        fired = false;
        active = true;
        _firerate = BulletSpeed;
        EndTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                FirstTouchPos = touch.position;
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                LastTouchPos = touch.position;
                

                if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > dragDistance || Mathf.Abs(LastTouchPos.y - FirstTouchPos.y) > dragDistance)
                {
                    fired = true;
                }
            }
        }

        Timer = Time.deltaTime / StaticGame.seconds;
        time -= Timer;
        _firerate -= Time.deltaTime;
        if (active == true)
        {
            NewMissle = new Vector2(0, Travel + (time * 4));
            Missle.transform.position = NewMissle;
        }       
        if (time <= 0 && active == true)
        {
            lose();
        }
        //if (Input.GetKeyDown(KeyCode.Mouse0) && fired == false)
        //{
        //    fired = true;
        //}
        if (fired == true && _firerate <= 0 && active == true)
        {
            NewBullet = new Vector2(0, (NewBullet.y += 0.1f));
            bullet.transform.position = NewBullet;
            _firerate = BulletSpeed;
        }
        if (active == false)
        {
            EndTime += Time.deltaTime;
            if (EndTime >= 1)
            {
                win();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D Target)
    {
        Debug.Log("hit");
        if (Target.gameObject.tag.Equals("Bullet"))
        {
            
            Missle.gameObject.GetComponent<Animator>().enabled = true;
            

            Destroy(bullet);
            active = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{

    public GameObject Hunger;
    public GameObject Cookie;
    public GameObject TimeBar;

    private float HungerLossClone;
    private float HungerGainClone;
    private float HungerValueClone;
    private float TimerBarClone;
    

    public float HungerValue;
    public float HungerLoss;
    public float HungerGain;
    public float TimerBar;
    
    // Use this for initialization
    void Start()
    {
        HungerValueClone = HungerValue;
        HungerLossClone = HungerLoss;
        HungerGainClone = HungerGain;
        TimerBarClone = TimerBar;
        
        
        Debug.Log(StaticGame.Lives);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("UseableObject"));


        HungerValueClone -= HungerLossClone;
        TimerBarClone -= Time.deltaTime/StaticGame.seconds;
        TimeBar.gameObject.GetComponent<Slider>().value = TimerBarClone;
        Hunger.gameObject.GetComponent<Slider>().value = HungerValueClone;

        if (Hunger.gameObject.GetComponent<Slider>().value <= 0)
        {
            lose();
        }
        if (TimeBar.gameObject.GetComponent<Slider>().value <= 0)
        {
            lose();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Hit.collider != null)
            {
                if (Hit.collider.gameObject.tag.Equals("cookie"))
                {
                    HungerValueClone += HungerGainClone;
                }
            }
        }
        if (Hunger.gameObject.GetComponent<Slider>().value >= 1)
        {
            win();
            
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
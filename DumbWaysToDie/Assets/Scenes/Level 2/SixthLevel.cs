using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SixthLevel : MonoBehaviour {

    public GameObject World;
    public GameObject bar;


    private float Timer;
    private float time;

    public float Tilt;

    // Use this for initialization
    void Start () {
        time = 1;
    }
	
	// Update is called once per frame
	void Update () {

        Timer = Time.deltaTime / StaticGame.seconds;
        time -= Timer;
        bar.gameObject.GetComponent<Slider>().value = time;
        if (time <= 0)
        {
            win();
        }

        World.transform.Rotate(Input.acceleration.y * 0, 0, Input.acceleration.x * Tilt, Space.World);

    }
   void OnTriggerEnter2D(Collider2D Trigger)
    {
        if (Trigger.gameObject.tag.Equals("Spikes"))
        {
            lose();
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

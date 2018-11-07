using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevel : MonoBehaviour {


    public float RAND;
    public float ChangeTime;
    public float flashSpeed;
    private float flash;
    public GameObject Face;
    public GameObject Text;
    private GameObject empty;
    public Sprite Press;
    public Sprite DontPress;
    public Sprite Happy;
    public Sprite Sad;

	// Use this for initialization
	void Start () {

        RAND = Random.Range(1f, 4f);
        ChangeTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("UseableObject"));
        flash += Time.deltaTime;
        ChangeTime += Time.deltaTime;

        if (ChangeTime >= RAND)
        {
            Face.gameObject.GetComponent<SpriteRenderer>().sprite = Happy;
            Text.gameObject.GetComponent<SpriteRenderer>().sprite = Press;
        }
        if (Face.gameObject.GetComponent<SpriteRenderer>().sprite == Happy)
        {
            if (flash >= flashSpeed)
            {
                if (Text.gameObject.GetComponent<SpriteRenderer>().enabled == true)
                {
                    Text.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    flash = 0;
                }

                else
                {
                    Text.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    flash = 0;
                }
            }
        }
        if (ChangeTime >= StaticGame.seconds)
        {
            lose();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Hit.collider != null)
            {
                if (Hit.collider.gameObject.tag.Equals("face"))
                {
                    if (Face.gameObject.GetComponent<SpriteRenderer>().sprite == Happy)
                    {
                        win();
                    }
                    else
                    {
                        lose();
                    }
                }
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

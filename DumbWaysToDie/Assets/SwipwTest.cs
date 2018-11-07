using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipwTest : MonoBehaviour {

    private Vector3 FirstTouchPos;
    private Vector3 LastTouchPos;

    public int ScreenPercentageForSwipe;
    private float DragDistance;

    private Text MyTXT;

	void Start () {
        DragDistance = Screen.height * ScreenPercentageForSwipe / 100;
        MyTXT = GameObject.Find("Text").GetComponent<Text>();
	}
	
	
	void Update () {
		if (Input.touchCount == 1)
        {
            Touch to = Input.GetTouch(0);
            if(to.phase == TouchPhase.Began)
            {
                FirstTouchPos = to.position;
                LastTouchPos = to.position;
            }
            else if(to.phase == TouchPhase.Moved)
            {
                LastTouchPos = to.position;
            }
            else if (to.phase == TouchPhase.Ended)
            {
                LastTouchPos = to.position;

                if(Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > DragDistance ||
                    Mathf.Abs(LastTouchPos.y - FirstTouchPos.y) > DragDistance)
                {
                    if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > 
                        Mathf.Abs(LastTouchPos.y - FirstTouchPos.y))
                    {
                        if (LastTouchPos.x > FirstTouchPos.x)
                        {
                            //Right Swipe
                            MyTXT.text = "Right Swipe";
                        }
                        else
                        {
                            MyTXT.text = "Left Swipe";
                            //Left Swipe
                        }                   
                    }
                    else
                    {
                        if (LastTouchPos.y > FirstTouchPos.y)
                        {
                            //Up Swipe
                            MyTXT.text = "Up Swipe";
                        }
                        else
                        {
                            MyTXT.text = "Down Swipe";
                            //Down Swipe
                        }
                    }
                }
                else
                {
                    //Tapped Screen
                    MyTXT.text = "TAP";
                }
            }
        }
	}
}

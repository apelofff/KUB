using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class TouchInput : MonoBehaviour
{

    public LayerMask touchInputMask;
    public Camera camera;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    private RaycastHit hit;


    void Update()
    {

#if UNITIY_EDITOR

        if (Input.GetmouseBoutton)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = camera.ScreenPointToRay(touch.position);
             

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipiant = hit.transform.gameObject;
                    touchList.Add(recipiant);

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipiant.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipiant.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipiant.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipiant.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                }

            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }

            }
        }
    }
#endif
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = camera.ScreenPointToRay(touch.position);
             

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipiant = hit.transform.gameObject;
                    touchList.Add(recipiant);

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipiant.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipiant.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipiant.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipiant.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                }

            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }

            }
        }
    }
}

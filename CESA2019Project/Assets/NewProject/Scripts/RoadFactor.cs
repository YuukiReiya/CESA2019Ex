using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFactor : MonoBehaviour
{
    [SerializeField] LineFactor line;
    public  StartPoint startPoint;
    public  EndPoint endPoint;

    void Start()
    {
    }

    void Update()
    {
#if UNITY_EDITOR
        //  押した瞬間
        if(GetDown())
        {
            if (startPoint.InRange(Input.mousePosition))
            {
                line.DrawLine();
            }
        }

        //  押している間
        if(GetMove())
        {
            line.DrawLine();
        }

        //  離した
        else if (GetUp())
        {
            if(endPoint.InRange(Input.mousePosition))
            {
                line.ActiveCol(true);
            }
            else
            {
                line.DecIndex();
                Destroy(line.GetParentNow());
            }
        }

#else
#endif
    }

    bool GetDown()
    {
#if UNITY_EDITOR
        return Input.GetMouseButtonDown(0);
#else
        if(Input.touchCount>0)
        {
        var touch = Input.GetTouch(0);
        if(touch.phase== TouchPhase.Began)
        return true;
        }
        return false;
#endif
    }

    bool GetMove()
    {
#if UNITY_EDITOR
        return Input.GetMouseButton(0);
#else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
                return true;
        }
        return false;
#endif

    }
    bool GetUp()
    {
#if UNITY_EDITOR
        return Input.GetMouseButtonUp(0);
#else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
                return true;
        }
#endif
    }
}

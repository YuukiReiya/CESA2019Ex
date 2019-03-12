using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFactor : MonoBehaviour
{
    public GameObject linePrefab;
    public float lineLength = 0.2f;
    public float lineWidth = 0.1f;
    Vector3 touchPos;
    [SerializeField] Material vlMat;
    [SerializeField] Material lMat;
    GameObject ptr;
    int pIndex;

    // Start is called before the first frame update
    void Start()
    {
        pIndex = 0;
        var c = linePrefab.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawLine()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCount <= 0) { return; }
        Touch touch = Input.GetTouch(0);
        if(touch.phase==TouchPhase.Began)
#endif
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = Camera.main.transform.position.z;

            //  親生成
            ++pIndex;
            ptr = new GameObject("Empty"+pIndex);
            ptr.transform.parent = this.transform;
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
#else
        if(touch.phase==TouchPhase.Moved)
#endif
        {

            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;

            if ((endPos - startPos).magnitude > lineLength)
            {
                GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

                obj.transform.parent = ptr.transform;
                touchPos = endPos;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index">active mat index</param>
    public void ChangeColor(int index)
    {

    }

    public GameObject GetParentNow()
    {
        return transform.GetChild(pIndex).gameObject;
    }

    public void ActiveCol(bool flags)
    {
        var p = GetParentNow();

        for(int i = 1; i < p.transform.childCount; ++i)
        {
            Collider col = p.transform.GetChild(i).GetComponent<Collider>();
            col.enabled = flags;
        }
    }

    public void DecIndex()
    {
        pIndex--;
    }

    public GameObject GetParentTail()
    {
        return transform.GetChild(transform.childCount).gameObject;
    }
}

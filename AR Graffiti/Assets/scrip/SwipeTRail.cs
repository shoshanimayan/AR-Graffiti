using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTRail : MonoBehaviour
{
    public GameObject lines;
    public GameObject white;
    public GameObject black;
    public GameObject blue;
    private GameObject trailPrefab;
    public GameObject red;
    private GameObject thisTrail;
    private Vector3 startPos;
    private Plane objPlane;

    // Use this for initialization
    void Start()
    {
        trailPrefab = white;
    }
    public void White()
    {
        trailPrefab = white;
    }
    public void Black()
    {
        trailPrefab = black;
    }
    public void Red()
    {
        trailPrefab = red;
    }
    public void Blue()
    {
        trailPrefab = blue;
    }
    public void Whipe() {
        var children = lines.transform.GetComponentsInChildren<Transform>();
        for (var c = 0; c < children.Length; c++)
        { //var child : Transform in allChildren
            Destroy(children[c].gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            float rayDistance;

            if (objPlane.Raycast(mRay, out rayDistance))
            {
                startPos = mRay.GetPoint(rayDistance);
            }
            thisTrail = (GameObject)Instantiate(trailPrefab, startPos, Quaternion.identity);
            thisTrail.transform.parent = lines.transform;
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            float rayDistance;

            if (objPlane.Raycast(mRay, out rayDistance))
            {
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
            }
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
            {
                Destroy(thisTrail);
            }
        }
    }
}

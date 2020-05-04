using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IPointerDownHandler
{
    public enum button { white,black,blue,red,erase }
    public button btn;
    public SwipeTRail swipe;
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (btn)
        {
            case (button.white):
                swipe.White();
                break;
            case (button.black):
                swipe.Black();
                break;
            case (button.red):
                swipe.Red();
                break;
            case (button.blue):
                swipe.Blue();
                break;
            case (button.erase):
                swipe.Whipe();
                break;


        }
    }
}
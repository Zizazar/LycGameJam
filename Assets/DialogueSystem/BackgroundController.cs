using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image background1;
    public Image background2;
    public Animator animator;

    public void SmoothSwitchBackground(Sprite sprite)
    {
        
        if (isSwitched)
        {
            //Скрываем background1 показываем background2
            background2.sprite = sprite;
            animator.SetTrigger("Switch1");
        }
        else
        {
            //Скрываем background2 показываем background1
            background1.sprite = sprite;
            animator.SetTrigger("Switch2");
        }
        isSwitched = !isSwitched;
        Debug.Log(isSwitched);
    }
    public void SetBackground(Sprite sprite)
    {
        if (isSwitched)
        {
            background2.sprite = sprite;
        }
        else
        {
            background1.sprite = sprite;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ChooseLabelController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public StoryScene scene;
    
    private TMP_Text textComp;
    private Image backImageComp;
    private ChooseController controller;

    void Start()
    {
        backImageComp = GetComponent<Image>();
        backImageComp.color = defaultColor;
    }

    public float GetHeight()
    {
        return textComp.rectTransform.sizeDelta.y * textComp.rectTransform.localScale.y;
    }

    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller, float y)
    {
        scene = label.nextScene;
        textComp.text = label.text;
        this.controller = controller;
        Vector3 pos = textComp.rectTransform.localPosition;
        pos.y = y;
        textComp.rectTransform.localPosition = pos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Клик");
        controller.PerformChoose(scene);
    }
    public void OnPointerEnter(PointerEventData eventData) 
    {
        backImageComp.color = hoverColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        backImageComp.color = defaultColor;
    }
}

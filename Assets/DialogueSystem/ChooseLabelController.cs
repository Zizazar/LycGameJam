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
    public RectTransform transformComp;
    private ChooseController controller;

    void Start()
    {
        backImageComp = GetComponent<Image>();

       
        backImageComp.color = defaultColor;
}


    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller, float y)
    {
        transformComp = GetComponent<RectTransform>();
        textComp = GetComponentInChildren<TMP_Text>();
        scene = label.nextScene;
        textComp.text = label.text;
        this.controller = controller;

        transform.Translate(new Vector3(0,y,0)); //Ура я нашёл способ поднять это
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

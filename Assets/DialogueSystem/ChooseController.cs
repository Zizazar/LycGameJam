using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    public NovelController gameController;
    private RectTransform rectTransform;
    private ChooseLabelController[] labelsObjs;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        DestroyLabels();
        StartCoroutine(ShowChooses(scene));

    }
    private IEnumerator ShowChooses(ChooseScene scene) //Какой же тут говнокод
    {
        labelsObjs = new ChooseLabelController[scene.labels.Count];
        for (int index = 0; index < scene.labels.Count; index++)
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();
            Debug.Log(newLabel.GetComponent<RectTransform>().rect.height * index); // Ладно пусть так будет
            newLabel.Setup(scene.labels[index], this, newLabel.GetComponent<RectTransform>().rect.height * index);
            newLabel.GetComponent<Animator>().SetTrigger("Show");
            labelsObjs[index] = newLabel; // Это для анимации скрытия
            yield return new WaitForSeconds(0.2f);
        }
    }


    public void PerformChoose(StoryScene scene)
    {
        gameController.PlayScene(scene);
        foreach (var label in labelsObjs)
        {
            label.GetComponent<Animator>().SetTrigger("Hide");   
        }


    }


    private void DestroyLabels()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
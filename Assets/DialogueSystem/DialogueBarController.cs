using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBarController : MonoBehaviour
{
    public TMP_Text characterNameComp;
    public TMP_Text textComp;
    public float textSpeed = 0.05f;

    private int phraseIndex = -1;
    private GameScene currentScene;
    private State curState = State.COMPLITED;

    private enum State
    {
        COMPLITED,
        PLAYING
    }

    public void PlayScene(GameScene scene)
    {
        currentScene = scene;
        phraseIndex = -1;
        PlayNextPhrase();
    }

    public int PlayNextPhrase()
    {
        StartCoroutine(TypeText((currentScene as StoryScene).phrases[++phraseIndex].text));
        characterNameComp.color = (currentScene as StoryScene).phrases[phraseIndex].speaker.nameColor;
        characterNameComp.text = (currentScene as StoryScene).phrases[phraseIndex].speaker.speakerName;

        return phraseIndex;
    }

    public bool IsCompleted()
    {
        return curState == State.COMPLITED;
    }
    public bool IsLastPhrase()
    {
        return phraseIndex + 1 == (currentScene as StoryScene).phrases.Count;
    }

    private IEnumerator TypeText(string text) // Посимвольное показывание текста
    {
        curState = State.PLAYING;
        textComp.text = "";
        int index = 0;
        while (curState != State.COMPLITED)
        {
            textComp.text += text[index];
            yield return new WaitForSeconds(textSpeed);
            index++;
            if (index >= text.Length)
            {
                curState = State.COMPLITED;
                break;
            }
        }
    }
}

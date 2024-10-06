using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelController : MonoBehaviour
{
    public GameScene currentScene;
    public DialogueBarController dialogueBar;
    public BackgroundController backgroundController;
    public BgmController bgmController;
    public ChooseController chooseController;

    void Start()
    {
        dialogueBar.PlayScene(currentScene as StoryScene);
        backgroundController.SetBackground((currentScene as StoryScene).Background);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene is StoryScene)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (dialogueBar.IsCompleted())
                {
                    if (dialogueBar.IsLastPhrase())
                    {
                        PlayScene(currentScene);
                        backgroundController.SmoothSwitchBackground((currentScene as StoryScene).Background);
                    }
                    else
                    {
                        StoryScene currentStoryScene = currentScene as StoryScene;
                        Debug.Log("Следующая фраза");
                        int phraseIndex = dialogueBar.PlayNextPhrase();
                        if (currentStoryScene.phrases[phraseIndex].bgm)
                        {
                            Debug.Log("Музыка поменялась");
                            bgmController.SetBgmSmooth(currentStoryScene.phrases[phraseIndex].bgm);

                        }
                    }
                }
            }
        }
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        currentScene = scene;
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SmoothSwitchBackground(storyScene.Background);
            yield return new WaitForSeconds(1f);
            dialogueBar.PlayScene(storyScene);
        }
        else if (scene is ChooseScene)
        {
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}

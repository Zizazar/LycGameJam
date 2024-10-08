using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NovelController : MonoBehaviour
{
    public GameScene currentScene;
    public DialogueBarController dialogueBar;
    public BackgroundController backgroundController;
    public BgmController bgmController;
    public ChooseController chooseController;
    public CharactersController charactersController;

    void Start()
    {
        PlayScene(currentScene);
        backgroundController.SetBackground((currentScene as StoryScene).Background);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene is StoryScene)
        {
            StoryScene currentStoryScene = currentScene as StoryScene;
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) & EventSystem.current.IsPointerOverGameObject()))
            {
                if (dialogueBar.IsCompleted())
                {
                    if (dialogueBar.IsLastPhrase())
                    {
                        PlayScene(currentStoryScene.nextScene);
                    }
                    else
                    {
                        Debug.Log("Следующая фраза");
                        int phraseIndex = dialogueBar.PlayNextPhrase();
                        if (currentStoryScene.phrases[phraseIndex].hideCharacter) {
                            charactersController.HideCharacter();
                        } else {
                            charactersController.SpawnCharacter(currentStoryScene.phrases[phraseIndex].speaker.sprite);
                        }
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
        //StartCoroutine(SwitchScene(scene));
        currentScene = scene;
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SmoothSwitchBackground(storyScene.Background);
            //yield return new WaitForSeconds(1f);
            dialogueBar.PlayScene(storyScene);
            if (storyScene.phrases[0].hideCharacter)
            {
                charactersController.HideCharacter();
            }
            else
            {
                charactersController.SpawnCharacter(storyScene.phrases[0].speaker.sprite);
            }
        }
        else if (scene is ChooseScene)
        {
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Dialogue/NewStoryScene")]
[System.Serializable]
public class StoryScene : GameScene
{
    public List<Phrase> phrases;
    public Sprite Background;
    public GameScene nextScene;

    [System.Serializable]
    public struct Phrase
    {
        public string text;
        public Speaker speaker;
        public Animation animation;
        public AudioClip bgm;
    }
}

public class GameScene : ScriptableObject
{

}

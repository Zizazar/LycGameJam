using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewChooseScene", menuName = "Dialogue/NewChooseScene")]
[System.Serializable]
public class ChooseScene : GameScene
{
    public List<ChooseLabel> labels;
    public AudioClip bgm;

    [System.Serializable]
    public struct ChooseLabel
    {
        public string text;
        public StoryScene nextScene;
    }
}

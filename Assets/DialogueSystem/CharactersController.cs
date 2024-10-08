using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharactersController : MonoBehaviour
{
    public Image character;
    public NovelController novelController;
    private GameObject[] charactersOnScene;
    public void SpawnCharacter(Sprite sprite)
    {
        character.gameObject.SetActive(true);
        character.sprite = sprite;
    }
    public void HideCharacter()
    {
        character.gameObject.SetActive(false);
    }
}

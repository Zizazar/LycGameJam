using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{

    public AudioSource audioSource;


    public void SetBGM(AudioClip audioClip) //������ ����� ������
    {
        Debug.Log(audioClip);

        audioSource.clip = audioClip;

        Debug.Log(audioSource.clip);
        audioSource.Play();
    }
    public void SetBgmSmooth(AudioClip audioClip)
    {
        if (audioSource.clip != audioClip) 
        { 
            StartCoroutine(VolumeSmooth(audioClip));
        }
    }
    private IEnumerator VolumeSmooth(AudioClip audioClip)
    {
        if (audioSource.isPlaying)      //������ ������� ��������� ���� ��� �� ������
        {
            while (audioSource.volume > 0)
            {
                audioSource.volume -= 0.08f;
                yield return new WaitForSeconds(0.1f);
            }
        }
            audioSource.clip = audioClip;
            audioSource.Play();

        while (audioSource.volume < 1)  //������ �������� ���������
            {
                audioSource.volume += 0.02f;
                yield return new WaitForSeconds(0.1f);
            }
        
        }
    }

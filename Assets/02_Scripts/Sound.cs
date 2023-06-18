using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource1;  // 사운드를 재생할 AudioSource 컴포넌트
    public AudioSource audioSource2;

    // 재생할 사운드 클립들 아래에 선언
    public AudioClip clock;
    public AudioClip step;

    private float volume;

    // 사운드 재생 메소드
    public void PlaySound(string whatSound) //어떤 소리를 재생할지 변수 가져옴.
    {
        volume = PlayerPrefs.GetFloat("Volume");

        if (whatSound == "clock")  
        {
            audioSource1.PlayOneShot(clock, volume);  // 사운드를 한 번 재생합니다.
        }
        audioSource2.PlayOneShot(step, volume);

    }
}

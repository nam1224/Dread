using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;  // 사운드를 재생할 AudioSource 컴포넌트

    public AudioClip soundClip;  // 재생할 사운드 클립

    // 사운드 재생 메소드
    public void PlaySound()
    {
        audioSource.PlayOneShot(soundClip);  // 사운드를 한 번 재생합니다.
    }
}

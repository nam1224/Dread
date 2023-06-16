using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;  // ���带 ����� AudioSource ������Ʈ

    public AudioClip soundClip;  // ����� ���� Ŭ��

    // ���� ��� �޼ҵ�
    public void PlaySound()
    {
        audioSource.PlayOneShot(soundClip);  // ���带 �� �� ����մϴ�.
    }
}

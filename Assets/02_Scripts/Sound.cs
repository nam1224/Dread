using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource1;  // ���带 ����� AudioSource ������Ʈ
    public AudioSource audioSource2;

    // ����� ���� Ŭ���� �Ʒ��� ����
    public AudioClip clock;
    public AudioClip step;

    private float volume;

    // ���� ��� �޼ҵ�
    public void PlaySound(string whatSound) //� �Ҹ��� ������� ���� ������.
    {
        volume = PlayerPrefs.GetFloat("Volume");

        if (whatSound == "clock")  
        {
            audioSource1.PlayOneShot(clock, volume);  // ���带 �� �� ����մϴ�.
        }
        audioSource2.PlayOneShot(step, volume);

    }
}

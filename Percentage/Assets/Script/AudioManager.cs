using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("----- BGM -----")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    AudioSource bgmSource;
    //public int bgmChannel;
    //int bgmChannelIndex;

    [Header("----- Effect -----")]
    public AudioClip[] effectClip;
    public float effectVolume;
    AudioSource[] effectSource;
    public int effectChannel;
    int effectChannelIndex;

    public enum BGM {Intro, bgm1, bgm2, bgm3, bgm4, bgm5, bgm6, bgm7, bgm8, bgm9, bgm10, bgm11, bgm12, bgm13, bgm14};
    public enum Effect {ButtonClick, PanelOpen, GetCoin, GetHealth, GetItem, Damaged, Swap, Success, Fail, Destroyed, Portal, Victory, Dead, 
    Buff, KnightAttack, GuardAttack, SwardAura, WizardShot, Meteor, Infernorize, ThiefAttack, LandMine, Timer, Bomb, Assasination, GunnerShot, BulletParty, HeadShot};

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    void Init()
    {
        // BGM
        GameObject bgmObject = new GameObject("bgm");
        bgmObject.transform.parent = transform;
        bgmSource = bgmObject.AddComponent<AudioSource>();
        bgmSource.playOnAwake = false;
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;
        //bgmSource = new AudioSource[bgmChannel];
        //for (int i = 0; i < bgmSource.Length; i++)
        //{
        //    bgmSource[i] = bgmObject.AddComponent<AudioSource>();
        //    bgmSource[i].playOnAwake = false;
        //    bgmSource[i].loop = true;
        //    bgmSource[i].volume = bgmVolume;
        //}

        // Effect
        GameObject effectObject = new GameObject("effect");
        effectObject.transform.parent = transform;
        effectSource = new AudioSource[effectChannel];
        for(int i=0; i<effectSource.Length; i++)
        {
            effectSource[i] = effectObject.AddComponent<AudioSource>();
            effectSource[i].playOnAwake = false;
            effectSource[i].volume = effectVolume;
        }
    }

    public void BGMPlay(int bgmIndex)
    {
        bgmSource.clip = bgmClip[bgmIndex];
        if (bgmIndex == 1) bgmSource.volume = 0.5f;
        bgmSource.Play();
        //for (int i = 0; i < bgmSource.Length; i++)
        //{
        //    // �տ������� ���鼭 ������� �ƴ� ����� �ҽ��� ã�´�
        //    int index = (i + bgmChannelIndex) % bgmSource.Length;

        //    // ã���� �ε����� �ٲٰ� ������� �����ϰ� ����Ѵ�
        //    if (!bgmSource[index].isPlaying)
        //    {
        //        bgmChannelIndex = index;
        //        bgmSource[index].clip = bgmClip[(int)bgm];
        //        bgmSource[index].Play();
        //        break;
        //    }
        //}
    }

    public void BGMStop()
    {
        bgmSource.Stop();
        //bgmSource[bgmChannelIndex].Stop();
    }

    public void EffectPlay(Effect effect)
    {
        for(int i=0; i<effectSource.Length; i++)
        {
            // �տ������� ���鼭 ������� �ƴ� ����� �ҽ��� ã�´�
            int index = (i + effectChannelIndex) % effectSource.Length;

            // ã���� �ε����� �ٲٰ� ������� �����ϰ� ����Ѵ�
            if (!effectSource[index].isPlaying)
            {
                effectChannelIndex = index;
                effectSource[index].clip = effectClip[(int)effect];
                effectSource[index].Play();
                break;
            }
        }
    }

    public void ButtonClickEffectPlay()
    {
        EffectPlay(Effect.ButtonClick);
    }
}
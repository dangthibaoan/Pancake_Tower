using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundConfig", menuName = "Game/SoundConfig")]
public class SoundConfig : ScriptableObject
{
    public List<SoundData> SoundDatas;
}

[Serializable]
public class SoundData
{
    public SoundType SoundType;
    public AudioClip Clip;
}
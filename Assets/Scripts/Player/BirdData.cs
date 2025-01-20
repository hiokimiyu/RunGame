using UnityEngine;

[System.Serializable]
public class BirdData
{
    /// <summary>キャラクターを判別するID</summary>
    public int ID;

    /// <summary>アンロックしたかどうか</summary>
    public bool isUnlocked;

    /// <summary>スピード</summary>
    public float Speed;

    /// <summary>HP</summary>
    public int Hp;

    /// <summary>重み</summary>
    public float Wei;

    /// <summary>スコアが何倍か</summary>
    public int Score;

    /// <summary>キャラクターに対応したマテリアル</summary>
    public Material characterMaterial;

    // コンストラクタ
    public BirdData(int id, bool unlocked, float speed, int hp, float wei, int score, Material material)
    {
        isUnlocked = unlocked;
        ID = id;
        Speed = speed;
        Hp = hp;
        Wei = wei;
        Score = score;
        characterMaterial = material;
    }
}
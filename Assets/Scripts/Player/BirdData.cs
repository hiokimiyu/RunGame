using UnityEngine;

[System.Serializable]
public class BirdData
{
    /// <summary>�L�����N�^�[�𔻕ʂ���ID</summary>
    public int ID;

    /// <summary>�A�����b�N�������ǂ���</summary>
    public bool isUnlocked;

    /// <summary>�X�s�[�h</summary>
    public float Speed;

    /// <summary>HP</summary>
    public int Hp;

    /// <summary>�d��</summary>
    public float Wei;

    /// <summary>�X�R�A�����{��</summary>
    public int Score;

    /// <summary>�L�����N�^�[�ɑΉ������}�e���A��</summary>
    public Material characterMaterial;

    // �R���X�g���N�^
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
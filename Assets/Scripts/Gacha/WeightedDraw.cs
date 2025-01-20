using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �K�`���̏d�ݕt�����v�Z�����肷��N���X
/// </summary>
public class WeightedDraw : MonoBehaviour
{
    /// <summary>�K�`���̏d��(�m���ɒ���)������</summary>
    float[] _gacha = new float[5];

    /// <summary>�K�`���̒��g</summary>
    //[SerializeField] TextAsset _birdFile = default;

    /// <summary> �����i����ɂȂ鐔�j</summary>
    float _total;

    //��΂ꂽ���ɂ�邱��(�R���X�g���N�^
    public WeightedDraw(float[] weighs)
    {
        _gacha = weighs;

        foreach (var i in weighs)
        {
            //�g�[�^���ɑ��a������
            _total += i;
        }
    }

    public int PerformLottery()
    {
        float randomPoint = Random.Range(0, _total);

        //���݂̑��a�𒲂ׂ邽�߂̃J�E���g
        float count = 0;

        for (int i = 0; i < _gacha.Length; i++)
        {
            //�d�݂���C���f�b�N�X��T��
            count += _gacha[i];

            if (randomPoint < count)
            {
                return i;
            }
        }

        //�ߎ��l�ōs���邽�߂�����������̕ی�
        //������ԑ��������̂ɂ���ƃ��A�x���Ⴂ�̂��o�Ă���͂�
        return _gacha.Length - 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ガチャの重み付けを計算したりするクラス
/// </summary>
public class WeightedDraw : MonoBehaviour
{
    /// <summary>ガチャの重み(確率に直結)をつける</summary>
    float[] _gacha = new float[5];

    /// <summary>ガチャの中身</summary>
    //[SerializeField] TextAsset _birdFile = default;

    /// <summary> 総数（分母になる数）</summary>
    float _total;

    //よばれた時にやること(コンストラクタ
    public WeightedDraw(float[] weighs)
    {
        _gacha = weighs;

        foreach (var i in weighs)
        {
            //トータルに総和を入れる
            _total += i;
        }
    }

    public int PerformLottery()
    {
        float randomPoint = Random.Range(0, _total);

        //現在の総和を調べるためのカウント
        float count = 0;

        for (int i = 0; i < _gacha.Length; i++)
        {
            //重みからインデックスを探す
            count += _gacha[i];

            if (randomPoint < count)
            {
                return i;
            }
        }

        //近似値で行われるためもしかしたらの保険
        //数が一番多いいものにするとレア度が低いのが出てくるはず
        return _gacha.Length - 1;
    }
}

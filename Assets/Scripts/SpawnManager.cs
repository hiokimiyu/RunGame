using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ランダムにコインを出す。
//ランダムに出した残り２レーンから１つ選びエネミーを出す
//もしかしたら２レーン同時に出すのもあり

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _coin = default;
    [SerializeField] GameObject[] _enemy = default;
    [SerializeField] GameObject[] _crow = default;

    [SerializeField] float _spawnInterval = 5f;
    [SerializeField] float _spawnEnemyInterval = 10f;
    [SerializeField] float _maxDistance = 50f;

    float _position = 0f;
    float _positionEnemy = 0f;

    int _lastLane = 1; //直前に出したレーン
    float _lastItemPos = default;//直前のアイテムの位置
    float _lastEnemy = default;

    /// <summary>レーンの高さ</summary>
    [SerializeField] float[] _lanes = new float[3];

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        while (_lastItemPos <= _maxDistance)
        {
            int laneIndex = 0;
            int enemyLane = 0;

            if (_lastLane == 1)
            {
                //コインを出す場所を決める
                laneIndex = Random.Range(0, 3);
            }
            else if (_lastLane == 2)
            {
                laneIndex = Random.Range(1, 3);
            }
            else if (_lastLane == 0)
            {
                laneIndex = Random.Range(0, 2);
            }

            //Debug.Log(laneIndex);

            //直前に出したもののインデックスを記憶
            _lastLane = laneIndex;

            //間隔をあけている
            _position += _spawnInterval;
            _positionEnemy += _spawnInterval;
            _lastItemPos = _position;

            int a = Random.Range(0, 5);
            if (a > 0)
                Instantiate(_coin, new Vector3(0, _lanes[laneIndex] + transform.position.y, _position + transform.position.z), Quaternion.identity, gameObject.transform);

            _lastEnemy = _positionEnemy;

            enemyLane = Random.Range(0, 3);

            //乱数の取得
            while (enemyLane == laneIndex)
            {
                enemyLane = Random.Range(0, 3);
                //Debug.Log(enemyLane);
            }

            int index = Random.Range(0, _enemy.Length);

            if (enemyLane == 0)
            {
                //人
                Instantiate(_enemy[index], new Vector3(0, _lanes[enemyLane] + transform.position.y, _positionEnemy + transform.position.z), Quaternion.identity, gameObject.transform);
            }
            else if (enemyLane == 1)
            {
                //カラス
                Instantiate(_crow[index], new Vector3(0, _lanes[enemyLane] + transform.position.y, _positionEnemy + transform.position.z), Quaternion.identity, gameObject.transform);
            }
            else if (enemyLane == 2)
            {
                //カラス
                Instantiate(_crow[0], new Vector3(0, _lanes[enemyLane] + transform.position.y, _positionEnemy + transform.position.z), Quaternion.identity, gameObject.transform);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�����_���ɃR�C�����o���B
//�����_���ɏo�����c��Q���[������P�I�уG�l�~�[���o��
//������������Q���[�������ɏo���̂�����

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

    int _lastLane = 1; //���O�ɏo�������[��
    float _lastItemPos = default;//���O�̃A�C�e���̈ʒu
    float _lastEnemy = default;

    /// <summary>���[���̍���</summary>
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
                //�R�C�����o���ꏊ�����߂�
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

            //���O�ɏo�������̂̃C���f�b�N�X���L��
            _lastLane = laneIndex;

            //�Ԋu�������Ă���
            _position += _spawnInterval;
            _positionEnemy += _spawnInterval;
            _lastItemPos = _position;

            int a = Random.Range(0, 5);
            if (a > 0)
                Instantiate(_coin, new Vector3(0, _lanes[laneIndex] + transform.position.y, _position + transform.position.z), Quaternion.identity, gameObject.transform);

            _lastEnemy = _positionEnemy;

            enemyLane = Random.Range(0, 3);

            //�����̎擾
            while (enemyLane == laneIndex)
            {
                enemyLane = Random.Range(0, 3);
                //Debug.Log(enemyLane);
            }

            int index = Random.Range(0, _enemy.Length);

            if (enemyLane == 0)
            {
                //�l
                Instantiate(_enemy[index], new Vector3(0, _lanes[enemyLane] + transform.position.y, _positionEnemy + transform.position.z), Quaternion.identity, gameObject.transform);
            }
            else if (enemyLane == 1)
            {
                //�J���X
                Instantiate(_crow[index], new Vector3(0, _lanes[enemyLane] + transform.position.y, _positionEnemy + transform.position.z), Quaternion.identity, gameObject.transform);
            }
            else if (enemyLane == 2)
            {
                //�J���X
                Instantiate(_crow[0], new Vector3(0, _lanes[enemyLane] + transform.position.y, _positionEnemy + transform.position.z), Quaternion.identity, gameObject.transform);
            }

        }
    }
}

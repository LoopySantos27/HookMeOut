using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject[] _levels1;
    public Transform _spawnPlayerPosition;
    public GameObject _player;

    int _counterLevel;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        AudioManager.instance.Play("MusicGameplay");
        //Comenzar el nivel
        Instantiate(_levels1[0]);
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawnPlayerPosition = GameObject.FindGameObjectWithTag("SpawnPlayer").GetComponent<Transform>();
    }


    public void NextLevel()
    {
        //Destruir el nivel actual
        GameObject _currentLevel = GameObject.FindGameObjectWithTag("CurrentLevel");
        Debug.Log(_currentLevel);
        Destroy(_currentLevel, 0.2f);

        //Sumarle al arreglo el nivel que se va a agregar
        if (_counterLevel > 3)
            return;
        else
        {
            _counterLevel++;
            Instantiate(_levels1[_counterLevel]);
            
            
        }
        
    }

    public void RestetLevel()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawnPlayerPosition = GameObject.FindGameObjectWithTag("SpawnPlayer").GetComponent<Transform>();
        _player.transform.position = _spawnPlayerPosition.position;
    }
}

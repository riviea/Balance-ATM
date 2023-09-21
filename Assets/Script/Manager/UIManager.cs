using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // is Sigletone
    public static UIManager Instance;

    [SerializeField] public Dictionary<string, List<GameObject>> uiDict;

    [Header("Caching List")]
    [SerializeField] ObjectArray[] uiObjects;

    private void Awake()
    {
        this.uiDict = new Dictionary<string, List<GameObject>>();
        this.InitializeData();

        Instance = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        InitializeScene();
    }

    //Cahcing.
    public void InitializeData()
    {
        foreach(var obj in uiObjects)
        {
            uiDict.Add(obj.key, obj.scene_object);
        }
    }

    public void InitializeScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        foreach(var obj in uiDict[scene.name])
        {
            GameObject temp = Instantiate(obj);
            temp.name = obj.name;
        }
    }
}

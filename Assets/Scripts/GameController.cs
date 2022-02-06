using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController :MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = GameObject.Find("GameController");
                if(go == null) go = new GameObject("GameController");
                if (_instance == null) _instance = go.GetComponent<GameController>();
                if(_instance == null) _instance = go.AddComponent<GameController>();

            }
            return _instance;
        }
    }

    public Health playerHealth;
    public List<GameObject> targetables { get; set; }
    public InputActionAsset defaultControls;

    public void AddTarget(GameObject target)
    {
        if (targetables == null) targetables = new List<GameObject>();
        targetables.Add(target);
    }

    public Target GetPlayerTarget()
    {
        return playerHealth.GetComponent<Target>();
    }

    public void OnEnable()
    {
        defaultControls.Enable();
    }

    public void OnDisable()
    {
        defaultControls.Disable();
    }
}

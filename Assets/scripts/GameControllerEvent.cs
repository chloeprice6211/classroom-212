using UnityEngine;

public class GameControllerEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEventController.AddListener("disappear",OnGameEvent);
    }

    private void OnGameEvent(string type, object payload){
        Debug.Log(type + " " + payload);   
    }

    private void OnDestroy(){
        GameEventController.RemoveListener("Disappear", OnGameEvent);
    }
}

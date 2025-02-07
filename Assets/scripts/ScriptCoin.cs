using Unity.VisualScripting;
using UnityEngine;

public class ScriptCoin : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){

        Debug.Log(other.gameObject.name);
        animator.SetTrigger("OnCollected");
        GameEventController.EmitEvent("collected", "coin");
    }

    public void OnDisappearClipEnd(){
        GameEventController.EmitEvent("disappear", "coin");
        Destroy(this.gameObject);
    }
}
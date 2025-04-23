using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log(1);
                break;
            case "Finish":
                Debug.Log(2);
                break;
            case "Fuel":
                Debug.Log(3);
                break;
            default:
                Debug.Log(4);
                break;

        }    
    }
}

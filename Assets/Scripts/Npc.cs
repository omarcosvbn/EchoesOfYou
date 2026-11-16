using UnityEngine;

public class Npc : MonoBehaviour{
    [SerializeField] Sprite image;
    [SerializeField] Transform player;
    [SerializeField] float imageScale = 1f;

    void Update(){
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if(direction.sqrMagnitude > 0f){
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}

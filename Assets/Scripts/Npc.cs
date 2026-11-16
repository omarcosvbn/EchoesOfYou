using UnityEngine;

public class Npc : MonoBehaviour{
    [SerializeField] Sprite image;
    [SerializeField] Transform player;
    [SerializeField] float imageScale = 1f;
    [SerializeField] float interactionDistance = 3f;

    public bool IsInteractable { get; private set; }

    GameObject interactable;

    void Start(){
        interactable = transform.Find("Interactable").gameObject;
        interactable.SetActive(false);
    }

    void Update(){
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if(direction.sqrMagnitude > 0f){
            transform.rotation = Quaternion.LookRotation(direction);
        }

        float distance = direction.magnitude;
        IsInteractable = distance < interactionDistance &&
                         Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, distance) &&
                         hit.transform == player;

        interactable.SetActive(IsInteractable);
    }
}

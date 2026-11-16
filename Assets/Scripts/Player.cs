using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float lookSpeed = 1f;
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference lookAction;

    float cameraPitch;

    void OnEnable(){
        moveAction.action.Enable();
        lookAction.action.Enable();
    }

    void OnDisable(){
        moveAction.action.Disable();
        lookAction.action.Disable();
    }

    void Update(){
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);

        transform.Rotate(Vector3.up, lookInput.x * lookSpeed * Time.deltaTime);

        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y * lookSpeed * Time.deltaTime, -80f, 80f);
        Camera.main.transform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }
}

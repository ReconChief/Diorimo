using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputs : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }
    private void OnStart() {
        player.StartButton();
    }
    private void OnMovement(InputValue value) {
        player.Move = value.Get<Vector2>();
    }
    private void OnA() {
        //player.Jump();
        print("Jump hoe");
    }
    private void OnB() {

    }
    private void OnX() {

    }
    private void OnY() {
        player.FlashLight();
    }
    private void OnL2() {
        player.Missle();
    }
    private void OnR2() {
        player.Shoot();
    }
    private void OnL1() {

    }
    private void OnR1() {

    }
    private void OnDpadUp() {
        player.Dup();
    }
    private void OnDpadDown() {
        player.DDown();
    }
    private void OnDpadLeft() {
        player.DLeft();
    }
    private void OnDpadRight() {
        player.DRight();
    }
}

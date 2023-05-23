using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFloat : MonoBehaviour
{
    public float floatSpeed = 2f; // Adjust this value to control the speed of the floating animation
    public float floatHeight = 1f; // Adjust this value to control the height of the floating animation

    private float startY;

    private void Start()
    {
        startY = transform.position.y; // Store the initial y position of the GameObject
    }

    private void Update()
    {
        // Calculate the new y position based on the floating animation
        float newY = startY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update the position of the parent GameObject
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

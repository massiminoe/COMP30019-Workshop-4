// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class DestroyInvisible : MonoBehaviour
{
    private float zMax = 20.0f;


    // Update is called once per frame
    private void Update()
    {
        if (transform.localPosition[2] >= zMax) {
            Destroy(this);
        }
    }
}
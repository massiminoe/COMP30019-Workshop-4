// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using System.Collections;
using UnityEngine;

public class SwarmManager : MonoBehaviour
{
    // External parameters/variables
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private int enemyRows;
    [SerializeField] private int enemyCols;
    [SerializeField] private float enemySpacing;
    [SerializeField] private float stepSize;
    [SerializeField] private float stepTime;
    [SerializeField] private float leftBoundaryX;
    [SerializeField] private float rightBoundaryX;
    private float direction = 1.0f;

    private void Start()
    {
        // Initialise the swarm by instantiating enemy prefabs.
        GenerateSwarm();

        // Start swarm at the far left.
        transform.localPosition = new Vector3(this.leftBoundaryX, 0f, 0f);

        // Use a coroutine to periodically step the swarm. Coroutines are worth
        // learning about if you are unfamiliar with them. In Unity they allow
        // us to define sequences that span multiple frames in a very clean way.
        // Although it might look like it, using coroutines is *not* the same as
        // using multithreading! Read more here:
        // https://docs.unity3d.com/Manual/Coroutines.html
        StartCoroutine(StepSwarmPeriodically());
    }

    private IEnumerator StepSwarmPeriodically()
    {
        // Yep, this is an infinite loop, but the gameplay isn't ever "halted"
        // since the function is invoked as a coroutine. It's also automatically 
        // stopped when the game object is destroyed.
        while (true)
        {
            yield return new WaitForSeconds(this.stepTime); // Not blocking!
            StepSwarm();
        }
    }

    // Automatically generate swarm of enemies based on the given serialized
    // attributes/parameters.
    private void GenerateSwarm()
    {
        // Write code here...
        for (var row = 0; row < enemyRows; row++)
        {
            for (var col = 0; col < enemyCols; col++)
            {
                Instantiate(enemyTemplate, new Vector3(row * 2.0f - (enemyRows - 1.0f), 0, col * 2.0f), Quaternion.identity, transform);
            }
        }
    }

    // Step the swarm across the screen, based on the current direction, or down
    // and reverse when it reaches the edge.
    private void StepSwarm()
    {
        // Write code here...
        transform.localPosition += new Vector3(stepSize * direction, 0, 0);

        if ((transform.localPosition[0] >= this.rightBoundaryX) || (transform.localPosition[0] <= this.leftBoundaryX)) {
            direction *= -1;
            transform.localPosition += new Vector3(0, 0, -1.0f);
        }
        // Tip: You probably want a private variable to keep track of the
        // direction the swarm is moving. You could alternate this between 1 and
        // -1 to serve as a vector multiplier when stepping the swarm.
    }
}

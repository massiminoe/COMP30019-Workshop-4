// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;

    // Update is called once per frame
    private void Update()
    {
        transform.localPosition += new Vector3(0, 0, this.speed * Time.deltaTime);

        if (transform.localPosition[2] >= 20) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
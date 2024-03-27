using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;

    Blade hand;
    private ParticleSystem juiceEffect;
    Spawner spawner;



    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<Blade>();
        spawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Spawner>();
        juiceEffect = GetComponentInChildren<ParticleSystem>();


    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        //GameManager.Instance.IncreaseScore(points);

        // Disable the whole fruit
        fruitCollider.enabled = false;
        whole.SetActive(false);

        // Enable the sliced fruit
        sliced.SetActive(true);

        // Rotate based on the slice angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        // Add a force to each slice based on the blade direction
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Slice(hand.Direction, hand.transform.position, 20);
            juiceEffect.Play();
            spawner.IncreaseScore(1);
        }
    }



}

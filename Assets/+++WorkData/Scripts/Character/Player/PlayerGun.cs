using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    Camera playerCamera;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] float projectileForce;

    public void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        HandleShooting();
    }

    public void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            Vector3 shootDirection = ray.direction;

            GameObject projectile = Instantiate(
                projectilePrefab,
                playerCamera.transform.position + ray.direction.normalized * 2f,
                Quaternion.LookRotation(shootDirection)
            );

            particleSystem.Play();

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(shootDirection * projectileForce);
            }
        }
    }
}

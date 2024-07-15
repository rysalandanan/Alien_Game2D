using System.Collections;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private float TimeBeforEachShot;
    private bool canFire = true;
    private bool isFiring = false;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canFire)
        {
            FireWeapon();
            StartCoroutine(RateOfFire());
        }
    }

    private void FireWeapon()
    {
        isFiring = true;
        // Instantiate the bullet at the gun barrel's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Calculate the firing direction based on the gun barrel's right direction
        Vector3 firingDirection = this.transform.localScale;

        // Apply force to the bullet in the firing direction
        rb.AddForce(firingDirection * bulletSpeed, ForceMode2D.Impulse);
    }
    private IEnumerator RateOfFire()
    {
        isFiring = false;
        canFire = false;
        yield return new WaitForSecondsRealtime(TimeBeforEachShot);
        canFire = true;
    }
    public bool IsFiring()
    {
        return isFiring;
    }
}

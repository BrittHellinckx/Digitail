using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Guitar : MonoBehaviour
{
    [Header("Basic Stats")]
    public float regularSpeed;
    public float sprintSpeed;
    public float jumpBoost;

    [Header("Shooting")]
    bool readyToShoot = true, reloading = false;

    [Header("Guns")]
    public GameObject weapon;

    [Header("GunProperties")]
    int magSize = 40;
    public int damageDone = 2;
    float bulletForce = 350f, timeBetweenShooting = 0.15f, reloadTime = 0.5f;

    [Header("Bullet")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    int bulletsLeft;

    [Header("Animations")]
    public Animator animator;

    [Header("UI")]
    public TextMesh ammunitionDisplay;

    ////////////////////////////////////////////
    public void UseGuitarAbilities()
    {
        //Show amunition
        //ShowDisplay();

        //Check if shooting
        ShootGun();
    }
    void ShowDisplay()
    {
        if (bulletsLeft <= 0 || reloading)
        {
            ammunitionDisplay.text = "Reloading ...";
        }
        else
        {
            ammunitionDisplay.text = bulletsLeft + " / " + magSize;
        }
    }

    void ShootGun()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.E) && readyToShoot && !reloading && bulletsLeft != 0) StartCoroutine(Shooting());
        //Reloading
        else if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) StartCoroutine(Reloading());
        //Reload automatically when no bullets left
        else if (readyToShoot && !reloading && bulletsLeft <= 0 || bulletsLeft > magSize) StartCoroutine(Reloading());
    }

    ///////
    IEnumerator Shooting()
    {
        readyToShoot = false;
        animator.SetBool("aim", true);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletForce);

        bulletsLeft--;

        yield return new WaitForSeconds(timeBetweenShooting);
        readyToShoot = true;
        animator.SetBool("aim", false);
    }
    IEnumerator Reloading()
    {
        reloading = true;
        bulletsLeft = magSize;
        animator.SetBool("reload", true);

        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        animator.SetBool("reload", false);
    }
}

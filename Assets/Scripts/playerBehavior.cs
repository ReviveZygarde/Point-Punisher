using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    //--------------------------------------------
    private float _hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private soundManager soundPlaybackCuesheet;
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;
    //private GameBehavior _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        fetchSoundPlaybackCuesheetFromSingleton();
    }

    void fetchSoundPlaybackCuesheetFromSingleton()
    {
        GameObject common = GameObject.Find("common");
        soundPlaybackCuesheet = common.GetComponent<soundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //3 - Detects Left/right -> is multiplied by the Movespeed.
        _hInput = Input.GetAxis("Horizontal") * MoveSpeed;
        // TwinBee-style shooting. Press the button down, shoots 1 projectile, lift your finger from the button and it'll shoot another projectile.
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0) || Input.GetKeyDown("joystick button 2") || Input.GetKeyUp("joystick button 2"))
        {
            ShootBullet();
            soundPlaybackCuesheet.shootSoundPlayback();
        };
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(this.transform.position + this.transform.right * _hInput * Time.fixedDeltaTime);
    }

    void ShootBullet()
    {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * BulletSpeed;
    }
}

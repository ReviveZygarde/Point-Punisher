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
    private ObjectPoolScript OBJpoolManager;
    public float BulletSpeed = 100f;
    private bool _isShooting;
    //private GameBehavior _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        fetchSoundPlaybackCuesheetFromSingleton();
        getPoolManagerForBullets();
    }

    void fetchSoundPlaybackCuesheetFromSingleton()
    {
        GameObject common = GameObject.Find("common");
        soundPlaybackCuesheet = common.GetComponent<soundManager>();
    }

    void getPoolManagerForBullets()
    {
        GameObject temp = GameObject.Find("OBJECT_POOL_MANAGER");
        OBJpoolManager = temp.GetComponent<ObjectPoolScript>();
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
        OBJpoolManager.spawn();
    }
}

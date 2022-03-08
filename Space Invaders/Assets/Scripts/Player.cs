using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator _playerAnimator;
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    public float speed = 5f;

    //-----------------------------------------------------------------------------
    void Start()
    {
       // playerAnimator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            // playerAnimator.SetTrigger(Shoot);
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            //Debug.Log("Bang!");

            Destroy(shot, 3f);
        }

        
        float inputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(speed * inputX,  0,0);

        movement *= Time.deltaTime;

        transform.Translate(movement);

    }
}

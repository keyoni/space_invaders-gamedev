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
    private static readonly int Death = Animator.StringToHash("Death");

    //-----------------------------------------------------------------------------
    void Start()
    {
        _playerAnimator = GetComponent<Animator>(); 
        // MenuLogic.MenuScreenClose += UnIdleAnimate;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            _playerAnimator.SetTrigger(Shoot);
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            //Debug.Log("Bang!");

            Destroy(shot, 10f);
        }

        
        float inputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(speed * inputX,  0,0);

        movement *= Time.deltaTime;

        transform.Translate(movement);

    }

    public void DeathAnimate()
    {
        _playerAnimator.SetTrigger(Death);
    }

}

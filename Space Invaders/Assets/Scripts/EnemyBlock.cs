using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBlock : MonoBehaviour
{
    public float timerMax = 0.5f;
    public float speedIncrease = 0.2f;
    private float _timer;

    private float _xMove = 0.5f;
    private float _yMove;

    public GameObject enemySmallPrefab;
    public GameObject enemyMidPrefab;
    public GameObject enemyLargePrefab;
    public GameObject enemyHugePrefab;

    public GameObject rowPlaceHolder;

    [FormerlySerializedAs("_leftPlaceholder")] public GameObject leftPlaceholder;
    [FormerlySerializedAs("_rightPlaceholder")] public GameObject rightPlaceholder;
    private float _hugeEnemySpeed;
    private int _numberOfEnemyBullets = 1;

    public int numberOfColumns = 10;
    private bool _down;


    // Start is called before the first frame update
    private void Start()
    {
        EnemySpawn();
        Boundary.BoundHit += DirectionSwitch;
        ScoreTracker.KillCountHit += SpawnHugeEnemy;
        PlayerBullet.EnemyDeath += SpeedUp;
        ScoreTracker.KillCountHit += IncreaseEnemyBullets;
    }

    // Update is called once per frame
    private void Update()
    {
        BlockMove();
        if (_down)
        {
            _yMove = 0;
            _down = false;
        }
    }

    private void BlockMove()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            if (_yMove < 0)
                _down = true;

            transform.Translate(new Vector3(_xMove, _yMove, 0));
            _timer = timerMax;
        }
    }

    public void EnemySpawn()
    {
        for (var i = 0; i < 4; i++) EnemySpawnRow(i);
    }

    public void EnemySpawnRow(int type)
    {
        switch (type)
        {
            case 0:
                for (var i = 0; i < numberOfColumns; i++)
                {
                    var space = new Vector3(i + i + 1, 0, 0);
                    var enemy = Instantiate(enemyLargePrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }

                break;
            case 1:
                for (var i = 0; i < numberOfColumns; i++)
                {
                    var space = new Vector3(i + i + 1, -2, 0);
                    var enemy = Instantiate(enemyMidPrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }

                break;
            case 2:
                for (var i = 0; i < numberOfColumns; i++)
                {
                    var space = new Vector3(i + i + 1, -4, 0);
                    var enemy = Instantiate(enemySmallPrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }

                break;
            case 3:
                for (var i = 0; i < numberOfColumns; i++)
                {
                    var space = new Vector3(i + i + 1, -6, 0);
                    var enemy = Instantiate(enemySmallPrefab, rowPlaceHolder.transform.position + space,
                        Quaternion.identity);
                    enemy.transform.SetParent(transform);
                }

                break;
        }
    }

    private void DirectionSwitch()
    {
        _xMove = -_xMove;
        _yMove = -0.5f;
    }

    private void SpawnHugeEnemy()
    {
        var placeholder = Random.Range(0, 1);

        GameObject hugeEnemyShip;
        if (placeholder == 1)
        {
            hugeEnemyShip = Instantiate(enemyHugePrefab, leftPlaceholder.transform.position + Vector3.right,
                Quaternion.identity);
            hugeEnemyShip.GetComponent<HugeEnemy>().SetDirection(1);
        }
        else
        {
            hugeEnemyShip = Instantiate(enemyHugePrefab, rightPlaceholder.transform.position + Vector3.left, 
                Quaternion.identity);
            hugeEnemyShip.GetComponent<HugeEnemy>().SetDirection(-1);
        }

        hugeEnemyShip.GetComponent<HugeEnemy>().speed += _hugeEnemySpeed;
        hugeEnemyShip.GetComponent<HugeEnemy>().SetIsVisible(true);
    }

    //Increase speed everytime anu enemy dies
    private void SpeedUp(string enemyType)
    {
        _xMove += speedIncrease;
        _hugeEnemySpeed += speedIncrease;
    }

    private void IncreaseEnemyBullets()
    {
        _numberOfEnemyBullets++;
    }
}
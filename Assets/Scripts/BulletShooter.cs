using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private Bullet _bullet;

    private float _nextTimeWaitShooting;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var waitForSecond = new WaitForSeconds(_nextTimeWaitShooting);
            var direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return waitForSecond;
        }
    }
}
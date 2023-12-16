using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacesPoint;

    private Transform[] _arrayPlaces;
    private int _placesIndex;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var pointByNumberInArray = _arrayPlaces[_placesIndex];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
        {
            Move();
        }
    }

    public Vector3 Move()
    {
        _placesIndex++;

        if (_placesIndex == _arrayPlaces.Length)
            _placesIndex = 0;

        var pointVector = _arrayPlaces[_placesIndex].transform.position;
        transform.forward = pointVector - transform.position;
        return pointVector;
    }
}

using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField]
    private float _distance = 10f;
    [SerializeField]
    private LayerMask _layerMask;

    private Transform _transform;

    public void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray.origin, ray.direction * _distance);
    }

    public T GetRaycast<T>() where T : MonoBehaviour
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
        {
            if (hit.transform.TryGetComponent(out T component))
            {
                Debug.Log(component.gameObject.name);
                return component;
            }
        }

        return default(T);
    }

    public bool TryGetRaycast<T>(out T component) where T : MonoBehaviour
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
        {
            if (hit.transform.TryGetComponent(out T get))
            {
                Debug.Log(get.gameObject.name);
                component = get;
                return true;
            }
        }

        component = null;
        return false;
    }

    private void Awake()
    {
        _transform = transform;
    }
}
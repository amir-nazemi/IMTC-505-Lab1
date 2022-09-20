using UnityEngine;

namespace IMTC505.starter.SampleGame
{
    [RequireComponent(typeof(Collider))]
    public class GamePoint : MonoBehaviour
    {
        public float y_rotation = 0.1f;
        public float delta = 0.1f;
        public float speed = 2.0f;
        private Vector3 startPos;

        [Tooltip("Points scored by touching this object.")]
        public float points = 10;
        
        [Tooltip("Event to trigger when controller interacts with point object.")]
        public System.Action<GamePoint> OnTriggerEnterAction;

        void Start()
        {
            // Make sure non of the colliders in child objects are active
            foreach (Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }

            // Make sure the root collider is a trigger and enabled
            Collider rootCollider = GetComponent<Collider>();
            rootCollider.enabled = true;
            rootCollider.isTrigger = true;

            startPos = transform.position;
        }

        void Update()
        {
            transform.Rotate(0, y_rotation * points, 0, Space.Self);

            Vector3 v = startPos;
            v.y += delta * Mathf.Abs(Mathf.Sin(Time.time * speed));
            transform.position = v;
        }

        void OnTriggerEnter(Collider collider)
        {
            OnTriggerEnterAction?.Invoke(this);
        }
    }
}

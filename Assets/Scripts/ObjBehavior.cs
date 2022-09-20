using UnityEngine;

namespace IMTC505.starter.SampleGame
{
    //[RequireComponent(typeof(Collider))]
    public class ObjBehavior : MonoBehaviour
    {
        public float X_rotation = 0f;
        public float Y_rotation = 0f;
        public float Z_rotation = 0f;
        public float deltaX = 0.1f;
        public float deltaY = 0f;
        public float deltaZ = 0.1f;
        public float speed = 2.0f;
        private Vector3 startPos;
        
        //[Tooltip("Event to trigger when controller interacts with point object.")]
        //public System.Action<ObjBehavior> OnTriggerEnterAction;

        void Start()
        {
            // Make sure non of the colliders in child objects are active
            /*foreach (Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }*/

            // Make sure the root collider is a trigger and enabled
            //Collider rootCollider = GetComponent<Collider>();
            //rootCollider.enabled = true;
            //rootCollider.isTrigger = true;

            startPos = transform.position;
        }

        void Update()
        {
            transform.Rotate(X_rotation, Y_rotation, Z_rotation, Space.Self);
            Vector3 v = startPos;
            v.x += deltaX * Mathf.Abs(Mathf.Sin(Time.time * speed));
            v.y += deltaY * Mathf.Abs(Mathf.Sin(Time.time * speed));
            v.z += deltaZ * Mathf.Abs(Mathf.Sin(Time.time * speed));
            transform.position = v;
        }

        /*void OnTriggerEnter(Collider collider)
        {
            OnTriggerEnterAction?.Invoke(this);
        }*/
    }
}

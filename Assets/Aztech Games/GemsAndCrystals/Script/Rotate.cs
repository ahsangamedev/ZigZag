using UnityEngine;

namespace AztechGames
{
    public class Rotate : MonoBehaviour
    {
        public float speed = 10f;
        public float floatSpeed = 2f;
        public float floatHeight = 0.2f;

        private Vector3 startPosition;

        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            // Rotate
            transform.Rotate(Vector3.up, speed * Time.deltaTime);

            // Move up and down
            float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

            transform.position = new Vector3(
                startPosition.x,
                newY,
                startPosition.z
            );
        }
    }
}
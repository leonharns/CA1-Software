using UnityEngine;
using UnityEngine.AI;
namespace Unity.FPS.Game
{
    public class EnemyAI : MonoBehaviour
    {

        public float damageGiven;

        public Transform player;
        public Transform[] patrolPoints;


        private NavMeshAgent agent;
        private int currentPatrolIndex;
        public bool chasingPlayer;

        public float detectionRange = 10f;
        public float loseSightRange = 15f;
        public float fieldOfViewAngle = 60f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            currentPatrolIndex = 0;
            chasingPlayer = false;

            PatrolToNextPoint();
        }

        void Update()
        {
            if (CanSeePlayer())
            {
                Debug.Log("ola");
                StartChase();
            }
            else if (chasingPlayer)
            {
                if (Vector3.Distance(transform.position, player.position) > loseSightRange)
                {
                    Debug.Log("se ya now");
                    StopChase();
                }
            }

            if (!chasingPlayer && !agent.pathPending && agent.remainingDistance < 0.5f)
            {
                PatrolToNextPoint();
            }
        }

        void PatrolToNextPoint()
        {
            if (patrolPoints.Length == 0)
                return;
            int i = Random.RandomRange(0, patrolPoints.Length);
            agent.destination = patrolPoints[currentPatrolIndex].position;
            currentPatrolIndex = (currentPatrolIndex + i) % patrolPoints.Length;
        }

        void StartChase()
        {
            chasingPlayer = true;
            agent.destination = player.position;
        }

        void StopChase()
        {
            chasingPlayer = false;
            PatrolToNextPoint();
        }

        bool CanSeePlayer()
        {
            Vector3 directionToPlayer = player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer > detectionRange)
            {
                return false;
            }

            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleToPlayer > fieldOfViewAngle / 2)
            {
                return false;
            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, detectionRange))
            {
                return true;
                Debug.Log(" 3");
                if (hit.transform == player)
                {
                    Debug.Log(" 4");
                    return true;
                }
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRange);

            Vector3 leftBoundary = Quaternion.Euler(0, -fieldOfViewAngle / 2, 0) * transform.forward;
            Vector3 rightBoundary = Quaternion.Euler(0, fieldOfViewAngle / 2, 0) * transform.forward;

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + leftBoundary * detectionRange);
            Gizmos.DrawLine(transform.position, transform.position + rightBoundary * detectionRange);

            if (player != null)
            {
                Gizmos.color = CanSeePlayer() ? Color.green : Color.red;
                Gizmos.DrawLine(transform.position, player.position);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
            {
                Debug.Log("Damahge");
                other.gameObject.GetComponent<Health>().TakeDamage(damageGiven, this.gameObject);
            }
        }
    }
}


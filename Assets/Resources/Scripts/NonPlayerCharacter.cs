using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class NonPlayerCharacter : MonoBehaviour
{
    [Tooltip("Объект зоны патрулирования")]
    [SerializeField] public Transform patrolZoneCenter;

    private NavMeshHit navMeshHit;
    private float randomPointRadius;
    private NavMeshPath navMeshPath; //Путь.
    private NavMeshAgent agent;
    private Vector2 randomPoin; //Случайная точка, созданная в заданном радиусе.


    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();
        randomPointRadius = patrolZoneCenter.GetComponent<CircleCollider2D>().radius;

        //При использовании NavMeshPlus с Tailmap, данные параметры необходимо отключать.
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        NavRandomPoint();
    }

    public virtual void Update()
    {
        if (agent.remainingDistance == 0)
        {
            NavRandomPoint();
        }
        Move();
    }

    public virtual void Move()
    {
        bool getCurrentPoint = false;

        while (!getCurrentPoint)
        {
            agent.CalculatePath(randomPoin, navMeshPath); //Высчитываем путь до точки
            if (navMeshPath.status == NavMeshPathStatus.PathComplete) //Если расстояние до точки существует...
                getCurrentPoint = true;
        }
        agent.SetDestination(randomPoin); //...следуем до неё
    }

    public void NavRandomPoint() //Получаем случайную точку, в заданном радиусе
    {
        NavMesh.SamplePosition(Random.insideUnitSphere * randomPointRadius + patrolZoneCenter.position, out navMeshHit, 5f, NavMesh.AllAreas);
        randomPoin = navMeshHit.position;
    }
}



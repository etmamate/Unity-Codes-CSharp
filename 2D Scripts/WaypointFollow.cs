using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) //pega a distancia dos dois waypoints e compara se a distancia for menor que 0
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) //pega o tamanho do array de waypoints volta a ser 0
            {
                currentWaypointIndex = 0;
            }
        }
        //Time.deltaTime calcula o intervalo do ultimo frame para o atual
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}

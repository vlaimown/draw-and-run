using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private List<Hero> heroList = new List<Hero>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Transform finish)
    {
        transform.position = Vector3.MoveTowards(transform.position, finish.position, speed * Time.deltaTime);
    }

    public int HeroAlivesCount() => heroList.Count;

    public void HeroDeath(Hero hero)
    {
        heroList.Remove(hero);
    }
}

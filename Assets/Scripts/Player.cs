using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private List<Hero> heroList = new List<Hero>();

    public void Move(Transform finish)
    {
        transform.position = Vector3.MoveTowards(transform.position, finish.position, speed * Time.deltaTime);
    }

    //public int HeroAlivesCount() => heroList.Count;

    public void HeroDeath(Hero hero)
    {
        heroList.Remove(hero);
    }

    public void ArmyIncrease(Hero hero)
    {
        heroList.Add(hero);
    }

    public int HeroListCount() => heroList.Count;
}

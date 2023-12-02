using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private List<Hero> heroList = new List<Hero>();
    private Transform moveTargetTransform;

    public void Move(Transform finish)
    {
        transform.position = Vector3.MoveTowards(transform.position, finish.position, speed * Time.deltaTime);
    }

    public void SetMoveTargets(Vector3 moveTarget)
    {
        foreach (Hero hero in heroList)
        {
            moveTargetTransform.position = moveTarget;
            hero.MoveTarget = moveTargetTransform;
        }
    }

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

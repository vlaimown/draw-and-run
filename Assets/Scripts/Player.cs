using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void SetMoveTargets(List<Vector3> moveTargets)
    {
        int count = 0;
        for (int i = 0; i < heroList.Count; i++)
        {
            if (count == moveTargets.Count)
                count = 0;
            heroList[i].MoveTarget = moveTargets[count];
            heroList[i].Tumbler = true;
            count++;
        }
        //foreach (Hero hero in heroList)
        //{
        //    moveTargetTransform.position = moveTargets;
        //    hero.MoveTarget = moveTargetTransform;
        //}
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

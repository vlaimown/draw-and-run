using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseArmyBonus : MonoBehaviour
{
    private Hero hero;
    [SerializeField] Material my_material;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            MeshRenderer my_renderer = GetComponent<MeshRenderer>();
            my_renderer.material = my_material;

            Player player = FindAnyObjectByType<Player>().GetComponent<Player>();
            player.ArmyIncrease(hero);
            gameObject.AddComponent<Hero>();
            gameObject.transform.SetParent(player.transform);
            IncreaseArmyBonus increaseArmyBonus = GetComponent<IncreaseArmyBonus>();
            Destroy(increaseArmyBonus);
        }
    }
}

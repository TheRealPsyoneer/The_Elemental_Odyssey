using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Attack/Attack Factory SO"), fileName = ("New Attack Factory"))]
public class AttackFactory : ScriptableObject
{
    [SerializeField] GameObject attackProduct;
    Stack<AttackBehaviour> productPool;
    [SerializeField] float poolCapacity;

    public void FactoryInitialization()
    {
        for (int i = 0; i < poolCapacity; i++)
        {
            AttackBehaviour instance = Instantiate(attackProduct).GetComponent<AttackBehaviour>();
            instance.pool = productPool;
            instance.gameObject.SetActive(false);
            productPool.Push(instance);
        }
    }

    public AttackBehaviour GetProduct(Vector2 spawnPosition)
    {
        AttackBehaviour instance;

        if (productPool.Count == 0)
        {
            instance = Instantiate(attackProduct).GetComponent<AttackBehaviour>();
            instance.pool = productPool;
        }
        else
        {
            instance = productPool.Pop();
            instance.gameObject.SetActive(true);
        }
        
        instance.transform.position = spawnPosition;
        return instance;
    }
}

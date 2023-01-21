using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    Rock,
    Paper,
    Scissors
}
public class Element : MonoBehaviour
{
    public ElementType elementType;
    public List<ElementType> weaknesses;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Element>(out Element element))
        {
            //If the collided object is weak against our type
            if (element.weaknesses.Contains(elementType))
            {
                Destroy(element.gameObject);
            }
            //If we collided with an element we're weak against
            if (weaknesses.Contains(element.elementType))
            {
                Destroy(this.gameObject);
            }
        }
    }
}

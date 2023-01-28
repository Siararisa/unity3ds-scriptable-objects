using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element",
    menuName = "RockPaperScissorsGame/Element")]
public class ElementType : ScriptableObject
{
    public List<ElementType> weaknesses;
    public Sprite icon;
}

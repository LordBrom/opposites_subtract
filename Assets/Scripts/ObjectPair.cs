using UnityEngine;

[CreateAssetMenu(fileName = "New Object Pair", menuName = "Custom/Object Pair")]
public class ObjectPair : ScriptableObject {

	public new string name;
	public Sprite sprite;
	public ObjectPair reactsWith;

}


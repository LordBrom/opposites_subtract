using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Pair", menuName = "Custom/Object Pair")]
public class ObjectPair : ScriptableObject {

	public new string name;
	public Sprite sprite;
	public ObjectPair[] reactsWith;
	public ObjectPair createdResult;

	public List<ObjectPair> reactsWithList() {
		return reactsWith.ToList();
	}

}


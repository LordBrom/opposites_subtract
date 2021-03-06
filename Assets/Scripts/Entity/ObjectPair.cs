using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Object", menuName = "Custom/Object")]
public class ObjectPair : ScriptableObject {
	public new string name;
	public Sprite sprite;
}

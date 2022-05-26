using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelObject {
	#region Variables


	public Type type;
	public Vector2 position;
	public int collisionGroupNum;
	public bool hasLevelEnd;

	public string name;

	[SerializeField]
	public Sprite sprite;

	[System.Serializable]
	public enum Type {
		Spawn,
		LevelEnd,
		Object,
		DeathTile,
		InverseSpawn,
		FakeWall,
		wall
	}

	#endregion

	public LevelObject(Type type, Vector2 position) {
		this.type = type;
		this.position = position;
		this.name = type.ToString();
		this.collisionGroupNum = 0;
	}
	public LevelObject(Type type, Vector2 position, ObjectPair objectPair, int collisionGroupNum) {
		this.type = type;
		this.position = position;
		this.collisionGroupNum = collisionGroupNum;
		this.name = objectPair.name;
		this.sprite = objectPair.sprite;
	}

}

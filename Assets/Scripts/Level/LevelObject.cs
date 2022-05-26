using UnityEngine;

[System.Serializable]
public class LevelObject {
	#region Variables


	public Type type;
	public Vector2 position;
	//public ObjectPair objectPair;
	public string collisionID;
	public bool hasLevelEnd;

	public string name;
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
	}
	public LevelObject(Type type, Vector2 position, ObjectPair objectPair, string collisionID) {
		this.type = type;
		this.position = position;
		//this.objectPair = objectPair;
		this.collisionID = collisionID;
		this.name = objectPair.name;
		this.sprite = objectPair.sprite;
	}
}

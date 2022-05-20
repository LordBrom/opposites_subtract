using UnityEngine;

public class Grid {

	#region Variables

	public int width { get; private set; }
	public int height { get; private set; }
	public float cellSize { get; private set; }
	public Vector3 originPosition { get; private set; }

	private GridTile[,] gridArray;

	#endregion

	public Grid(int width, int height, bool showDebug = false) {
		this.width = width;
		this.height = height;
		this.cellSize = 1;
		this.originPosition = new Vector3(0.5f, 0.5f, 0);

		this.gridArray = new GridTile[width, height];
		for (int x = 0; x < this.gridArray.GetLength(0); x++) {
			for (int y = 0; y < this.gridArray.GetLength(1); y++) {
				this.gridArray[x, y] = new GridTile(this, x, y);
			}
		}

		if (showDebug) {
			for (int x = 0; x < this.gridArray.GetLength(0); x++) {
				for (int y = 0; y < this.gridArray.GetLength(1); y++) {
					Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
					Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
				}
			}
			Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
			Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
		}
	}

	public bool OnGrid(int x, int y) {
		return x >= 0 && y >= 0 && x < this.width && y < this.height;
	}
	public bool OnGrid(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return OnGrid(x, y);
	}
	public bool OnGrid() {
		return OnGrid(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public GridTile GetGridTile(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return GetGridTile(x, y);
	}
	public GridTile GetGridTile(int x, int y) {
		if (OnGrid(x, y)) {
			return this.gridArray[x, y];
		}
		return default(GridTile);
	}
	public GridTile GetGridTile() {
		return GetGridTile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public Vector3 GetWorldPosition(int x, int y) {
		return new Vector3(x, y) * this.cellSize + this.originPosition;
	}
	public void GetXY(Vector3 worldPosition, out int x, out int y) {
		x = Mathf.FloorToInt((worldPosition - this.originPosition).x / this.cellSize);
		y = Mathf.FloorToInt((worldPosition - this.originPosition).y / this.cellSize);
	}
	public void GetXY(out int x, out int y) {
		GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y);
	}

	public Vector3 GetTileCenter(int x, int y) {
		if (OnGrid(x, y)) {
			return new Vector3(x, y) * this.cellSize + Vector3.one * (this.cellSize / 2);
		}
		return default(Vector3);
	}
	public Vector3 GetTileCenter(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return GetTileCenter(x, y);
	}
	public Vector3 GetTileCenter(Vector2 coords) {
		return GetTileCenter((int)coords.x, (int)coords.y);
	}
	public Vector3 GetTileCenter() {
		return GetTileCenter(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}

public class GridTile {

	private Grid grid;
	public int x;
	public int y;

	public GridTile(Grid grid, int x, int y) {
		this.grid = grid;
		this.x = x;
		this.y = y;
	}
	public override string ToString() {
		return x + " " + y;
	}
	public Vector2 GetXYVector() {
		return new Vector2(this.x, this.y);
	}

	public Vector2 GetTileCenter() {
		return grid.GetTileCenter(x, y);
	}
}


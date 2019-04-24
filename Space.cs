using System;

public class Space
{
    public Tile currentTile;
    bool empty;
    string type;
    public int owner;
	public Space(string type)
	{
        this.currentTile = null;
        this.empty = true;
        this.type = type;
        this.owner = 0;
	}

    public void setTile(Tile piece)
    {
        this.currentTile = piece;
        this.owner = piece.owner;
    }

    public bool isEmpty()
    {
        return this.empty;
    }

    public int pieceVal()
    {
        return (this.currentTile.mobility * this.owner);
    }

}

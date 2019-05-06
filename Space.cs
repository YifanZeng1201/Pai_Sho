/* Author: Andrew Crapitto
 * Updated: 5/04/2019
 */

using System;

public class Space
{
    public Tile currentTile;
    public string type;
    public int owner;
    bool empty;

    // Initializer for an empty space
    public Space(string type)
	{
        this.currentTile = null;
        this.empty = true;
        this.type = type;
        this.owner = 0;
	}

    // Initializer for a null (border) space
    public Space()
    {
        this.currentTile = null;
        this.empty = true;
        this.type = null;
        this.owner = 0;
    }

    // Set the tile that is on the space
    public void setTile(Tile piece)
    {
        this.currentTile = piece;
        this.owner = piece.owner;
    }

    // Check if the space is empty
    public bool isEmpty()
    {
        return this.empty;
    }

    // Returns the mobility value of the tile on the space
    public int pieceVal()
    {
        if (!isEmpty()) return (this.currentTile.mobility * this.owner);
        else return 0;
    }

    public Tile getTile()
    {
        return this.currentTile;
    }

    public bool isNull()
    {
        if (this.type == null) return true;
        else return false;
    }

}

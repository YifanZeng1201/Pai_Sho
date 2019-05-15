/* Author: Andrew Crapitto
 * Updated: 5/13/2019
 */

// Changelog: 5/13/2019: Added the paremeters i and j to keep track of coordinates, aded the emptyUp() method to be used when moving tiles

using System;

public class Space
{
    public Tile currentTile;
    public string type;
    public int owner;
    public int i, j;
    bool empty, harmony;

    // Initializer for an empty space
    public Space(string type, int i, int j)
    {
        this.currentTile = null;
        this.empty = true;
        this.type = type;
        this.owner = 0;
        this.i = i;
        this.j = j;
    }

    // Initializer for a null (border) space
    public Space(int i, int j)
    {
        this.currentTile = null;
        this.empty = true;
        this.type = null;
        this.owner = 0;
        this.i = i;
        this.j = j;
    }

    // Set the tile that is on the space
    public void setTile(Tile piece)
    {
        this.currentTile = piece;
        this.empty = false;
        this.owner = piece.owner;
        piece.i = this.i;
        piece.j = this.j;
    }

    // Check if the space is empty
    public bool isEmpty()
    {
        return this.empty;
    }

    // Returns the mobility value of the tile on the space
    public int pieceVal()
    {
        if (!isEmpty()) return this.currentTile.mobility * this.owner;
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

    public void emptyUp()
    {
        this.currentTile = null;
        this.empty = true;
        this.owner = 0;
    }

    public void setHarmony()
    {
        this.harmony = true;
    }

    public bool inHarmony()
    {
        if (this.harmony) return true;
        else return false;
    }

}

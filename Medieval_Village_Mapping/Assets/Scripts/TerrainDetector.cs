using UnityEngine;

public class TerrainDetector
{
    private TerrainData terrainData;
    private int alphamapWidth;
    private int alphamapHeight;
	//A 3D array of floats, where the 3rd dimension represents the mixing weight of each splatmap at each x,y coordinate.
    private float[,,] splatmapData;
    private int numTextures;

    public TerrainDetector()
    {
		//detect and get the dimensions of activeTerrain
        terrainData = Terrain.activeTerrain.terrainData;
        alphamapWidth = terrainData.alphamapWidth;
        alphamapHeight = terrainData.alphamapHeight;

		//The returned array is three-dimensional - the first two dimensions represent x and y coordinates on the map,
		//while the third denotes the splatmap texture to which the alphamap is applied
        splatmapData = terrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
		//caching tje number o textures
        numTextures = splatmapData.Length / (alphamapWidth * alphamapHeight);
    }

	//method that conert the splatmap values based of world map values
    private Vector3 ConvertToSplatMapCoordinate(Vector3 worldPosition)
    {
        Vector3 splatPosition = new Vector3();
        Terrain ter = Terrain.activeTerrain;
        Vector3 terPosition = ter.transform.position;
		
		//translate world coordinates to terrain coordinatess
        splatPosition.x = ((worldPosition.x - terPosition.x) / ter.terrainData.size.x) * ter.terrainData.alphamapWidth;
        splatPosition.z = ((worldPosition.z - terPosition.z) / ter.terrainData.size.z) * ter.terrainData.alphamapHeight;
        return splatPosition;
    }

    //int method wihch return the index of the specific position of the terrain
	public int GetActiveTerrainTextureIdx(Vector3 position)
    {
        Vector3 terrainCord = ConvertToSplatMapCoordinate(position);
        int activeTerrainIndex = 0;
        float largestOpacity = 0f;

        for (int i = 0; i < numTextures; i++)
        {
            if (largestOpacity < splatmapData[(int)terrainCord.z, (int)terrainCord.x, i])
            {
                activeTerrainIndex = i;
                largestOpacity = splatmapData[(int)terrainCord.z, (int)terrainCord.x, i];
            }
        }
		
		//return activeTerrainIndex
        return activeTerrainIndex;
    }

}
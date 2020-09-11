using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProcedural : MonoBehaviour {
    private VoxelMap map;
    public float seed;
    public bool useRandomSeed;

    [Range(0,100)]
    public float randomFillPercent;
    private void Awake() {
        map = GameObject.FindGameObjectWithTag("VoxelMap").GetComponent<VoxelMap>();
    }

    private void Start(){
        GenerateMap();
    }

    public void GenerateMap(){
        RandomFillMap();
    }

    public void RandomFillMap() {
        if(useRandomSeed){
            seed =  Random.Range(1,255);   
        }

        System.Random psuedoRandom = new System.Random(seed.GetHashCode());

        for(int x = 0; x < map.size; x++){
            for(int y = 0; y < map.size; y++){
                map.EditVoxelsGenerate(new Vector3(x ,y), psuedoRandom.Next(0, 100) < randomFillPercent);
            }
        }

        for(int x = 0; x < map.size; x++){
            for(int y = 0; y < map.size; y++){
                map.Refresh();
            }
        }
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)){
        }
    }
}

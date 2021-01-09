using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 
public class SpawnEnemy : MonoBehaviour { 
  public GameObject[] objects; 
  private Vector3 spawnPosition; 
  private Quaternion spawnRotation;
  private WaitForSeconds wfs; 
  private IEnumerator coroutineSpawn; 
  // Start is called before the first frame update 
  void Start() { 
    coroutineSpawn = Spawn(); 
    StartCoroutine(coroutineSpawn); 
  } 
  private IEnumerator Spawn(){ 
    while(true){ 
        wfs = new WaitForSeconds(Random.Range(3,6)); 
        spawnPosition.x = Random.Range (15, 24); 
        spawnPosition.y = 0f; 
        spawnPosition.z = Random.Range (67, 73); 
        spawnRotation.x = 0;
        spawnRotation.y = 195;
        spawnRotation.z = 0; 
        Instantiate(objects[Random.Range(0,objects.Length-1)],spawnPosition,spawnRotation); 
        yield return wfs; 
    } 
  } 

  public void stopSpawn(){
        StopCoroutine(coroutineSpawn);
        var clones = GameObject.FindGameObjectsWithTag ("clone");
        foreach (var clone in clones){
            Destroy(clone);
        }
  }

  // Update is called once per frame 
  void Update() { 
  
  } 
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour
{    private GameObject[] carList;
private int currentCar=0;


    //use this for intialization
    void Start()
    { //count the child gameobj from the car transform
        carList=new GameObject[transform.childCount];

        //loop through the child item and fill the list in the corrct slot
        for (int i = 0; i < transform.childCount; ++i)
        {
            carList [i]=transform.GetChild (i).gameObject;

        }
        //deactivate all the gameobject in the list
        foreach (GameObject gameObj in carList){
            gameObj.SetActive (false);
        }
        //set the initial object deactive
        if (carList [0])
        {
            carList [0].SetActive (true);
        }
        
    }

public void toggleCars(string direction)
{
carList [currentCar].SetActive (false);

if(direction =="Right")
{
    currentCar++;
        if(currentCar > carList.Length - 1){
        currentCar = 0;
        }

}
else if(direction == "Left")
{
    currentCar--;
    if(currentCar < 0){
        currentCar = carList.Length - 1;
    }
}
carList[currentCar].SetActive(true);
gameController.currentSelectCar=carList[currentCar].name;
GameObject cloudSystem = Instantiate (Resources.Load ("cloudParticle")) as GameObject;
ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
cloudPuff.Play ();
cloudPuff.transform.position = new Vector3(22f,-1.5f,0f);
Destroy (cloudSystem ,2f);


}


}

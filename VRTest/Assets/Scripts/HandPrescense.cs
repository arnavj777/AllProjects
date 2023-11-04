using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPrescense : MonoBehaviour
{

    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;
    public InputDeviceCharacteristics controllerCharacteristics;

    public InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    
    public bool showController = false;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject Prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(Prefab)
            {
                spawnedController = Instantiate(Prefab, transform);
            }
            else
            {
                Debug.Log("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        spawnedHandModel.SetActive(true);


    }
}

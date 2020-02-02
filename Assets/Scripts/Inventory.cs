using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    public string CurrentlySelectedName;
    public GameObject CurrentlySelected;

    public GameObject VoiceChip;
    public GameObject USBDrive;
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject OpticalSensorArray;
    public GameObject PowerCell;


    /**********************************
     * TOGGLE
     **********************************/
    public void Toggle(string slotName, string Name)
    {
        GameObject slot = this.transform.Find(slotName).gameObject;
        GameObject button = this.transform.Find(slotName + "/" + Name).gameObject;
        Image slotImage = slot.GetComponent<Image>();
        Image buttonImage = button.GetComponent<Image>();
        if(Name == this.CurrentlySelectedName)
        {
            this.CurrentlySelectedName = "";
            this.CurrentlySelected = null;
            slotImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            buttonImage.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        } else {
            this.CurrentlySelectedName = Name;
            this.CurrentlySelected = null;
            slotImage.color = new Color(1.0f, 0.9f, 0.16f, 1.0f);
            buttonImage.color = new Color(1.0f, 0.9f, 0.16f, 1.0f);
        }
    }
    public void ToggleVoiceChip()
    {
        Toggle("Slot1", "VoiceChip");
    }
    public void TogglePowerCell()
    {
        Toggle("Slot2", "PowerCell");
    }
    public void ToggleUSBDrive()
    {
        Toggle("Slot3", "USBDrive");
    }
    public void ToggleArm1()
    {
        Toggle("Slot4", "Arm1");
    }
    public void ToggleArm2()
    {
        Toggle("Slot5", "Arm2");
    }
    public void ToggleOpticalSensorArray()
    {
        Toggle("Slot6", "OpticalSensorArray");
    }


    /**********************************
     * PICKUP
     **********************************/
    public void Pickup(string pathToButton)
    {
        GameObject vc = this.transform.Find(pathToButton).gameObject;
        vc.SetActive(true);
        Image vcImage = vc.GetComponent<Image>();
        vcImage.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
    }
    public void PickupVoiceChip()
    {
        Pickup("Slot1/VoiceChip");
    }
    public void PickupPowerCell()
    {
        Pickup("Slot2/PowerCell");
    }
    public void PickupUSBDrive()
    {
        Pickup("Slot3/USBDrive");
    }
    public void PickupArm1()
    {
        Pickup("Slot4/Arm1");
    }
    public void PickupArm2()
    {
        Pickup("Slot5/Arm2");
    }
    public void PickupOpticalSensorArray()
    {
        Pickup("Slot6/OpticalSensorArray");
    }
    
    /**********************************
     * SELECT
     **********************************/
    public void SelectVoiceChip()
    {
        this.CurrentlySelectedName = "VoiceChip";
        this.CurrentlySelected = VoiceChip;
    }
    public void SelectUSBDrive()
    {
        this.CurrentlySelectedName = "USBDrive";
        this.CurrentlySelected = USBDrive;
    }
    public void SelectArm1()
    {
        this.CurrentlySelectedName = "Arm1";
        this.CurrentlySelected = Arm1;
    }
    public void SelectArm2()
    {
        this.CurrentlySelectedName = "Arm2";
        this.CurrentlySelected = Arm2;
    }
    public void SelectOpticalSensorArray()
    {
        this.CurrentlySelectedName = "OpticalSensorArray";
        this.CurrentlySelected = OpticalSensorArray;
    }
    public void SelectPowerCell()
    {
        this.CurrentlySelectedName = "PowerCell";
        this.CurrentlySelected = PowerCell;
    }
    public string GetCurrentlySelectedName()
    {
        return this.CurrentlySelectedName;
    }

    public GameObject GetCurrentlySelected()
    {
        return this.CurrentlySelected;
    }
}

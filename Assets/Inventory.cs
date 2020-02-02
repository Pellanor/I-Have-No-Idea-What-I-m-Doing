using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject CurrentlySelected;

    public GameObject VoiceChip;
    public GameObject USBDrive;
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject OpticalSensorArray;
    public GameObject PowerCell;

    public void SelectVoiceChip()
    {
        this.CurrentlySelected = VoiceChip;
    }
    public void SelectUSBDrive()
    {
        this.CurrentlySelected = USBDrive;
    }
    public void SelectArm1()
    {
        this.CurrentlySelected = Arm1;
    }
    public void SelectArm2()
    {
        this.CurrentlySelected = Arm2;
    }
    public void SelectOpticalSensorArray()
    {
        this.CurrentlySelected = OpticalSensorArray;
    }
    public void SelectPowerCell()
    {
        this.CurrentlySelected = PowerCell;
    }

    public GameObject GetCurrentlySelected()
    {
        return this.CurrentlySelected;
    }
}

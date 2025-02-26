using UnityEngine;

public class ArduinoDataSender : MonoBehaviour
{
    [SerializeField] SerialDataSender m_serialSender;
    [SerializeField] string scenario1Trigger;
    [SerializeField] string scenario2Trigger;
    [SerializeField] string scenario3Trigger;

    private void Start()
    {
        scenario1Trigger = ConfigManager.GetInstance().GetStringValue("SCENARIO_1_TRIGGER");
        scenario2Trigger = ConfigManager.GetInstance().GetStringValue("SCENARIO_2_TRIGGER");
        //scenario3Trigger = ConfigManager.GetInstance().GetStringValue("SCENARIO_3_TRIGGER");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            Debug.Log(scenario1Trigger);
            SendData(scenario1Trigger);
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            Debug.Log(scenario2Trigger);
            SendData(scenario2Trigger);
        }
    }

    public void SendData(string p_message)
    {
        m_serialSender.SendData(p_message);
    }

    //public void SetLightMood(RoomMood p_roomMood)
    //{
    //    switch (p_roomMood)
    //    {
    //        case RoomMood.CALM:
    //            m_serialSender.SendData(scenario1Trigger);
    //            break;
    //        case RoomMood.ENERGY:
    //            m_serialSender.SendData(scenario2Trigger);
    //            break;
    //        case RoomMood.FOCUS:
    //            m_serialSender.SendData(scenario3Trigger);
    //            break;
    //        default:
    //            m_serialSender.SendData(scenario1Trigger);
    //            break;
    //    }

    //}
}

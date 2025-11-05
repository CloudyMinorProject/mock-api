using MockApi.Models;

namespace MockApi.Services {
  public class DataService {
    public List<Machine> Machines { get; set; } = new();

    public DataService()
    {
      SeedData();
    }

    private void SeedData()
    {
      // Add machine
      Machines.AddRange(new List<Machine>
      {
        new Machine
        {
          MachineID = 1,
          MachineName = "MP-001",
          AccespointID = 101,
          DeviceSerialNr = 23456789,
          ZigbeeSerialNrHigh = 44556,
          ZigbeeSerialNrLow = 77889,
          DestinationPort = 8080,
          BoardType = 2,
          SoftwareVersion = 215,
          SettingsDatabaseSecs = 3600,
          SettingsMachineSecs = 7200,
          SettingRecievedSecs = 1634567890,
          SettingsWriteGroup = 1,
          StateAPMS = 1,
          StateChangedSecs = 1634567895,
          LastRecievedSecs = 1634567895,
          Active = 1,
          ArchivedUp = 0
        },
        new Machine
        {
          MachineID = 2,
          MachineName = "MP-002",
          AccespointID = 102,
          DeviceSerialNr = 23456790,
          ZigbeeSerialNrHigh = 44557,
          ZigbeeSerialNrLow = 77890,
          DestinationPort = 8080,
          BoardType = 2,
          SoftwareVersion = 218,
          SettingsDatabaseSecs = 3600,
          SettingsMachineSecs = 7200,
          SettingRecievedSecs = 1634567880,
          SettingsWriteGroup = 1,
          StateAPMS = 2,
          StateChangedSecs = 1634567885,
          LastRecievedSecs = 1634567885,
          Active = 1,
          ArchivedUp = 0
        },
        new Machine
        {
          MachineID = 3,
          MachineName = "MP-003",
          AccespointID = 103,
          DeviceSerialNr = 23456791,
          ZigbeeSerialNrHigh = 44558,
          ZigbeeSerialNrLow = 77891,
          DestinationPort = 8080,
          BoardType = 2,
          SoftwareVersion = 215,
          SettingsDatabaseSecs = 3600,
          SettingsMachineSecs = 7200,
          SettingRecievedSecs = 1634567870,
          SettingsWriteGroup = 1,
          StateAPMS = 3,
          StateChangedSecs = 1634567875,
          LastRecievedSecs = 1634567875,
          Active = 1,
          ArchivedUp = 0
        },
      });
    }
  }
}
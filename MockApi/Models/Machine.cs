using System.Diagnostics.Contracts;

namespace MockApi.Models
{
    public class Machine
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public int AccespointID { get; set; }
        public int DeviceSerialNr { get; set; }
        public int ZigbeeSerialNrHigh { get; set; }
        public int ZigbeeSerialNrLow { get; set; }
        public int DestinationPort { get; set; }
        public int BoardType { get; set; }
        public int SoftwareVersion { get; set; }
        public int SettingsDatabaseSecs { get; set; }
        public int SettingsMachineSecs { get; set; }
        public int SettingRecievedSecs { get; set; }
        public int SettingsWriteGroup { get; set; }
        public int StateAPMS { get; set; }
        public int StateChangedSecs { get; set; }
        public int LastRecievedSecs { get; set; }
        public int Active { get; set; }
        public int ArchivedUp { get; set; }  

    }
}
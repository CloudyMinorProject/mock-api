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
        
    }
}
using MockApi.Models;

namespace MockApi.Services
{
  public class MachineService
  {
    private readonly List<Machine> _machines;
    private int _nextId = 1;

    public MachineService() {
      _machines = new List<Machine>();
      SeedData();
    }

    // Initial Machine init
    private void SeedData() {
      CreateMachine(new Machine {
        MachineName = "Test-001",
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
      });
    }

    // GET ALL
    public IEnumerable<Machine> GetAllMachines() {
      return _machines;
    }

    // GET BY ID
    public Machine? GetMachineById(int id) {
      return _machines.FirstOrDefault(m => m.MachineID == id);
    }

// GET ACTIVE
    public IEnumerable<Machine> GetActiveMachines() {
      return _machines.Where(m => m.Active == 1);
    }

    // GET BY ACCESSPOINT
    public IEnumerable<Machine> GetMachinesByAccessPoint(int accessPointId) {
      return _machines.Where(m => m.AccespointID == accessPointId);
    }

    // CREATE
    public Machine CreateMachine(Machine machine) {
      _machines.Add(machine);
      machine.MachineID = _nextId++;
      return machine;
    }

    // UPDATE
    public Machine? UpdateMachine(int id, Machine machine) {
      var existingMachine = _machines.FirstOrDefault(m => m.MachineID == id);
      if (existingMachine == null)
        return null;

      existingMachine = UpdateProperties(machine, existingMachine);

      return existingMachine;
    }

    // DELETE
    public bool DeleteMachine(int id) {
      var machine = _machines.FirstOrDefault(m => m.MachineID == id);
      if (machine == null)
        return false;

      _machines.Remove(machine);
      return true;
    }
    
  // ~~~~~~~~~~~~~~~~ Private Methods ~~~~~~~~~~~~~~~~~~~~ 
    // Update properties
    private Machine UpdateProperties(Machine machine, Machine existingMachine) {
      existingMachine.MachineName = machine.MachineName;
      existingMachine.AccespointID = machine.AccespointID;
      existingMachine.DeviceSerialNr = machine.DeviceSerialNr;
      existingMachine.ZigbeeSerialNrHigh = machine.ZigbeeSerialNrHigh;
      existingMachine.ZigbeeSerialNrLow = machine.ZigbeeSerialNrLow;
      existingMachine.DestinationPort = machine.DestinationPort;
      existingMachine.BoardType = machine.BoardType;
      existingMachine.SoftwareVersion = machine.SoftwareVersion;
      existingMachine.SettingsDatabaseSecs = machine.SettingsDatabaseSecs;
      existingMachine.SettingsMachineSecs = machine.SettingsMachineSecs;
      existingMachine.SettingRecievedSecs = machine.SettingRecievedSecs;
      existingMachine.SettingsWriteGroup = machine.SettingsWriteGroup;
      existingMachine.StateAPMS = machine.StateAPMS;
      existingMachine.StateChangedSecs = machine.StateChangedSecs;
      existingMachine.LastRecievedSecs = machine.LastRecievedSecs;
      existingMachine.Active = machine.Active;
      existingMachine.ArchivedUp = machine.ArchivedUp;

      return existingMachine;
    }
  }
}
namespace MotMaintOnline4.ViewModels.Maintenance
{
    public class MaintenanceViewModel
    {
        public int Id { get; set; }

        public int MaintenanceTypeId { get; set; }

        public string MaintenanceType { get; set; }

        public decimal Price { get; set; }

        public string DateDone { get; set; }

        public int MotorcycleId { get; set; }

        public string Description { get; set; }

        public int KilometersOnChange { get; set; }
    }
}

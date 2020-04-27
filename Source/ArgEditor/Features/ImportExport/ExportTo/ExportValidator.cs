using System.Linq;
using ArgEditor.Features.Main;

namespace ArgEditor.Features.ImportExport.ExportTo
{
    public static class ExportValidator
    {
        public static CanExportToExeStatus CanExportToExe(MainViewModel viewModel)
        {
            var groupBys = viewModel.Drivers
                .Where(d => d.Enabled)
                .GroupBy(d => d.Number)
                .Where(grp => grp.Count() > 1 && grp.Key > 0);
            var groupedNumbers = groupBys.ToList();

            if (groupedNumbers.Count > 0)
            {
                return CanExportToExeStatus.SharedDriverNumbers;
            }

            var activeCount = viewModel.Drivers.Count(d => d.Enabled);

            if (activeCount < 26)
            {
                return CanExportToExeStatus.TooFewActiveDrivers;
            }

            return CanExportToExeStatus.OK;
        }

        public static string GetMessageForStatus(CanExportToExeStatus status)
        {
            switch (status)
            {
                case CanExportToExeStatus.OK:
                    return string.Empty;
                case CanExportToExeStatus.SharedDriverNumbers:
                    return "Cannot export! Each driver must have a unique number.";
                case CanExportToExeStatus.TooFewActiveDrivers:
                    return "Cannot export! There must be at least 26 active drivers.";
            }

            return string.Empty;
        }
    }

    public enum CanExportToExeStatus
    {
        OK,
        SharedDriverNumbers,
        TooFewActiveDrivers,
    }
}

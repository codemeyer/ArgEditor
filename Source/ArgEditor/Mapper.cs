using ArgEditor.Interactors;
using ArgEditor.ViewModels;

namespace ArgEditor
{
    public static class Mapper
    {
        public static CarSetTeam MapCarSetTeam(TeamViewModel team)
        {
            return new CarSetTeam
            {
                Engine = team.Engine,
                Horsepower = team.Horsepower,
                Name = team.Name
            };
        }

        public static CarSetCarColors MapCarSetCarColors(CarEditingViewModel car)
        {
            return new CarSetCarColors
            {
                CockpitFrontColorIndex = car.CockpitFrontColorIndex,
                CockpitSideColorIndex = car.CockpitSideColorIndex,
                EngineCoverColorIndex = car.EngineCoverColorIndex,
                EngineCoverRearColorIndex = car.EngineCoverRearColorIndex,
                EngineCoverSideColorIndex = car.EngineCoverSideColorIndex,
                FrontAndRearWingColorIndex = car.FrontAndRearWingColorIndex,
                FrontWingEndplateColorIndex = car.FrontWingEndplateColorIndex,
                NoseAngleColorIndex = car.NoseAngleColorIndex,
                NoseSideColorIndex = car.NoseSideColorIndex,
                NoseTopColorIndex = car.NoseTopColorIndex,
                RearWingSideColorIndex = car.RearWingSideColorIndex,
                SidepodColorIndex = car.SidepodColorIndex,
                SidepodTopColorIndex = car.SidepodTopColorIndex
            };
        }

        public static CarSetPitCrewColors MapCarSetPitCrewColors(PitCrewViewModel pitCrew)
        {
            return new CarSetPitCrewColors
            {
                PantsPrimaryColorIndex = pitCrew.PantsPrimaryColorIndex,
                PantsSecondaryColorIndex = pitCrew.PantsSecondaryColorIndex,
                ShirtPrimaryColorIndex = pitCrew.ShirtPrimaryColorIndex,
                ShirtSecondaryColorIndex = pitCrew.ShirtSecondaryColorIndex,
                SocksColorIndex = pitCrew.SocksColorIndex
            };
        }

        public static CarSetDriver MapCarSetDriver(DriverViewModel driver)
        {
            return new CarSetDriver
            {
                Name = driver.Name,
                Number = driver.Number,
                QualifyingGripLevel = driver.QualifyingGripLevel,
                RaceGripLevel = driver.RaceGripLevel
            };
        }

        public static void MapCarSetTeamToTeamViewModel(CarSetTeam fileTeam, TeamViewModel team)
        {
            team.Name = fileTeam.Name;
            team.Engine = fileTeam.Engine;
            team.Horsepower = fileTeam.Horsepower;
        }

        public static void MapCarSetCarColorsToCarEditingViewModel(CarSetCarColors carColors, CarEditingViewModel car)
        {
            car.CockpitFrontColorIndex = carColors.CockpitFrontColorIndex;
            car.CockpitSideColorIndex = carColors.CockpitSideColorIndex;
            car.EngineCoverColorIndex = carColors.EngineCoverColorIndex;
            car.EngineCoverRearColorIndex = carColors.EngineCoverRearColorIndex;
            car.EngineCoverSideColorIndex = carColors.EngineCoverSideColorIndex;
            car.FrontAndRearWingColorIndex = carColors.FrontAndRearWingColorIndex;
            car.FrontWingEndplateColorIndex = carColors.FrontWingEndplateColorIndex;
            car.NoseAngleColorIndex = carColors.NoseAngleColorIndex;
            car.NoseSideColorIndex = carColors.NoseSideColorIndex;
            car.NoseTopColorIndex = carColors.NoseTopColorIndex;
            car.RearWingSideColorIndex = carColors.RearWingSideColorIndex;
            car.SidepodColorIndex = carColors.SidepodColorIndex;
            car.SidepodTopColorIndex = carColors.SidepodTopColorIndex;
        }

        public static void MapCarSetPitCrewColorsToPitCrewViewModel(CarSetPitCrewColors pitCrewColors, PitCrewViewModel pitCrew)
        {
            pitCrew.ShirtPrimaryColorIndex = pitCrewColors.ShirtPrimaryColorIndex;
            pitCrew.ShirtSecondaryColorIndex = pitCrewColors.ShirtSecondaryColorIndex;
            pitCrew.PantsPrimaryColorIndex = pitCrewColors.PantsPrimaryColorIndex;
            pitCrew.PantsSecondaryColorIndex = pitCrewColors.PantsSecondaryColorIndex;
            pitCrew.SocksColorIndex = pitCrewColors.SocksColorIndex;
        }

        public static void MapCarSetDriverToDriverViewModel(CarSetDriver fileDriver, DriverViewModel driver)
        {
            driver.Name = fileDriver.Name;
            driver.Number = fileDriver.Number;
            driver.QualifyingGripLevel = fileDriver.QualifyingGripLevel;
            driver.RaceGripLevel = fileDriver.RaceGripLevel;
        }

        // TODO: helmets

        public static void MapCarEditingViewModel(CarEditingViewModel source, CarEditingViewModel target)
        {
            target.CockpitFrontColorIndex = source.CockpitFrontColorIndex;
            target.CockpitSideColorIndex = source.CockpitSideColorIndex;
            target.EngineCoverColorIndex = source.EngineCoverColorIndex;
            target.EngineCoverRearColorIndex = source.EngineCoverRearColorIndex;
            target.EngineCoverSideColorIndex = source.EngineCoverSideColorIndex;
            target.FrontAndRearWingColorIndex = source.FrontAndRearWingColorIndex;
            target.FrontWingEndplateColorIndex = source.FrontWingEndplateColorIndex;
            target.NoseAngleColorIndex = source.NoseAngleColorIndex;
            target.NoseSideColorIndex = source.NoseSideColorIndex;
            target.NoseTopColorIndex = source.NoseTopColorIndex;
            target.RearWingSideColorIndex = source.RearWingSideColorIndex;
            target.SidepodColorIndex = source.SidepodColorIndex;
            target.SidepodTopColorIndex = source.SidepodTopColorIndex;
        }
    }
}

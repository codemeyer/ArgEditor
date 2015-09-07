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
                CockpitFront = car.CockpitFrontColorIndex,
                CockpitSide = car.CockpitSideColorIndex,
                EngineCover = car.EngineCoverColorIndex,
                EngineCoverRear = car.EngineCoverRearColorIndex,
                EngineCoverSide = car.EngineCoverSideColorIndex,
                FrontAndRearWing = car.FrontAndRearWingColorIndex,
                FrontWingEndplate = car.FrontWingEndplateColorIndex,
                NoseAngle = car.NoseAngleColorIndex,
                NoseSide = car.NoseSideColorIndex,
                NoseTop = car.NoseTopColorIndex,
                RearWingSide = car.RearWingSideColorIndex,
                Sidepod = car.SidepodColorIndex,
                SidepodTop = car.SidepodTopColorIndex
            };
        }

        public static CarSetPitCrewColors MapCarSetPitCrewColors(PitCrewViewModel pitCrew)
        {
            return new CarSetPitCrewColors
            {
                PantsPrimary = pitCrew.PantsPrimaryColorIndex,
                PantsSecondary = pitCrew.PantsSecondaryColorIndex,
                ShirtPrimary = pitCrew.ShirtPrimaryColorIndex,
                ShirtSecondary = pitCrew.ShirtSecondaryColorIndex,
                Socks = pitCrew.SocksColorIndex
            };
        }

        public static CarSetDriver MapCarSetDriver(DriverViewModel driver)
        {
            return new CarSetDriver
            {
                Name = driver.Name,
                Number = driver.Number,
                QualifyingGripLevel = driver.QualifyingGripLevel,
                RaceGripLevel = driver.RaceGripLevel,
            };
        }

        public static CarSetHelmetColors MapCarSetHelmetColors(HelmetViewModel helmet)
        {
            return new CarSetHelmetColors
            {
                Stripe1 = helmet.Stripe1ColorIndex,
                Stripe2 = helmet.Stripe2ColorIndex,
                Stripe3 = helmet.Stripe3ColorIndex,
                Stripe4 = helmet.Stripe4ColorIndex,
                Stripe5 = helmet.Stripe5ColorIndex,
                Stripe6 = helmet.Stripe6ColorIndex,
                Stripe7 = helmet.Stripe7ColorIndex,
                Stripe8 = helmet.Stripe8ColorIndex,
                Stripe9 = helmet.Stripe9ColorIndex,
                Stripe10 = helmet.Stripe10ColorIndex,
                Stripe11 = helmet.Stripe11ColorIndex,
                Stripe12 = helmet.Stripe12ColorIndex,
                Stripe13 = helmet.Stripe13ColorIndex,
                Visor = helmet.VisorColorIndex,
                VisorSurround = helmet.VisorSurroundColorIndex
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
            car.CockpitFrontColorIndex = carColors.CockpitFront;
            car.CockpitSideColorIndex = carColors.CockpitSide;
            car.EngineCoverColorIndex = carColors.EngineCover;
            car.EngineCoverRearColorIndex = carColors.EngineCoverRear;
            car.EngineCoverSideColorIndex = carColors.EngineCoverSide;
            car.FrontAndRearWingColorIndex = carColors.FrontAndRearWing;
            car.FrontWingEndplateColorIndex = carColors.FrontWingEndplate;
            car.NoseAngleColorIndex = carColors.NoseAngle;
            car.NoseSideColorIndex = carColors.NoseSide;
            car.NoseTopColorIndex = carColors.NoseTop;
            car.RearWingSideColorIndex = carColors.RearWingSide;
            car.SidepodColorIndex = carColors.Sidepod;
            car.SidepodTopColorIndex = carColors.SidepodTop;
        }

        public static void MapCarSetPitCrewColorsToPitCrewViewModel(CarSetPitCrewColors pitCrewColors, PitCrewViewModel pitCrew)
        {
            pitCrew.ShirtPrimaryColorIndex = pitCrewColors.ShirtPrimary;
            pitCrew.ShirtSecondaryColorIndex = pitCrewColors.ShirtSecondary;
            pitCrew.PantsPrimaryColorIndex = pitCrewColors.PantsPrimary;
            pitCrew.PantsSecondaryColorIndex = pitCrewColors.PantsSecondary;
            pitCrew.SocksColorIndex = pitCrewColors.Socks;
        }

        public static void MapCarSetDriverToDriverViewModel(CarSetDriver fileDriver, DriverViewModel driver)
        {
            driver.Name = fileDriver.Name;
            driver.Number = fileDriver.Number;
            driver.QualifyingGripLevel = fileDriver.QualifyingGripLevel;
            driver.RaceGripLevel = fileDriver.RaceGripLevel;
        }

        public static void MapCarSetHelmetToHelmetViewModel(CarSetHelmetColors fileHelmet, HelmetViewModel helmet)
        {
            helmet.Stripe1ColorIndex = fileHelmet.Stripe1;
            helmet.Stripe2ColorIndex = fileHelmet.Stripe2;
            helmet.Stripe3ColorIndex = fileHelmet.Stripe3;
            helmet.Stripe4ColorIndex = fileHelmet.Stripe4;
            helmet.Stripe5ColorIndex = fileHelmet.Stripe5;
            helmet.Stripe6ColorIndex = fileHelmet.Stripe6;
            helmet.Stripe7ColorIndex = fileHelmet.Stripe7;
            helmet.Stripe8ColorIndex = fileHelmet.Stripe8;
            helmet.Stripe9ColorIndex = fileHelmet.Stripe9;
            helmet.Stripe10ColorIndex = fileHelmet.Stripe10;
            helmet.Stripe11ColorIndex = fileHelmet.Stripe11;
            helmet.Stripe12ColorIndex = fileHelmet.Stripe12;
            helmet.Stripe13ColorIndex = fileHelmet.Stripe13;
            helmet.VisorColorIndex = fileHelmet.Visor;
            helmet.VisorSurroundColorIndex = fileHelmet.VisorSurround;
        }

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

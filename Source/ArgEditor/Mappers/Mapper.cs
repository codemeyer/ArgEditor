using System;
using System.Linq;
using ArgData.Entities;
using ArgEditor.Features.CarSet;
using ArgEditor.Features.CarSet.CarColors;
using ArgEditor.Features.CarSet.HelmetColors;
using ArgEditor.Features.CarSet.MenuImages;
using ArgEditor.Features.CarSet.PitCrew;
using ArgEditor.Features.CarSet.PointsSystem;
using ArgEditor.Features.CarSetupEditing;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence.Common.CarSets;
using ArgEditor.Features.Persistence.Common.LegacyCarSets;
using CarSetDriver = ArgEditor.Features.Persistence.Common.CarSets.CarSetDriver;
using CarSetTeam = ArgEditor.Features.Persistence.Common.CarSets.CarSetTeam;

namespace ArgEditor.Mappers
{
    public static class Mapper
    {
        // TODO: split into more classes?
        // TODO: cleanup, standardize naming?
        // TODO: which create new objects, and which work on existing ones?

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

        /// <summary>
        /// "Map" menu image to a Base64 encoded string.
        /// </summary>
        /// <param name="menuImage"></param>
        /// <returns></returns>
        public static string MapMenuImage(MenuImageViewModel menuImage)
        {
            if (menuImage.IsDefault() || menuImage.PixelData == null)
            {
                return string.Empty;
            }

            return Convert.ToBase64String(menuImage.PixelData);
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
            if (fileHelmet == null) { return; }

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

        // call it something with Copy instead?
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





        public static void MapDataCarToViewModelCar(Car car, CarEditingViewModel viewModelCar)
        {
            viewModelCar.CockpitFrontColorIndex = car.CockpitFront;
            viewModelCar.CockpitSideColorIndex = car.CockpitSide;
            viewModelCar.EngineCoverRearColorIndex = car.EngineCoverRear;
            viewModelCar.EngineCoverColorIndex = car.EngineCover;
            viewModelCar.EngineCoverSideColorIndex = car.EngineCoverSide;
            viewModelCar.FrontAndRearWingColorIndex = car.FrontAndRearWing;
            viewModelCar.FrontWingEndplateColorIndex = car.FrontWingEndplate;
            viewModelCar.NoseAngleColorIndex = car.NoseAngle;
            viewModelCar.NoseSideColorIndex = car.NoseSide;
            viewModelCar.NoseTopColorIndex = car.NoseTop;
            viewModelCar.RearWingSideColorIndex = car.RearWingSide;
            viewModelCar.SidepodColorIndex = car.Sidepod;
            viewModelCar.SidepodTopColorIndex = car.SidepodTop;
        }

        public static void MapDataPitCrewToViewModelPitCrew(PitCrew pitCrew, PitCrewViewModel viewModel)
        {
            viewModel.ShirtPrimaryColorIndex = pitCrew.ShirtPrimary;
            viewModel.ShirtSecondaryColorIndex = pitCrew.ShirtSecondary;
            viewModel.PantsPrimaryColorIndex = pitCrew.PantsPrimary;
            viewModel.PantsSecondaryColorIndex = pitCrew.PantsSecondary;
            viewModel.SocksColorIndex = pitCrew.Socks;
        }

        public static void MapLegacyDriverToViewModelDriver(LegacyDriver driver, DriverViewModel viewModelDriver)
        {
            viewModelDriver.Number = (byte)driver.Number;
            viewModelDriver.Name = driver.Name;
            viewModelDriver.QualifyingGripLevel = (byte)driver.QualifyingPerformance;
            viewModelDriver.RaceGripLevel = (byte)driver.RacePerformance;
        }

        public static void MapDataHelmetToViewModelHelmet(Helmet helmet, HelmetViewModel viewModelHelmet)
        {
            viewModelHelmet.Stripe1ColorIndex = helmet.Stripes[0];
            viewModelHelmet.Stripe2ColorIndex = helmet.Stripes[1];
            viewModelHelmet.Stripe3ColorIndex = helmet.Stripes[2];
            viewModelHelmet.Stripe4ColorIndex = helmet.Stripes[3];
            viewModelHelmet.Stripe5ColorIndex = helmet.Stripes[4];
            viewModelHelmet.Stripe6ColorIndex = helmet.Stripes[5];
            viewModelHelmet.Stripe7ColorIndex = helmet.Stripes[6];
            viewModelHelmet.Stripe8ColorIndex = helmet.Stripes[7];
            viewModelHelmet.Stripe9ColorIndex = helmet.Stripes[8];
            viewModelHelmet.Stripe10ColorIndex = helmet.Stripes[9];
            viewModelHelmet.Stripe11ColorIndex = helmet.Stripes[10];
            viewModelHelmet.Stripe12ColorIndex = helmet.Stripes[11];
            viewModelHelmet.Stripe13ColorIndex = helmet.Stripes[12];
            viewModelHelmet.VisorColorIndex = helmet.Visor;
            viewModelHelmet.VisorSurroundColorIndex = helmet.VisorSurround;
        }



        public static LegacyCarSet LegacyCarSetFromMainViewModel(MainViewModel viewModel)
        {
            var carset = new LegacyCarSet();

            foreach (var team in viewModel.Teams)
            {
                var legacyTeam = new LegacyTeam();

                legacyTeam.Name = team.Name;
                legacyTeam.Engine = team.Engine;
                legacyTeam.Horsepower = team.Horsepower;
                legacyTeam.Driver1Number = team.Drivers[0].Number;
                legacyTeam.Driver2Number = team.Drivers[1].Number;
                legacyTeam.CarColors = BytesFromCar(team.Car);
                legacyTeam.PitCrewColors = BytesFromPitCrew(team.PitCrew);

                carset.Teams.Add(legacyTeam);
            }

            for (int i = 1; i <= 40; i++)
            {
                var driver = viewModel.Drivers.FirstOrDefault(d => d.Number == i);

                if (driver == null)
                {
                    driver = new DriverViewModel((byte)i, "", 0, 0);
                }

                var legacyDriver = new LegacyDriver();
                legacyDriver.Number = i;
                legacyDriver.Name = driver.Name;
                legacyDriver.RacePerformance = driver.RaceGripLevel;
                legacyDriver.QualifyingPerformance = driver.QualifyingGripLevel;
                legacyDriver.HelmetColors = BytesFromHelmet(driver.Helmet);

                carset.Drivers.Add(legacyDriver);
            }

            carset.Settings.PlayerHorsepower = viewModel.PlayerHorsepower;

            if (carset.Settings.PlayerHorsepower > 999)
            {
                carset.Settings.PlayerHorsepower = 999;
            }

            if (carset.Settings.PlayerHorsepower < 450)
            {
                carset.Settings.PlayerHorsepower = 450;
            }

            carset.Settings.GeneralGripLevel = viewModel.GeneralGripLevel;
            carset.Settings.ChanceOfRain = viewModel.ChanceOfRainPercent;
            carset.Settings.RainAtFirstTrack = viewModel.RainAtFirstTrack;
            carset.Settings.RetireHitWall = viewModel.DamageSettings.RetireAfterHittingWall;
            carset.Settings.RetireHitCar = viewModel.DamageSettings.RetireAfterHittingOtherCar;
            carset.Settings.DamageHitWall = viewModel.DamageSettings.DamageAfterHittingWall;
            carset.Settings.DamageHitCar = viewModel.DamageSettings.DamageAfterHittingOtherCar;
            carset.Settings.YellowFlags = viewModel.DamageSettings.YellowFlagsAfterSeconds;
            carset.Settings.RemoveCars = viewModel.DamageSettings.RemoveCarsAfterSeconds;

            return carset;
        }

        private static byte[] BytesFromCar(CarEditingViewModel car)
        {
            // TODO: basically same as in ArgData.Entities.Car
            return new byte[]
            {
                33,
                car.EngineCoverColorIndex,
                car.CockpitFrontColorIndex,
                car.FrontWingEndplateColorIndex,
                car.RearWingSideColorIndex,
                car.NoseSideColorIndex,
                car.SidepodColorIndex,
                car.FrontAndRearWingColorIndex,
                car.NoseTopColorIndex,
                54,
                36,
                car.NoseAngleColorIndex,
                car.CockpitSideColorIndex,
                car.EngineCoverSideColorIndex,
                car.EngineCoverRearColorIndex,
                car.SidepodTopColorIndex
            };
        }

        private static byte[] BytesFromPitCrew(PitCrewViewModel pitCrew)
        {
            // TODO: basically same as in ArgData.Entities.PitCrew
            return new byte[]
            {
                0,
                1,
                202,
                pitCrew.SocksColorIndex,
                pitCrew.PantsSecondaryColorIndex,
                pitCrew.ShirtSecondaryColorIndex,
                pitCrew.ShirtPrimaryColorIndex,
                7,
                8,
                205,
                10,
                pitCrew.PantsPrimaryColorIndex,
                12,
                13,
                14,
                15
            };
        }

        private static byte[] BytesFromHelmet(HelmetViewModel helmet)
        {
            // TODO: basically same as in ArgData.Entities.Helmet

            return new byte[]
            {
                helmet.VisorColorIndex,
                1,
                helmet.Stripe1ColorIndex,
                helmet.Stripe2ColorIndex,
                helmet.Stripe3ColorIndex,
                helmet.Stripe4ColorIndex,
                helmet.VisorSurroundColorIndex,
                helmet.Stripe5ColorIndex,
                helmet.Stripe6ColorIndex,
                helmet.Stripe7ColorIndex,
                helmet.Stripe8ColorIndex,
                helmet.Stripe9ColorIndex,
                helmet.Stripe10ColorIndex,
                helmet.Stripe11ColorIndex,
                helmet.Stripe12ColorIndex,
                helmet.Stripe13ColorIndex
            };
        }




        public static void MapCarSetPointsSystemToViewModel(CarSetPointsSystem system, PointsSystemViewModel viewModel)
        {
            viewModel.PointsFor1st = system.PointsFor1st;
            viewModel.PointsFor2nd = system.PointsFor2nd;
            viewModel.PointsFor3rd = system.PointsFor3rd;
            viewModel.PointsFor4th = system.PointsFor4th;
            viewModel.PointsFor5th = system.PointsFor5th;
            viewModel.PointsFor6th = system.PointsFor6th;
            viewModel.PointsFor7th = system.PointsFor7th;
            viewModel.PointsFor8th = system.PointsFor8th;
            viewModel.PointsFor9th = system.PointsFor9th;
            viewModel.PointsFor10th = system.PointsFor10th;
            viewModel.PointsFor11th = system.PointsFor11th;
            viewModel.PointsFor12th = system.PointsFor12th;
            viewModel.PointsFor13th = system.PointsFor13th;
            viewModel.PointsFor14th = system.PointsFor14th;
            viewModel.PointsFor15th = system.PointsFor15th;
            viewModel.PointsFor16th = system.PointsFor16th;
            viewModel.PointsFor17th = system.PointsFor17th;
            viewModel.PointsFor18th = system.PointsFor18th;
            viewModel.PointsFor19th = system.PointsFor19th;
            viewModel.PointsFor20th = system.PointsFor20th;
            viewModel.PointsFor21st = system.PointsFor21st;
            viewModel.PointsFor22nd = system.PointsFor22nd;
            viewModel.PointsFor23rd = system.PointsFor23rd;
            viewModel.PointsFor24th = system.PointsFor24th;
            viewModel.PointsFor25th = system.PointsFor25th;
            viewModel.PointsFor26th = system.PointsFor26th;
        }

        public static void MapPointsSystemViewModelToCarSet(PointsSystemViewModel viewModel, CarSetPointsSystem system)
        {
            system.PointsFor1st = viewModel.PointsFor1st;
            system.PointsFor2nd = viewModel.PointsFor2nd;
            system.PointsFor3rd = viewModel.PointsFor3rd;
            system.PointsFor4th = viewModel.PointsFor4th;
            system.PointsFor5th = viewModel.PointsFor5th;
            system.PointsFor6th = viewModel.PointsFor6th;
            system.PointsFor7th = viewModel.PointsFor7th;
            system.PointsFor8th = viewModel.PointsFor8th;
            system.PointsFor9th = viewModel.PointsFor9th;
            system.PointsFor10th = viewModel.PointsFor10th;
            system.PointsFor11th = viewModel.PointsFor11th;
            system.PointsFor12th = viewModel.PointsFor12th;
            system.PointsFor13th = viewModel.PointsFor13th;
            system.PointsFor14th = viewModel.PointsFor14th;
            system.PointsFor15th = viewModel.PointsFor15th;
            system.PointsFor16th = viewModel.PointsFor16th;
            system.PointsFor17th = viewModel.PointsFor17th;
            system.PointsFor18th = viewModel.PointsFor18th;
            system.PointsFor19th = viewModel.PointsFor19th;
            system.PointsFor20th = viewModel.PointsFor20th;
            system.PointsFor21st = viewModel.PointsFor21st;
            system.PointsFor22nd = viewModel.PointsFor22nd;
            system.PointsFor23rd = viewModel.PointsFor23rd;
            system.PointsFor24th = viewModel.PointsFor24th;
            system.PointsFor25th = viewModel.PointsFor25th;
            system.PointsFor26th = viewModel.PointsFor26th;
        }



        public static void MapDataPointsSystemToViewModel(PointsSystem system, PointsSystemViewModel viewModel)
        {
            viewModel.PointsFor1st = system.PointsFor1st;
            viewModel.PointsFor2nd = system.PointsFor2nd;
            viewModel.PointsFor3rd = system.PointsFor3rd;
            viewModel.PointsFor4th = system.PointsFor4th;
            viewModel.PointsFor5th = system.PointsFor5th;
            viewModel.PointsFor6th = system.PointsFor6th;
            viewModel.PointsFor7th = system.PointsFor7th;
            viewModel.PointsFor8th = system.PointsFor8th;
            viewModel.PointsFor9th = system.PointsFor9th;
            viewModel.PointsFor10th = system.PointsFor10th;
            viewModel.PointsFor11th = system.PointsFor11th;
            viewModel.PointsFor12th = system.PointsFor12th;
            viewModel.PointsFor13th = system.PointsFor13th;
            viewModel.PointsFor14th = system.PointsFor14th;
            viewModel.PointsFor15th = system.PointsFor15th;
            viewModel.PointsFor16th = system.PointsFor16th;
            viewModel.PointsFor17th = system.PointsFor17th;
            viewModel.PointsFor18th = system.PointsFor18th;
            viewModel.PointsFor19th = system.PointsFor19th;
            viewModel.PointsFor20th = system.PointsFor20th;
            viewModel.PointsFor21st = system.PointsFor21st;
            viewModel.PointsFor22nd = system.PointsFor22nd;
            viewModel.PointsFor23rd = system.PointsFor23rd;
            viewModel.PointsFor24th = system.PointsFor24th;
            viewModel.PointsFor25th = system.PointsFor25th;
            viewModel.PointsFor26th = system.PointsFor26th;
        }

        public static void MapPointsSystemViewModelToData(PointsSystemViewModel viewModel, PointsSystem system)
        {
            system.PointsFor1st = viewModel.PointsFor1st;
            system.PointsFor2nd = viewModel.PointsFor2nd;
            system.PointsFor3rd = viewModel.PointsFor3rd;
            system.PointsFor4th = viewModel.PointsFor4th;
            system.PointsFor5th = viewModel.PointsFor5th;
            system.PointsFor6th = viewModel.PointsFor6th;
            system.PointsFor7th = viewModel.PointsFor7th;
            system.PointsFor8th = viewModel.PointsFor8th;
            system.PointsFor9th = viewModel.PointsFor9th;
            system.PointsFor10th = viewModel.PointsFor10th;
            system.PointsFor11th = viewModel.PointsFor11th;
            system.PointsFor12th = viewModel.PointsFor12th;
            system.PointsFor13th = viewModel.PointsFor13th;
            system.PointsFor14th = viewModel.PointsFor14th;
            system.PointsFor15th = viewModel.PointsFor15th;
            system.PointsFor16th = viewModel.PointsFor16th;
            system.PointsFor17th = viewModel.PointsFor17th;
            system.PointsFor18th = viewModel.PointsFor18th;
            system.PointsFor19th = viewModel.PointsFor19th;
            system.PointsFor20th = viewModel.PointsFor20th;
            system.PointsFor21st = viewModel.PointsFor21st;
            system.PointsFor22nd = viewModel.PointsFor22nd;
            system.PointsFor23rd = viewModel.PointsFor23rd;
            system.PointsFor24th = viewModel.PointsFor24th;
            system.PointsFor25th = viewModel.PointsFor25th;
            system.PointsFor26th = viewModel.PointsFor26th;
        }

        public static void MapHelmetViewModel(HelmetViewModel source, HelmetViewModel target)
        {
            target.VisorColorIndex = source.VisorColorIndex;
            target.VisorSurroundColorIndex = source.VisorSurroundColorIndex;
            target.Stripe1ColorIndex = source.Stripe1ColorIndex;
            target.Stripe2ColorIndex = source.Stripe2ColorIndex;
            target.Stripe3ColorIndex = source.Stripe3ColorIndex;
            target.Stripe4ColorIndex = source.Stripe4ColorIndex;
            target.Stripe5ColorIndex = source.Stripe5ColorIndex;
            target.Stripe6ColorIndex = source.Stripe6ColorIndex;
            target.Stripe7ColorIndex = source.Stripe7ColorIndex;
            target.Stripe8ColorIndex = source.Stripe8ColorIndex;
            target.Stripe9ColorIndex = source.Stripe9ColorIndex;
            target.Stripe10ColorIndex = source.Stripe10ColorIndex;
            target.Stripe11ColorIndex = source.Stripe11ColorIndex;
            target.Stripe12ColorIndex = source.Stripe12ColorIndex;
            target.Stripe13ColorIndex = source.Stripe13ColorIndex;
        }



        public static void MapCarSetupToViewModel(Setup sourceData, SetupViewModel targetViewModel)
        {
            targetViewModel.FrontWing = sourceData.FrontWing;
            targetViewModel.RearWing = sourceData.RearWing;
            targetViewModel.BrakeBalance = sourceData.BrakeBalance;
            targetViewModel.GearRatio1 = sourceData.GearRatio1;
            targetViewModel.GearRatio2 = sourceData.GearRatio2;
            targetViewModel.GearRatio3 = sourceData.GearRatio3;
            targetViewModel.GearRatio4 = sourceData.GearRatio4;
            targetViewModel.GearRatio5 = sourceData.GearRatio5;
            targetViewModel.GearRatio6 = sourceData.GearRatio6;
            targetViewModel.TyreCompound = sourceData.TyreCompound;
        }

        public static void MapCarSetupToData(SetupViewModel sourceViewModel, Setup targetData)
        {
            targetData.FrontWing = sourceViewModel.FrontWing;
            targetData.RearWing = sourceViewModel.RearWing;
            targetData.BrakeBalance = sourceViewModel.BrakeBalance;
            targetData.GearRatio1 = sourceViewModel.GearRatio1;
            targetData.GearRatio2 = sourceViewModel.GearRatio2;
            targetData.GearRatio3 = sourceViewModel.GearRatio3;
            targetData.GearRatio4 = sourceViewModel.GearRatio4;
            targetData.GearRatio5 = sourceViewModel.GearRatio5;
            targetData.GearRatio6 = sourceViewModel.GearRatio6;
            targetData.TyreCompound = sourceViewModel.TyreCompound;
        }

        public static void MapCarSetupViewModel(SetupViewModel source, SetupViewModel target)
        {
            target.FrontWing = source.FrontWing;
            target.RearWing = source.RearWing;
            target.BrakeBalance = source.BrakeBalance;
            target.GearRatio1 = source.GearRatio1;
            target.GearRatio2 = source.GearRatio2;
            target.GearRatio3 = source.GearRatio3;
            target.GearRatio4 = source.GearRatio4;
            target.GearRatio5 = source.GearRatio5;
            target.GearRatio6 = source.GearRatio6;
            target.TyreCompound = source.TyreCompound;
        }

        public static void MapCarSetMenuImageToMenuImageViewModel(string menuImageBase64, MenuImageViewModel driverMenuImage)
        {
            if (string.IsNullOrEmpty(menuImageBase64))
            {
                driverMenuImage.SetDefault();
                return;
            }

            byte[] pixelData = Convert.FromBase64String(menuImageBase64);

            driverMenuImage.SetFromPixelData(pixelData);
        }
    }
}

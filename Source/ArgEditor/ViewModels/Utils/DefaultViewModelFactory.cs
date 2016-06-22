using System;

namespace ArgEditor.ViewModels.Utils
{
    public static class DefaultViewModelFactory
    {
        public static MainViewModel DefaultData()
        {
            var drivers = new[]
            {
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),
                new Tuple<byte, string, byte, byte>(0, string.Empty, 1, 1),

                //new Tuple<byte, string, byte, byte>(1, "Ayrton Senna", 1, 1),
                //new Tuple<byte, string, byte, byte>(2, "Gerhard Berger", 4, 4),
                //new Tuple<byte, string, byte, byte>(3, "Satoru Nakajima", 16, 16),
                //new Tuple<byte, string, byte, byte>(4, "Stefano Modena", 9, 9),
                //new Tuple<byte, string, byte, byte>(5, "Nigel Mansell", 2, 3),
                //new Tuple<byte, string, byte, byte>(6, "Riccardo Patrese", 3, 2),
                //new Tuple<byte, string, byte, byte>(7, "Martin Brundle", 19, 19),
                //new Tuple<byte, string, byte, byte>(8, "Mark Blundell", 21, 21),
                //new Tuple<byte, string, byte, byte>(9, "Michele Alboreto", 26, 26),
                //new Tuple<byte, string, byte, byte>(10, "Stefan Johansson", 31, 31),
                //new Tuple<byte, string, byte, byte>(11, "Mika Häkkinen", 25, 25),
                //new Tuple<byte, string, byte, byte>(12, "Johnny Herbert", 27, 27),
                //new Tuple<byte, string, byte, byte>(14, "Olivier Grouillard", 28, 28),
                //new Tuple<byte, string, byte, byte>(0, "", 0, 0),
                //new Tuple<byte, string, byte, byte>(15, "Mauricio Gugelmin", 12, 12),
                //new Tuple<byte, string, byte, byte>(16, "Ivan Capelli", 14, 14),
                //new Tuple<byte, string, byte, byte>(17, "Gabriele Tarquini", 30, 30),
                //new Tuple<byte, string, byte, byte>(18, "Fabrizio Barbazza", 32, 32),
                //new Tuple<byte, string, byte, byte>(19, "Michael Schumacher", 8, 8),
                //new Tuple<byte, string, byte, byte>(20, "Nelson Piquet", 7, 7),
                //new Tuple<byte, string, byte, byte>(21, "Emanuele Pirro", 18, 18),
                //new Tuple<byte, string, byte, byte>(22, "J.J. Lehto", 15, 15),
                //new Tuple<byte, string, byte, byte>(23, "Pierluigi Martini", 11, 11),
                //new Tuple<byte, string, byte, byte>(24, "Gianni Morbidelli", 17, 17),
                //new Tuple<byte, string, byte, byte>(25, "Thierry Boutsen", 20, 20),
                //new Tuple<byte, string, byte, byte>(26, "Erik Comas", 24, 24),
                //new Tuple<byte, string, byte, byte>(27, "Alain Prost", 5, 5),
                //new Tuple<byte, string, byte, byte>(28, "Jean Alesi", 6, 6),
                //new Tuple<byte, string, byte, byte>(29, "Eric Bernard", 22, 22),
                //new Tuple<byte, string, byte, byte>(30, "Aguri Suzuki", 23, 23),
                //new Tuple<byte, string, byte, byte>(31, "Pedro Chaves", 34, 34),
                //new Tuple<byte, string, byte, byte>(0, "", 0, 0),
                //new Tuple<byte, string, byte, byte>(32, "Bertrand Gachot", 13, 13),
                //new Tuple<byte, string, byte, byte>(33, "Andrea de Cesaris", 10, 10),
                //new Tuple<byte, string, byte, byte>(34, "Nicola Larini", 29, 29),
                //new Tuple<byte, string, byte, byte>(35, "Eric van de Poele", 33, 33),
                //new Tuple<byte, string, byte, byte>(0, "", 0, 0),
                //new Tuple<byte, string, byte, byte>(0, "", 0, 0),
                //new Tuple<byte, string, byte, byte>(0, "", 0, 0),
                //new Tuple<byte, string, byte, byte>(0, "", 0, 0)
            };

            var teams = new[]
            {
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 716, new byte[]{ 47, 62, 44, 58, 32, 44, 47, 47, 46, 47, 47, 62, 47 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 676, new byte[]{ 34, 47, 45, 56, 33, 33, 32, 47, 46, 46, 46, 46, 34 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 716, new byte[]{ 110, 111, 86, 86, 84, 44, 47, 89, 87, 86, 86, 87, 47 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 650, new byte[]{ 89, 87, 86, 86, 45, 86, 46, 88, 46, 46, 46, 46, 89 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 620, new byte[]{ 46, 47, 45, 45, 63, 45, 47, 47, 46, 46, 46, 46, 47 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 625, new byte[]{ 46, 47, 70, 70, 69, 44, 46, 47, 46, 46, 46, 46, 74 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 620, new byte[]{ 36, 38, 32, 47, 35, 59, 37, 38, 36, 36, 36, 36, 61}, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 665, new byte[]{70, 231, 228, 228, 226, 228, 32, 231, 229, 229, 46, 46, 231 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 610, new byte[]{46, 47, 44, 44, 43, 44, 32, 47, 46, 46, 46, 46, 47 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 680, new byte[]{ 110, 111, 107, 86, 72, 85, 111, 75, 74, 110, 110, 110, 90}, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 655, new byte[]{ 62, 47, 57, 57, 56, 57, 60, 62, 61, 46, 46, 46, 62 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 665, new byte[]{  32, 33, 32, 109, 32, 32, 111, 33, 34, 34, 47, 110, 36 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 640, new byte[]{ 94, 95, 32, 32, 92, 32, 95, 95, 94, 94, 94, 94, 95  }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 700, new byte[]{ 60, 61, 32, 32, 32, 56, 32, 61, 60, 60, 60, 60, 61 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 630, new byte[]{ 32, 61, 32, 32, 32, 32, 111, 62, 34, 34, 60, 60, 36 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 610, new byte[]{ 94, 40, 45, 45, 45, 45, 47, 40, 39, 39, 39, 39, 47  }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 680, new byte[]{ 71, 72, 70, 70, 91, 92, 72, 72, 71, 71, 71, 71, 72 }, DefaultPitCrewColors()),
                new Tuple<string, string, int, byte[], byte[]>(string.Empty, string.Empty, 615, new byte[]{ 88, 88, 32, 32, 86, 86, 33, 88, 87, 87, 87, 87, 88 }, DefaultPitCrewColors()),
                //new Tuple<string, string, int, byte[], byte[]>("", "", 0, new byte[]{ 88, 88, 32, 32, 86, 86, 33, 88, 87, 87, 87, 87, 88 }, DefaultPitCrewColors()),
                //new Tuple<string, string, int, byte[], byte[]>("", "", 0, new byte[]{ 88, 88, 32, 32, 86, 86, 33, 88, 87, 87, 87, 87, 88 }, DefaultPitCrewColors())
            };

            var mainViewModel = new MainViewModel();

            for (int d = 0; d < drivers.Length; d++)
            {
                mainViewModel.Drivers[d].Number = drivers[d].Item1;
                mainViewModel.Drivers[d].Name = drivers[d].Item2;
                mainViewModel.Drivers[d].RaceGripLevel = drivers[d].Item3;
                mainViewModel.Drivers[d].QualifyingGripLevel = drivers[d].Item4;
            }

            for (int t = 0; t < teams.Length; t++)
            {
                mainViewModel.Teams[t].Name = teams[t].Item1;
                mainViewModel.Teams[t].Engine = teams[t].Item2;
                mainViewModel.Teams[t].Horsepower = teams[t].Item3;
                mainViewModel.Teams[t].Car = new CarEditingViewModel(teams[t].Item4);
                if (t == 0)
                {
                    mainViewModel.Teams[t].Car.IsSpecialShape = true;
                }
                mainViewModel.Teams[t].PitCrew = new PitCrewViewModel(teams[t].Item5);
            }

            return mainViewModel;
        }

        private static byte[] DefaultPitCrewColors()
        {
            return new byte[]{46, 43, 70, 74, 40};
        }
    }
}

using System;

namespace lesson4Task2
{
    class Program
    {
        static void Main()
        {
            var buildingOne = BuildingFactory.CreateBuilding(height: 25, floorСount: 10);
            Console.WriteLine($"Уникальный номер здания: {buildingOne.Id}\n" +
                $"Высота этажа: {buildingOne.GetFloorHeights(buildingOne.GetHeight(), buildingOne.GetFloorСount())}\n");
            
            var buildingTwo = BuildingFactory.CreateBuilding(apartmentsCount: 300, entrancesCount: 3);
            Console.WriteLine($"Уникальный номер здания: {buildingTwo.Id}\n" +
                $"Количество квартир в подъезде: {buildingTwo.GetCountApartmentsInEntrance(buildingTwo.GetApartmentsCount(), buildingTwo.GetEntrancesCount())}\n");
            
            var buildingThree = BuildingFactory.CreateBuilding(apartmentsCount: 300, entrancesCount: 3, floorСount: 10);
            Console.WriteLine($"Уникальный номер здания: {buildingThree.Id}\n" +
                $"Количество квартир на этаже: " +
                $"{buildingThree.GetCountApartmentsInFloor(buildingThree.GetApartmentsCount(), buildingThree.GetEntrancesCount(), buildingThree.GetFloorСount())}\n");

            var buildingFour = BuildingFactory.CreateBuilding(height: 25, floorСount: 10, apartmentsCount: 300, entrancesCount: 3);
            var buildingFive = BuildingFactory.CreateBuilding(height: 15, floorСount: 5, apartmentsCount: 150, entrancesCount: 3);
            var buildingSix = BuildingFactory.CreateBuilding(height: 6.6, floorСount: 3, apartmentsCount: 60, entrancesCount: 2);

            PrintBuildingInfo(buildingFour);
            PrintBuildingInfo(buildingFive);
            PrintBuildingInfo(buildingSix);
        }

        /// <summary>
        /// Вывод информации о здании
        /// </summary>
        /// <param name="building">Здание</param>
        public static void PrintBuildingInfo(Building building)
        {
            Console.WriteLine($"Уникальный номер здания: {building.Id}");
            Console.WriteLine($"Высота этажа: {building.GetFloorHeights(building.GetHeight(), building.GetFloorСount())}");
            Console.WriteLine($"Количество квартир в подъезде: {building.GetCountApartmentsInEntrance(building.GetApartmentsCount(), building.GetEntrancesCount())}");
            Console.WriteLine($"Количество квартир на этаже: {building.GetCountApartmentsInFloor(building.GetApartmentsCount(), building.GetEntrancesCount(), building.GetFloorСount())}\n");
        }
    }

    internal sealed class BuildingFactory : Building
    {
        private BuildingFactory()
        {

        }

        public static Building CreateBuilding(double height, int floorСount)
        {
            return new Building(height, floorСount);
        }

        public static Building CreateBuilding(int apartmentsCount, int entrancesCount)
        {
            return new Building(apartmentsCount, entrancesCount);
        }

        public static Building CreateBuilding(int apartmentsCount, int entrancesCount, int floorСount)
        {
            return new Building(apartmentsCount, entrancesCount, floorСount);
        }

        public static Building CreateBuilding(double height, int floorСount, int apartmentsCount, int entrancesCount)
        {
            return new Building(height, floorСount, apartmentsCount, entrancesCount);
        }
    }

    internal class Building
    {
        private static int _id = 1;

        internal Building()
        {
            Id = _id++;
        }

        internal Building(double height, int floorСount)
        {
            Id = _id++;
            Height = height;
            FloorСount = floorСount;
        }

        internal Building(int apartmentsCount, int entrancesCount)
        {
            Id = _id++;
            ApartmentsCount = apartmentsCount;
            EntrancesCount = entrancesCount;
        }

        internal Building(int apartmentsCount, int entrancesCount, int floorСount)
        {
            Id = _id++;
            ApartmentsCount = apartmentsCount;
            EntrancesCount = entrancesCount;
            FloorСount = floorСount;
        }

        internal Building(double height, int floorСount, int apartmentsCount, int entrancesCount)
        {
            Id = _id++;
            Height = height;
            FloorСount = floorСount;
            ApartmentsCount = apartmentsCount;
            EntrancesCount = entrancesCount;
        }

        /// <summary>
        /// Уникальный номер здания
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Высота
        /// </summary>
        private double Height { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        private int FloorСount { get; set; }
        /// <summary>
        /// Количество квартир
        /// </summary>
        private int ApartmentsCount { get; set; }
        /// <summary>
        /// Количество подъездов
        /// </summary>
        private int EntrancesCount { get; set; }

        public double GetHeight()
        {
            return Height;
        }

        public int GetFloorСount()
        {
            return FloorСount;
        }

        public int GetApartmentsCount()
        {
            return ApartmentsCount;
        }

        public int GetEntrancesCount()
        {
            return EntrancesCount;
        }

        /// <summary>
        /// Получить высоту этажа
        /// </summary>
        /// <param name="height">Высота</param>
        /// <param name="floorСount">Количество этажей</param>
        /// <returns></returns>
        public double GetFloorHeights(double height, int floorСount)
        {
            return floorСount != 0 ? Math.Round(height / floorСount, 2) : 0;
        }

        /// <summary>
        /// Получить количество квартир в подъезде
        /// </summary>
        /// <param name="apartmentsCount">Количество квартир</param>
        /// <param name="entrancesCount">Количество подъездов</param>
        /// <returns></returns>
        public int GetCountApartmentsInEntrance(int apartmentsCount, int entrancesCount)
        {
            return entrancesCount != 0 ? apartmentsCount / entrancesCount : 0;
        }

        /// <summary>
        /// Получить количество квартир на этаже
        /// </summary>
        /// <param name="apartmentsCount">Количество квартир</param>
        /// <param name="entrancesCount">Количество подъездов</param>
        /// <param name="floorСount">Количество этажей</param>
        /// <returns></returns>
        public int GetCountApartmentsInFloor(int apartmentsCount, int entrancesCount, int floorСount)
        {
            return floorСount != 0 ? (apartmentsCount / entrancesCount) / floorСount : 0;
        }
    }
}
